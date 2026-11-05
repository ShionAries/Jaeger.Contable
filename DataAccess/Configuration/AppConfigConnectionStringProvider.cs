using System;

namespace Jaeger.Contable.DataAccess.Configuration {
    /// <summary>
    /// Obtiene la cadena de conexión desde una variable de entorno.
    /// Opcionalmente permite un valor de configuración local para desarrollo.
    /// </summary>
    public sealed class AppConfigConnectionStringProvider : IConnectionStringProvider {
        private const string EnvironmentVariableName = "JAEGER_CONTABLE_CONNECTION";

        /// <summary>
        /// Obtiene la cadena de conexión de Jaeger.Contable.
        /// La variable de entorno tiene prioridad y evita almacenar credenciales en el ejecutable.
        /// </summary>
        public string GetConnectionString() {
            var connectionString = Environment.GetEnvironmentVariable(EnvironmentVariableName);

            if (string.IsNullOrWhiteSpace(connectionString)) {
                var settings = Properties.Settings.Default;
                connectionString = settings == null ? null : settings.ConnectionString;
            }

            if (string.IsNullOrWhiteSpace(connectionString)) {
                throw new InvalidOperationException(
                    "No se configuró la cadena de conexión de Jaeger.Contable. " +
                    "Defina la variable de entorno '" + EnvironmentVariableName + "'.");
            }

            return connectionString.Trim();
        }
    }
}
