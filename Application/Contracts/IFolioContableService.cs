using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Define la generación segura de folios de pólizas.
    /// </summary>
    public interface IFolioContableService {
        Task<FolioContable> ObtenerSiguienteAsync(string tipoPoliza, short ejercicio, short periodo);
    }
}
