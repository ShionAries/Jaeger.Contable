using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    public class CGruposService : ICGruposService {
        private readonly ICGruposRepository _repository;
        public CGruposService(ICGruposRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task ActualizarAsync(GrupoContable grupo) {
            return _repository.ActualizarAsync(grupo);
        }
        public Task CrearAsync(GrupoContable grupo) {
            return _repository.CrearAsync(grupo);
        }
        public Task EliminarAsync(short idGrupo) {
            return _repository.EliminarAsync(idGrupo);
        }
        public Task<GrupoContable> ObtenerAsync(short idGrupo) {
            return _repository.ObtenerAsync(idGrupo);
        }
        public Task<List<GrupoContable>> ObtenerTodosAsync() {
            return _repository.ObtenerTodosAsync();
        }
    }
}
