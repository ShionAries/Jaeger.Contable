using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface ICuentaRepository {
        Task<List<CuentaContable>> ObtenerPorPadreAsync(string ctaPapa);
        Task<CuentaContable> ObtenerPorNumeroAsync(string numeroCuenta);
        Task<List<CuentaContable>> ObtenerTodasAsync();
        Task<List<CuentaContable>> ObtenerActivasAsync();
        Task<List<CuentaContable>> ObtenerHijosAsync(string cuentaPapa);
        Task<List<CuentaContable>> ObtenerRaicesAsync();
        Task<List<RangoConCuentasDto>> ObtenerRangosConCuentasAsync();
        Task<List<RangoCuentaModel>> Lista1();
        Task<List<RubroContableModel>> ObtenerRangosActivosAsync();
        Task<List<RubroContableModel>> ObtenerRangosPorCuentaAsync(string numeroCuenta);
        Task<bool> AsociarCuentaRangoAsync(string numeroCuenta, int rango, string segPapa);
        Task<bool> DesasociarCuentaRangoAsync(string numeroCuenta, int rango);
        Task<bool> ExisteAsync(string numeroCuenta);
        Task<bool> RegistrarNuevaAsync(CuentaContable cuenta, EstructuraCuenta estructura);
        Task<bool> RegistrarNuevaEnRangoAsync(CuentaContable cuenta, EstructuraCuenta estructura, int rango);
        Task<bool> ActualizarAsync(CuentaContable cuenta);
        Task<bool> CambiarStatusAsync(string numeroCuenta, string status);
    }
}
