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
    public sealed class CentroCostosRepository : ICentroCostosRepository {
        private readonly MariaDbContext _context;

        public CentroCostosRepository(MariaDbContext context) {
            _context = context;
        }

        public async Task<List<CentroCosto>> ObtenerTodosAsync() {
            try {
                var entidades = await _context.Db.Queryable<CentroCostosEntity>()
                    .ToListAsync();
                return entidades.Select(Mappers.CentroCostosMapper.Map).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar CENTRO DE COSTOS.", ex);
            }
        }

        public async Task<CentroCosto> ObtenerAsync(short idCentroCosto) {
            try {
                var entidad = await _context.Db.Queryable<CentroCostosEntity>()
                    .Where(x => x.ID == idCentroCosto)
                    .FirstAsync();
                return entidad == null ? null : Mappers.CentroCostosMapper.Map(entidad);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el centro de costos.", ex);
            }
        }

        public async Task CrearAsync(CentroCosto centroCosto) {
            if (centroCosto == null)
                throw new ArgumentNullException(nameof(centroCosto));
            try {
                await _context.Db.Insertable(Mappers.CentroCostosMapper.Map(centroCosto)).ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible crear el centro de costos. Es posible que el código ya exista.", ex);
            }
        }

        public async Task ActualizarAsync(CentroCosto centroCosto) {
            if (centroCosto == null)
                throw new ArgumentNullException(nameof(centroCosto));
            try {
                int afectados = await _context.Db.Updateable(Mappers.CentroCostosMapper.Map(centroCosto))
                    .WhereColumns(x => x.ID)
                    .ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El centro de costos indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar el centro de costos.", ex);
            }
        }

        public async Task EliminarAsync(short idCentroCosto) {
            try {
                int afectados = await _context.Db.Deleteable<CentroCostosEntity>()
                    .Where(x => x.ID == idCentroCosto)
                    .ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El centro de costos indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible eliminar el centro de costos.", ex);
            }
        }
    }
}
