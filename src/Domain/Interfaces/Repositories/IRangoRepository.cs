using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories
{
    public interface IRangoRepository
    {
        Task<List<RubroContableModel>> ObtenerTodosAsync();
        Task<RubroContableModel> ObtenerPorIdAsync(int idRango);
        Task<bool> ExisteEnCtarubAsync(int idRango);
        Task<bool> InsertarAsync(RubroContableModel rango);
        Task<bool> ActualizarAsync(RubroContableModel rango);
        Task<bool> EliminarAsync(int idRango);
    }
}
