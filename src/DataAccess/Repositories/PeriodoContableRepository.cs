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
    /// Consulta el estado del periodo en ADMPER.
    /// </summary>
    public sealed class PeriodoContableRepository : IPeriodoContableRepository {
        private readonly MariaDbContext _context;

        public PeriodoContableRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PeriodoContable> ObtenerAsync(short ejercicio, short periodo) {
            try {
                var entity = await _context.Db.Queryable<PeriodoContableEntity>()
                    .Where(x => x.EJERCICIO == ejercicio && x.PERIODO == periodo)
                    .FirstAsync();

                if (entity == null)
                    return null;
                return Mappers.PeriodoContableMapper.Map(entity);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar el estado del periodo en ADMPER.", ex);
            }
        }
        public async Task<List<PeriodoContable>> ObtenerTodosAsync(short ejercicio) {
            try {
                var entities = await _context.Db.Queryable<PeriodoContableEntity>()
                    .Where(x => x.EJERCICIO == ejercicio)
                    .ToListAsync();

                var result = new List<PeriodoContable>();
                foreach (var entity in entities.OrderBy(x => x.ORDENADO ?? 0).ThenBy(x => x.PERIODO)) {
                    result.Add(Mappers.PeriodoContableMapper.Map(entity));
                }
                return result;
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar los periodos del ejercicio en ADMPER.", ex);
            }
        }

        public async Task<List<short>> ObtenerEjerciciosAsync() {
            try {
                return await _context.Db.Queryable<PeriodoContableEntity>()
                    .Select(x => x.EJERCICIO)
                    .Distinct()
                    .ToListAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar los ejercicios contables en ADMPER.", ex);
            }
        }

        /// <summary>
        /// Genera los registros faltantes de ADMPER para los 14 periodos del ejercicio.
        /// La operación es transaccional y no modifica periodos existentes.
        /// </summary>
        public async Task<int> CrearEjercicioAsync(short ejercicio) {
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));

            bool transaccionIniciada = false;
            try {
                _context.Db.Ado.BeginTran();
                transaccionIniciada = true;

                var existentes = await _context.Db.Queryable<PeriodoContableEntity>()
                    .Where(x => x.EJERCICIO == ejercicio)
                    .ToListAsync();

                var periodosExistentes = new HashSet<short>();
                foreach (var existente in existentes)
                    periodosExistentes.Add(existente.PERIODO);

                int creados = 0;
                for (short periodo = 1; periodo <= 14; periodo++) {
                    if (periodosExistentes.Contains(periodo))
                        continue;

                    var nuevo = new PeriodoContableEntity {
                        PERIODO = periodo,
                        EJERCICIO = ejercicio,
                        CERRADO = 0,
                        ORDENADO = periodo,
                        REQTRASP = 0,
                        CTPOLIZAS = 0
                    };

                    int afectados = await _context.Db.Insertable(nuevo).ExecuteCommandAsync();
                    if (afectados != 1)
                        throw new InvalidOperationException(string.Format(
                            "No fue posible crear el periodo {0} del ejercicio {1} en ADMPER.",
                            periodo, ejercicio));

                    creados++;
                }

                _context.Db.Ado.CommitTran();
                transaccionIniciada = false;
                return creados;
            } catch (Exception ex) {
                if (transaccionIniciada) {
                    try {
                        _context.Db.Ado.RollbackTran();
                    } catch (Exception rollbackEx) {
                        throw new InvalidOperationException(
                            "No fue posible revertir la creación de periodos en ADMPER.",
                            new AggregateException(ex, rollbackEx));
                    }
                }

                if (ex is InvalidOperationException)
                    throw;
                if (ex is SqlSugarException)
                    throw new InvalidOperationException(
                        "Error de base de datos al crear los periodos del ejercicio en ADMPER.", ex);
                throw new InvalidOperationException(
                    "Error inesperado al crear los periodos del ejercicio en ADMPER.", ex);
            }
        }

        /// <summary>
        /// Actualiza ORDENADO para reflejar la secuencia visual indicada.
        /// La actualización completa se realiza en una sola transacción.
        /// </summary>
        public async Task ActualizarOrdenAsync(short ejercicio, IList<short> periodosOrdenados) {
            bool transaccionIniciada = false;
            try {
                var existentes = await _context.Db.Queryable<PeriodoContableEntity>()
                    .Where(x => x.EJERCICIO == ejercicio)
                    .ToListAsync();

                if (existentes.Count != periodosOrdenados.Count)
                    throw new InvalidOperationException("La lista de periodos cambió. Actualiza la consulta e intenta nuevamente.");

                var periodosExistentes = new HashSet<short>(existentes.Select(x => x.PERIODO));
                if (periodosOrdenados.Any(x => !periodosExistentes.Contains(x)))
                    throw new InvalidOperationException("La lista contiene un periodo que no existe en ADMPER.");

                _context.Db.Ado.BeginTran();
                transaccionIniciada = true;

                for (int indice = 0; indice < periodosOrdenados.Count; indice++) {
                    short periodo = periodosOrdenados[indice];
                    int orden = indice + 1;
                    int afectados = await _context.Db.Updateable<PeriodoContableEntity>()
                        .SetColumns(x => x.ORDENADO == (int?)orden)
                        .Where(x => x.EJERCICIO == ejercicio && x.PERIODO == periodo)
                        .ExecuteCommandAsync();

                    if (afectados != 1)
                        throw new InvalidOperationException(string.Format(
                            "No fue posible actualizar el orden del periodo {0} del ejercicio {1}.", periodo, ejercicio));
                }

                _context.Db.Ado.CommitTran();
                transaccionIniciada = false;
            } catch (Exception ex) {
                if (transaccionIniciada) {
                    try {
                        _context.Db.Ado.RollbackTran();
                    } catch (Exception rollbackEx) {
                        throw new InvalidOperationException(
                            "No fue posible revertir el cambio de orden de los periodos.",
                            new AggregateException(ex, rollbackEx));
                    }
                }

                if (ex is InvalidOperationException)
                    throw;
                if (ex is SqlSugarException)
                    throw new InvalidOperationException("No fue posible guardar el orden de los periodos en ADMPER.", ex);
                throw new InvalidOperationException("Ocurrió un error al guardar el orden de los periodos.", ex);
            }
        }

        public async Task ActualizarCierreAsync(short ejercicio, short periodo, bool cerrado) {
            try {
                int afectados = await _context.Db.Updateable<PeriodoContableEntity>()
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
