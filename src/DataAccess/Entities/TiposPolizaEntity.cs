using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de la tabla TIPOSPOL.
    /// </summary>
    [SugarTable("TIPOSPOL")]
    public sealed class TiposPolizaEntity {
        /// <summary>
        /// obtener o establecer indice
        /// </summary>
        [SugarColumn(ColumnName = "Tipo", IsPrimaryKey = true, IsNullable = false, Length = 2)]
        public string Tipo { get; set; }

        /// <summary>
        /// obtener o establecer descripcion
        /// </summary>
        [SugarColumn(ColumnName = "DESCRIP", IsNullable = true, Length = 15)]
        public string Descripcion { get; set; }
        
        /// <summary>
        /// obtener o establecer clave SAT
        /// </summary>
        [SugarColumn(ColumnName = "Classat", IsNullable = true)]
        public int? ClaveSAT { get; set; }
    }
}
