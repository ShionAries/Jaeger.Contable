using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// interface de servicio para el catalogo de monedas
    /// </summary>
    public interface IMonedaService {
        Task<List<Moneda>> ObtenerTodosAsync();
        Task<double?> ObtenerTipoCambioAsync(short moneda);
        Task CrearAsync(Moneda moneda);
        Task ActualizarAsync(Moneda moneda);
        Task EliminarAsync(short moneda);
    }
}
