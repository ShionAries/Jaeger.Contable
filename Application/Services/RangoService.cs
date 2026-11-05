using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    public sealed class RangoService : Contracts.IRangoService {
        private readonly IRangoRepository _repository;

        public RangoService(IRangoRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<RubroContableModel>> ListarRangosAsync() {
            return _repository.ObtenerTodosAsync();
        }

        public Task<RubroContableModel> ObtenerAsync(int idRango) {
            ValidarId(idRango);
            return _repository.ObtenerPorIdAsync(idRango);
        }

        public async Task CrearAsync(int idRango, string descripcion) {
            ValidarId(idRango);
            ValidarDescripcion(descripcion);
            if (await _repository.ObtenerPorIdAsync(idRango) != null)
                throw new InvalidOperationException("El rango ya existe.");
            await _repository.InsertarAsync(new RubroContableModel { Rango = idRango, Descripcion = descripcion.Trim() });
        }

        public async Task ActualizarAsync(int idRango, string descripcion) {
            ValidarId(idRango);
            ValidarDescripcion(descripcion);
            if (await _repository.ObtenerPorIdAsync(idRango) == null)
                throw new InvalidOperationException("El rango no existe.");
            await _repository.ActualizarAsync(new RubroContableModel { Rango = idRango, Descripcion = descripcion.Trim() });
        }

        public async Task EliminarAsync(int idRango) {
            ValidarId(idRango);
            if (await _repository.ObtenerPorIdAsync(idRango) == null)
                throw new InvalidOperationException("El rango no existe.");
            if (await _repository.ExisteEnCtarubAsync(idRango))
                throw new InvalidOperationException("No se puede eliminar el rango porque existen cuentas asociadas en CTARUB.");
            await _repository.EliminarAsync(idRango);
        }

        public Task RegistrarRangoAsync(int idRango, string descripcion) { return CrearAsync(idRango, descripcion); }

        private static void ValidarId(int id) {
            if (id <= 0)
                throw new ArgumentException("El identificador del rango debe ser mayor que cero.", nameof(id));
        }

        private static void ValidarDescripcion(string descripcion) {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción del rango es obligatoria.", nameof(descripcion));
            if (descripcion.Trim().Length > 100)
                throw new ArgumentException("La descripción no puede exceder 100 caracteres.", nameof(descripcion));
        }
    }
}
