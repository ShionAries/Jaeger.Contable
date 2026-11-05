using System.Threading.Tasks;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    /// <summary>
    /// Consulta la existencia de movimientos contables asociados a una cuenta.
    /// </summary>
    public interface IHistorialCuentaRepository {
        Task<bool> TieneMovimientosAsync(string numeroCuenta);
    }
}
