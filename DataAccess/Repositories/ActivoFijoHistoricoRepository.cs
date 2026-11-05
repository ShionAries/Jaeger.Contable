using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using SqlSugar;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    public sealed class ActivoFijoHistoricoRepository : IActivoFijoHistoricoRepository {
        private readonly MariaDbContext _context;
        public ActivoFijoHistoricoRepository(MariaDbContext context) { _context = context ?? throw new ArgumentNullException(nameof(context)); }

        public async Task<List<ActivoFijo>> ObtenerEjercicio24Async() {
            try {
                var rows = await _context.Db.Queryable<ActivoFijoEntity>().OrderBy(x => x.CLAVE, OrderByType.Asc).ToListAsync();
                return rows.Select(Mappers.ActivoFijoMapper.Map).ToList();
            } catch (SqlSugarException ex) { throw new InvalidOperationException("Error al consultar ACTIVOS24.", ex); }
        }

        public async Task<List<ActivoFijo>> ObtenerEjercicio25Async() {
            try {
                var rows = await _context.Db.Queryable<ActivoFijoEntity>().OrderBy(x => x.CLAVE, OrderByType.Asc).ToListAsync();
                return rows.Select(Mappers.ActivoFijoMapper.Map).ToList();
            } catch (SqlSugarException ex) { throw new InvalidOperationException("Error al consultar ACTIVOS25.", ex); }
        }
    }
}
