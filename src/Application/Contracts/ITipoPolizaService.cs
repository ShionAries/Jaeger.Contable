using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface ITipoPolizaService {
        Task<List<TipoPoliza>> ObtenerTodosAsync();
        Task<TipoPoliza> ObtenerAsync(string tipo);
        //Task<bool> ExisteAsync(string tipo);
        Task CrearAsync(string tipo, string descripcion, int? classAt);
        Task ActualizarAsync(string tipo, string descripcion, int? classAt);
        Task EliminarAsync(string tipo);
    }
}
