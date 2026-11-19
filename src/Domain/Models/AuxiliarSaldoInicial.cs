namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Saldo inicial de una cuenta para el ejercicio consultado.</summary>
    public sealed class AuxiliarSaldoInicial {
        public string NumeroCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
    }
}
