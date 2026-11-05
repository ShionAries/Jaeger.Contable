namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa un concepto reutilizable para pólizas contables.
    /// </summary>
    public sealed class Concepto {
        /// <summary>
        /// obtener o establecer indice del concepto 
        /// </summary>
        public int IdConcepto { get; set; }

        /// <summary>
        /// obtener o establecer nombre o descripcion del concepto
        /// </summary>
        public string Descripcion { get; set; }
    }
}
