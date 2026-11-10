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
    /// <summary>
    /// Gestiona el catálogo CONCEPTO.
    /// </summary>
    public sealed class ConceptoRepository : IConceptoRepository {
        private readonly MariaDbContext _context;

        public ConceptoRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Concepto>> ObtenerTodosAsync() {
            try {
                return (await _context.Db.Queryable<ConceptoEntity>()
                    .OrderBy(x => x.IdConcepto, OrderByType.Asc)
                    .ToListAsync())
                    .Select(Mappers.ConceptoMapper.Map).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar CONCEPTO.", ex);
            }
        }

        public async Task<Concepto> ObtenerAsync(int concepto) {
            try {
                var entidad = await _context.Db.Queryable<ConceptoEntity>()
                    .Where(x => x.IdConcepto == concepto)
                    .FirstAsync();
                return entidad == null ? null : Mappers.ConceptoMapper.Map(entidad);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar el concepto de póliza.", ex);
            }
        }

        public async Task<int> ObtenerSiguienteNumeroAsync() {
            try {
                var ultimo = await _context.Db.Queryable<ConceptoEntity>()
                    .OrderBy(x => x.IdConcepto, OrderByType.Desc)
                    .FirstAsync();
                return (ultimo == null ? 0 : ultimo.IdConcepto) + 1;
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al generar el siguiente código de CONCEPTO.", ex);
            }
        }

        public async Task CrearAsync(Concepto concepto) {
            if (concepto == null)
                throw new ArgumentNullException(nameof(concepto));

            try {
                await _context.Db.Insertable(new ConceptoEntity {
                    IdConcepto = concepto.IdConcepto,
                    Descripcion = concepto.Descripcion
                }).ExecuteCommandAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible insertar el concepto. Es posible que el código ya exista.", ex);
            }
        }

        public async Task ActualizarAsync(Concepto concepto) {
            if (concepto == null)
                throw new ArgumentNullException(nameof(concepto));

            try {
                int afectados = await _context.Db.Updateable(new ConceptoEntity {
                    IdConcepto = concepto.IdConcepto,
                    Descripcion = concepto.Descripcion
                })
                .WhereColumns(x => x.IdConcepto)
                .ExecuteCommandAsync();

                if (afectados == 0)
                    throw new InvalidOperationException("El concepto indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar el concepto.", ex);
            }
        }

        public async Task EliminarAsync(int concepto) {
            try {
                int afectados = await _context.Db.Deleteable<ConceptoEntity>()
                    .Where(x => x.IdConcepto == concepto)
                    .ExecuteCommandAsync();

                if (afectados == 0)
                    throw new InvalidOperationException("El concepto indicado no existe.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible eliminar el concepto.", ex);
            }
        }
    }
}
