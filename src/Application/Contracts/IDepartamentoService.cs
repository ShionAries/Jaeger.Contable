using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IDepartamentoService {
        Task<List<Departamento>> ObtenerTodosAsync();
        Task<Departamento> ObtenerAsync(short idDepartamento);
        Task CrearAsync(Departamento departamento);
        Task ActualizarAsync(Departamento departamento);
        Task EliminarAsync(short idDepartamento);
    }
}
