using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    /// <summary>Define la persistencia transaccional de una póliza y sus partidas.</summary>
    public interface IPolizaContableRepository {
        Task RegistrarAsync(PolizaContableRequest request);
        Task ActualizarAsync(PolizaContableRequest request);
        Task EliminarAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo);
    }
}
