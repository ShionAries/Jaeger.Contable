using SqlSugar;
namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("CGRUPOS")] 
    public sealed class CGruposEntity {
        /// <summary>
        /// Número de la clave del proyecto que se le asignó automáticamente al darlo de alta en el sistema. 
        /// </summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true)]
        public int ID { get; set; }

        /// <summary>
        /// Nombre que se le da a los proyectos  en el sistema
        /// </summary>
        [SugarColumn(ColumnName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }
}
