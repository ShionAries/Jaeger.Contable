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
    /// Gestiona la persistencia de ACTIVOS25.
    /// </summary>
    public sealed class ActivoFijoRepository : IActivoFijoRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public ActivoFijoRepository(MariaDbContext context, IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public async Task<List<ActivoFijo>> ObtenerTodosAsync() {
            try {
                return (await _context.Db.Queryable<ActivoFijoEntity>()
                    .OrderBy(x => x.CLAVE, OrderByType.Asc).ToListAsync()).Select(Mappers.ActivoFijoMapper.Map).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar ACTIVOS25.", ex);
            }
        }

        public async Task<List<ActivoFijo>> ObtenerTodosAsync(short ejercicio) {
            string tabla = _tableResolver.ObtenerTablaActivos(ejercicio);
            try {
                string sql = string.Format("SELECT * FROM {0} ORDER BY CLAVE", tabla);
                var rows = await _context.Db.Ado.SqlQueryAsync<ActivoFijoEntity>(sql);
                return rows.Select(Mappers.ActivoFijoMapper.Map).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar " + tabla + ".", ex);
            }
        }

        public async Task<ActivoFijo> ObtenerAsync(string clave) {
            try {
                var x = await _context.Db.Queryable<ActivoFijoEntity>()
                    .Where(a => a.CLAVE == clave).FirstAsync();
                return x == null ? null : Mappers.ActivoFijoMapper.Map(x);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el activo fijo.", ex);
            }
        }

        public async Task<ActivoFijo> ObtenerAsync(short ejercicio, string clave) {
            string tabla = _tableResolver.ObtenerTablaActivos(ejercicio);
            try {
                string sql = string.Format("SELECT * FROM {0} WHERE CLAVE=@clave LIMIT 1", tabla);
                var rows = await _context.Db.Ado.SqlQueryAsync<ActivoFijoEntity>(sql,
                    new SugarParameter("@clave", clave));
                var row = rows.FirstOrDefault();
                return row == null ? null : Mappers.ActivoFijoMapper.Map(row);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el activo fijo en " + tabla + ".", ex);
            }
        }

        public async Task ActualizarDepreciacionAsync(short ejercicio, string clave, double depacu) {
            string tabla = _tableResolver.ObtenerTablaActivos(ejercicio);
            try {
                string sql = string.Format("UPDATE {0} SET DEPACU=@depacu WHERE CLAVE=@clave", tabla);
                int afectados = await _context.Db.Ado.ExecuteCommandAsync(sql,
                    new SugarParameter("@depacu", depacu),
                    new SugarParameter("@clave", clave));
                if (afectados != 1)
                    throw new InvalidOperationException("No fue posible actualizar la depreciación acumulada del activo " + clave + ".");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al actualizar la depreciación acumulada en " + tabla + ".", ex);
            }
        }

        public async Task CrearAsync(ActivoFijo activo) {
            try {
                await _context.Db.Insertable(Mappers.ActivoFijoMapper.ToEntity(activo)).ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible crear el activo fijo. Es posible que la clave ya exista.", ex);
            }
        }

        public async Task ActualizarAsync(ActivoFijo activo) {
            try {
                int afectados = await _context.Db.Updateable(Mappers.ActivoFijoMapper.ToEntity(activo))
                    .WhereColumns(x => x.CLAVE).ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El activo fijo indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar el activo fijo.", ex);
            }
        }

        public async Task EliminarAsync(string clave) {
            try {
                int afectados = await _context.Db.Deleteable<ActivoFijoEntity>()
                    .Where(x => x.CLAVE == clave).ExecuteCommandAsync();
                if (afectados == 0)
                    throw new InvalidOperationException("El activo fijo indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible eliminar el activo fijo.", ex);
            }
        }

        public async Task<bool> ExisteTipoAsync(short tipo) {
            try {
                return await _context.Db.Queryable<ActivoFijoTipoEntity>().AnyAsync(x => x.CLAVE == tipo);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar el tipo de activo.", ex);
            }
        }
    }
}
