using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    /// <summary>Proporciona acceso transaccional a la numeración de FOLIOS.</summary>
    public interface IFolioContableRepository {
        Task<FolioContable> ObtenerSiguienteAsync(string tipoPoliza, short ejercicio, short periodo);
    }
}
