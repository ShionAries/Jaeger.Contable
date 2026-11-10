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
    public sealed class RubroContableRepository : IRangoRepository {
        private readonly MariaDbContext _context;

        public RubroContableRepository(MariaDbContext context) { _context = context ?? throw new ArgumentNullException(nameof(context)); }

        public async Task<List<RubroContableModel>> ObtenerTodosAsync() {
            try {
                return (
                    await _context.Db.Queryable<RubroContableEntity>().OrderBy(x => x.Rango, OrderByType.Asc).ToListAsync()).Select(Map).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar RANGOS.", ex);
            }
        }

        public async Task<RubroContableModel> ObtenerPorIdAsync(int idRango) {
            try {
                var x = await _context.Db.Queryable<RubroContableEntity>().Where(r => r.Rango == idRango).FirstAsync();
                return x == null ? null : Map(x);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el rango.", ex);
            }
        }

        public async Task<bool> ExisteEnCtarubAsync(int idRango) {
            try {
                return await _context.Db.Queryable<CuentaRubroContableEntity>().AnyAsync(x => x.Rubro == idRango);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar el uso del rango en CTARUB.", ex);
            }
        }

        public async Task<bool> InsertarAsync(RubroContableModel rango) {
            if (rango == null)
                throw new ArgumentNullException(nameof(rango));
            try {
                return await _context.Db.Insertable(
                new RubroContableEntity { Rango = rango.Rango, Descripcion = rango.Descripcion }).ExecuteCommandAsync() > 0;
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al insertar el rango.", ex);
            }
        }

        public async Task<bool> ActualizarAsync(RubroContableModel rango) {
            if (rango == null)
                throw new ArgumentNullException(nameof(rango));
            try {
                return await _context.Db.Updateable(
                new RubroContableEntity {
                    Rango = rango.Rango,
                    Descripcion = rango.Descripcion
                }).Where(x => x.Rango == rango.Rango).ExecuteCommandAsync() > 0;
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al actualizar el rango.", ex);
            }
        }

        public async Task<bool> EliminarAsync(int idRango) {
            try {
                return await _context.Db.Deleteable<RubroContableEntity>().Where(x => x.Rango == idRango).ExecuteCommandAsync() > 0;
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al eliminar el rango.", ex);
            }
        }

        private static RubroContableModel Map(RubroContableEntity x) {
            return new RubroContableModel { Rango = x.Rango, Descripcion = x.Descripcion };
        }
    }
}
