namespace Jaeger.Contable.DataAccess.Configuration {
    /// <summary>
    /// Proporciona la cadena de conexión utilizada por Jaeger.Contable.
    /// </summary>
    public interface IConnectionStringProvider {
        /// <summary>
        /// Obtiene la cadena de conexión de Jaeger.Contable.
        /// </summary>
        string GetConnectionString();
    }
}
