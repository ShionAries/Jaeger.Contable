using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface ITipoActivoService {
        Task<List<TipoActivo>> ObtenerTodosAsync();
        Task<TipoActivo> ObtenerAsync(short clave);
        Task CrearAsync(TipoActivo tipo);
        Task ActualizarAsync(TipoActivo tipo);
        Task EliminarAsync(short clave);
    }
}
