using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa la solicitud para generar una póliza de reversión.
    /// </summary>
    public sealed class PolizaReversionRequest {
        public string TipoPolizaOriginal { get; set; }
        public string NumeroPolizaOriginal { get; set; }
        public short Ejercicio { get; set; }
        public short Periodo { get; set; }
        public string TipoPolizaNueva { get; set; }
        public string NumeroPolizaNueva { get; set; }
        public DateTime? Fecha { get; set; }
        public string Motivo { get; set; }
    }
}
