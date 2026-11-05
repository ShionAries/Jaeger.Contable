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
    /// Gestiona la persistencia del catálogo TIPACTIV.
    /// </summary>
    public sealed class TipoActivoRepository : ITipoActivoRepository {
        private readonly MariaDbContext _context;

        public TipoActivoRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<TipoActivo>> ObtenerTodosAsync() {
            try {
                return (await _context.Db.Queryable<TipActivoEntity>()
                    .OrderBy(x => x.CLAVE, OrderByType.Asc)
                    .ToListAsync()).Select(Mappers.TipoActivoMapper.Map).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar TIPACTIV.", ex);
            }
        }

        public async Task<TipoActivo> ObtenerAsync(short clave) {
            try {
                var entity = await _context.Db.Queryable<TipActivoEntity>()
                    .Where(x => x.CLAVE == clave)
                    .FirstAsync();
                return entity == null ? null :Mappers.TipoActivoMapper. Map(entity);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el tipo de activo.", ex);
            }
        }

        public async Task CrearAsync(TipoActivo tipo) {
            try {
                await _context.Db.Insertable(Mappers.TipoActivoMapper.ToEntity(tipo)).ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible crear el tipo de activo. Es posible que la clave ya exista.", ex);
            }
        }

        public async Task ActualizarAsync(TipoActivo tipo) {
            try {
                int afectados = await _context.Db.Updateable(Mappers.TipoActivoMapper.ToEntity(tipo))
                    .WhereColumns(x => x.CLAVE)
                    .ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El tipo de activo indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar el tipo de activo.", ex);
            }
        }

        public async Task EliminarAsync(short clave) {
            try {
                int afectados = await _context.Db.Deleteable<TipActivoEntity>()
                    .Where(x => x.CLAVE == clave)
                    .ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El tipo de activo indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible eliminar el tipo de activo.", ex);
            }
        }

        public async Task<bool> ExisteCuentaAsync(string numeroCuenta) {
            try {
                return await _context.Db.Queryable<CuentaContableEntity>()
                    .AnyAsync(x => x.NumCta == numeroCuenta);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar la cuenta contable.", ex);
            }
        }

        public async Task<bool> ExisteMonedaAsync(short moneda) {
            try {
                return await _context.Db.Queryable<MonedaEntity>()
                    .AnyAsync(x => x.IdMoneda == moneda);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar la moneda.", ex);
            }
        }

        public async Task<bool> EstaEnUsoAsync(short clave) {
            try {
                return await _context.Db.Queryable<ActivoFijoEntity>()
                    .AnyAsync(x => x.TIPO == clave);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "Error al validar el uso del tipo de activo en ACTIVOS25.", ex);
            }
        }
    }
}
