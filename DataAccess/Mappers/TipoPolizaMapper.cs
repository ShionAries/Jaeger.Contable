using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class TipoPolizaMapper {
        public static TipoPoliza Map(TiposPolizaEntity x) {
            return new TipoPoliza {
                Tipo = x.Tipo,
                Descripcion = x.Descripcion,
                ClaveSAT = x.ClaveSAT
            };
        }
    }
}
