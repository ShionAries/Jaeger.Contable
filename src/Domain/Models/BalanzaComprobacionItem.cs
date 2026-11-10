namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Renglón de la balanza de comprobación.</summary>
    public sealed class BalanzaComprobacionItem {
        public string NumeroCuenta { get; set; }
        public string NombreCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public short Nivel { get; set; }
        public decimal SaldoInicialDeudor { get; set; }
        public decimal SaldoInicialAcreedor { get; set; }
        public decimal Cargos { get; set; }
        public decimal Abonos { get; set; }
        public decimal SaldoFinalDeudor { get; set; }
        public decimal SaldoFinalAcreedor { get; set; }
        public bool TieneMovimientos { get; set; }
    }
}
