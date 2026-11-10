using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Expone operaciones de validación y persistencia de pólizas contables.
    /// </summary>
    public interface IPolizaContableService {
        Task<ResultadoRegistroPoliza> RegistrarAsync(PolizaContableRequest request);
        Task ActualizarAsync(PolizaContableRequest request);
        Task EliminarAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo);
    }
}
