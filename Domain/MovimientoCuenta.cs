namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa un movimiento contable mínimo para cálculos de acumulación.
    /// </summary>
    public sealed class MovimientoCuenta {
        public string NumeroCuenta { get; set; }
        public short Ejercicio { get; set; }
        public short Periodo { get; set; }
        public string DebeHaber { get; set; }
        public double Importe { get; set; }
    }
}
