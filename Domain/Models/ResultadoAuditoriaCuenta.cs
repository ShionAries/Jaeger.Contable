using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado individual de la auditoría de una cuenta.</summary>
    public sealed class ResultadoAuditoriaCuenta {
        private readonly List<string> _errores;

        public ResultadoAuditoriaCuenta(string numeroCuenta) {
            NumeroCuenta = numeroCuenta;
            _errores = new List<string>();
        }

        public string NumeroCuenta { get; private set; }
        public bool EsValida { get { return _errores.Count == 0; } }
        public IReadOnlyList<string> Errores { get { return _errores.AsReadOnly(); } }

        public void AgregarError(string mensaje) {
            if (!string.IsNullOrWhiteSpace(mensaje))
                _errores.Add(mensaje);
        }
    }
}
