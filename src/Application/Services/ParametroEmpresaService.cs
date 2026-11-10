using System;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Servicio de acceso a parámetros generales de empresa.
    /// </summary>
    public sealed class ParametroEmpresaService : Contracts.IParametroEmpresaService {
        private readonly IParametroEmpresaRepository _repository;
        public ParametroEmpresaService(IParametroEmpresaRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task<ParametroEmpresa> ObtenerAsync(int idEmpresa) {
            if (idEmpresa <= 0)
                throw new ArgumentOutOfRangeException(nameof(idEmpresa));
            return _repository.ObtenerAsync(idEmpresa);
        }
    }
}
