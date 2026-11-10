using System;

namespace Jaeger.Contable.Domain.Entities {
    public sealed class DepreciacionMovimiento {
        public string ClaveActivo { get; set; }
        public double NuevaDepreciacionAcumulada { get; set; }
        public string CuentaGasto { get; set; }
        public string CuentaDepreciacion { get; set; }
        public short? NumeroDepartamento { get; set; }
        public double Importe { get; set; }
        public string Concepto { get; set; }
    }
}
