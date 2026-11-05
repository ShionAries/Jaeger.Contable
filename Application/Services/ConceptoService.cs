using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    public sealed class ConceptoService : Contracts.IConceptoService {
        private readonly IConceptoRepository _repository;

        public ConceptoService(IConceptoRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<Concepto>> ObtenerTodosAsync() {
            return _repository.ObtenerTodosAsync();
        }

        public Task<int> ObtenerSiguienteNumeroAsync() {
            return _repository.ObtenerSiguienteNumeroAsync();
        }

        //public Task<Concepto> ObtenerAsync(int concepto) {
        //    if (concepto <= 0)
        //        throw new ArgumentOutOfRangeException(nameof(concepto), "El código del concepto debe ser mayor que cero.");
        //    return _repository.ObtenerAsync(concepto);
        //}

        public async Task<Concepto> CrearAsync(string descripcion) {
            ValidarDescripcion(descripcion);

            for (int intento = 0; intento < 3; intento++) {
                int numero = await _repository.ObtenerSiguienteNumeroAsync();
                var concepto = new Concepto {
                    IdConcepto = numero,
                    Descripcion = descripcion.Trim()
                };

                try {
                    await _repository.CrearAsync(concepto);
                    return concepto;
                } catch (InvalidOperationException) when (intento < 2) {
                    // Otro proceso pudo insertar el mismo MAX + 1. Se vuelve a calcular.
                }
            }

            throw new InvalidOperationException("No fue posible generar un código disponible para el concepto.");
        }

        public async Task ActualizarAsync(int concepto, string descripcion) {
            if (concepto <= 0)
                throw new ArgumentOutOfRangeException(nameof(concepto), "El código del concepto debe ser mayor que cero.");

            ValidarDescripcion(descripcion);

            var existente = await _repository.ObtenerAsync(concepto);
            if (existente == null)
                throw new InvalidOperationException("El concepto indicado no existe.");

            existente.Descripcion = descripcion.Trim();
            await _repository.ActualizarAsync(existente);
        }

        public async Task EliminarAsync(int concepto) {
            if (concepto <= 0)
                throw new ArgumentOutOfRangeException(nameof(concepto), "El código del concepto debe ser mayor que cero.");

            var existente = await _repository.ObtenerAsync(concepto);
            if (existente == null)
                throw new InvalidOperationException("El concepto indicado no existe.");

            await _repository.EliminarAsync(concepto);
        }

        private static void ValidarDescripcion(string descripcion) {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción del concepto es obligatoria.", nameof(descripcion));

            if (descripcion.Trim().Length > 120)
                throw new ArgumentException("La descripción del concepto no puede exceder 120 caracteres.", nameof(descripcion));
        }
    }
}
