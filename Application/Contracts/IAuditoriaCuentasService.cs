using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IAuditoriaCuentasService {
        Task<ResultadoAuditoriaCuentas> AuditarAsync();
    }
}
