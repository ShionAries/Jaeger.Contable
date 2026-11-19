using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Configuration;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Consulta movimientos y saldos iniciales de AUXILIARxx y SALDOSxx.</summary>
    public sealed class AuxiliarCuentaRepository : IAuxiliarCuentaRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public AuxiliarCuentaRepository(MariaDbContext context, IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public async Task<List<AuxiliarMovimiento>> ObtenerMovimientosAsync(
            short ejercicio, string cuentaInicial, string cuentaFinal) {
            ValidarConsulta(ejercicio, cuentaInicial, cuentaFinal);
            string tabla = _tableResolver.ObtenerTablaAuxiliar(ejercicio);
            string tablaPolizas = _tableResolver.ObtenerTablaPolizas(ejercicio);

            string sql = string.Format(CultureInfo.InvariantCulture,
                @"SELECT
                    a.NUM_CTA AS NumeroCuenta,
                    a.FECHA_POL AS Fecha,
                    a.PERIODO AS Periodo,
                    a.TIPO_POLI AS TipoPoliza,
                    a.NUM_POLIZ AS NumeroPoliza,
                    a.NUM_PART AS NumeroPartida,
                    a.CONCEP_PO AS Concepto,
                    a.DEBE_HABER AS DebeHaber,
                    COALESCE(a.MONTOMOV, 0) AS Importe,
                    a.NUMDEPTO AS NumeroDepartamento,
                    a.TIPCAMBIO AS TipoCambio,
                    a.CONTRAPAR AS Contrapartida,
                    a.ORDEN AS Orden,
                    a.CCOSTOS AS CentroCostos,
                    a.CGRUPOS AS Grupo
                  FROM {0} a
                  INNER JOIN {1} p
                    ON p.TIPO_POLI = a.TIPO_POLI
                   AND p.NUM_POLIZ = a.NUM_POLIZ
                   AND p.PERIODO = a.PERIODO
                   AND p.EJERCICIO = a.EJERCICIO
                  WHERE a.EJERCICIO = @ejercicio
                    AND a.NUM_CTA >= @cuentaInicial
                    AND a.NUM_CTA <= @cuentaFinal
                    AND p.CONTABILIZ = 'S'
                  ORDER BY a.NUM_CTA, a.PERIODO, a.FECHA_POL, a.TIPO_POLI, a.NUM_POLIZ, a.NUM_PART", tabla, tablaPolizas);

            try {
                return await _context.Db.Ado.SqlQueryAsync<AuxiliarMovimiento>(
                    sql,
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@cuentaInicial", cuentaInicial.Trim()),
                    new SugarParameter("@cuentaFinal", cuentaFinal.Trim()));
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture,
                        "No fue posible consultar los movimientos auxiliares del ejercicio {0}.", ejercicio), ex);
            }
        }

        public async Task<List<AuxiliarSaldoInicial>> ObtenerSaldosInicialesAsync(
            short ejercicio, string cuentaInicial, string cuentaFinal) {
            ValidarConsulta(ejercicio, cuentaInicial, cuentaFinal);
            string tabla = _tableResolver.ObtenerTablaSaldos(ejercicio);

            string sql = string.Format(CultureInfo.InvariantCulture,
                @"SELECT NUM_CTA AS NumeroCuenta, COALESCE(INICIAL, 0) AS SaldoInicial
                  FROM {0}
                  WHERE EJERCICIO = @ejercicio
                    AND NUM_CTA >= @cuentaInicial
                    AND NUM_CTA <= @cuentaFinal
                  ORDER BY NUM_CTA", tabla);

            try {
                return await _context.Db.Ado.SqlQueryAsync<AuxiliarSaldoInicial>(
                    sql,
                    new SugarParameter("@ejercicio", ejercicio),
                    new SugarParameter("@cuentaInicial", cuentaInicial.Trim()),
                    new SugarParameter("@cuentaFinal", cuentaFinal.Trim()));
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture,
                        "No fue posible consultar los saldos iniciales del ejercicio {0}.", ejercicio), ex);
            }
        }

        private static void ValidarConsulta(short ejercicio, string cuentaInicial, string cuentaFinal) {
            if (ejercicio < 1900 || ejercicio > 9999)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (string.IsNullOrWhiteSpace(cuentaInicial))
                throw new ArgumentException("La cuenta inicial es obligatoria.", nameof(cuentaInicial));
            if (string.IsNullOrWhiteSpace(cuentaFinal))
                throw new ArgumentException("La cuenta final es obligatoria.", nameof(cuentaFinal));
            if (string.Compare(cuentaInicial.Trim(), cuentaFinal.Trim(), StringComparison.Ordinal) > 0)
                throw new ArgumentException("La cuenta inicial no puede ser mayor que la cuenta final.");
        }
    }
}
