using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SqlSugar;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Consulta el estado del periodo en ADMPER.</summary>
    public sealed class PeriodoContableRepository : IPeriodoContableRepository {
        private readonly MariaDbContext _context;

        public PeriodoContableRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PeriodoContable> ObtenerAsync(short ejercicio, short periodo) {
            try {
                var entity = await _context.Db.Queryable<AdmperEntity>()
                    .Where(x => x.EJERCICIO == ejercicio && x.PERIODO == periodo)
                    .FirstAsync();

                if (entity == null)
                    return null;

                return new PeriodoContable(
                    entity.PERIODO,
                    entity.EJERCICIO,
                    entity.CERRADO ?? 0,
                    entity.ORDENADO ?? 0,
                    entity.REQTRASP ?? 0,
                    entity.CTPOLIZAS ?? 0);
            }
            catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar el estado del periodo en ADMPER.", ex);
            }
        }
        public async Task<List<PeriodoContable>> ObtenerTodosAsync(short ejercicio) {
            try {
                var entities = await _context.Db.Queryable<AdmperEntity>()
                    .Where(x => x.EJERCICIO == ejercicio)
                    .OrderBy(x => x.PERIODO)
                    .ToListAsync();

                var result = new List<PeriodoContable>();
                foreach (var entity in entities) {
                    result.Add(new PeriodoContable(
                        entity.PERIODO, entity.EJERCICIO, entity.CERRADO ?? 0,
                        entity.ORDENADO ?? 0, entity.REQTRASP ?? 0, entity.CTPOLIZAS ?? 0));
                }
                return result;
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar los periodos del ejercicio en ADMPER.", ex);
            }
        }

        public async Task<List<short>> ObtenerEjerciciosAsync() {
            try {
                return await _context.Db.Queryable<AdmperEntity>()
                    .Select(x => x.EJERCICIO)
                    .Distinct()
                    .ToListAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar los ejercicios contables en ADMPER.", ex);
            }
        }

        public async Task ActualizarCierreAsync(short ejercicio, short periodo, bool cerrado) {
            try {
                int afectados = await _context.Db.Updateable<AdmperEntity>()
                    .SetColumns(x => x.CERRADO == (short?)(cerrado ? 1 : 0))
                    .Where(x => x.EJERCICIO == ejercicio && x.PERIODO == periodo)
                    .ExecuteCommandAsync();
                if (afectados != 1)
                    throw new InvalidOperationException("No fue posible actualizar el estado del periodo en ADMPER.");
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible actualizar el cierre del periodo en ADMPER.", ex);
            }
        }

    }
}
