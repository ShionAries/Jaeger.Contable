using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IDepreciacionActivoRepository {
        Task<ResultadoProcesoDepreciacion> EjecutarAsync(short ejercicio, short periodo, IList<DepreciacionMovimiento> movimientos);
    }
}
