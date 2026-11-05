using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Lee los saldos anuales SALDOSxx sin modificar información contable.</summary>
    public sealed class BalanzaComprobacionRepository : IBalanzaComprobacionRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public BalanzaComprobacionRepository(MariaDbContext context, IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public async Task<List<SaldoCuentaEjercicio>> ObtenerSaldosAsync(short ejercicio) {
            if (ejercicio < 1900)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));

            try {
                string tabla = _tableResolver.ObtenerTablaSaldos(ejercicio);
                var entidades = await _context.Db.Queryable<SaldosEntity>().AS(tabla)
                    .Where(x => x.EJERCICIO == ejercicio).ToListAsync();
                var resultado = new List<SaldoCuentaEjercicio>(entidades.Count);

                foreach (var entidad in entidades) {
                    var cargos = new decimal[14];
                    var abonos = new decimal[14];
                    for (int periodo = 1; periodo <= 14; periodo++) {
                        cargos[periodo - 1] = ObtenerImporte(entidad, "CARGO", periodo);
                        abonos[periodo - 1] = ObtenerImporte(entidad, "ABONO", periodo);
                    }

                    resultado.Add(new SaldoCuentaEjercicio {
                        NumeroCuenta = entidad.NUM_CTA,
                        SaldoInicial = ConvertirImporte(entidad.INICIAL),
                        Cargos = cargos,
                        Abonos = abonos
                    });
                }

                return resultado;
            }
            catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture, "No fue posible consultar los saldos del ejercicio {0}.", ejercicio), ex);
            }
        }

        private static decimal ObtenerImporte(SaldosEntity entidad, string prefijo, int periodo) {
            string propiedad = prefijo + periodo.ToString("00", CultureInfo.InvariantCulture);
            PropertyInfo info = typeof(SaldosEntity).GetProperty(propiedad, BindingFlags.Instance | BindingFlags.Public);
            if (info == null)
                throw new InvalidOperationException("No existe la columna de saldo " + propiedad + ".");
            return ConvertirImporte((double?)info.GetValue(entidad, null));
        }

        private static decimal ConvertirImporte(double? importe) {
            return importe.HasValue ? decimal.Round(Convert.ToDecimal(importe.Value), 2, MidpointRounding.AwayFromZero) : 0m;
        }
    }
}
