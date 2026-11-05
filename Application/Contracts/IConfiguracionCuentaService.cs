using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Contrato para consultar la configuración de niveles contables.
    /// </summary>
    public interface IConfiguracionCuentaService {
        Task<ConfiguracionNiveles> ObtenerAsync(int idEmpresa);
    }
}
