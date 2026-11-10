namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Resume si una cuenta tiene movimientos o saldos persistidos.
    /// </summary>
    public sealed class EstadoContableCuenta {
        public string NumeroCuenta { get; set; }
        public bool TieneMovimientos { get; set; }
        public bool TieneSaldos { get; set; }
        public bool TieneSaldosDepartamentales { get; set; }

        public bool TieneActividadContable {
            get { return TieneMovimientos || TieneSaldos || TieneSaldosDepartamentales; }
        }
    }
}
