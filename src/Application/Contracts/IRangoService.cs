using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IRangoService {
        Task<List<RubroContableModel>> ListarRangosAsync();
      //  Task<RubroContableModel> ObtenerAsync(int idRango);
        Task CrearAsync(int idRango, string descripcion);
        Task ActualizarAsync(int idRango, string descripcion);
        Task EliminarAsync(int idRango);
        Task RegistrarRangoAsync(int idRango, string descripcion);
    }
}
