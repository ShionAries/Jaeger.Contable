using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Centraliza la regla de apertura/cierre definida por ADMPER.</summary>
    public sealed class PeriodoContableService : Contracts.IPeriodoContableService {
        private readonly IPeriodoContableRepository _repository;

        public PeriodoContableService(IPeriodoContableRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        //public async Task<PeriodoContable> ObtenerAsync(short ejercicio, short periodo) {
        //    ValidarParametros(ejercicio, periodo);
        //    return await _repository.ObtenerAsync(ejercicio, periodo);
        //}

        public async Task<List<PeriodoContable>> ObtenerTodosAsync(short ejercicio) {
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            return await _repository.ObtenerTodosAsync(ejercicio);
        }

        public async Task<List<short>> ObtenerEjerciciosAsync() {
            return await _repository.ObtenerEjerciciosAsync();
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
