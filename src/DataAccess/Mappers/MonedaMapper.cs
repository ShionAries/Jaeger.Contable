using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class MonedaMapper {
        public static Moneda Map(MonedaEntity x) {
            return new Moneda {
                IdMoneda = x.IdMoneda,
                Nombre = x.Nombre,
                Prefijo = x.Prefijo,
                Fecha = x.Fecha,
                TipoCambio = x.TipoCambio,
                Monto = x.Monto,
                DESPAUTO = x.DESPAUTO,
                CveSAT = x.CveSAT
            };
        }

        public static MonedaEntity ToEntity(Moneda x) {
            return new MonedaEntity {
                IdMoneda = x.IdMoneda,
                Nombre = x.Nombre,
                Prefijo = x.Prefijo,
                Fecha = x.Fecha,
                TipoCambio = x.TipoCambio,
                Monto = x.Monto,
                DESPAUTO = x.DESPAUTO,
                CveSAT = x.CveSAT
            };
        }
    }
}
