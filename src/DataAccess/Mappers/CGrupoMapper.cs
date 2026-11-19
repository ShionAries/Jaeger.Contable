using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class CGrupoMapper {
        public static GrupoContable Map(CGruposEntity x) {
            return new GrupoContable {
                Id = x.ID,
                Descripcion = x.DESCRIPCION
            };
        }
        public static CGruposEntity Map(GrupoContable x) {
            return new CGruposEntity {
                ID = x.Id,
                DESCRIPCION = x.Descripcion
            };
        }
    }
}
