using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    public sealed class ActivoFijoHistoricoService : Contracts.IActivoFijoHistoricoService {
        private readonly IActivoFijoHistoricoRepository _repository;

        public ActivoFijoHistoricoService(IActivoFijoHistoricoRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<ActivoFijo>> ObtenerAsync(short ejercicioTabla) {
            switch (ejercicioTabla) {
                case 24: return _repository.ObtenerEjercicio24Async();
                case 25: return _repository.ObtenerEjercicio25Async();
                default: throw new ArgumentOutOfRangeException(nameof(ejercicioTabla), "Solo están disponibles las tablas ACTIVOS24 y ACTIVOS25.");
            }
        }
    }
}
