using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class ActivoFijoTipoMapper {
        public static ActivoFijoTipo Map(ActivoFijoTipoEntity x) {
            return new ActivoFijoTipo {
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

        public static ActivoFijoTipoEntity ToEntity(ActivoFijoTipo x) {
            return new ActivoFijoTipoEntity {
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
