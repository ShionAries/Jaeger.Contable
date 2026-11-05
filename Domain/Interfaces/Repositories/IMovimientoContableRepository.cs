using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    /// <summary>Define la persistencia transaccional de pólizas, partidas y saldos.</summary>
    public interface IMovimientoContableRepository {
        Task RegistrarAsync(MovimientoContableRequest request);
    }
}
