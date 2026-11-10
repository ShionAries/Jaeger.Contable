using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    /// <summary>
    /// repositorio de tipos de poliza
    /// </summary>
    public interface ITipoPolizaRepository {
        Task<List<TipoPoliza>> ObtenerTodosAsync();
        Task<TipoPoliza> ObtenerAsync(string tipo);
        Task<bool> ExisteEnPolizasAsync(string tipo);
        Task CrearAsync(TipoPoliza tipo);
        Task ActualizarAsync(TipoPoliza tipo);
        Task EliminarAsync(string tipo);
    }
}
