using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class ActivoFijoMapper {
        public static ActivoFijo Map(ActivoFijoEntity x) {
            return new ActivoFijo {
                Clave = x.CLAVE,
                Tipo = x.TIPO,
                Descripcion = x.DESCRIP,
                Localizacion = x.LOCALIZ,
                MontoOriginal = x.MONTORIG,
                MontoOriginalMonedaExtranjera = x.MONTORIGEX,
                FecAdquisicion = x.FECHAADQ,
                MaximoDeducible = x.MAXDED,
                ValorMercado = x.VALMER,
                DepresiacionAcumulada = x.DEPACU,
                VidaUtil = x.VIDAUT,
                MetodoDepresiacion = x.METDEP,
                TasaDepresiacion = x.TASDEP,
                TasaDepresiacionFiscal = x.TASDEPFIS,
                Status = x.STATUS,
                FechaBaja = x.FECHAELIM,
                IdDepartamento = x.NUMDEPTO,
                FECHAULTRE = x.FECHAULTRE,
                NumSerie = x.NUMSERIE,
                BANDEDINM = x.BANDEDINM,
                FecInicioDepresiacion = x.FECINIDEP,
                FecInicioDepresiacionFiscal = x.FECINIDEPF,
                DepresiacionAcumuladaFiscal = x.DEPACUFISC,
                Nota = x.OBSERVACIO,
                TipoCambio = x.TIPOCAMBIO,
                PolizaSeguro = x.POLIZASEG,
                CompaniaSeguro = x.COMPASEGU,
                AgenteSeguro = x.AGENTESEG,
                TelefonoSiniestro = x.TELSINIES,
                TipoCobertura = x.TIPOCOBER,
                MontoAsegurado = x.MONTOASEG,
                PrimaTotal = x.PRIMATOTA,
                Deducible = x.DEDUCIBLE,
                FecVigencia = x.FECVIGENC,
                FecProximoMantto = x.FECPROXMA,
                FecUltMantto = x.FECULTMAN,
                PeriodoMantto = x.PERIODOMA,
                CostoMantto = x.COSTOMANT,
                Responsable = x.RESPACTFIJO
            };
        }

        public static ActivoFijoEntity ToEntity(ActivoFijo x) {
            return new ActivoFijoEntity {
                CLAVE = x.Clave,
                TIPO = x.Tipo,
                DESCRIP = x.Descripcion,
                LOCALIZ = x.Localizacion,
                MONTORIG = x.MontoOriginal,
                MONTORIGEX = x.MontoOriginalMonedaExtranjera,
                FECHAADQ = x.FecAdquisicion,
                MAXDED = x.MaximoDeducible,
                VALMER = x.ValorMercado,
                DEPACU = x.DepresiacionAcumulada,
                VIDAUT = x.VidaUtil,
                METDEP = x.MetodoDepresiacion,
                TASDEP = x.TasaDepresiacion,
                TASDEPFIS = x.TasaDepresiacionFiscal,
                STATUS = x.Status,
                FECHAELIM = x.FechaBaja,
                NUMDEPTO = x.IdDepartamento,
                FECHAULTRE = x.FECHAULTRE,
                NUMSERIE = x.NumSerie,
                BANDEDINM = x.BANDEDINM,
                FECINIDEP = x.FecInicioDepresiacion,
                FECINIDEPF = x.FecInicioDepresiacionFiscal,
                DEPACUFISC = x.DepresiacionAcumuladaFiscal,
                OBSERVACIO = x.Nota,
                TIPOCAMBIO = x.TipoCambio,
                POLIZASEG = x.PolizaSeguro,
                COMPASEGU = x.CompaniaSeguro,
                AGENTESEG = x.AgenteSeguro,
                TELSINIES = x.TelefonoSiniestro,
                TIPOCOBER = x.TipoCobertura,
                MONTOASEG = x.MontoAsegurado,
                PRIMATOTA = x.PrimaTotal,
                DEDUCIBLE = x.Deducible,
                FECVIGENC = x.FecVigencia,
                FECPROXMA = x.FecProximoMantto,
                FECULTMAN = x.FecUltMantto,
                PERIODOMA = x.PeriodoMantto,
                COSTOMANT = x.CostoMantto,
                RESPACTFIJO = x.Responsable
            };
        }
    }
}
