using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    /// <summary>Acceso al estado administrativo de los periodos de ADMPER.</summary>
    public interface IPeriodoContableRepository {
        Task<PeriodoContable> ObtenerAsync(short ejercicio, short periodo);
        Task<List<PeriodoContable>> ObtenerTodosAsync(short ejercicio);
        Task<List<short>> ObtenerEjerciciosAsync();
        Task ActualizarCierreAsync(short ejercicio, short periodo, bool cerrado);
    }
}
