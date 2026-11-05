using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado de la validación de un movimiento contable antes de persistirlo.</summary>
    public sealed class ResultadoValidacionMovimiento {
        private readonly List<string> _errores = new List<string>();

        public bool EsValido { get { return _errores.Count == 0; } }
        public IReadOnlyList<string> Errores { get { return _errores.AsReadOnly(); } }

        public void AgregarError(string mensaje) {
            if (!string.IsNullOrWhiteSpace(mensaje))
                _errores.Add(mensaje);
        }
    }
}
