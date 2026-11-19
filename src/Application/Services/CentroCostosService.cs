using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    public class CentroCostosService : ICentroCostosService {
        private readonly ICentroCostosRepository _repository;

        public CentroCostosService(ICentroCostosRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task ActualizarAsync(CentroCosto centroCosto) {
            return _repository.ActualizarAsync(centroCosto);
        }

        public Task CrearAsync(CentroCosto centroCosto) {
            return _repository.CrearAsync(centroCosto);
        }

        public Task EliminarAsync(short idCentroCosto) {
            return _repository.EliminarAsync(idCentroCosto);
        }

        public Task<CentroCosto> ObtenerAsync(short idCentroCosto) {
            return _repository.ObtenerAsync(idCentroCosto);
        }

        public Task<List<CentroCosto>> ObtenerTodosAsync() {
            return _repository.ObtenerTodosAsync();
        }
    }
}
