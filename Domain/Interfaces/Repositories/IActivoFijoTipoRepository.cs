using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IActivoFijoTipoRepository {
        Task<List<ActivoFijoTipo>> ObtenerTodosAsync();
        Task<ActivoFijoTipo> ObtenerAsync(short clave);
        Task CrearAsync(ActivoFijoTipo tipo);
        Task ActualizarAsync(ActivoFijoTipo tipo);
        Task EliminarAsync(short clave);
        Task<bool> ExisteCuentaAsync(string numeroCuenta);
        Task<bool> ExisteMonedaAsync(short moneda);
        Task<bool> EstaEnUsoAsync(short clave);
    }
}
