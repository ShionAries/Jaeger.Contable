using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    public sealed class CatalogosPartidaService : Contracts.ICatalogosPartidaService {
        private readonly ICatalogosPartidaRepository _repository;

        public CatalogosPartidaService(ICatalogosPartidaRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<Departamento>> ObtenerDepartamentosAsync() { return _repository.ObtenerDepartamentosAsync(); }
        public Task<List<CentroCosto>> ObtenerCentrosCostosAsync() { return _repository.ObtenerCentrosCostosAsync(); }
        public Task<List<GrupoContable>> ObtenerGruposAsync() { return _repository.ObtenerGruposAsync(); }
        public Task<bool> ExisteDepartamentoAsync(short departamento) { return _repository.ExisteDepartamentoAsync(departamento); }
        public Task<bool> ExisteCentroCostoAsync(int centroCosto) { return _repository.ExisteCentroCostoAsync(centroCosto); }
        public Task<bool> ExisteGrupoAsync(int grupo) { return _repository.ExisteGrupoAsync(grupo); }

        public async Task CrearDepartamentoAsync(short departamento, string descripcion) {
            ValidarIdDepartamento(departamento);
            ValidarDescripcion(descripcion);
            if (await _repository.ExisteDepartamentoAsync(departamento))
                throw new InvalidOperationException("El departamento ya existe.");
            await _repository.CrearDepartamentoAsync(new Departamento { DEPTO = departamento, DESCRIP = Normalizar(descripcion) });
        }

        public async Task ActualizarDepartamentoAsync(short departamento, string descripcion) {
            ValidarIdDepartamento(departamento);
            ValidarDescripcion(descripcion);
            if (!await _repository.ExisteDepartamentoAsync(departamento))
                throw new InvalidOperationException("El departamento no existe.");
            await _repository.ActualizarDepartamentoAsync(new Departamento { DEPTO = departamento, DESCRIP = Normalizar(descripcion) });
        }

        public Task EliminarDepartamentoAsync(short departamento) { ValidarIdDepartamento(departamento); return _repository.EliminarDepartamentoAsync(departamento); }

        public async Task CrearCentroCostoAsync(int id, string descripcion) {
            ValidarId(id, "El ID del centro de costos debe ser mayor que cero.");
            ValidarDescripcion(descripcion);
            if (await _repository.ExisteCentroCostoAsync(id))
                throw new InvalidOperationException("El centro de costos ya existe.");
            await _repository.CrearCentroCostoAsync(new CentroCosto { Id = id, Descripcion = Normalizar(descripcion) });
        }

        public async Task ActualizarCentroCostoAsync(int id, string descripcion) {
            ValidarId(id, "El ID del centro de costos debe ser mayor que cero.");
            ValidarDescripcion(descripcion);
            if (!await _repository.ExisteCentroCostoAsync(id))
                throw new InvalidOperationException("El centro de costos no existe.");
            await _repository.ActualizarCentroCostoAsync(new CentroCosto { Id = id, Descripcion = Normalizar(descripcion) });
        }

        public Task EliminarCentroCostoAsync(int id) { ValidarId(id, "El ID del centro de costos debe ser mayor que cero."); return _repository.EliminarCentroCostoAsync(id); }

        public async Task CrearGrupoAsync(int id, string descripcion) {
            ValidarId(id, "El ID del grupo debe ser mayor que cero.");
            ValidarDescripcion(descripcion);
            if (await _repository.ExisteGrupoAsync(id))
                throw new InvalidOperationException("El grupo ya existe.");
            await _repository.CrearGrupoAsync(new GrupoContable { Id = id, Descripcion = Normalizar(descripcion) });
        }

        public async Task ActualizarGrupoAsync(int id, string descripcion) {
            ValidarId(id, "El ID del grupo debe ser mayor que cero.");
            ValidarDescripcion(descripcion);
            if (!await _repository.ExisteGrupoAsync(id))
                throw new InvalidOperationException("El grupo no existe.");
            await _repository.ActualizarGrupoAsync(new GrupoContable { Id = id, Descripcion = Normalizar(descripcion) });
        }

        public Task EliminarGrupoAsync(int id) { ValidarId(id, "El ID del grupo debe ser mayor que cero."); return _repository.EliminarGrupoAsync(id); }

        private static void ValidarIdDepartamento(short id) {
            if (id <= 0)
                throw new ArgumentException("El departamento debe ser mayor que cero.", nameof(id));
        }

        private static void ValidarId(int id, string mensaje) {
            if (id <= 0)
                throw new ArgumentException(mensaje, nameof(id));
        }

        private static void ValidarDescripcion(string descripcion) {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción es obligatoria.", nameof(descripcion));
            if (descripcion.Trim().Length > 40)
                throw new ArgumentException("La descripción no puede exceder 40 caracteres.", nameof(descripcion));
        }

        private static string Normalizar(string valor) { return valor.Trim().ToUpperInvariant(); }
    }
}
