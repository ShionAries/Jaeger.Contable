using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado de la consulta de auxiliares para un rango de cuentas.</summary>
    public sealed class AuxiliarCuentaResultado {
        public short Ejercicio { get; set; }
        public string CuentaInicial { get; set; }
        public string CuentaFinal { get; set; }
        public List<AuxiliarCuenta> Cuentas { get; set; }
        public decimal TotalCargos { get; set; }
        public decimal TotalAbonos { get; set; }
    }
}
