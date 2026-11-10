using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Domain.Interfaces.Repositories
{
    public interface ICatalogosPartidaRepository
    {
        Task<List<Departamento>> ObtenerDepartamentosAsync();
        Task<List<CentroCosto>> ObtenerCentrosCostosAsync();
        Task<List<GrupoContable>> ObtenerGruposAsync();
        Task<bool> ExisteDepartamentoAsync(short departamento);
        Task<bool> ExisteCentroCostoAsync(int centroCosto);
        Task<bool> ExisteGrupoAsync(int grupo);
        Task CrearDepartamentoAsync(Departamento departamento);
        Task ActualizarDepartamentoAsync(Departamento departamento);
        Task EliminarDepartamentoAsync(short departamento);
        Task CrearCentroCostoAsync(CentroCosto centroCosto);
        Task ActualizarCentroCostoAsync(CentroCosto centroCosto);
        Task EliminarCentroCostoAsync(int centroCosto);
        Task CrearGrupoAsync(GrupoContable grupo);
        Task ActualizarGrupoAsync(GrupoContable grupo);
        Task EliminarGrupoAsync(int grupo);
    }
}
