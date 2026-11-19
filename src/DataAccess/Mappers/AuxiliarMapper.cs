using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class AuxiliarMapper {
        public static AuxiliarMovimiento Map(Auxiliar25Entity x) {
            return new AuxiliarMovimiento {
                TipoPoliza = x.TIPO_POLI,
                NumeroPoliza = x.NUM_POLIZ,
                NumeroPartida = (int)x.NUM_PART,
                Periodo = x.PERIODO,
                //Ejercicio = x.EJERCICIO,
                NumeroCuenta = x.NUM_CTA?.Trim() ?? string.Empty,
                //SubCuenta = x.NUM_SUBCTA?.Trim() ?? string.Empty,
                Fecha = x.FECHA_POL,
                Concepto = x.CONCEP_PO?.Trim() ?? string.Empty,
                DebeHaber = x.DEBE_HABER?.Trim() ?? string.Empty,
                //MontoMovimiento = (decimal?)x.MONTOMOV ?? 0m,
                //SaldoCuenta = (decimal?)x.SALDOCTA ?? 0m,
                TipoCambio = (decimal?)x.TIPCAMBIO ?? 0m,
                Contrapartida = (short?)x.CONTRAPAR ?? 0,
                Orden = (int?)x.ORDEN ?? 0,
                CentroCostos = (int?)x.CCOSTOS ?? 0,
                //CentroGrupos = (int?)x.CGRUPOS ?? 0
            };
        }
        public static Auxiliar25Entity Map(AuxiliarMovimiento x) {
            return new Auxiliar25Entity {
                TIPO_POLI = x.TipoPoliza,
                NUM_POLIZ = x.NumeroPoliza,
                NUM_PART = x.NumeroPartida,
                PERIODO = x.Periodo,
                //EJERCICIO = x.Ejercicio,
                NUM_CTA = x.NumeroCuenta?.Trim() ?? string.Empty,
                //NUM_SUBCTA = x.SubCuenta?.Trim() ?? string.Empty,
                FECHA_POL = x.Fecha,
                CONCEP_PO = x.Concepto?.Trim() ?? string.Empty,
                DEBE_HABER = x.DebeHaber?.Trim() ?? string.Empty,
                //MONTOMOV = (double?)x.MontoMovimiento ?? 0d,
                //SALDOCTA = (short?)x.SaldoCuenta ?? 0,
                TIPCAMBIO = (double?)x.TipoCambio ?? 0d,
                CONTRAPAR = (short?)x.Contrapartida ?? 0,
                ORDEN = (int?)x.Orden ?? 0,
                CCOSTOS = (int?)x.CentroCostos ?? 0
                //CGRUPOS = (int?)x.CentroGrupos ?? 0
            };
        }
    }
}
