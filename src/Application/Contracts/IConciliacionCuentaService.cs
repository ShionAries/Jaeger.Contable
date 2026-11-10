using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IConciliacionCuentaService {
        Task<ConciliacionCuenta> ConciliarAsync(string numeroCuenta, short ejercicio, short periodo);
    }
}
