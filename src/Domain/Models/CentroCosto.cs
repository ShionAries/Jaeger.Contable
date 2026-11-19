namespace Jaeger.Contable.Domain.Entities {
    public sealed class CentroCosto {
        /// <summary>
        /// Número de la clave del centro de costos que se le asignó automáticamente al darlo de alta en el sistema.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre que se le da al centro de costo  en el sistema. 
        /// </summary>
        public string Descripcion { get; set; }
    }
}
