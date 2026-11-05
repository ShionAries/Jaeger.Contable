using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa una coincidencia de póliza para consultas de historial.
    /// </summary>
    public sealed class PolizaContableResumen {
        public string TipoPoliza { get; set; }
        public string NumeroPoliza { get; set; }
        public short Ejercicio { get; set; }
        public short Periodo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Concepto { get; set; }
        public string Contabilizada { get; set; }
        public string LogAudita { get; set; }
        public string Origen { get; set; }
        public int NumeroPartidas { get; set; }
    }
}
