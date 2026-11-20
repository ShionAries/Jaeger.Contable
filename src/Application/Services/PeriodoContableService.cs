using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Centraliza la regla de apertura/cierre definida por ADMPER.
    /// </summary>
    public sealed class PeriodoContableService : Contracts.IPeriodoContableService {
        private readonly IPeriodoContableRepository _repository;

        public PeriodoContableService(IPeriodoContableRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<PeriodoContable>> ObtenerTodosAsync(short ejercicio) {
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            return await _repository.ObtenerTodosAsync(ejercicio);
        }

        public async Task<List<short>> ObtenerEjerciciosAsync() {
            return await _repository.ObtenerEjerciciosAsync();
        }

        /// <summary>
        /// Crea los periodos faltantes del ejercicio contable (1 a 14).
        /// Los registros existentes se conservan sin modificaciones.
        /// </summary>
        public async Task<int> CrearEjercicioAsync(short ejercicio) {
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));

            return await _repository.CrearEjercicioAsync(ejercicio);
        }

        /// <summary>
        /// Guarda el orden visual de los periodos del ejercicio.
        /// ORDENADO se utiliza exclusivamente como criterio de ordenamiento.
        /// </summary>
        public async Task ActualizarOrdenAsync(short ejercicio, IList<short> periodosOrdenados) {
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodosOrdenados == null)
                throw new ArgumentNullException(nameof(periodosOrdenados));
            if (periodosOrdenados.Count > 14)
                throw new ArgumentException("Un ejercicio no puede contener más de 14 periodos.", nameof(periodosOrdenados));

            var unicos = new HashSet<short>();
            foreach (short periodo in periodosOrdenados) {
                if (periodo < 1 || periodo > 14)
                    throw new ArgumentOutOfRangeException(nameof(periodosOrdenados), "Todos los periodos deben estar entre 1 y 14.");
                if (!unicos.Add(periodo))
                    throw new ArgumentException("La lista contiene periodos duplicados.", nameof(periodosOrdenados));
            }

            await _repository.ActualizarOrdenAsync(ejercicio, periodosOrdenados);
        }

        public async Task CerrarAsync(short ejercicio, short periodo) {
            await CambiarCierreAsync(ejercicio, periodo, true);
        }

        public async Task AbrirAsync(short ejercicio, short periodo) {
            await CambiarCierreAsync(ejercicio, periodo, false);
        }

        private async Task CambiarCierreAsync(short ejercicio, short periodo, bool cerrado) {
            ValidarParametros(ejercicio, periodo);
            var estado = await _repository.ObtenerAsync(ejercicio, periodo);
            if (estado == null)
                throw new InvalidOperationException(string.Format(
                    "El periodo {0} del ejercicio {1} no existe en ADMPER.", periodo, ejercicio));

            if (cerrado && estado.EstaCerrado)
                throw new InvalidOperationException("El periodo ya está cerrado.");
            if (!cerrado && !estado.EstaCerrado)
                throw new InvalidOperationException("El periodo ya está abierto.");

            await _repository.ActualizarCierreAsync(ejercicio, periodo, cerrado);
        }

        private static void ValidarParametros(short ejercicio, short periodo) {
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo));
        }

        public async Task ValidarRegistroAsync(short ejercicio, short periodo) {
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo));

            var estado = await _repository.ObtenerAsync(ejercicio, periodo);
            if (estado == null)
                throw new InvalidOperationException(string.Format(
                    "El periodo {0} del ejercicio {1} no existe en ADMPER.", periodo, ejercicio));

            if (estado.EstaCerrado)
                throw new InvalidOperationException(string.Format(
                    "El periodo {0} del ejercicio {1} está cerrado y no permite registrar pólizas.", periodo, ejercicio));
        }
    }
}
