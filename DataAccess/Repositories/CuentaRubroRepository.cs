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
    public sealed class CuentaRubroRepository : ICuentaRubroRepository {
        private readonly MariaDbContext _context;
        public CuentaRubroRepository(MariaDbContext context) { _context = context ?? throw new ArgumentNullException(nameof(context)); }
        public async Task<List<CuentaRubro>> ObtenerTodasAsync() {
            try {
                var rows = await _context.Db.Queryable<CuentaRubroContableEntity>().ToListAsync();
                return rows.Select(x => new CuentaRubro { Rubro = x.Rubro, Cuenta = x.Cuenta, SegPapa = x.SegPapa }).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar CTARUB.", ex);
            }
        }
    }
}
