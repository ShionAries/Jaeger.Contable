using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IDepreciacionActivoService {
        Task<List<ResultadoValidacionDepreciacion>> ValidarTodosAsync(short ejercicio);
        Task<ResultadoValidacionDepreciacion> ValidarAsync(short ejercicio, string clave);
        Task<ResultadoProcesoDepreciacion> EjecutarAsync(short ejercicio, short periodo);
    }
}
