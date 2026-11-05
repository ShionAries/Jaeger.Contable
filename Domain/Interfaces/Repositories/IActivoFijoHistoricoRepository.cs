using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IActivoFijoHistoricoRepository {
        Task<List<ActivoFijo>> ObtenerEjercicio24Async();
        Task<List<ActivoFijo>> ObtenerEjercicio25Async();
    }
}
