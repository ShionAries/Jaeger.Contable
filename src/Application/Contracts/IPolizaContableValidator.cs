using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Contracts {
    public interface IPolizaContableValidator {
        void ValidarCabecera(PolizaContableRequest request);
        void ValidarPartida(MovimientoContableRequest partida, int numeroPartida);
        void ValidarBalance(double totalDebe, double totalHaber);
    }
}
