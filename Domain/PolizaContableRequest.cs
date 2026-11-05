using System;
using System.Collections.Generic;
namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa una póliza completa y sus partidas.
    /// </summary>
    public sealed class PolizaContableRequest {
        public string TipoPoliza { get; set; }
        public string NumeroPoliza { get; set; }
        public short Ejercicio { get; set; }
        public short Periodo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Concepto { get; set; }
        public IList<MovimientoContableRequest> Partidas { get; set; }
    }
}
