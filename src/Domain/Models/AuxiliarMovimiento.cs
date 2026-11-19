using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Movimiento registrado en AUXILIARxx.</summary>
    public sealed class AuxiliarMovimiento {
        public string NumeroCuenta { get; set; }
        public DateTime? Fecha { get; set; }
        public short Periodo { get; set; }
        public string TipoPoliza { get; set; }
        public string NumeroPoliza { get; set; }
        public double NumeroPartida { get; set; }
        public string Concepto { get; set; }
        public string DebeHaber { get; set; }
        public decimal Importe { get; set; }
        public short? NumeroDepartamento { get; set; }
        public decimal? TipoCambio { get; set; }
        public short? Contrapartida { get; set; }
        public int? Orden { get; set; }
        public int? CentroCostos { get; set; }
        public int? Grupo { get; set; }
        public decimal SaldoAcumulado { get; set; }
    }
}
