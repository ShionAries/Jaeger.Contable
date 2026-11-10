using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado de la validación estructural y jerárquica de una cuenta.</summary>
    public sealed class ResultadoValidacionCuenta {
        private readonly List<string> _errores;

        public ResultadoValidacionCuenta() {
            _errores = new List<string>();
        }

        public bool EsValida { get { return _errores.Count == 0; } }
        public IReadOnlyList<string> Errores { get { return _errores.AsReadOnly(); } }

        public void AgregarError(string mensaje) {
            if (!string.IsNullOrWhiteSpace(mensaje))
                _errores.Add(mensaje);
        }
    }
}
