using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    /// <summary>Define consultas de pólizas y su trazabilidad.</summary>
    public interface IPolizaConsultaRepository {
        Task<PolizaContableConsulta> ObtenerAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo);
        Task<List<PolizaContableResumen>> ObtenerPorCuentaAsync(string numeroCuenta, short ejercicio, short periodo);
        Task<List<PolizaContableResumen>> ObtenerPorPeriodoAsync(short ejercicio, short periodo);
    }
}
