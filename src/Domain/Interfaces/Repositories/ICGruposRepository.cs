using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface ICGruposRepository {
        Task<List<GrupoContable>> ObtenerTodosAsync();
        Task<GrupoContable> ObtenerAsync(short idGrupo);
        Task CrearAsync(GrupoContable grupo);
        Task ActualizarAsync(GrupoContable grupo);
        Task EliminarAsync(short idGrupo);
    }
}