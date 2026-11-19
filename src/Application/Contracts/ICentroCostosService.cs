using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface ICentroCostosService {
        Task<List<CentroCosto>> ObtenerTodosAsync();
        Task<CentroCosto> ObtenerAsync(short idCentroCosto);
        Task CrearAsync(CentroCosto centroCosto);
        Task ActualizarAsync(CentroCosto centroCosto);
        Task EliminarAsync(short idCentroCosto);
    }
}
