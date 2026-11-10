using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Registra una póliza completa y sus saldos en la tabla física del ejercicio solicitado.</summary>
    public sealed class PolizaContableRepository : IPolizaContableRepository {
        private readonly MariaDbContext _context;
        private readonly IFolioContableRepository _folioRepository;
        private readonly IPeriodoContableRepository _periodoRepository;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public PolizaContableRepository(
            MariaDbContext context,
            IFolioContableRepository folioRepository,
            IPeriodoContableRepository periodoRepository,
            IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _folioRepository = folioRepository ?? throw new ArgumentNullException(nameof(folioRepository));
            _periodoRepository = periodoRepository ?? throw new ArgumentNullException(nameof(periodoRepository));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public async Task RegistrarAsync(PolizaContableRequest request) {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Partidas == null || request.Partidas.Count == 0)
                throw new InvalidOperationException("La póliza debe contener al menos una partida.");

            string tablaPolizas = _tableResolver.ObtenerTablaPolizas(request.Ejercicio);
            string tablaAuxiliar = _tableResolver.ObtenerTablaAuxiliar(request.Ejercicio);
            string tablaSaldos = _tableResolver.ObtenerTablaSaldos(request.Ejercicio);
            string tablaSaldosDp = _tableResolver.ObtenerTablaSaldosDepartamentales(request.Ejercicio);

            try {
                _context.Db.Ado.BeginTran();
                await ValidarPeriodoDentroDeTransaccionAsync(request.Ejercicio, request.Periodo);

                if (string.IsNullOrWhiteSpace(request.NumeroPoliza)) {
                    var folio = await _folioRepository.ObtenerSiguienteAsync(
                        request.TipoPoliza.Trim(), request.Ejercicio, request.Periodo);
                    request.NumeroPoliza = folio.NumeroPoliza;
                }

                await InsertarPolizaAsync(request, tablaPolizas);
                foreach (MovimientoContableRequest partida in request.Partidas) {
                    partida.TipoPoliza = request.TipoPoliza.Trim();
                    partida.NumeroPoliza = request.NumeroPoliza.Trim();
                    partida.Ejercicio = request.Ejercicio;
                    partida.Periodo = request.Periodo;
                    await InsertarAuxiliarAsync(partida, tablaAuxiliar);
                    await ActualizarSaldoAsync(partida, tablaSaldos);
                    if (partida.NumeroDepartamento.HasValue)
                        await ActualizarSaldoDepartamentalAsync(partida, tablaSaldosDp);
                }

                _context.Db.Ado.CommitTran();
            } catch (Exception ex) {
                try { _context.Db.Ado.RollbackTran(); }
                catch (Exception rollbackEx) {
                    throw new InvalidOperationException(
                        "No fue posible revertir la transacción de la póliza.",
                        new AggregateException(ex, rollbackEx));
                }

                if (ex is InvalidOperationException) throw;
                if (ex is SqlSugarException)
                    throw new InvalidOperationException("Error de base de datos al registrar la póliza contable.", ex);
                throw new InvalidOperationException("Error inesperado al registrar la póliza contable.", ex);
            }
        }

        public async Task ActualizarAsync(PolizaContableRequest request) {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Partidas == null || request.Partidas.Count == 0)
                throw new InvalidOperationException("La póliza debe contener al menos una partida.");

            string tipo = request.TipoPoliza.Trim();
            string numero = request.NumeroPoliza.Trim();
            string tablaPolizas = _tableResolver.ObtenerTablaPolizas(request.Ejercicio);
            string tablaAuxiliar = _tableResolver.ObtenerTablaAuxiliar(request.Ejercicio);
            string tablaSaldos = _tableResolver.ObtenerTablaSaldos(request.Ejercicio);
            string tablaSaldosDp = _tableResolver.ObtenerTablaSaldosDepartamentales(request.Ejercicio);

            try {
                _context.Db.Ado.BeginTran();
                await ValidarPeriodoDentroDeTransaccionAsync(request.Ejercicio, request.Periodo);

                var poliza = await ObtenerPolizaAsync(tablaPolizas, tipo, numero, request.Ejercicio, request.Periodo);
                ValidarPolizaModificable(poliza, tablaPolizas);

                var anteriores = await ObtenerPartidasPersistidasAsync(
                    tablaAuxiliar, tipo, numero, request.Ejercicio, request.Periodo);

                foreach (var anterior in anteriores) {
                    var partida = MapearPartida(anterior);
                    await AplicarSaldoAsync(partida, -1, tablaSaldos);
                    if (partida.NumeroDepartamento.HasValue)
                        await AplicarSaldoDepartamentalAsync(partida, -1, tablaSaldosDp);
                }

                await EliminarPartidasAsync(tablaAuxiliar, tipo, numero, request.Ejercicio, request.Periodo);

                foreach (var partida in request.Partidas) {
                    partida.TipoPoliza = tipo;
                    partida.NumeroPoliza = numero;
                    partida.Ejercicio = request.Ejercicio;
                    partida.Periodo = request.Periodo;
                    await InsertarAuxiliarAsync(partida, tablaAuxiliar);
                    await AplicarSaldoAsync(partida, 1, tablaSaldos);
                    if (partida.NumeroDepartamento.HasValue)
                        await AplicarSaldoDepartamentalAsync(partida, 1, tablaSaldosDp);
                }

                string sql = string.Format(
                    "UPDATE {0} SET FECHA_POL=@fecha, CONCEP_PO=@concepto, NUM_PART=@numPart WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND PERIODO=@periodo AND EJERCICIO=@ejercicio",
                    tablaPolizas);
                int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                    new SugarParameter("@fecha", request.Fecha),
                    new SugarParameter("@concepto", request.Concepto),
                    new SugarParameter("@numPart", request.Partidas.Count),
                    new SugarParameter("@tipo", tipo),
                    new SugarParameter("@numero", numero),
                    new SugarParameter("@periodo", request.Periodo),
                    new SugarParameter("@ejercicio", request.Ejercicio));
                if (afectados == 0)
                    throw new InvalidOperationException("No fue posible actualizar la cabecera de la póliza.");

                _context.Db.Ado.CommitTran();
            }
            catch (Exception ex) {
                try { _context.Db.Ado.RollbackTran(); }
                catch (Exception rollbackEx) {
                    throw new InvalidOperationException(
                        "No fue posible revertir la transacción de actualización de la póliza.",
                        new AggregateException(ex, rollbackEx));
                }

                if (ex is InvalidOperationException) throw;
                if (ex is SqlSugarException)
                    throw new InvalidOperationException("Error de base de datos al actualizar la póliza contable.", ex);
                throw new InvalidOperationException("Error inesperado al actualizar la póliza contable.", ex);
            }
        }

        public async Task EliminarAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo) {
            if (string.IsNullOrWhiteSpace(tipoPoliza)) throw new ArgumentException("El tipo de póliza es obligatorio.", nameof(tipoPoliza));
            if (string.IsNullOrWhiteSpace(numeroPoliza)) throw new ArgumentException("El número de póliza es obligatorio.", nameof(numeroPoliza));

            string tipo = tipoPoliza.Trim();
            string numero = numeroPoliza.Trim();
            string tablaPolizas = _tableResolver.ObtenerTablaPolizas(ejercicio);
            string tablaAuxiliar = _tableResolver.ObtenerTablaAuxiliar(ejercicio);
            string tablaSaldos = _tableResolver.ObtenerTablaSaldos(ejercicio);
            string tablaSaldosDp = _tableResolver.ObtenerTablaSaldosDepartamentales(ejercicio);

            try {
                _context.Db.Ado.BeginTran();
                await ValidarPeriodoDentroDeTransaccionAsync(ejercicio, periodo);

                var poliza = await ObtenerPolizaAsync(tablaPolizas, tipo, numero, ejercicio, periodo);
                ValidarPolizaModificable(poliza, tablaPolizas);

                var partidas = await ObtenerPartidasPersistidasAsync(tablaAuxiliar, tipo, numero, ejercicio, periodo);
                foreach (var auxiliar in partidas) {
                    var partida = MapearPartida(auxiliar);
                    await AplicarSaldoAsync(partida, -1, tablaSaldos);
                    if (partida.NumeroDepartamento.HasValue)
                        await AplicarSaldoDepartamentalAsync(partida, -1, tablaSaldosDp);
                }

                await EliminarPartidasAsync(tablaAuxiliar, tipo, numero, ejercicio, periodo);

                string sql = string.Format(
                    "DELETE FROM {0} WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND PERIODO=@periodo AND EJERCICIO=@ejercicio",
                    tablaPolizas);
                int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                    new SugarParameter("@tipo", tipo),
                    new SugarParameter("@numero", numero),
                    new SugarParameter("@periodo", periodo),
                    new SugarParameter("@ejercicio", ejercicio));
                if (afectados == 0)
                    throw new InvalidOperationException("No fue posible eliminar la cabecera de la póliza.");

                _context.Db.Ado.CommitTran();
            }
            catch (Exception ex) {
                try { _context.Db.Ado.RollbackTran(); }
                catch (Exception rollbackEx) {
                    throw new InvalidOperationException(
                        "No fue posible revertir la transacción de eliminación de la póliza.",
                        new AggregateException(ex, rollbackEx));
                }

                if (ex is InvalidOperationException) throw;
                if (ex is SqlSugarException)
                    throw new InvalidOperationException("Error de base de datos al eliminar la póliza contable.", ex);
                throw new InvalidOperationException("Error inesperado al eliminar la póliza contable.", ex);
            }
        }

        private static void ValidarPolizaModificable(PolizaEntity poliza, string tablaPolizas)
        {
            if (poliza == null)
                throw new InvalidOperationException("La póliza no existe en " + tablaPolizas + ".");

            string logAudita = poliza.LOGAUDITA == null ? string.Empty : poliza.LOGAUDITA.Trim();
            if (string.Equals(logAudita, "S", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(logAudita, "SI", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(logAudita, "1", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(logAudita, "TRUE", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("La póliza está auditada y no puede modificarse ni eliminarse.");
        }

        private async Task<PolizaEntity> ObtenerPolizaAsync(
            string tabla,
            string tipo,
            string numero,
            short ejercicio,
            short periodo) {
            string sql = string.Format(
                "SELECT * FROM {0} WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND PERIODO=@periodo AND EJERCICIO=@ejercicio LIMIT 1",
                tabla);
            var resultado = await _context.Db.Ado.SqlQueryAsync<PolizaEntity>(sql,
                new SugarParameter("@tipo", tipo),
                new SugarParameter("@numero", numero),
                new SugarParameter("@periodo", periodo),
                new SugarParameter("@ejercicio", ejercicio));
            return resultado.FirstOrDefault();
        }

        private async Task<List<Auxiliar25Entity>> ObtenerPartidasPersistidasAsync(
            string tabla,
            string tipo,
            string numero,
            short ejercicio,
            short periodo) {
            string sql = string.Format(
                "SELECT * FROM {0} WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND PERIODO=@periodo AND EJERCICIO=@ejercicio ORDER BY NUM_PART ASC",
                tabla);
            return await _context.Db.Ado.SqlQueryAsync<Auxiliar25Entity>(sql,
                new SugarParameter("@tipo", tipo),
                new SugarParameter("@numero", numero),
                new SugarParameter("@periodo", periodo),
                new SugarParameter("@ejercicio", ejercicio));
        }

        private async Task EliminarPartidasAsync(
            string tabla,
            string tipo,
            string numero,
            short ejercicio,
            short periodo) {
            string sql = string.Format(
                "DELETE FROM {0} WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND PERIODO=@periodo AND EJERCICIO=@ejercicio",
                tabla);
            await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@tipo", tipo),
                new SugarParameter("@numero", numero),
                new SugarParameter("@periodo", periodo),
                new SugarParameter("@ejercicio", ejercicio));
        }

        private async Task AplicarSaldoAsync(MovimientoContableRequest partida, int movimiento, string tabla) {
            string columna = ObtenerColumnaSaldo(partida.Periodo, partida.DebeHaber);
            string sql = string.Format(
                "UPDATE {0} SET {1}=COALESCE({1},0)+@importe, MOV{2}=COALESCE(MOV{2},0)+@movimiento WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio",
                tabla, columna, partida.Periodo.ToString("00"));
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", partida.Importe * movimiento),
                new SugarParameter("@movimiento", movimiento),
                new SugarParameter("@cuenta", partida.NumeroCuenta),
                new SugarParameter("@ejercicio", partida.Ejercicio));
            if (afectados == 0)
                throw new InvalidOperationException("No fue posible actualizar " + tabla + " para la cuenta " + partida.NumeroCuenta + ".");
        }

        private async Task AplicarSaldoDepartamentalAsync(MovimientoContableRequest partida, int movimiento, string tabla) {
            string columna = ObtenerColumnaSaldo(partida.Periodo, partida.DebeHaber);
            string sql = string.Format(
                "UPDATE {0} SET {1}=COALESCE({1},0)+@importe, MOV{2}=COALESCE(MOV{2},0)+@movimiento WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio AND DEPTO=@depto",
                tabla, columna, partida.Periodo.ToString("00"));
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", partida.Importe * movimiento),
                new SugarParameter("@movimiento", movimiento),
                new SugarParameter("@cuenta", partida.NumeroCuenta),
                new SugarParameter("@ejercicio", partida.Ejercicio),
                new SugarParameter("@depto", partida.NumeroDepartamento.Value));
            if (afectados == 0)
                throw new InvalidOperationException("No fue posible actualizar " + tabla + " para la cuenta " + partida.NumeroCuenta + " y departamento " + partida.NumeroDepartamento.Value + ".");
        }

        private static MovimientoContableRequest MapearPartida(Auxiliar25Entity x) {
            if (!x.MONTOMOV.HasValue)
                throw new InvalidOperationException("La partida " + x.NUM_PART + " no tiene importe en AUXILIAR.");

            return new MovimientoContableRequest {
                TipoPoliza = x.TIPO_POLI,
                NumeroPoliza = x.NUM_POLIZ,
                NumeroPartida = x.NUM_PART,
                Ejercicio = (short)x.EJERCICIO,
                Periodo = x.PERIODO,
                Fecha = x.FECHA_POL,
                Concepto = x.CONCEP_PO,
                NumeroCuenta = x.NUM_CTA,
                DebeHaber = x.DEBE_HABER,
                Importe = x.MONTOMOV.Value,
                NumeroDepartamento = x.NUMDEPTO,
                TipoCambio = x.TIPCAMBIO,
                Contrapartida = x.CONTRAPAR,
                Orden = x.ORDEN,
                CentroCostos = x.CCOSTOS,
                Grupo = x.CGRUPOS
            };
        }

        private async Task ValidarPeriodoDentroDeTransaccionAsync(short ejercicio, short periodo) {
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo), "El periodo contable debe estar entre 1 y 14.");

            PeriodoContable estado = await _periodoRepository.ObtenerAsync(ejercicio, periodo);
            if (estado == null)
                throw new InvalidOperationException(string.Format(
                    "El periodo {0} del ejercicio {1} no existe en ADMPER.", periodo, ejercicio));
            if (estado.EstaCerrado)
                throw new InvalidOperationException(string.Format(
                    "El periodo {0} del ejercicio {1} está cerrado y no permite registrar pólizas.", periodo, ejercicio));
        }

        private async Task InsertarPolizaAsync(PolizaContableRequest request, string tabla) {
            string sqlExiste = string.Format(
                "SELECT COUNT(1) FROM {0} WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND PERIODO=@periodo AND EJERCICIO=@ejercicio",
                tabla);
            object existente = await _context.Db.Ado.GetScalarAsync(sqlExiste,
                new SugarParameter("@tipo", request.TipoPoliza.Trim()),
                new SugarParameter("@numero", request.NumeroPoliza.Trim()),
                new SugarParameter("@periodo", request.Periodo),
                new SugarParameter("@ejercicio", request.Ejercicio));
            if (Convert.ToInt32(existente) > 0)
                throw new InvalidOperationException("La póliza ya existe en " + tabla + ".");

            string sql = string.Format(
                "INSERT INTO {0} (TIPO_POLI,NUM_POLIZ,PERIODO,EJERCICIO,FECHA_POL,CONCEP_PO,NUM_PART,LOGAUDITA,CONTABILIZ) VALUES (@tipo,@numero,@periodo,@ejercicio,@fecha,@concepto,@numPart,'N','N')",
                tabla);
            await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@tipo", request.TipoPoliza.Trim()),
                new SugarParameter("@numero", request.NumeroPoliza.Trim()),
                new SugarParameter("@periodo", request.Periodo),
                new SugarParameter("@ejercicio", request.Ejercicio),
                new SugarParameter("@fecha", request.Fecha),
                new SugarParameter("@concepto", request.Concepto),
                new SugarParameter("@numPart", request.Partidas.Count));
        }

        private async Task InsertarAuxiliarAsync(MovimientoContableRequest request, string tabla) {
            string sqlExiste = string.Format(
                "SELECT COUNT(1) FROM {0} WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND NUM_PART=@partida AND PERIODO=@periodo AND EJERCICIO=@ejercicio",
                tabla);
            object existente = await _context.Db.Ado.GetScalarAsync(sqlExiste,
                new SugarParameter("@tipo", request.TipoPoliza),
                new SugarParameter("@numero", request.NumeroPoliza),
                new SugarParameter("@partida", request.NumeroPartida),
                new SugarParameter("@periodo", request.Periodo),
                new SugarParameter("@ejercicio", request.Ejercicio));
            if (Convert.ToInt32(existente) > 0)
                throw new InvalidOperationException("La partida " + request.NumeroPartida + " ya existe en " + tabla + ".");

            string sql = string.Format(
                "INSERT INTO {0} (TIPO_POLI,NUM_POLIZ,NUM_PART,PERIODO,EJERCICIO,NUM_CTA,FECHA_POL,CONCEP_PO,DEBE_HABER,MONTOMOV,NUMDEPTO,TIPCAMBIO,CONTRAPAR,ORDEN,CCOSTOS,CGRUPOS) VALUES (@tipo,@numero,@partida,@periodo,@ejercicio,@cuenta,@fecha,@concepto,@dh,@importe,@depto,@tc,@contra,@orden,@cc,@grupo)",
                tabla);
            await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@tipo", request.TipoPoliza),
                new SugarParameter("@numero", request.NumeroPoliza),
                new SugarParameter("@partida", request.NumeroPartida),
                new SugarParameter("@periodo", request.Periodo),
                new SugarParameter("@ejercicio", request.Ejercicio),
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@fecha", request.Fecha),
                new SugarParameter("@concepto", request.Concepto),
                new SugarParameter("@dh", request.DebeHaber),
                new SugarParameter("@importe", request.Importe),
                new SugarParameter("@depto", request.NumeroDepartamento),
                new SugarParameter("@tc", request.TipoCambio),
                new SugarParameter("@contra", request.Contrapartida),
                new SugarParameter("@orden", request.Orden),
                new SugarParameter("@cc", request.CentroCostos),
                new SugarParameter("@grupo", request.Grupo));
        }

        private async Task ActualizarSaldoAsync(MovimientoContableRequest request, string tabla) {
            string columna = ObtenerColumnaSaldo(request.Periodo, request.DebeHaber);
            string sql = string.Format(
                "UPDATE {0} SET {1}=COALESCE({1},0)+@importe, MOV{2}=COALESCE(MOV{2},0)+1 WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio",
                tabla, columna, request.Periodo.ToString("00"));
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", request.Importe),
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@ejercicio", request.Ejercicio));
            if (afectados > 0) return;

            string crear = string.Format(
                "INSERT INTO {0} (NUM_CTA,EJERCICIO) VALUES (@cuenta,@ejercicio)", tabla);
            await _context.Db.Ado.ExecuteCommandAsync(crear,
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@ejercicio", request.Ejercicio));
            afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", request.Importe),
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@ejercicio", request.Ejercicio));
            if (afectados == 0)
                throw new InvalidOperationException("No fue posible actualizar " + tabla + ".");
        }

        private async Task ActualizarSaldoDepartamentalAsync(MovimientoContableRequest request, string tabla) {
            string columna = ObtenerColumnaSaldo(request.Periodo, request.DebeHaber);
            string sql = string.Format(
                "UPDATE {0} SET {1}=COALESCE({1},0)+@importe, MOV{2}=COALESCE(MOV{2},0)+1 WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio AND DEPTO=@depto",
                tabla, columna, request.Periodo.ToString("00"));
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", request.Importe),
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@ejercicio", request.Ejercicio),
                new SugarParameter("@depto", request.NumeroDepartamento.Value));
            if (afectados > 0) return;

            string crear = string.Format(
                "INSERT INTO {0} (NUM_CTA,EJERCICIO,DEPTO) VALUES (@cuenta,@ejercicio,@depto)", tabla);
            await _context.Db.Ado.ExecuteCommandAsync(crear,
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@ejercicio", request.Ejercicio),
                new SugarParameter("@depto", request.NumeroDepartamento.Value));
            afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@importe", request.Importe),
                new SugarParameter("@cuenta", request.NumeroCuenta),
                new SugarParameter("@ejercicio", request.Ejercicio),
                new SugarParameter("@depto", request.NumeroDepartamento.Value));
            if (afectados == 0)
                throw new InvalidOperationException("No fue posible actualizar " + tabla + ".");
        }

        private static string ObtenerColumnaSaldo(short periodo, string debeHaber) {
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo));
            if (string.Equals(debeHaber, "D", StringComparison.OrdinalIgnoreCase))
                return "CARGO" + periodo.ToString("00");
            if (string.Equals(debeHaber, "H", StringComparison.OrdinalIgnoreCase))
                return "ABONO" + periodo.ToString("00");
            throw new InvalidOperationException("El movimiento debe indicar DEBE ('D') o HABER ('H').");
        }
    }
}
