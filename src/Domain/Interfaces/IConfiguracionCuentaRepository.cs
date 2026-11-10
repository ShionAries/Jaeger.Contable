using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces {
    /// <summary>
    /// Obtiene la configuración de estructura contable persistida en PARAMEMP.
    /// </summary>
    public interface IConfiguracionCuentaRepository {
        Task<ConfiguracionNiveles> ObtenerAsync(int idEmpresa);
    }
}
