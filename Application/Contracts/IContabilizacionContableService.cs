using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Enums;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Expone la contabilización de pólizas de un periodo según el criterio seleccionado.
    /// </summary>
    public interface IContabilizacionContableService {
        Task<ResultadoContabilizacionPeriodo> ContabilizarPolizaAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo);

        Task<ResultadoContabilizacionPeriodo> ContabilizarPeriodoAsync(
            short ejercicio,
            short periodo,
            ContabilizacionModoEnum modo,
            string tipoPoliza);
    }
}
