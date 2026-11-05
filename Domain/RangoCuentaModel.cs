namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa un rubro del catálogo RANGOS.
    /// </summary>
    public class RangoCuentaModel : CuentaContable {
        public RangoCuentaModel() : base() { }

        /// <summary>
        /// obtener o establecer rango
        /// </summary>
        public int Rango { get; set; }

        /// <summary>
        /// obtener o establecer descripcion
        /// </summary>
        public string Descripcion { get; set; }
    }
}
