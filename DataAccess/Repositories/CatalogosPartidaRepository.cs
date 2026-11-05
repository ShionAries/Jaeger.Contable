using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;

namespace Jaeger.Contable.DataAccess.Repositories {
    public sealed class CatalogosPartidaRepository : ICatalogosPartidaRepository {
        private readonly MariaDbContext _context;

        public CatalogosPartidaRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Departamento>> ObtenerDepartamentosAsync() {
            try {
                return (
                    await _context.Db.Queryable<DeptoEntity>().OrderBy(x => x.IdDepto, OrderByType.Asc).ToListAsync())
                    .Select(x => new Departamento { DEPTO = x.IdDepto, DESCRIP = x.Descripcion }).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar DEPTOS.", ex);
            }
        }

        public async Task<List<CentroCosto>> ObtenerCentrosCostosAsync() {
            try {
                return (await _context.Db.Queryable<CcostosEntity>().OrderBy(x => x.ID, OrderByType.Asc).ToListAsync()).Select(x => new CentroCosto { Id = x.ID, Descripcion = x.DESCRIPCION }).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar CCOSTOS.", ex);
            }
        }

        public async Task<List<GrupoContable>> ObtenerGruposAsync() {
            try {
                return (
                    await _context.Db.Queryable<CgruposEntity>().OrderBy(x => x.ID, OrderByType.Asc).ToListAsync()).Select(x => new GrupoContable { Id = x.ID, Descripcion = x.DESCRIPCION }).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar CGRUPOS.", ex);
            }
        }

        public async Task<bool> ExisteDepartamentoAsync(short departamento) {
            try {
                return await _context.Db.Queryable<DeptoEntity>().AnyAsync(x => x.IdDepto == departamento);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar DEPTOS.", ex);
            }
        }
        public async Task<bool> ExisteCentroCostoAsync(int centroCosto) {
            try { return await _context.Db.Queryable<CcostosEntity>().AnyAsync(x => x.ID == centroCosto); } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar CCOSTOS.", ex);
            }
        }
        public async Task<bool> ExisteGrupoAsync(int grupo) {
            try { return await _context.Db.Queryable<CgruposEntity>().AnyAsync(x => x.ID == grupo); } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar CGRUPOS.", ex);
            }
        }

        public async Task CrearDepartamentoAsync(Departamento item) {
            try { await _context.Db.Insertable(new DeptoEntity { IdDepto = item.DEPTO, Descripcion = item.DESCRIP }).ExecuteCommandAsync(); } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible crear el departamento.", ex);
            }
        }
        public async Task ActualizarDepartamentoAsync(Departamento item) {
            try { await _context.Db.Updateable(new DeptoEntity { IdDepto = item.DEPTO, Descripcion = item.DESCRIP }).Where(x => x.IdDepto == item.DEPTO).ExecuteCommandAsync(); } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar el departamento.", ex);
            }
        }
        public async Task EliminarDepartamentoAsync(short id) {
            try { await _context.Db.Deleteable<DeptoEntity>().Where(x => x.IdDepto == id).ExecuteCommandAsync(); } catch (SqlSugarException ex) { throw new InvalidOperationException("No fue posible eliminar el departamento.", ex); }
        }

        public async Task CrearCentroCostoAsync(CentroCosto item) {
            try { await _context.Db.Insertable(new CcostosEntity { ID = item.Id, DESCRIPCION = item.Descripcion }).ExecuteCommandAsync(); } catch (SqlSugarException ex) { throw new InvalidOperationException("No fue posible crear el centro de costos.", ex); }
        }
        public async Task ActualizarCentroCostoAsync(CentroCosto item) {
            try { await _context.Db.Updateable(new CcostosEntity { ID = item.Id, DESCRIPCION = item.Descripcion }).Where(x => x.ID == item.Id).ExecuteCommandAsync(); } catch (SqlSugarException ex) { throw new InvalidOperationException("No fue posible actualizar el centro de costos.", ex); }
        }
        public async Task EliminarCentroCostoAsync(int id) {
            try { await _context.Db.Deleteable<CcostosEntity>().Where(x => x.ID == id).ExecuteCommandAsync(); } catch (SqlSugarException ex) { throw new InvalidOperationException("No fue posible eliminar el centro de costos.", ex); }
        }

        public async Task CrearGrupoAsync(GrupoContable item) {
            try { await _context.Db.Insertable(new CgruposEntity { ID = item.Id, DESCRIPCION = item.Descripcion }).ExecuteCommandAsync(); } catch (SqlSugarException ex) { throw new InvalidOperationException("No fue posible crear el grupo.", ex); }
        }
        public async Task ActualizarGrupoAsync(GrupoContable item) {
            try { await _context.Db.Updateable(new CgruposEntity { ID = item.Id, DESCRIPCION = item.Descripcion }).Where(x => x.ID == item.Id).ExecuteCommandAsync(); } catch (SqlSugarException ex) { throw new InvalidOperationException("No fue posible actualizar el grupo.", ex); }
        }
        public async Task EliminarGrupoAsync(int id) {
            try { await _context.Db.Deleteable<CgruposEntity>().Where(x => x.ID == id).ExecuteCommandAsync(); } catch (SqlSugarException ex) { throw new InvalidOperationException("No fue posible eliminar el grupo.", ex); }
        }
    }
}
