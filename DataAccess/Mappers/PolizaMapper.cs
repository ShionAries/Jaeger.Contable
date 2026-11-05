using System.Collections.Generic;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class PolizaMapper {
        public static PolizaContableConsulta MapearPoliza(
            PolizaEntity x,
            List<MovimientoContableRequest> partidas) {
            return new PolizaContableConsulta {
                TipoPoliza = x.TIPO_POLI,
                NumeroPoliza = x.NUM_POLIZ,
                Ejercicio = (short)x.EJERCICIO,
                Periodo = x.PERIODO,
                Fecha = x.FECHA_POL,
                Concepto = x.CONCEP_PO,
                Contabilizada = x.CONTABILIZ,
                LogAudita = x.LOGAUDITA,
                Origen = x.ORIGEN,
                NumeroPartidas = x.NUM_PART ?? partidas.Count,
                Partidas = partidas
            };
        }

        public static MovimientoContableRequest MapearPartida(Auxiliar25Entity x) {
            return new MovimientoContableRequest {
                TipoPoliza = x.TIPO_POLI,
                NumeroPoliza = x.NUM_POLIZ,
                NumeroPartida = x.NUM_PART,
                Ejercicio = x.EJERCICIO,
                Periodo = x.PERIODO,
                Fecha = x.FECHA_POL,
                Concepto = x.CONCEP_PO,
                NumeroCuenta = x.NUM_CTA,
                DebeHaber = x.DEBE_HABER,
                Importe = x.MONTOMOV.Value,
                NumeroDepartamento = x.NUMDEPTO,
                Contrapartida = x.CONTRAPAR,
                Orden = x.ORDEN,
                CentroCostos = x.CCOSTOS,
                Grupo = x.CGRUPOS,
                TipoCambio = x.TIPCAMBIO
            };
        }
    }
}
