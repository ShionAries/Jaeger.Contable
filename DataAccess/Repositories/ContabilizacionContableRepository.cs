using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Enums;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Contabiliza las pólizas pendientes y reconstruye los importes del periodo en SALDOSNN.</summary>
    public sealed class ContabilizacionContableRepository : IContabilizacionContableRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public ContabilizacionContableRepository(
            MariaDbContext context,
            IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public async Task<ResultadoContabilizacionPeriodo> ContabilizarPolizaAsync(
            string tipoPoliza, string numeroPoliza, short ejercicio, short periodo) {
            string tablaPolizas = _tableResolver.ObtenerTablaPolizas(ejercicio);
            string tablaAuxiliar = _tableResolver.ObtenerTablaAuxiliar(ejercicio);
            string tablaSaldos = _tableResolver.ObtenerTablaSaldos(ejercicio);
            string columnaCargo = "CARGO" + periodo.ToString("00");
            string columnaAbono = "ABONO" + periodo.ToString("00");
            string columnaMov = "MOV" + periodo.ToString("00");

            try {
                _context.Db.Ado.BeginTran();
                string sql = string.Format(
                    "SELECT * FROM {0} WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND EJERCICIO=@ejercicio AND PERIODO=@periodo LIMIT 1",
                    tablaPolizas);
                var polizas = await _context.Db.Ado.SqlQueryAsync<PolizaEntity>(sql,
                    new SugarParameter("@tipo", tipoPoliza),
                    new SugarParameter("@numero", numeroPoliza),
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@periodo", periodo));

                if (polizas.Count == 0)
                    throw new InvalidOperationException(string.Format("No existe la póliza {0}-{1} en el ejercicio {2}, periodo {3}.", tipoPoliza, numeroPoliza, ejercicio, periodo));

                var poliza = polizas[0];
                var partidas = await ObtenerPartidasAsync(tablaAuxiliar, tipoPoliza, numeroPoliza, ejercicio, periodo);
                if (partidas.Count == 0)
                    throw new InvalidOperationException(string.Format("La póliza {0}-{1} no tiene partidas en {2}.", tipoPoliza, numeroPoliza, tablaAuxiliar));
                ValidarPartidas(partidas, poliza);

                string actualizar = string.Format(
                    "UPDATE {0} SET CONTABILIZ='S' WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND EJERCICIO=@ejercicio AND PERIODO=@periodo",
                    tablaPolizas);
                await _context.Db.Ado.ExecuteCommandAsync(actualizar,
                    new SugarParameter("@tipo", tipoPoliza),
                    new SugarParameter("@numero", numeroPoliza),
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@periodo", periodo));

                int cuentasAfectadas = await ReconstruirSaldosPeriodoAsync(
                    tablaPolizas, tablaAuxiliar, tablaSaldos, ejercicio, periodo,
                    columnaCargo, columnaAbono, columnaMov);

                _context.Db.Ado.CommitTran();
                return new ResultadoContabilizacionPeriodo(ejercicio, periodo, 1, partidas.Count, cuentasAfectadas);
            } catch (Exception ex) {
                try { _context.Db.Ado.RollbackTran(); }
                catch (Exception rollbackEx) {
                    throw new InvalidOperationException("No fue posible revertir la contabilización de la póliza.", new AggregateException(ex, rollbackEx));
                }
                if (ex is InvalidOperationException) throw;
                if (ex is SqlSugarException) throw new InvalidOperationException("Error de base de datos al contabilizar la póliza.", ex);
                throw new InvalidOperationException("Error inesperado al contabilizar la póliza.", ex);
            }
        }

        public async Task<ResultadoContabilizacionPeriodo> ContabilizarPeriodoAsync(short ejercicio, short periodo, ContabilizacionModoEnum modo, string tipoPoliza) {
            string tablaPolizas = _tableResolver.ObtenerTablaPolizas(ejercicio);
            string tablaAuxiliar = _tableResolver.ObtenerTablaAuxiliar(ejercicio);
            string tablaSaldos = _tableResolver.ObtenerTablaSaldos(ejercicio);
            string columnaCargo = "CARGO" + periodo.ToString("00");
            string columnaAbono = "ABONO" + periodo.ToString("00");
            string columnaMov = "MOV" + periodo.ToString("00");

            try {
                _context.Db.Ado.BeginTran();

                var pendientes = await ObtenerPolizasAsync(tablaPolizas, ejercicio, periodo, modo, tipoPoliza);
                int partidasContabilizadas = 0;

                foreach (var poliza in pendientes) {
                    var partidas = await ObtenerPartidasAsync(
                        tablaAuxiliar,
                        poliza.TIPO_POLI,
                        poliza.NUM_POLIZ,
                        ejercicio,
                        periodo);

                    if (partidas.Count == 0)
                        throw new InvalidOperationException(
                            string.Format("La póliza {0}-{1} no tiene partidas en {2}.", poliza.TIPO_POLI, poliza.NUM_POLIZ, tablaAuxiliar));

                    ValidarPartidas(partidas, poliza);
                    partidasContabilizadas += partidas.Count;

                    string actualizar = string.Format(
                        "UPDATE {0} SET CONTABILIZ='S' WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND EJERCICIO=@ejercicio AND PERIODO=@periodo",
                        tablaPolizas);

                    int afectados = await _context.Db.Ado.ExecuteCommandAsync(
                        actualizar,
                        new SugarParameter("@tipo", poliza.TIPO_POLI),
                        new SugarParameter("@numero", poliza.NUM_POLIZ),
                        new SugarParameter("@ejercicio", ejercicio),
                        new SugarParameter("@periodo", periodo));

                    if (afectados != 1)
                        throw new InvalidOperationException(
                            string.Format("No fue posible marcar como contabilizada la póliza {0}-{1}.", poliza.TIPO_POLI, poliza.NUM_POLIZ));
                }

                int cuentasAfectadas = await ReconstruirSaldosPeriodoAsync(
                    tablaPolizas,
                    tablaAuxiliar,
                    tablaSaldos,
                    ejercicio,
                    periodo,
                    columnaCargo,
                    columnaAbono,
                    columnaMov);

                _context.Db.Ado.CommitTran();

                return new ResultadoContabilizacionPeriodo(
                    ejercicio,
                    periodo,
                    pendientes.Count,
                    partidasContabilizadas,
                    cuentasAfectadas);
            }
            catch (Exception ex) {
                try {
                    _context.Db.Ado.RollbackTran();
                }
                catch (Exception rollbackEx) {
                    throw new InvalidOperationException(
                        "No fue posible revertir la contabilización del periodo.",
                        new AggregateException(ex, rollbackEx));
                }

                if (ex is InvalidOperationException)
                    throw;
                if (ex is SqlSugarException)
                    throw new InvalidOperationException(
                        "Error de base de datos al contabilizar el periodo.", ex);
                throw new InvalidOperationException(
                    "Error inesperado al contabilizar el periodo.", ex);
            }
        }

        private async Task<List<PolizaEntity>> ObtenerPolizasAsync(
            string tabla,
            short ejercicio,
            short periodo,
            ContabilizacionModoEnum modo,
            string tipoPoliza) {
            string filtro = "EJERCICIO=@ejercicio AND PERIODO=@periodo";
            if (modo == ContabilizacionModoEnum.SoloNoContabilizadas || modo == ContabilizacionModoEnum.SoloNoContabilizadasTipo)
                filtro += " AND COALESCE(CONTABILIZ,'N')='N'";
            if (modo == ContabilizacionModoEnum.SoloNoContabilizadasTipo)
                filtro += " AND TIPO_POLI=@tipo";

            string sql = string.Format(
                "SELECT * FROM {0} WHERE {1} ORDER BY TIPO_POLI, NUM_POLIZ",
                tabla, filtro);
            if (modo == ContabilizacionModoEnum.SoloNoContabilizadasTipo)
                return await _context.Db.Ado.SqlQueryAsync<PolizaEntity>(sql,
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@periodo", periodo),
                    new SugarParameter("@tipo", tipoPoliza));

            return await _context.Db.Ado.SqlQueryAsync<PolizaEntity>(sql,
                new SugarParameter("@ejercicio", ejercicio),
                new SugarParameter("@periodo", periodo));
        }

        private async Task<List<Auxiliar25Entity>> ObtenerPartidasAsync(
            string tabla,
            string tipo,
            string numero,
            short ejercicio,
            short periodo) {
            string sql = string.Format(
                "SELECT * FROM {0} WHERE TIPO_POLI=@tipo AND NUM_POLIZ=@numero AND EJERCICIO=@ejercicio AND PERIODO=@periodo ORDER BY NUM_PART",
                tabla);
            return await _context.Db.Ado.SqlQueryAsync<Auxiliar25Entity>(
                sql,
                new SugarParameter("@tipo", tipo),
                new SugarParameter("@numero", numero),
                new SugarParameter("@ejercicio", ejercicio),
                new SugarParameter("@periodo", periodo));
        }

        private static void ValidarPartidas(
            IList<Auxiliar25Entity> partidas,
            PolizaEntity poliza) {
            foreach (var partida in partidas) {
                if (string.IsNullOrWhiteSpace(partida.NUM_CTA))
                    throw new InvalidOperationException(
                        string.Format("La partida {0} de la póliza {1}-{2} no tiene cuenta contable.", partida.NUM_PART, poliza.TIPO_POLI, poliza.NUM_POLIZ));
                if (!string.Equals(partida.DEBE_HABER, "D", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(partida.DEBE_HABER, "H", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException(
                        string.Format("La partida {0} de la póliza {1}-{2} tiene un indicador Debe/Haber inválido.", partida.NUM_PART, poliza.TIPO_POLI, poliza.NUM_POLIZ));
                if (!partida.MONTOMOV.HasValue || partida.MONTOMOV.Value <= 0 ||
                    double.IsNaN(partida.MONTOMOV.Value) || double.IsInfinity(partida.MONTOMOV.Value))
                    throw new InvalidOperationException(
                        string.Format("La partida {0} de la póliza {1}-{2} tiene un importe inválido.", partida.NUM_PART, poliza.TIPO_POLI, poliza.NUM_POLIZ));
            }
        }

        private async Task<int> ReconstruirSaldosPeriodoAsync(
            string tablaPolizas,
            string tablaAuxiliar,
            string tablaSaldos,
            short ejercicio,
            short periodo,
            string columnaCargo,
            string columnaAbono,
            string columnaMov) {
            string reiniciar = string.Format(
                "UPDATE {0} SET {1}=0, {2}=0, {3}=0 WHERE EJERCICIO=@ejercicio",
                tablaSaldos, columnaCargo, columnaAbono, columnaMov);
            await _context.Db.Ado.ExecuteCommandAsync(
                reiniciar,
                new SugarParameter("@ejercicio", ejercicio));

            string sql = string.Format(
                @"SELECT a.NUM_CTA AS NumeroCuenta,
                         SUM(CASE WHEN UPPER(a.DEBE_HABER)='D' THEN COALESCE(a.MONTOMOV,0) ELSE 0 END) AS Cargo,
                         SUM(CASE WHEN UPPER(a.DEBE_HABER)='H' THEN COALESCE(a.MONTOMOV,0) ELSE 0 END) AS Abono,
                         COUNT(*) AS Movimientos
                  FROM {0} a
                  INNER JOIN {1} p
                     ON p.TIPO_POLI=a.TIPO_POLI
                    AND p.NUM_POLIZ=a.NUM_POLIZ
                    AND p.EJERCICIO=a.EJERCICIO
                    AND p.PERIODO=a.PERIODO
                  WHERE a.EJERCICIO=@ejercicio
                    AND a.PERIODO=@periodo
                    AND p.CONTABILIZ='S'
                  GROUP BY a.NUM_CTA",
                tablaAuxiliar, tablaPolizas);

            var saldos = await _context.Db.Ado.SqlQueryAsync<SaldoPeriodoRow>(
                sql,
                new SugarParameter("@ejercicio", ejercicio),
                new SugarParameter("@periodo", periodo));

            foreach (var saldo in saldos) {
                if (string.IsNullOrWhiteSpace(saldo.NumeroCuenta))
                    continue;

                await ActualizarSaldoAsync(
                    tablaSaldos,
                    ejercicio,
                    saldo.NumeroCuenta,
                    saldo.Cargo,
                    saldo.Abono,
                    saldo.Movimientos,
                    columnaCargo,
                    columnaAbono,
                    columnaMov);
            }

            int acumulativasAfectadas = await ActualizarCuentasAcumulativasAsync(
                tablaSaldos,
                ejercicio,
                columnaCargo,
                columnaAbono,
                columnaMov);

            return saldos.Count + acumulativasAfectadas;
        }

        private async Task ActualizarSaldoAsync(
            string tablaSaldos,
            short ejercicio,
            string numeroCuenta,
            double cargo,
            double abono,
            int movimientos,
            string columnaCargo,
            string columnaAbono,
            string columnaMov) {
            string actualizar = string.Format(
                "UPDATE {0} SET {1}=@cargo, {2}=@abono, {3}=@movimientos WHERE NUM_CTA=@cuenta AND EJERCICIO=@ejercicio",
                tablaSaldos, columnaCargo, columnaAbono, columnaMov);

            int afectados = await _context.Db.Ado.ExecuteCommandAsync(
                actualizar,
                new SugarParameter("@cargo", cargo),
                new SugarParameter("@abono", abono),
                new SugarParameter("@movimientos", movimientos),
                new SugarParameter("@cuenta", numeroCuenta),
                new SugarParameter("@ejercicio", ejercicio));

            if (afectados == 0) {
                string insertar = string.Format(
                    "INSERT INTO {0} (NUM_CTA,EJERCICIO,{1},{2},{3}) VALUES (@cuenta,@ejercicio,@cargo,@abono,@movimientos)",
                    tablaSaldos, columnaCargo, columnaAbono, columnaMov);
                await _context.Db.Ado.ExecuteCommandAsync(
                    insertar,
                    new SugarParameter("@cuenta", numeroCuenta),
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@cargo", cargo),
                    new SugarParameter("@abono", abono),
                    new SugarParameter("@movimientos", movimientos));
            }
        }

        private async Task<int> ActualizarCuentasAcumulativasAsync(
            string tablaSaldos,
            short ejercicio,
            string columnaCargo,
            string columnaAbono,
            string columnaMov) {
            var cuentas = await _context.Db.Queryable<CuentaContableEntity>()
                .Select(x => new CuentaJerarquiaRow {
                    NumeroCuenta = x.NumCta,
                    CuentaPadre = x.CtaPapa,
                    Tipo = x.Tipo
                })
                .ToListAsync();

            var detalles = cuentas
                .Where(x => string.Equals(x.Tipo, "D", StringComparison.OrdinalIgnoreCase))
                .Where(x => !string.IsNullOrWhiteSpace(x.NumeroCuenta))
                .ToList();

            var acumulativas = cuentas
                .Where(x => string.Equals(x.Tipo, "A", StringComparison.OrdinalIgnoreCase))
                .Where(x => !string.IsNullOrWhiteSpace(x.NumeroCuenta))
                .ToList();

            if (acumulativas.Count == 0)
                return 0;

            string sql = string.Format(
                "SELECT NUM_CTA AS NumeroCuenta, COALESCE({0},0) AS Cargo, COALESCE({1},0) AS Abono, COALESCE({2},0) AS Movimientos FROM {3} WHERE EJERCICIO=@ejercicio",
                columnaCargo, columnaAbono, columnaMov, tablaSaldos);

            var saldos = await _context.Db.Ado.SqlQueryAsync<SaldoPeriodoRow>(
                sql, new SugarParameter("@ejercicio", ejercicio));

            var saldosPorCuenta = saldos
                .Where(x => !string.IsNullOrWhiteSpace(x.NumeroCuenta))
                .ToDictionary(x => x.NumeroCuenta.Trim(), StringComparer.Ordinal);

            var hijos = cuentas
                .Where(x => !string.IsNullOrWhiteSpace(x.CuentaPadre))
                .GroupBy(x => x.CuentaPadre.Trim(), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => x.Select(y => y.NumeroCuenta.Trim()).ToList(), StringComparer.Ordinal);

            int afectados = 0;
            foreach (var acumulativa in acumulativas) {
                var descendientes = ObtenerCuentasDetalleDescendientes(
                    acumulativa.NumeroCuenta.Trim(), hijos,
                    new HashSet<string>(StringComparer.Ordinal));

                double cargo = 0;
                double abono = 0;
                int movimientos = 0;

                foreach (var detalle in descendientes) {
                    SaldoPeriodoRow saldo;
                    if (!saldosPorCuenta.TryGetValue(detalle, out saldo))
                        continue;

                    cargo += saldo.Cargo;
                    abono += saldo.Abono;
                    movimientos += saldo.Movimientos;
                }

                await ActualizarSaldoAsync(
                    tablaSaldos,
                    ejercicio,
                    acumulativa.NumeroCuenta.Trim(),
                    cargo,
                    abono,
                    movimientos,
                    columnaCargo,
                    columnaAbono,
                    columnaMov);
                afectados++;
            }

            return afectados;
        }

        private static List<string> ObtenerCuentasDetalleDescendientes(
            string cuentaRaiz,
            Dictionary<string, List<string>> hijos,
            HashSet<string> visitadas) {
            var resultado = new List<string>();
            var pendientes = new Queue<string>();
            pendientes.Enqueue(cuentaRaiz);
            visitadas.Add(cuentaRaiz);

            while (pendientes.Count > 0) {
                var padre = pendientes.Dequeue();
                List<string> lista;
                if (!hijos.TryGetValue(padre, out lista))
                    continue;

                foreach (var hijo in lista) {
                    if (!visitadas.Add(hijo))
                        continue;

                    var cuenta = hijos.ContainsKey(hijo);
                    if (cuenta)
                        pendientes.Enqueue(hijo);
                    else
                        resultado.Add(hijo);
                }
            }

            return resultado;
        }

        private sealed class CuentaJerarquiaRow {
            public string NumeroCuenta { get; set; }
            public string CuentaPadre { get; set; }
            public string Tipo { get; set; }
        }

        private sealed class SaldoPeriodoRow {
            public string NumeroCuenta { get; set; }
            public double Cargo { get; set; }
            public double Abono { get; set; }
            public int Movimientos { get; set; }
        }
    }
}
