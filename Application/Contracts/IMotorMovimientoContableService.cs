using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Define las reglas de preparación de movimientos contables.
    /// </summary>
    public interface IMotorMovimientoContableService {
        Task<ResultadoValidacionMovimiento> ValidarAsync(MovimientoCuenta movimiento);
        Task<MovimientoCuenta> PrepararAsync(MovimientoCuenta movimiento);
    }
}
