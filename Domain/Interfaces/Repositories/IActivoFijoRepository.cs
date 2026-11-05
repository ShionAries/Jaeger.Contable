using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IActivoFijoRepository {
        Task<List<ActivoFijo>> ObtenerTodosAsync();
        Task<List<ActivoFijo>> ObtenerTodosAsync(short ejercicio);
        Task<ActivoFijo> ObtenerAsync(string clave);
        Task<ActivoFijo> ObtenerAsync(short ejercicio, string clave);
        Task CrearAsync(ActivoFijo activo);
        Task ActualizarAsync(ActivoFijo activo);
        Task EliminarAsync(string clave);
        Task<bool> ExisteTipoAsync(short tipo);
        Task ActualizarDepreciacionAsync(short ejercicio, string clave, double depacu);
    }
}
