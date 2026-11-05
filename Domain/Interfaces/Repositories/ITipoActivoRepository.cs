using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface ITipoActivoRepository {
        Task<List<TipoActivo>> ObtenerTodosAsync();
        Task<TipoActivo> ObtenerAsync(short clave);
        Task CrearAsync(TipoActivo tipo);
        Task ActualizarAsync(TipoActivo tipo);
        Task EliminarAsync(short clave);
        Task<bool> ExisteCuentaAsync(string numeroCuenta);
        Task<bool> ExisteMonedaAsync(short moneda);
        Task<bool> EstaEnUsoAsync(short clave);
    }
}
