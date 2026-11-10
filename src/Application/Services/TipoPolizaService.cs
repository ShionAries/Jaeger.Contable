using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    public sealed class TipoPolizaService : Contracts.ITipoPolizaService {
        private readonly ITipoPolizaRepository _repository;

        public TipoPolizaService(ITipoPolizaRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<TipoPoliza>> ObtenerTodosAsync() {
            return _repository.ObtenerTodosAsync();
        }

        public Task<TipoPoliza> ObtenerAsync(string tipo) {
            string normalizado = NormalizarTipo(tipo);
            return _repository.ObtenerAsync(normalizado);
        }

        public async Task<bool> ExisteAsync(string tipo) {
            return await ObtenerAsync(tipo) != null;
        }

        public async Task CrearAsync(string tipo, string descripcion, int? classAt) {
            string codigo = NormalizarTipo(tipo);
            ValidarDescripcion(descripcion);
            if (classAt.HasValue && classAt.Value < 0)
                throw new ArgumentException("CLASSAT no puede ser negativo.", nameof(classAt));

            if (await _repository.ObtenerAsync(codigo) != null)
                throw new InvalidOperationException("El tipo de póliza ya existe.");

            await _repository.CrearAsync(new TipoPoliza {
                Tipo = codigo,
                Descripcion = descripcion.Trim(),
                ClaveSAT = classAt
            });
        }

        public async Task ActualizarAsync(string tipo, string descripcion, int? classAt) {
            string codigo = NormalizarTipo(tipo);
            ValidarDescripcion(descripcion);
            if (classAt.HasValue && classAt.Value < 0)
                throw new ArgumentException("CLASSAT no puede ser negativo.", nameof(classAt));

            if (await _repository.ObtenerAsync(codigo) == null)
                throw new InvalidOperationException("El tipo de póliza no existe.");

            await _repository.ActualizarAsync(new TipoPoliza {
                Tipo = codigo,
                Descripcion = descripcion.Trim(),
                ClaveSAT = classAt
            });
        }

        public async Task EliminarAsync(string tipo) {
            string codigo = NormalizarTipo(tipo);
            if (await _repository.ObtenerAsync(codigo) == null)
                throw new InvalidOperationException("El tipo de póliza no existe.");

            if (await _repository.ExisteEnPolizasAsync(codigo))
                throw new InvalidOperationException("No se puede eliminar el tipo de póliza porque existen pólizas asociadas en POLIZAS25.");

            await _repository.EliminarAsync(codigo);
        }

        private static string NormalizarTipo(string tipo) {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("El tipo de póliza es obligatorio.", nameof(tipo));

            string valor = tipo.Trim().ToUpperInvariant();
            if (valor.Length > 2)
                throw new ArgumentException("El tipo de póliza no puede exceder 2 caracteres.", nameof(tipo));
            return valor;
        }

        private static void ValidarDescripcion(string descripcion) {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción del tipo de póliza es obligatoria.", nameof(descripcion));
            if (descripcion.Trim().Length > 15)
                throw new ArgumentException("La descripción no puede exceder 15 caracteres.", nameof(descripcion));
        }
    }
}
