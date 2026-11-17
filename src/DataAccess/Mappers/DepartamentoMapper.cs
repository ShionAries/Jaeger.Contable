using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.DataAccess.Mappers {
    internal static class DepartamentoMapper {
        public static Departamento Map(DeptoEntity x) {
            return new Departamento {
                IdDepartamento = x.IdDepto,
                Descripcion = x.Descripcion
            };
        }
        public static DeptoEntity ToEntity(Departamento x) {
            return new DeptoEntity {
                IdDepto = x.IdDepartamento,
                Descripcion = x.Descripcion
            };
        }
    }
}
