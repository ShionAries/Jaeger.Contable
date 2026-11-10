using System;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Servicio de aplicación para la configuración de cuentas.
    /// </summary>
    public sealed class ConfiguracionCuentaService : Contracts.IConfiguracionCuentaService {
        private readonly IConfiguracionCuentaRepository _repository;

        public ConfiguracionCuentaService(IConfiguracionCuentaRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<ConfiguracionNiveles> ObtenerAsync(int idEmpresa) {
            if (idEmpresa <= 0)
                throw new ArgumentOutOfRangeException(nameof(idEmpresa));
            return _repository.ObtenerAsync(idEmpresa);
        }
    }
}
