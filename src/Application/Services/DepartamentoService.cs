using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    public sealed class DepartamentoService : Contracts.IDepartamentoService {
        private readonly IDepartamentoRepository _repository;
        public DepartamentoService(IDepartamentoRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task<List<Departamento>> ObtenerTodosAsync() {
            return _repository.ObtenerTodosAsync();
        }
        public Task<Departamento> ObtenerAsync(short idDepartamento) {
            return _repository.ObtenerAsync(idDepartamento);
        }
        public Task CrearAsync(Departamento departamento) {
            if (departamento == null)
                throw new ArgumentNullException(nameof(departamento));
            return _repository.CrearAsync(departamento);
        }
        public Task ActualizarAsync(Departamento departamento) {
            if (departamento == null)
                throw new ArgumentNullException(nameof(departamento));
            return _repository.ActualizarAsync(departamento);
        }
        public Task EliminarAsync(short idDepartamento) {
            return _repository.EliminarAsync(idDepartamento);
        }
    }
}
