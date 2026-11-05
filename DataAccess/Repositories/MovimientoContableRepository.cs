using System;
using System.Threading.Tasks;
using SqlSugar;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>
    /// Persiste una partida y actualiza sus saldos dentro de una sola transacción.
    /// </summary>
    public sealed class MovimientoContableRepository : IMovimientoContableRepository {
        private readonly MariaDbContext _context;

        public MovimientoContableRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task RegistrarAsync(MovimientoContableRequest request) {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try {
                _context.Db.Ado.BeginTran();

                await AsegurarPolizaAsync(request);
                await InsertarAuxiliarAsync(request);
                await ActualizarSaldoAsync(request);

                if (request.NumeroDepartamento.HasValue)
                    await ActualizarSaldoDepartamentalAsync(request);

                _context.Db.Ado.CommitTran();
            }
            catch (Exception ex) {
                try {
                    _context.Db.Ado.RollbackTran();
                }
                catch (Exception rollbackEx) {
                    throw new InvalidOperationException(
                        "No fue posible revertir la transacción del movimiento contable.",
                        new AggregateException(ex, rollbackEx));
                }

                if (ex is InvalidOperationException)
                    throw;

                if (ex is SqlSugarException)
                    throw new InvalidOperationException(
                        "Error de base de datos al registrar el movimiento contable.", ex);

                throw new InvalidOperationException(
                    "Error inesperado al registrar el movimiento contable.", ex);
            }
        }

        private async Task AsegurarPolizaAsync(MovimientoContableRequest request) {
            var existente = await _context.Db.Queryable<PolizaEntity>()
                .Where(x => x.TIPO_POLI == request.TipoPoliza &&
                            x.NUM_POLIZ == request.NumeroPoliza &&
                            x.PERIODO == request.Periodo &&
                            x.EJERCICIO == request.Ejercicio)
                .FirstAsync();

            if (existente != null)
                return;

            var poliza = new PolizaEntity {
                TIPO_POLI = request.TipoPoliza,
                NUM_POLIZ = request.NumeroPoliza,
                PERIODO = request.Periodo,
                EJERCICIO = request.Ejercicio,
                FECHA_POL = request.Fecha,
                CONCEP_PO = request.Concepto,
                NUM_PART = Convert.ToInt32(request.NumeroPartida),
                CONTABILIZ = "N"
            };

            await _context.Db.Insertable(poliza).ExecuteCommandAsync();
        }

        private async Task InsertarAuxiliarAsync(MovimientoContableRequest request) {
            var existe = await _context.Db.Queryable<Auxiliar25Entity>()
                .Where(x => x.TIPO_POLI == request.TipoPoliza &&
                            x.NUM_POLIZ == request.NumeroPoliza &&
                            x.NUM_PART == request.NumeroPartida &&
                            x.PERIODO == request.Periodo &&
                            x.EJERCICIO == request.Ejercicio)
                .AnyAsync();

            if (existe)
                throw new InvalidOperationException(
                    "La partida contable ya existe en AUXILIAR25.");

            var auxiliar = new Auxiliar25Entity {
                TIPO_POLI = request.TipoPoliza,
                NUM_POLIZ = request.NumeroPoliza,
                NUM_PART = request.NumeroPartida,
                PERIODO = request.Periodo,
                EJERCICIO = request.Ejercicio,
                NUM_CTA = request.NumeroCuenta,
                DEBE_HABER = request.DebeHaber,
                MONTOMOV = request.Importe
            };

            await _context.Db.Insertable(auxiliar).ExecuteCommandAsync();
        }

        private async Task ActualizarSaldoAsync(MovimientoContableRequest request) {
            string columna = ObtenerColumnaSaldo(request.Periodo, request.DebeHaber, false);
            string sql = string.Format(
                "UPDATE SALDOS25 SET {0} = COALESCE({0}, 0) + @importe WHERE NUM_CTA = @cuenta AND EJERCICIO = @ejercicio",
                columna);

            int afectados = await _context.Db.Ado.ExecuteCommandAsync(
                sql,
                new SugarParameter("@importe", request.Importe),
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@ejercicio", request.Ejercicio));

            if (afectados == 0) {
                var saldo = new SaldosEntity {
                    NUM_CTA = request.NumeroCuenta,
                    EJERCICIO = request.Ejercicio
                };
                InicializarSaldos(saldo);
                await _context.Db.Insertable(saldo).ExecuteCommandAsync();

                afectados = await _context.Db.Ado.ExecuteCommandAsync(
                    sql,
                    new SugarParameter("@importe", request.Importe),
                    new SugarParameter("@cuenta", request.NumeroCuenta),
                    new SugarParameter("@ejercicio", request.Ejercicio));

                if (afectados == 0)
                    throw new InvalidOperationException("No fue posible actualizar SALDOS25.");
            }
        }

        private async Task ActualizarSaldoDepartamentalAsync(MovimientoContableRequest request) {
            string columna = ObtenerColumnaSaldo(request.Periodo, request.DebeHaber, false);
            string sql = string.Format(
                "UPDATE SALDOSDP25 SET {0} = COALESCE({0}, 0) + @importe WHERE NUM_CTA = @cuenta AND EJERCICIO = @ejercicio AND DEPTO = @depto",
                columna);

            int afectados = await _context.Db.Ado.ExecuteCommandAsync(
                sql,
                new SugarParameter("@importe", request.Importe),
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@ejercicio", request.Ejercicio),
                new SugarParameter("@depto", request.NumeroDepartamento.Value));

            if (afectados == 0) {
                var saldo = new SaldosDp25Entity {
                    NUM_CTA = request.NumeroCuenta,
                    EJERCICIO = request.Ejercicio,
                    DEPTO = request.NumeroDepartamento.Value
                };
                InicializarSaldosDepartamentales(saldo);
                await _context.Db.Insertable(saldo).ExecuteCommandAsync();

                afectados = await _context.Db.Ado.ExecuteCommandAsync(
                    sql,
                    new SugarParameter("@importe", request.Importe),
                    new SugarParameter("@cuenta", request.NumeroCuenta),
                    new SugarParameter("@ejercicio", request.Ejercicio),
                    new SugarParameter("@depto", request.NumeroDepartamento.Value));

                if (afectados == 0)
                    throw new InvalidOperationException("No fue posible actualizar SALDOSDP25.");
            }
        }

        private static string ObtenerColumnaSaldo(short periodo, string debeHaber, bool extranjero) {
            string prefijo = string.Equals(debeHaber, "D", StringComparison.OrdinalIgnoreCase) ? "CARGO" : "ABONO";
            if (extranjero)
                prefijo += "EX";
            return prefijo + periodo.ToString("00");
        }

        private static void InicializarSaldos(SaldosEntity saldo) {
            saldo.INICIAL = 0;
            saldo.INICIALEX = 0;
            saldo.CARGO01 = 0; saldo.ABONO01 = 0; saldo.CARGO02 = 0; saldo.ABONO02 = 0;
            saldo.CARGO03 = 0; saldo.ABONO03 = 0; saldo.CARGO04 = 0; saldo.ABONO04 = 0;
            saldo.CARGO05 = 0; saldo.ABONO05 = 0; saldo.CARGO06 = 0; saldo.ABONO06 = 0;
            saldo.CARGO07 = 0; saldo.ABONO07 = 0; saldo.CARGO08 = 0; saldo.ABONO08 = 0;
            saldo.CARGO09 = 0; saldo.ABONO09 = 0; saldo.CARGO10 = 0; saldo.ABONO10 = 0;
            saldo.CARGO11 = 0; saldo.ABONO11 = 0; saldo.CARGO12 = 0; saldo.ABONO12 = 0;
            saldo.CARGO13 = 0; saldo.ABONO13 = 0; saldo.CARGO14 = 0; saldo.ABONO14 = 0;
        }

        private static void InicializarSaldosDepartamentales(SaldosDp25Entity saldo) {
            saldo.INICIAL = 0;
            saldo.INICIALEX = 0;
            saldo.CARGO01 = 0; saldo.ABONO01 = 0; saldo.CARGO02 = 0; saldo.ABONO02 = 0;
            saldo.CARGO03 = 0; saldo.ABONO03 = 0; saldo.CARGO04 = 0; saldo.ABONO04 = 0;
            saldo.CARGO05 = 0; saldo.ABONO05 = 0; saldo.CARGO06 = 0; saldo.ABONO06 = 0;
            saldo.CARGO07 = 0; saldo.ABONO07 = 0; saldo.CARGO08 = 0; saldo.ABONO08 = 0;
            saldo.CARGO09 = 0; saldo.ABONO09 = 0; saldo.CARGO10 = 0; saldo.ABONO10 = 0;
            saldo.CARGO11 = 0; saldo.ABONO11 = 0; saldo.CARGO12 = 0; saldo.ABONO12 = 0;
            saldo.CARGO13 = 0; saldo.ABONO13 = 0; saldo.CARGO14 = 0; saldo.ABONO14 = 0;
        }

    }
}
