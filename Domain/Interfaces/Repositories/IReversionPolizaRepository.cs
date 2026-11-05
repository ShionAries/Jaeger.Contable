using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    /// <summary>Define la persistencia transaccional de una póliza de reversión.</summary>
    public interface IReversionPolizaRepository {
        Task<PolizaContableRequest> ObtenerOriginalAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo);
        Task RegistrarReversionAsync(PolizaContableRequest request);
    }
}
