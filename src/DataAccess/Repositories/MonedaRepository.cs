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
    /// Gestiona la persistencia del catálogo MONEDAS.
    /// </summary>
    public sealed class MonedaRepository : IMonedaRepository {
        private readonly MariaDbContext _context;

        public MonedaRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Moneda>> ObtenerTodosAsync() {
            try {
                return (await _context.Db.Queryable<MonedaEntity>()
                    .OrderBy(x => x.IdMoneda, OrderByType.Asc)
                    .ToListAsync())
                    .Select(Mappers.MonedaMapper.Map)
                    .ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar MONEDAS.", ex);
            }
        }

        public async Task<Moneda> ObtenerAsync(short moneda) {
            try {
                var entidad = await _context.Db.Queryable<MonedaEntity>()
                    .Where(x => x.IdMoneda == moneda)
                    .FirstAsync();
                return entidad == null ? null : Mappers.MonedaMapper.Map(entidad);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar la moneda.", ex);
            }
        }

        public async Task CrearAsync(Moneda moneda) {
            if (moneda == null) throw new ArgumentNullException(nameof(moneda));

            try {
                await _context.Db.Insertable(Mappers.MonedaMapper.ToEntity(moneda)).ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible crear la moneda. Es posible que el código ya exista.", ex);
            }
        }

        public async Task ActualizarAsync(Moneda moneda) {
            if (moneda == null) throw new ArgumentNullException(nameof(moneda));

            try {
                int afectados = await _context.Db.Updateable(Mappers.MonedaMapper.ToEntity(moneda))
                    .WhereColumns(x => x.IdMoneda)
                    .ExecuteCommandAsync();

                if (afectados == 0)
                    throw new InvalidOperationException("La moneda indicada no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar la moneda.", ex);
            }
        }

        public async Task<bool> ExisteEnHistorialAsync(short moneda) {
            try {
                return await _context.Db.Queryable<MonedaHistorialEntity>()
                    .AnyAsync(x => x.IdMoneda == moneda);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar el uso de la moneda en HISTOR.", ex);
            }
        }

        public async Task<bool> ExisteEnTiposActivoAsync(short moneda) {
            try {
                return await _context.Db.Queryable<ActivoFijoTipoEntity>()
                    .AnyAsync(x => x.QUEMONEDA == moneda);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar el uso de la moneda en TIPACTIV.", ex);
            }
        }

        public async Task EliminarAsync(short moneda) {
            try {
                int afectados = await _context.Db.Deleteable<MonedaEntity>()
                    .Where(x => x.IdMoneda == moneda)
                    .ExecuteCommandAsync();

                if (afectados == 0)
                    throw new InvalidOperationException("La moneda indicada no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible eliminar la moneda.", ex);
            }
        }
    }
}
