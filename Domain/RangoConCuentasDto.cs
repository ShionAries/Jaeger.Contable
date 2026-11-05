using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// DTO de presentación para la relación rubro-cuentas.
    /// </summary>
    public class RangoConCuentasDto {
        public int Rango { get; set; }
        public string Descripcion { get; set; }
        public List<CuentaContable> CuentasAsociadas { get; set; }

        public RangoConCuentasDto() {
            CuentasAsociadas = new List<CuentaContable>();
        }
    }
}
