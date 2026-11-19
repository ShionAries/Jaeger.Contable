using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface ICGruposService {
        Task<List<GrupoContable>> ObtenerTodosAsync();
        Task<GrupoContable> ObtenerAsync(short idGrupo);
        Task CrearAsync(GrupoContable grupo);
        Task ActualizarAsync(GrupoContable grupo);
        Task EliminarAsync(short idGrupo);
    }
}
