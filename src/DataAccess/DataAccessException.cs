using System;

namespace Jaeger.Contable.DataAccess {
    /// <summary>
    /// Representa un error producido durante una operación de persistencia.
    /// </summary>
    public sealed class DataAccessException : Exception {
        /// <summary>
        /// Inicializa una nueva excepción de acceso a datos.
        /// </summary>
        public DataAccessException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }
}
