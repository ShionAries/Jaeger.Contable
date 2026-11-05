using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IActivoFijoService {
        Task<List<ActivoFijo>> ObtenerTodosAsync();
        Task<ActivoFijo> ObtenerAsync(string clave);
        Task CrearAsync(ActivoFijo activo);
        Task ActualizarAsync(ActivoFijo activo);
        Task EliminarAsync(string clave);
    }
}
