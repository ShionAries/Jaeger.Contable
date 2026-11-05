using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface ICuentaRubroRepository {
        Task<List<CuentaRubro>> ObtenerTodasAsync();
    }
}
