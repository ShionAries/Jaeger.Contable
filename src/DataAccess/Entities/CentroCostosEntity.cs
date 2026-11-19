using SqlSugar;
namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("CCOSTOS")] 
    public sealed class CentroCostosEntity {
        /// <summary>
        /// Número de la clave del centro de costos que se le asignó automáticamente al darlo de alta en el sistema.
        /// </summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true)]
        public int ID { get; set; }

        /// <summary>
        /// Nombre que se le da al centro de costo  en el sistema. 
        /// </summary>
        [SugarColumn(ColumnName = "DESCRIPCION", Length = 40)]
        public string DESCRIPCION { get; set; }
    }
}
