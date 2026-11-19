using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Auxiliar anual de una cuenta contable.</summary>
    public sealed class AuxiliarCuenta {
        public string NumeroCuenta { get; set; }
        public string NombreCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Cargos { get; set; }
        public decimal Abonos { get; set; }
        public decimal SaldoFinal { get; set; }
        public List<AuxiliarMovimiento> Movimientos { get; set; }
    }
}
