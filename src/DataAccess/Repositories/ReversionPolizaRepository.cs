using System;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using SqlSugar;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Lee una póliza existente y registra su reversión en una transacción independiente.</summary>
    public sealed class ReversionPolizaRepository : IReversionPolizaRepository {
        private readonly MariaDbContext _context;

        public ReversionPolizaRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PolizaContableRequest> ObtenerOriginalAsync(string tipoPoliza, string numeroPoliza,
            short ejercicio, short periodo) {
            try {
                var poliza = await _context.Db.Queryable<PolizaEntity>()
                    .Where(x => x.TIPO_POLI == tipoPoliza && x.NUM_POLIZ == numeroPoliza &&
                                x.EJERCICIO == ejercicio && x.PERIODO == periodo)
                    .FirstAsync();

                if (poliza == null) return null;

                var partidas = await _context.Db.Queryable<Auxiliar25Entity>()
                    .Where(x => x.TIPO_POLI == tipoPoliza && x.NUM_POLIZ == numeroPoliza &&
                                x.EJERCICIO == ejercicio && x.PERIODO == periodo)
                    .OrderBy(x => x.NUM_PART, OrderByType.Asc)
                    .ToListAsync();

                return new PolizaContableRequest {
                    TipoPoliza = poliza.TIPO_POLI,
                    NumeroPoliza = poliza.NUM_POLIZ,
                    Ejercicio = ejercicio,
                    Periodo = periodo,
                    Fecha = poliza.FECHA_POL,
                    Concepto = poliza.CONCEP_PO,
                    Partidas = partidas.Select(MapearPartida).ToList()
                };
            }
            catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible consultar la póliza original.", ex);
            }
        }

        public async Task RegistrarReversionAsync(PolizaContableRequest request) {
            if (request == null) throw new ArgumentNullException(nameof(request));
            try {
                _context.Db.Ado.BeginTran();

                var existe = await _context.Db.Queryable<PolizaEntity>()
                    .Where(x => x.TIPO_POLI == request.TipoPoliza && x.NUM_POLIZ == request.NumeroPoliza &&
                                x.EJERCICIO == request.Ejercicio && x.PERIODO == request.Periodo)
                    .AnyAsync();
                if (existe) throw new InvalidOperationException("La póliza de reversión ya existe en POLIZAS25.");

                await _context.Db.Insertable(new PolizaEntity {
                    TIPO_POLI = request.TipoPoliza.Trim(),
                    NUM_POLIZ = request.NumeroPoliza.Trim(),
                    PERIODO = request.Periodo,
                    EJERCICIO = request.Ejercicio,
                    FECHA_POL = request.Fecha,
                    CONCEP_PO = request.Concepto,
                    NUM_PART = request.Partidas.Count,
                    CONTABILIZ = "N",
                    ORIGEN = "REVERSA"
                }).ExecuteCommandAsync();

                foreach (var partida in request.Partidas) {
                    await InsertarAuxiliarAsync(partida);
                    await ActualizarSaldoAsync(partida);
                    if (partida.NumeroDepartamento.HasValue)
                        await ActualizarSaldoDepartamentalAsync(partida);
                }

                _context.Db.Ado.CommitTran();
            }
            catch (Exception ex) {
                try { _context.Db.Ado.RollbackTran(); }
                catch (Exception rollbackEx) {
                    throw new InvalidOperationException("No fue posible revertir la transacción de la póliza de reversión.",
                        new AggregateException(ex, rollbackEx));
                }
                if (ex is InvalidOperationException) throw;
                if (ex is SqlSugarException)
                    throw new InvalidOperationException("Error de base de datos al registrar la reversión.", ex);
                throw new InvalidOperationException("Error inesperado al registrar la reversión.", ex);
            }
        }

        private async Task InsertarAuxiliarAsync(MovimientoContableRequest partida) {
            var existe = await _context.Db.Queryable<Auxiliar25Entity>()
                .Where(x => x.TIPO_POLI == partida.TipoPoliza && x.NUM_POLIZ == partida.NumeroPoliza &&
                            x.NUM_PART == partida.NumeroPartida && x.PERIODO == partida.Periodo &&
                            x.EJERCICIO == partida.Ejercicio)
                .AnyAsync();
            if (existe)
                throw new InvalidOperationException(string.Format("La partida {0} ya existe en AUXILIAR25.", partida.NumeroPartida));

            await _context.Db.Insertable(new Auxiliar25Entity {
                TIPO_POLI = partida.TipoPoliza,
                NUM_POLIZ = partida.NumeroPoliza,
                NUM_PART = partida.NumeroPartida,
                PERIODO = partida.Periodo,
                EJERCICIO = partida.Ejercicio,
                NUM_CTA = partida.NumeroCuenta,
                FECHA_POL = partida.Fecha,
                CONCEP_PO = partida.Concepto,
                DEBE_HABER = partida.DebeHaber,
                MONTOMOV = partida.Importe,
                NUMDEPTO = partida.NumeroDepartamento,
                CONTRAPAR = partida.Contrapartida,
                ORDEN = partida.Orden,
                CCOSTOS = partida.CentroCostos,
                CGRUPOS = partida.Grupo
            }).ExecuteCommandAsync();
        }

        private async Task ActualizarSaldoAsync(MovimientoContableRequest partida) {
            string columna = ObtenerColumnaSaldo(partida.Periodo, partida.DebeHaber);
            string sql = string.Format("UPDATE SALDOS25 SET {0}=COALESCE({0},0)+@importe WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio", columna);
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", partida.Importe),
                new SugarParameter("@cuenta", partida.NumeroCuenta),
                new SugarParameter("@ejercicio", partida.Ejercicio));
            if (afectados > 0) return;

            var saldo = new SaldosEntity { NUM_CTA = partida.NumeroCuenta, EJERCICIO = partida.Ejercicio };
            InicializarSaldos(saldo);
            await _context.Db.Insertable(saldo).ExecuteCommandAsync();
            afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", partida.Importe),
                new SugarParameter("@cuenta", partida.NumeroCuenta),
                new SugarParameter("@ejercicio", partida.Ejercicio));
            if (afectados == 0) throw new InvalidOperationException("No fue posible actualizar SALDOS25 durante la reversión.");
        }

        private async Task ActualizarSaldoDepartamentalAsync(MovimientoContableRequest partida) {
            string columna = ObtenerColumnaSaldo(partida.Periodo, partida.DebeHaber);
            string sql = string.Format("UPDATE SALDOSDP25 SET {0}=COALESCE({0},0)+@importe WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio AND DEPTO=@depto", columna);
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", partida.Importe),
                new SugarParameter("@cuenta", partida.NumeroCuenta),
                new SugarParameter("@ejercicio", partida.Ejercicio),
                new SugarParameter("@depto", partida.NumeroDepartamento.Value));
            if (afectados > 0) return;

            var saldo = new SaldosDp25Entity {
                NUM_CTA = partida.NumeroCuenta,
                EJERCICIO = partida.Ejercicio,
                DEPTO = partida.NumeroDepartamento.Value
            };
            InicializarSaldosDepartamentales(saldo);
            await _context.Db.Insertable(saldo).ExecuteCommandAsync();
            afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", partida.Importe),
                new SugarParameter("@cuenta", partida.NumeroCuenta),
                new SugarParameter("@ejercicio", partida.Ejercicio),
                new SugarParameter("@depto", partida.NumeroDepartamento.Value));
            if (afectados == 0) throw new InvalidOperationException("No fue posible actualizar SALDOSDP25 durante la reversión.");
        }

        private static MovimientoContableRequest MapearPartida(Auxiliar25Entity x) {
            return new MovimientoContableRequest {
                TipoPoliza = x.TIPO_POLI,
                NumeroPoliza = x.NUM_POLIZ,
                NumeroPartida = x.NUM_PART,
                Ejercicio = x.EJERCICIO,
                Periodo = x.PERIODO,
                Fecha = x.FECHA_POL,
                Concepto = x.CONCEP_PO,
                NumeroCuenta = x.NUM_CTA,
                DebeHaber = x.DEBE_HABER,
                Importe = x.MONTOMOV.Value,
                NumeroDepartamento = x.NUMDEPTO,
                Contrapartida = x.CONTRAPAR,
                Orden = x.ORDEN,
                CentroCostos = x.CCOSTOS,
                Grupo = x.CGRUPOS
            };
        }

        private static string ObtenerColumnaSaldo(short periodo, string debeHaber) {
            if (periodo < 1 || periodo > 14) throw new ArgumentOutOfRangeException(nameof(periodo));
            if (!string.Equals(debeHaber, "D", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(debeHaber, "H", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("DEBE_HABER inválido.", nameof(debeHaber));
            return (string.Equals(debeHaber, "D", StringComparison.OrdinalIgnoreCase) ? "CARGO" : "ABONO") + periodo.ToString("00");
        }

        private static void InicializarSaldos(SaldosEntity s) {
            s.INICIAL = 0; s.INICIALEX = 0;
            s.CARGO01=0;s.ABONO01=0;s.CARGO02=0;s.ABONO02=0;s.CARGO03=0;s.ABONO03=0;s.CARGO04=0;s.ABONO04=0;s.CARGO05=0;s.ABONO05=0;s.CARGO06=0;s.ABONO06=0;s.CARGO07=0;s.ABONO07=0;s.CARGO08=0;s.ABONO08=0;s.CARGO09=0;s.ABONO09=0;s.CARGO10=0;s.ABONO10=0;s.CARGO11=0;s.ABONO11=0;s.CARGO12=0;s.ABONO12=0;s.CARGO13=0;s.ABONO13=0;s.CARGO14=0;s.ABONO14=0;
        }

        private static void InicializarSaldosDepartamentales(SaldosDp25Entity s) {
            s.INICIAL=0;s.INICIALEX=0;
            s.CARGO01=0;s.ABONO01=0;s.CARGO02=0;s.ABONO02=0;s.CARGO03=0;s.ABONO03=0;s.CARGO04=0;s.ABONO04=0;s.CARGO05=0;s.ABONO05=0;s.CARGO06=0;s.ABONO06=0;s.CARGO07=0;s.ABONO07=0;s.CARGO08=0;s.ABONO08=0;s.CARGO09=0;s.ABONO09=0;s.CARGO10=0;s.ABONO10=0;s.CARGO11=0;s.ABONO11=0;s.CARGO12=0;s.ABONO12=0;s.CARGO13=0;s.ABONO13=0;s.CARGO14=0;s.ABONO14=0;
        }
    }
}
