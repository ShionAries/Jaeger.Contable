using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de la tabla ADMPER.
    /// </summary>
    [SugarTable("ADMPER")]
    public sealed class PeriodoContableEntity {
        [SugarColumn(ColumnName = "PERIODO", IsPrimaryKey = true)] 
        public short PERIODO { get; set; }

        [SugarColumn(ColumnName = "EJERCICIO", IsPrimaryKey = true)] 
        public short EJERCICIO { get; set; }

        [SugarColumn(ColumnName = "CERRADO", IsNullable = true)]
        public short? CERRADO { get; set; }

        [SugarColumn(ColumnName = "ORDENADO", IsNullable = true)]
        public int? ORDENADO { get; set; }

        [SugarColumn(ColumnName = "REQTRASP", IsNullable = true)]
        public short? REQTRASP { get; set; }
        
        [SugarColumn(ColumnName = "CTPOLIZAS", IsNullable = true)]
        public int? CTPOLIZAS { get; set; }
    }
}
