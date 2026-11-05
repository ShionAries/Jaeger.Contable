using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IEstadoContableCuentaRepository {
        Task<EstadoContableCuenta> ObtenerAsync(string numeroCuenta);
        Task<EstadoContableCuenta> ObtenerEstadoAsync(string numeroCuenta);
        Task<EstadoContableCuenta> ObtenerAsync(string numeroCuenta, short ejercicio);
        Task<EstadoContableCuenta> ObtenerEstadoAsync(string numeroCuenta, short ejercicio);
    }
}
