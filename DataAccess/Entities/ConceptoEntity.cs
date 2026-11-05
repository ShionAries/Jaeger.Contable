using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de la tabla CONCEPTO.
    /// </summary>
    [SugarTable("CONCEPTO")]
    public sealed class ConceptoEntity {
        /// <summary>
        /// obtener o establecer indice del concepto 
        /// </summary>
        [SugarColumn(ColumnName = "CONCEPTO", IsPrimaryKey = true)]
        public int IdConcepto { get; set; }

        /// <summary>
        /// obtener o establecer nombre o descripcion del concepto
        /// </summary>
        [SugarColumn(ColumnName = "DESCRIP", Length = 120)]
        public string Descripcion { get; set; }
    }
}
