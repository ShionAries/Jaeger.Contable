using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    public sealed class ResultadoValidacionDepreciacion {
        public string ClaveActivo { get; private set; }
        public bool EsValido { get; private set; }
        public IList<string> Observaciones { get; private set; }

        public ResultadoValidacionDepreciacion(string claveActivo, bool esValido, IList<string> observaciones) {
            ClaveActivo = claveActivo;
            EsValido = esValido;
            Observaciones = observaciones ?? new List<string>();
        }
    }
}
