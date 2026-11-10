using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IActivoFijoTipoService {
        Task<List<ActivoFijoTipo>> ObtenerTodosAsync();
        Task<ActivoFijoTipo> ObtenerAsync(short clave);
        Task CrearAsync(ActivoFijoTipo tipo);
        Task ActualizarAsync(ActivoFijoTipo tipo);
        Task EliminarAsync(short clave);
    }
}
