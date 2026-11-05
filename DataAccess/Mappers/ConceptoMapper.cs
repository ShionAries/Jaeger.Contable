using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class ConceptoMapper {
        public static Concepto Map(ConceptoEntity x) {
            return new Concepto {
                IdConcepto = x.IdConcepto,
                Descripcion = x.Descripcion
            };
        }
    }
}
