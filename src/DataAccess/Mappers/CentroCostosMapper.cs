using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class CentroCostosMapper {
        public static CentroCosto Map(CentroCostosEntity x) {
            return new CentroCosto {
                Id = x.ID,
                Descripcion = x.DESCRIPCION
            };
        }
        public static CentroCostosEntity Map(CentroCosto x) {
            return new CentroCostosEntity {
                ID = x.Id,
                DESCRIPCION = x.Descripcion
            };
        }
    }
}
