namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Resultado de acumulación de movimientos de una cuenta y sus descendientes.
    /// </summary>
    public sealed class AcumuladoCuenta {
        public string NumeroCuenta { get; set; }
        public short Ejercicio { get; set; }
        public short? Periodo { get; set; }
        public double Cargo { get; set; }
        public double Abono { get; set; }
        public double Neto { get { return Cargo - Abono; } }
        public int CuentasConsideradas { get; set; }
        public int MovimientosConsiderados { get; set; }
    }
}
