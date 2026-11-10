namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Saldo anual de una cuenta contable con movimientos por período.</summary>
    public sealed class SaldoCuentaEjercicio {
        public string NumeroCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal[] Cargos { get; set; }
        public decimal[] Abonos { get; set; }
    }
}
