using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Enums;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IContabilizacionContableRepository {
        Task<ResultadoContabilizacionPeriodo> ContabilizarPolizaAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo);

        Task<ResultadoContabilizacionPeriodo> ContabilizarPeriodoAsync(
            short ejercicio,
            short periodo,
            ContabilizacionModoEnum modo,
            string tipoPoliza);
    }
}
