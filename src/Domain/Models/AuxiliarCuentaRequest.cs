namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Parámetros para consultar auxiliares de cuentas de un ejercicio completo.</summary>
    public sealed class AuxiliarCuentaRequest {
        public short Ejercicio { get; set; }
        public string CuentaInicial { get; set; }
        public string CuentaFinal { get; set; }
    }
}
