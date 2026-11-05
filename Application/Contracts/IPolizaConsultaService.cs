using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    /// <summary>
    /// Expone consultas de solo lectura para pólizas contables.
    /// </summary>
    public interface IPolizaConsultaService {
        Task<PolizaContableConsulta> ObtenerAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo);
        Task<List<PolizaContableResumen>> ObtenerPorCuentaAsync(string numeroCuenta, short ejercicio, short periodo);
        Task<List<PolizaContableResumen>> ObtenerPorPeriodoAsync(short ejercicio, short periodo);
    }
}
