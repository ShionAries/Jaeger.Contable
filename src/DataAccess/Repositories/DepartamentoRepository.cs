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
    public sealed class DepartamentoRepository : IDepartamentoRepository {
        private readonly MariaDbContext _context;
        public DepartamentoRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Departamento>> ObtenerTodosAsync() {
            try {
                return (await _context.Db.Queryable<DeptoEntity>()
                    .OrderBy(x => x.IdDepto, OrderByType.Asc)
                    .ToListAsync())
                    .Select(Mappers.DepartamentoMapper.Map)
                    .ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar DEPARTAMENTOS.", ex);
            }
        }
        public async Task<Departamento> ObtenerAsync(short idDepartamento) {
            try {
                var entidad = await _context.Db.Queryable<DeptoEntity>()
                    .Where(x => x.IdDepto == idDepartamento)
                    .FirstAsync();
                return entidad == null ? null : Mappers.DepartamentoMapper.Map(entidad);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el departamento.", ex);
            }
        }
        public async Task CrearAsync(Departamento departamento) {
            if (departamento == null)
                throw new ArgumentNullException(nameof(departamento));
            try {
                await _context.Db.Insertable(Mappers.DepartamentoMapper.ToEntity(departamento)).ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible crear el departamento. Es posible que el código ya exista.", ex);
            }
        }
        public async Task ActualizarAsync(Departamento departamento) {
            if (departamento == null)
                throw new ArgumentNullException(nameof(departamento));
            try {
                int afectados = await _context.Db.Updateable(Mappers.DepartamentoMapper.ToEntity(departamento))
                    .WhereColumns(x => x.IdDepto)
                    .ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El departamento indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar el departamento.", ex);
            }
        }
        public async Task EliminarAsync(short idDepartamento) {
            try {
                int afectados = await _context.Db.Deleteable<DeptoEntity>()
                    .Where(x => x.IdDepto == idDepartamento)
                    .ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El departamento indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible eliminar el departamento.", ex);
            }
        }
    }
}