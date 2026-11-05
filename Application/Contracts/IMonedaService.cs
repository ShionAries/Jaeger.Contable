using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IMonedaService {
        Task<List<Moneda>> ObtenerTodosAsync();
        //Task<Moneda> ObtenerAsync(short moneda);
        Task<double?> ObtenerTipoCambioAsync(short moneda);
        Task CrearAsync(Moneda moneda);
        Task ActualizarAsync(Moneda moneda);
        Task EliminarAsync(short moneda);
    }
}
