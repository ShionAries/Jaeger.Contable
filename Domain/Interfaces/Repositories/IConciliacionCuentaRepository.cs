using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IConciliacionCuentaRepository {
        Task<List<MovimientoCuenta>> ObtenerMovimientosAsync(string numeroCuenta, short ejercicio, short periodo);
        Task<SaldosCuenta> ObtenerSaldoAsync(string numeroCuenta, short ejercicio, short periodo);
        Task<bool> TieneSaldosDepartamentalesAsync(string numeroCuenta, short ejercicio, short periodo);
    }

    public sealed class SaldosCuenta {
        public double Cargo { get; set; }
        public double Abono { get; set; }
    }
}
