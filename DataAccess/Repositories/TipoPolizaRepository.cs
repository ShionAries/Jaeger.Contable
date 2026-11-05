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
    /// repositorio de tipos de poliza
    /// </summary>
    public sealed class TipoPolizaRepository : ITipoPolizaRepository {
        private readonly MariaDbContext _context;

        public TipoPolizaRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<TipoPoliza>> ObtenerTodosAsync() {
            try {
                return (await _context.Db.Queryable<TiposPolizaEntity>()
                    .OrderBy(x => x.Tipo, OrderByType.Asc)
                    .ToListAsync()).Select(Mappers.TipoPolizaMapper.Map).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar TIPOSPOL.", ex);
            }
        }

        public async Task<TipoPoliza> ObtenerAsync(string tipo) {
            try {
                var entidad = await _context.Db.Queryable<TiposPolizaEntity>()
                    .Where(x => x.Tipo == tipo.Trim().ToUpperInvariant())
                    .FirstAsync();
                return entidad == null ? null : Mappers.TipoPolizaMapper.Map(entidad);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el tipo de póliza.", ex);
            }
        }

        public async Task<bool> ExisteEnPolizasAsync(string tipo) {
            try {
                return await _context.Db.Queryable<PolizaEntity>()
                    .AnyAsync(x => x.TIPO_POLI == tipo.Trim().ToUpperInvariant());
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al validar el uso del tipo de póliza en POLIZAS25.", ex);
            }
        }

        public async Task CrearAsync(TipoPoliza tipo) {
            if (tipo == null)
                throw new ArgumentNullException(nameof(tipo));
            try {
                await _context.Db.Insertable(new TiposPolizaEntity {
                    Tipo = tipo.Tipo,
                    Descripcion = tipo.Descripcion,
                    ClaveSAT = tipo.ClaveSAT
                }).ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible crear el tipo de póliza.", ex);
            }
        }

        public async Task ActualizarAsync(TipoPoliza tipo) {
            if (tipo == null)
                throw new ArgumentNullException(nameof(tipo));
            try {
                await _context.Db.Updateable(new TiposPolizaEntity {
                    Tipo = tipo.Tipo,
                    Descripcion = tipo.Descripcion,
                    ClaveSAT = tipo.ClaveSAT
                })
                .Where(x => x.Tipo == tipo.Tipo)
                .ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar el tipo de póliza.", ex);
            }
        }

        public async Task EliminarAsync(string tipo) {
            try {
                await _context.Db.Deleteable<TiposPolizaEntity>()
                    .Where(x => x.Tipo == tipo.Trim().ToUpperInvariant())
                    .ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible eliminar el tipo de póliza.", ex);
            }
        }
    }
}
