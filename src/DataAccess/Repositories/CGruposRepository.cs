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
    public sealed class CGruposRepository : ICGruposRepository {
       private readonly MariaDbContext _context;
        public CGruposRepository(MariaDbContext context) {
            _context = context;
        }
        public async Task<List<GrupoContable>> ObtenerTodosAsync() {
            try {
                var entidades = await _context.Db.Queryable<CGruposEntity>()
                    .ToListAsync();
                return entidades.Select(Mappers.CGrupoMapper.Map).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar GRUPOS CONTABLES.", ex);
            }
        }
        public async Task<GrupoContable> ObtenerAsync(short idGrupo) {
            try {
                var entidad = await _context.Db.Queryable<CGruposEntity>()
                    .Where(x => x.ID == idGrupo)
                    .FirstAsync();
                return entidad == null ? null : Mappers.CGrupoMapper.Map(entidad);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el grupo contable.", ex);
            }
        }
        public async Task CrearAsync(GrupoContable grupo) {
            if (grupo == null)
                throw new ArgumentNullException(nameof(grupo));
            try {
                await _context.Db.Insertable(Mappers.CGrupoMapper.Map(grupo)).ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible crear el grupo contable. Es posible que el código ya exista.", ex);
            }
        }
        public async Task ActualizarAsync(GrupoContable grupo) {
            if (grupo == null)
                throw new ArgumentNullException(nameof(grupo));
            try {
                int afectados = await _context.Db.Updateable(Mappers.CGrupoMapper.Map(grupo))
                    .WhereColumns(x => x.ID)
                    .ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El grupo contable indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar el grupo contable.", ex);
            }
        }
        public async Task EliminarAsync(short idGrupo) {
            try {
                int afectados = await _context.Db.Deleteable<CGruposEntity>()
                    .Where(x => x.ID == idGrupo)
                    .ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El grupo contable indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible eliminar el grupo contable.", ex);
            }
        }
    }
}
