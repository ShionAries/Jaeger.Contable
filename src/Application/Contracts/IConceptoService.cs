using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IConceptoService {
        Task<List<Concepto>> ObtenerTodosAsync();
        //Task<Concepto> ObtenerAsync(int concepto);
        Task<int> ObtenerSiguienteNumeroAsync();
        Task<Concepto> CrearAsync(string descripcion);
        Task ActualizarAsync(int concepto, string descripcion);
        Task EliminarAsync(int concepto);
    }
}
