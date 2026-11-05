using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IValidadorJerarquiaCuenta {
        //Task<ResultadoValidacionCuenta> ValidarAsync(CuentaContable cuenta);
        Task<ResultadoAuditoriaCuentas> ValidarTodasAsync(IReadOnlyList<CuentaContable> cuentas);
    }
}
