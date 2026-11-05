using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IAcumulacionCuentaRepository {
        Task<List<MovimientoCuenta>> ObtenerMovimientosAsync(
            IEnumerable<string> numerosCuenta,
            short ejercicio,
            short? periodo);
    }
}
