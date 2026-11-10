using System;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using SqlSugar;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Consulta el historial contable de las cuentas.</summary>
    public sealed class HistorialCuentaRepository : IHistorialCuentaRepository {
        private readonly MariaDbContext _context;

        public HistorialCuentaRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> TieneMovimientosAsync(string numeroCuenta) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                return false;

            try {
                var numero = numeroCuenta.Trim();
                return await _context.Db.Queryable<Auxiliar25Entity>()
                    .Where(x => x.NUM_CTA == numero)
                    .AnyAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar el historial contable de la cuenta.", ex);
            }
        }
    }
}
