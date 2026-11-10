using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IAcumulacionCuentaService {
        Task<AcumuladoCuenta> CalcularAsync(string numeroCuenta, short ejercicio, short? periodo);
    }
}
