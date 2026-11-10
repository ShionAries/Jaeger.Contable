using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Define la operación de reversión de pólizas sin eliminar el historial original.
    /// </summary>
    public interface IReversionPolizaService {
        Task<ResultadoReversionPoliza> RevertirAsync(PolizaReversionRequest request);
    }
}
