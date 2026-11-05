using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IActivoFijoHistoricoService {
        Task<List<ActivoFijo>> ObtenerAsync(short ejercicioTabla);
    }
}
