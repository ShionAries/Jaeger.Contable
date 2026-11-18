using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class PeriodoContableMapper {
        public static PeriodoContable Map(PeriodoContableEntity x) {
            return new PeriodoContable(x.PERIODO, x.EJERCICIO, x.CERRADO ?? 0, x.ORDENADO ?? 0, x.REQTRASP ?? 0, x.CTPOLIZAS ?? 0);
        }

        public static PeriodoContableEntity Map(PeriodoContable x) {
            return new PeriodoContableEntity {
                PERIODO = x.Periodo,
                EJERCICIO = x.Ejercicio,
                CERRADO = x.Cerrado,
                ORDENADO = x.Ordenado,
                REQTRASP = x.ReqTrasp,
                CTPOLIZAS = x.CtPolizas
            };
        }
    }
}
