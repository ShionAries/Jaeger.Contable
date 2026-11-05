using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IConceptoRepository {
        Task<List<Concepto>> ObtenerTodosAsync();
        Task<Concepto> ObtenerAsync(int concepto);
        Task<int> ObtenerSiguienteNumeroAsync();
        Task CrearAsync(Concepto concepto);
        Task ActualizarAsync(Concepto concepto);
        Task EliminarAsync(int concepto);
    }
}
