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
    /// <summary>Consulta movimientos del ejercicio solicitado para cálculos de acumulación.</summary>
    public sealed class AcumulacionCuentaRepository : IAcumulacionCuentaRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public AcumulacionCuentaRepository(MariaDbContext context, IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public async Task<List<MovimientoCuenta>> ObtenerMovimientosAsync(IEnumerable<string> numerosCuenta, short ejercicio, short? periodo) {
            if (numerosCuenta == null)
                throw new ArgumentNullException(nameof(numerosCuenta));

            var cuentas = numerosCuenta
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .Distinct(StringComparer.Ordinal)
                .ToList();

            if (cuentas.Count == 0)
                return new List<MovimientoCuenta>();

            try {
                var tabla = _tableResolver.ObtenerTablaAuxiliar(ejercicio);
                var query = _context.Db.Queryable<Auxiliar25Entity>()
                    .AS(tabla)
                    .Where(x => x.EJERCICIO == ejercicio && cuentas.Contains(x.NUM_CTA));

                if (periodo.HasValue)
                    query = query.Where(x => x.PERIODO == periodo.Value);

                return await query.Select(x => new MovimientoCuenta {
                    NumeroCuenta = x.NUM_CTA,
                    Ejercicio = x.EJERCICIO,
                    Periodo = x.PERIODO,
                    DebeHaber = x.DEBE_HABER,
                    Importe = x.MONTOMOV ?? 0
                }).ToListAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar los movimientos para la acumulación.", ex);
            }
        }
    }
}
