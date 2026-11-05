using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class TipoActivoMapper {
        public static TipoActivo Map(TipActivoEntity x) {
            return new TipoActivo {
                Clave = x.CLAVE,
                Descripcion = x.DESCRIP,
                DepresiacionNormal = x.DEDNORMAL,
                DepresiacionInmediata = x.DEDIMED,
                MaximoDepresiacion = x.MAXDED,
                MetodoDepresiacion = x.METODODEP,
                DepresiacionProyectada = x.DEPPROY,
                CuentaActivo = x.CTAAACTV,
                CuentaDepresiacion = x.CTADEPRE,
                CuentaGastos = x.CTAGASTOS,
                CuentaGanancias = x.CTAPERGAN,
                Moneda = x.QUEMONEDA
            };
        }

        public static TipActivoEntity ToEntity(TipoActivo x) {
            return new TipActivoEntity {
                CLAVE = x.Clave,
                DESCRIP = x.Descripcion,
                DEDNORMAL = x.DepresiacionNormal,
                DEDIMED = x.DepresiacionInmediata,
                MAXDED = x.MaximoDepresiacion,
                METODODEP = x.MetodoDepresiacion,
                DEPPROY = x.DepresiacionProyectada,
                CTAAACTV = x.CuentaActivo,
                CTADEPRE = x.CuentaDepresiacion,
                CTAGASTOS = x.CuentaGastos,
                CTAPERGAN = x.CuentaGanancias,
                QUEMONEDA = x.Moneda
            };
        }
    }
}
