using System;
using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa una póliza consultada junto con sus partidas.
    /// </summary>
    public sealed class PolizaContableConsulta {
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
        public IList<MovimientoContableRequest> Partidas { get; set; }
    }
}
