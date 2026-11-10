using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface ICatalogosPartidaService {
        Task<List<Departamento>> ObtenerDepartamentosAsync();
        Task<List<CentroCosto>> ObtenerCentrosCostosAsync();
        Task<List<GrupoContable>> ObtenerGruposAsync();
        Task<bool> ExisteDepartamentoAsync(short departamento);
        Task<bool> ExisteCentroCostoAsync(int centroCosto);
        Task<bool> ExisteGrupoAsync(int grupo);
        Task CrearDepartamentoAsync(short departamento, string descripcion);
        Task ActualizarDepartamentoAsync(short departamento, string descripcion);
        Task EliminarDepartamentoAsync(short departamento);
        Task CrearCentroCostoAsync(int id, string descripcion);
        Task ActualizarCentroCostoAsync(int id, string descripcion);
        Task EliminarCentroCostoAsync(int id);
        Task CrearGrupoAsync(int id, string descripcion);
        Task ActualizarGrupoAsync(int id, string descripcion);
        Task EliminarGrupoAsync(int id);
    }
}
