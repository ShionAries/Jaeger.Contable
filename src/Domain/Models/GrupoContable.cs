namespace Jaeger.Contable.Domain.Entities {
    public sealed class GrupoContable {
        /// <summary>
        /// Número de la clave del proyecto que se le asignó automáticamente al darlo de alta en el sistema
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre que se le da a los proyectos  en el sistema
        /// </summary>
        public string Descripcion { get; set; }
    }
}
