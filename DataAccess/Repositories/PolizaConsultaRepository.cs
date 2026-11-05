using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>
    /// Implementa consultas de pólizas utilizando las tablas físicas
    /// correspondientes al ejercicio solicitado.
    /// </summary>
    public sealed class PolizaConsultaRepository : IPolizaConsultaRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public PolizaConsultaRepository(
            MariaDbContext context,
            IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public async Task<PolizaContableConsulta> ObtenerAsync(
            string tipoPoliza,
            string numeroPoliza,
            short ejercicio,
            short periodo) {
            try {
                ValidarEjercicioPeriodo(ejercicio, periodo);

                string tablaPolizas = _tableResolver.ObtenerTablaPolizas(ejercicio);
                string tablaAuxiliar = _tableResolver.ObtenerTablaAuxiliar(ejercicio);

                string sqlPoliza = string.Format(
                    @"SELECT *
                      FROM {0}
                      WHERE TIPO_POLI = @tipoPoliza
                        AND TRIM(NUM_POLIZ) = @numeroPoliza
                        AND EJERCICIO = @ejercicio
                        AND PERIODO = @periodo
                      LIMIT 1", tablaPolizas);

                var polizas = await _context.Db.Ado.SqlQueryAsync<PolizaEntity>(
                    sqlPoliza,
                    new SugarParameter("@tipoPoliza", tipoPoliza),
                    new SugarParameter("@numeroPoliza", numeroPoliza),
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@periodo", periodo));

                var poliza = polizas.FirstOrDefault();
                if (poliza == null)
                    return null;

                var partidas = await ObtenerPartidasAsync(
                    tablaAuxiliar,
                    tipoPoliza,
                    numeroPoliza,
                    ejercicio,
                    periodo);

                return Mappers.PolizaMapper.MapearPoliza(poliza, partidas);
            }
            catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar la póliza.", ex);
            }
        }

        public async Task<List<PolizaContableResumen>> ObtenerPorCuentaAsync(
            string numeroCuenta,
            short ejercicio,
            short periodo) {
            try {
                ValidarEjercicioPeriodo(ejercicio, periodo);

                string tablaPolizas = _tableResolver.ObtenerTablaPolizas(ejercicio);
                string tablaAuxiliar = _tableResolver.ObtenerTablaAuxiliar(ejercicio);

                string sql = string.Format(
                    @"SELECT
                          p.TIPO_POLI AS TipoPoliza,
                          p.NUM_POLIZ AS NumeroPoliza,
                          p.EJERCICIO AS Ejercicio,
                          p.PERIODO AS Periodo,
                          p.FECHA_POL AS Fecha,
                          p.CONCEP_PO AS Concepto,
                          p.CONTABILIZ AS Contabilizada,
                          p.LOGAUDITA AS LogAudita,
                          p.ORIGEN AS Origen,
                          COALESCE(p.NUM_PART, COUNT(a.NUM_PART)) AS NumeroPartidas
                      FROM {0} p
                      INNER JOIN {1} a
                          ON a.TIPO_POLI = p.TIPO_POLI
                         AND a.NUM_POLIZ = p.NUM_POLIZ
                         AND a.EJERCICIO = p.EJERCICIO
                         AND a.PERIODO = p.PERIODO
                      WHERE a.NUM_CTA = @numeroCuenta
                        AND p.EJERCICIO = @ejercicio
                        AND p.PERIODO = @periodo
                      GROUP BY
                          p.TIPO_POLI,
                          p.NUM_POLIZ,
                          p.EJERCICIO,
                          p.PERIODO,
                          p.FECHA_POL,
                          p.CONCEP_PO,
                          p.CONTABILIZ,
                          p.LOGAUDITA,
                          p.ORIGEN,
                          p.NUM_PART
                      ORDER BY
                          p.FECHA_POL ASC,
                          p.TIPO_POLI ASC,
                          p.NUM_POLIZ ASC", tablaPolizas, tablaAuxiliar);

                var resultado = await _context.Db.Ado.SqlQueryAsync<PolizaContableResumen>(
                    sql,
                    new SugarParameter("@numeroCuenta", numeroCuenta),
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@periodo", periodo));

                return resultado;
            }
            catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar el historial de la cuenta.", ex);
            }
        }

        public async Task<List<PolizaContableResumen>> ObtenerPorPeriodoAsync(
            short ejercicio,
            short periodo) {
            try {
                ValidarEjercicioPeriodo(ejercicio, periodo);

                string tablaPolizas = _tableResolver.ObtenerTablaPolizas(ejercicio);

                string sql = string.Format(
                    @"SELECT
                          TIPO_POLI AS TipoPoliza,
                          NUM_POLIZ AS NumeroPoliza,
                          EJERCICIO AS Ejercicio,
                          PERIODO AS Periodo,
                          FECHA_POL AS Fecha,
                          CONCEP_PO AS Concepto,
                          CONTABILIZ AS Contabilizada,
                          LOGAUDITA AS LogAudita,
                          ORIGEN AS Origen,
                          COALESCE(NUM_PART, 0) AS NumeroPartidas
                      FROM {0}
                      WHERE EJERCICIO = @ejercicio
                        AND PERIODO = @periodo
                      ORDER BY
                          FECHA_POL ASC,
                          TIPO_POLI ASC,
                          NUM_POLIZ ASC", tablaPolizas);

                return await _context.Db.Ado.SqlQueryAsync<PolizaContableResumen>(
                    sql,
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@periodo", periodo));
            }
            catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar las pólizas del periodo.", ex);
            }
        }

        private async Task<List<MovimientoContableRequest>> ObtenerPartidasAsync(
            string tablaAuxiliar,
            string tipoPoliza,
            string numeroPoliza,
            short ejercicio,
            short periodo) {
            string sql = string.Format(
                @"SELECT *
                  FROM {0}
                  WHERE TIPO_POLI = @tipoPoliza
                    AND TRIM(NUM_POLIZ) = @numeroPoliza
                    AND EJERCICIO = @ejercicio
                    AND PERIODO = @periodo
                  ORDER BY NUM_PART ASC", tablaAuxiliar);

            var partidas = await _context.Db.Ado.SqlQueryAsync<Auxiliar25Entity>(
                sql,
                new SugarParameter("@tipoPoliza", tipoPoliza),
                new SugarParameter("@numeroPoliza", numeroPoliza),
                new SugarParameter("@ejercicio", ejercicio),
                new SugarParameter("@periodo", periodo));

            return partidas.Select(Mappers.PolizaMapper.MapearPartida).ToList();
        }

        private static void ValidarEjercicioPeriodo(short ejercicio, short periodo) {
            if (ejercicio < 1900 || ejercicio > 9999)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));

            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo));
        }
    }
}
