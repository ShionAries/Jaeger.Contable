using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IBalanzaComprobacionRepository {
        Task<List<SaldoCuentaEjercicio>> ObtenerSaldosAsync(short ejercicio);
    }
}
