using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class CuentaMapper {
        public static CuentaContable ToDomain(CuentaContableEntity x) {
            if (x == null)
                return null;
            return new CuentaContable {
                NumCta = x.NumCta,
                Status = x.Status,
                Tipo = x.Tipo,
                Nombre = x.Nombre,
                DeptoSiNo = x.DeptoSiNo,
                BandMulti = x.BandMulti ?? 0,
                BandAjt = x.BandAjt,
                CtaPapa = x.CtaPapa,
                CtaRaiz = x.CtaRaiz,
                Nivel = x.Nivel ?? 0,
                CtaComp = x.CtaComp,
                Naturaleza = x.Naturaleza ?? 0,
                RFC = x.Rfc,
                CodAgrup = x.CodAgrup,
                CapturaCheque = x.CapturaCheque ?? 0,
                CapturaUUID = x.CapturaUuid ?? 0,
                Banco = x.Banco ?? 0,
                CtaBancaria = x.CtaBancaria,
                CapturaChequeTipoMovimiento = x.CapCheqTipoMov,
                NoIncluirXML = x.NoIncluirXml ?? 0,
                IdFiscal = x.IdFiscal,
                EsFlujoEfectivo = x.EsFlujoDeEfectivo ?? 0,
                BancoExtranjero = x.BancoExtranjero,
                RfcFlujo = x.RfcFlujo
            };
        }

        public static CuentaContableEntity ToEntity(CuentaContable x) {
            return new CuentaContableEntity {
                NumCta = x.NumCta,
                Status = x.Status,
                Tipo = x.Tipo,
                Nombre = x.Nombre,
                DeptoSiNo = x.DeptoSiNo,
                BandMulti = x.BandMulti,
                BandAjt = x.BandAjt,
                CtaPapa = x.CtaPapa,
                CtaRaiz = x.CtaRaiz,
                Nivel = x.Nivel,
                CtaComp = x.CtaComp,
                Naturaleza = x.Naturaleza,
                Rfc = x.RFC,
                CodAgrup = x.CodAgrup,
                CapturaCheque = x.CapturaCheque,
                CapturaUuid = x.CapturaUUID,
                Banco = x.Banco,
                CtaBancaria = x.CtaBancaria,
                CapCheqTipoMov = x.CapturaChequeTipoMovimiento,
                NoIncluirXml = x.NoIncluirXML,
                IdFiscal = x.IdFiscal,
                EsFlujoDeEfectivo = x.EsFlujoEfectivo,
                BancoExtranjero = x.BancoExtranjero,
                RfcFlujo = x.RfcFlujo
            };
        }
    }
}
