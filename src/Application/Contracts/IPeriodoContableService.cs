using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Valida si un periodo contable permite registrar pólizas y movimientos.
    /// </summary>
    public interface IPeriodoContableService {
        Task ValidarRegistroAsync(short ejercicio, short periodo);
        Task<List<PeriodoContable>> ObtenerTodosAsync(short ejercicio);
        Task<List<short>> ObtenerEjerciciosAsync();
        Task<int> CrearEjercicioAsync(short ejercicio);
        Task ActualizarOrdenAsync(short ejercicio, IList<short> periodosOrdenados);
        Task CerrarAsync(short ejercicio, short periodo);
        Task AbrirAsync(short ejercicio, short periodo);
    }
}
