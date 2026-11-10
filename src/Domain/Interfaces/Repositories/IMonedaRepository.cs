using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IMonedaRepository {
        Task<List<Moneda>> ObtenerTodosAsync();
        Task<Moneda> ObtenerAsync(short moneda);
        Task CrearAsync(Moneda moneda);
        Task ActualizarAsync(Moneda moneda);
        Task<bool> ExisteEnHistorialAsync(short moneda);
        Task<bool> ExisteEnTiposActivoAsync(short moneda);
        Task EliminarAsync(short moneda);
    }
}