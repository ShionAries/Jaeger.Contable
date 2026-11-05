using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface ICuentaService {
        Task<List<CuentaContable>> ObtenerCuentasActivasAsync();
        Task<List<RangoCuentaModel>> Lista1();
        Task<List<RubroContableModel>> ListarEstructuraRangosActivosAsync();
        Task<bool> RegistrarCuentaAsync(CuentaContable cuenta);
        Task<string> GenerarSiguienteNumeroCuentaAsync(string cuentaPadre, short nivel);
        Task<bool> ActualizarCuentaAsync(CuentaContable cuenta);
        Task<bool> DesactivarCuentaAsync(string numeroCuenta);
        Task<bool> ReactivarCuentaAsync(string numeroCuenta);
        Task<ResultadoValidacionCuenta> ValidarCuentaParaMovimientoAsync(string numeroCuenta);
        Task<bool> RegistrarCuentaEnRangoAsync(CuentaContable cuenta, int rango);
        Task<List<RubroContableModel>> ObtenerRangosPorCuentaAsync(string numeroCuenta);
        Task<List<RubroContableModel>> ListarRangosDisponiblesParaCuentaAsync(string numeroCuenta);
        Task<bool> AsociarCuentaRangoAsync(string numeroCuenta, int rango);
        Task<bool> DesasociarCuentaRangoAsync(string numeroCuenta, int rango);
        Task<CuentaContable> ObtenerPorNumeroAsync(string numeroCuenta);
    }
}
