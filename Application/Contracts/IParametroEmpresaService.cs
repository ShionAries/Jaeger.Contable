using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Obtiene la configuración operativa de PARAMEMP requerida por la aplicación.
    /// </summary>
    public interface IParametroEmpresaService {
        Task<ParametroEmpresa> ObtenerAsync(int idEmpresa);
    }
}
