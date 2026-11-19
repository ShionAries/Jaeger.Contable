using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IAuxiliarCuentaRepository {
        Task<List<AuxiliarMovimiento>> ObtenerMovimientosAsync(short ejercicio, string cuentaInicial, string cuentaFinal);
        Task<List<AuxiliarSaldoInicial>> ObtenerSaldosInicialesAsync(short ejercicio, string cuentaInicial, string cuentaFinal);
    }
}
