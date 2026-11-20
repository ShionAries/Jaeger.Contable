using System.Threading.Tasks;

namespace Jaeger.Contable.Application.Contracts {
    public interface IMotorContableService {
        Task InicializarAsync(int idEmpresa);
        string ObtenerMascara();
        string AplicarMascara(string entradaSinFormato);
        Task<string> GenerarSiguienteCuentaDinamicaAsync(string ctaPapa, short nivel);
    }
}
