using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IParametroEmpresaRepository {
        Task<ParametroEmpresa> ObtenerAsync(int idEmpresa);
        Task ActualizarEstructuraCuentaAsync(ParametroEmpresa parametro);
    }
}
