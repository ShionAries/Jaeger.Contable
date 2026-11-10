using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Persiste el proceso completo de depreciación usando las tablas físicas del ejercicio.</summary>
    public sealed class DepreciacionActivoRepository : IDepreciacionActivoRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _resolver;
        private readonly IFolioContableRepository _folioRepository;
        private readonly IPeriodoContableRepository _periodoRepository;

        public DepreciacionActivoRepository(
            MariaDbContext context,
            IEjercicioContableTableResolver resolver,
            IFolioContableRepository folioRepository,
            IPeriodoContableRepository periodoRepository) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            _folioRepository = folioRepository ?? throw new ArgumentNullException(nameof(folioRepository));
            _periodoRepository = periodoRepository ?? throw new ArgumentNullException(nameof(periodoRepository));
        }

        public async Task<ResultadoProcesoDepreciacion> EjecutarAsync(short ejercicio, short periodo, IList<DepreciacionMovimiento> movimientos) {
            if (movimientos == null) throw new ArgumentNullException(nameof(movimientos));
            if (movimientos.Count == 0)
                throw new InvalidOperationException("No existen activos pendientes de depreciación para el periodo indicado.");

            string polizas = _resolver.ObtenerTablaPolizas(ejercicio);
            string auxiliar = _resolver.ObtenerTablaAuxiliar(ejercicio);
            string saldos = _resolver.ObtenerTablaSaldos(ejercicio);
            string saldosDp = _resolver.ObtenerTablaSaldosDepartamentales(ejercicio);
            string activos = _resolver.ObtenerTablaActivos(ejercicio);
            string concepto = "Póliza depreciación del periodo " + periodo.ToString("00") + " del ejercicio " + ejercicio;

            try {
                _context.Db.Ado.BeginTran();
                var estado = await _periodoRepository.ObtenerAsync(ejercicio, periodo);
                if (estado == null) throw new InvalidOperationException("El periodo no existe en ADMPER.");
                if (estado.EstaCerrado) throw new InvalidOperationException("El periodo está cerrado y no permite registrar pólizas.");

                string sqlExistente = string.Format("SELECT COUNT(1) FROM {0} WHERE TIPO_POLI='Dr' AND PERIODO=@periodo AND EJERCICIO=@ejercicio AND ORIGEN=@origen", polizas);
                object existe = await _context.Db.Ado.GetScalarAsync(sqlExistente,
                    new SugarParameter("@periodo", periodo), new SugarParameter("@ejercicio", ejercicio), new SugarParameter("@origen", "DEPRECIACION"));
                if (Convert.ToInt32(existe) > 0)
                    throw new InvalidOperationException("El proceso de depreciación ya fue registrado para el periodo indicado.");

                foreach (DepreciacionMovimiento movimiento in movimientos)
                    await ActualizarActivoAsync(activos, movimiento);

                var partidas = AgruparPartidas(movimientos);
                var folio = await _folioRepository.ObtenerSiguienteAsync("Dr", ejercicio, periodo);
                int partidasGeneradas = partidas.Count * 2;
                await InsertarPolizaAsync(polizas, folio.NumeroPoliza, ejercicio, periodo, concepto, partidasGeneradas);

                int numeroPartida = 1;
                foreach (MovimientoPartida partida in partidas) {
                    await InsertarAuxiliarAsync(auxiliar, folio.NumeroPoliza, ejercicio, periodo, numeroPartida++, partida.CuentaGasto, "D", partida.Importe, partida.Departamento, concepto);
                    await ActualizarSaldoAsync(saldos, ejercicio, periodo, partida.CuentaGasto, "D", partida.Importe);
                    if (partida.Departamento.HasValue && partida.Departamento.Value > 0)
                        await ActualizarSaldoDpAsync(saldosDp, ejercicio, periodo, partida.CuentaGasto, "D", partida.Importe, partida.Departamento.Value);

                    await InsertarAuxiliarAsync(auxiliar, folio.NumeroPoliza, ejercicio, periodo, numeroPartida++, partida.CuentaDepreciacion, "H", partida.Importe, partida.Departamento, concepto);
                    await ActualizarSaldoAsync(saldos, ejercicio, periodo, partida.CuentaDepreciacion, "H", partida.Importe);
                    if (partida.Departamento.HasValue && partida.Departamento.Value > 0)
                        await ActualizarSaldoDpAsync(saldosDp, ejercicio, periodo, partida.CuentaDepreciacion, "H", partida.Importe, partida.Departamento.Value);
                }

                _context.Db.Ado.CommitTran();
                var resultado = new ResultadoProcesoDepreciacion(
                    ejercicio,
                    periodo,
                    movimientos.Count,
                    movimientos.Sum(x => x.Importe),
                    "Dr",
                    folio.NumeroPoliza);
                resultado.PartidasGeneradas = partidasGeneradas;
                return resultado;
            } catch (Exception ex) {
                try { _context.Db.Ado.RollbackTran(); } catch (Exception rollbackEx) {
                    throw new InvalidOperationException("No fue posible revertir el proceso de depreciación.", new AggregateException(ex, rollbackEx));
                }
                if (ex is InvalidOperationException) throw;
                throw new InvalidOperationException("Error al ejecutar el proceso transaccional de depreciación.", ex);
            }
        }

        private async Task ActualizarActivoAsync(string tabla, DepreciacionMovimiento movimiento) {
            string sql = string.Format("UPDATE {0} SET DEPACU=@depacu WHERE CLAVE=@clave", tabla);
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@depacu", movimiento.NuevaDepreciacionAcumulada),
                new SugarParameter("@clave", movimiento.ClaveActivo));
            if (afectados != 1) throw new InvalidOperationException("No fue posible actualizar el activo " + movimiento.ClaveActivo + ".");
        }

        private async Task InsertarPolizaAsync(string tabla, string numero, short ejercicio, short periodo, string concepto, int partidas) {
            string sql = string.Format("INSERT INTO {0} (TIPO_POLI,NUM_POLIZ,PERIODO,EJERCICIO,FECHA_POL,CONCEP_PO,NUM_PART,LOGAUDITA,CONTABILIZ,NUMPARCUA,TIENEDOCUMENTOS,PROCCONTAB,ORIGEN) VALUES ('Dr',@numero,@periodo,@ejercicio,@fecha,@concepto,@partidas,'N','N',0,0,0,'DEPRECIACION')", tabla);
            await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@numero", numero), new SugarParameter("@periodo", periodo), new SugarParameter("@ejercicio", ejercicio),
                new SugarParameter("@fecha", FechaFinPeriodo(ejercicio, periodo)), new SugarParameter("@concepto", concepto), new SugarParameter("@partidas", partidas));
        }

        private async Task InsertarAuxiliarAsync(string tabla, string numero, short ejercicio, short periodo, int partida, string cuenta, string dh, double importe, short? depto, string concepto) {
            string sql = string.Format("INSERT INTO {0} (TIPO_POLI,NUM_POLIZ,NUM_PART,PERIODO,EJERCICIO,NUM_CTA,FECHA_POL,CONCEP_PO,DEBE_HABER,MONTOMOV,NUMDEPTO,TIPCAMBIO,CONTRAPAR,ORDEN,CCOSTOS,CGRUPOS) VALUES ('Dr',@numero,@partida,@periodo,@ejercicio,@cuenta,@fecha,@concepto,@dh,@importe,@depto,1,0,@orden,0,0)", tabla);
            await _context.Db.Ado.ExecuteCommandAsync(sql,
                new SugarParameter("@numero", numero), new SugarParameter("@partida", partida), new SugarParameter("@periodo", periodo),
                new SugarParameter("@ejercicio", ejercicio), new SugarParameter("@cuenta", cuenta), new SugarParameter("@fecha", FechaFinPeriodo(ejercicio, periodo)),
                new SugarParameter("@concepto", concepto), new SugarParameter("@dh", dh), new SugarParameter("@importe", importe),
                new SugarParameter("@depto", depto), new SugarParameter("@orden", partida));
        }

        private async Task ActualizarSaldoAsync(string tabla, short ejercicio, short periodo, string cuenta, string dh, double importe) {
            string columna = ColumnaSaldo(periodo, dh);
            string sql = string.Format("UPDATE {0} SET {1}=COALESCE({1},0)+@importe,MOV{2}=COALESCE(MOV{2},0)+1 WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio", tabla, columna, periodo.ToString("00"));
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql, new SugarParameter("@importe", importe), new SugarParameter("@cuenta", cuenta), new SugarParameter("@ejercicio", ejercicio));
            if (afectados > 0) return;
            await _context.Db.Ado.ExecuteCommandAsync(string.Format("INSERT INTO {0} (NUM_CTA,EJERCICIO) VALUES (@cuenta,@ejercicio)", tabla), new SugarParameter("@cuenta", cuenta), new SugarParameter("@ejercicio", ejercicio));
            afectados = await _context.Db.Ado.ExecuteCommandAsync(sql, new SugarParameter("@importe", importe), new SugarParameter("@cuenta", cuenta), new SugarParameter("@ejercicio", ejercicio));
            if (afectados == 0) throw new InvalidOperationException("No fue posible actualizar " + tabla + ".");
        }

        private async Task ActualizarSaldoDpAsync(string tabla, short ejercicio, short periodo, string cuenta, string dh, double importe, short depto) {
            string columna = ColumnaSaldo(periodo, dh);
            string sql = string.Format("UPDATE {0} SET {1}=COALESCE({1},0)+@importe,MOV{2}=COALESCE(MOV{2},0)+1 WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio AND DEPTO=@depto", tabla, columna, periodo.ToString("00"));
            int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql, new SugarParameter("@importe", importe), new SugarParameter("@cuenta", cuenta), new SugarParameter("@ejercicio", ejercicio), new SugarParameter("@depto", depto));
            if (afectados > 0) return;
            await _context.Db.Ado.ExecuteCommandAsync(string.Format("INSERT INTO {0} (NUM_CTA,EJERCICIO,DEPTO) VALUES (@cuenta,@ejercicio,@depto)", tabla), new SugarParameter("@cuenta", cuenta), new SugarParameter("@ejercicio", ejercicio), new SugarParameter("@depto", depto));
            afectados = await _context.Db.Ado.ExecuteCommandAsync(sql, new SugarParameter("@importe", importe), new SugarParameter("@cuenta", cuenta), new SugarParameter("@ejercicio", ejercicio), new SugarParameter("@depto", depto));
            if (afectados == 0) throw new InvalidOperationException("No fue posible actualizar " + tabla + ".");
        }

        private static string ColumnaSaldo(short periodo, string dh) {
            if (periodo < 1 || periodo > 14) throw new ArgumentOutOfRangeException(nameof(periodo));
            if (dh == "D") return "CARGO" + periodo.ToString("00");
            if (dh == "H") return "ABONO" + periodo.ToString("00");
            throw new InvalidOperationException("Movimiento contable inválido.");
        }

        private static DateTime FechaFinPeriodo(short ejercicio, short periodo) {
            if (periodo <= 12) return new DateTime(ejercicio, periodo, DateTime.DaysInMonth(ejercicio, periodo));
            return periodo == 13 ? new DateTime(ejercicio, 12, 31) : new DateTime(ejercicio, 12, 31);
        }

        private static List<MovimientoPartida> AgruparPartidas(IList<DepreciacionMovimiento> movimientos) {
            return movimientos.GroupBy(x => new { x.CuentaGasto, x.CuentaDepreciacion, Departamento = x.NumeroDepartamento.HasValue && x.NumeroDepartamento.Value > 0 ? x.NumeroDepartamento : (short?)null })
                .Select(g => new MovimientoPartida { CuentaGasto = g.Key.CuentaGasto, CuentaDepreciacion = g.Key.CuentaDepreciacion, Departamento = g.Key.Departamento, Importe = Math.Round(g.Sum(x => x.Importe), 2, MidpointRounding.AwayFromZero) })
                .Where(x => x.Importe > 0).ToList();
        }

        private sealed class MovimientoPartida {
            public string CuentaGasto { get; set; }
            public string CuentaDepreciacion { get; set; }
            public short? Departamento { get; set; }
            public double Importe { get; set; }
        }
    }
}
