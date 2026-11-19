using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de la tabla AUXILIAR25.
    /// Conserva las columnas y tipos utilizados por el esquema de la base de datos.
    /// </summary>
    [SugarTable("AUXILIAR25")]
    public sealed class Auxiliar25Entity {
        [SugarColumn(ColumnName = "TIPO_POLI", IsPrimaryKey = true)]
        public string TIPO_POLI { get; set; }

        [SugarColumn(ColumnName = "NUM_POLIZ", IsPrimaryKey = true)]
        public string NUM_POLIZ { get; set; }

        [SugarColumn(ColumnName = "NUM_PART", IsPrimaryKey = true)]
        public double NUM_PART { get; set; }

        [SugarColumn(ColumnName = "PERIODO", IsPrimaryKey = true)]
        public short PERIODO { get; set; }

        [SugarColumn(ColumnName = "EJERCICIO", IsPrimaryKey = true)]
        public short EJERCICIO { get; set; }

        [SugarColumn(ColumnName = "NUM_CTA", IsPrimaryKey = true)]
        public string NUM_CTA { get; set; }

        [SugarColumn(ColumnName = "NUM_SUBCTA", IsPrimaryKey = true)]
        public string NUM_SUBCTA { get; set; }

        [SugarColumn(ColumnName = "FECHA_POL")]
        public System.DateTime? FECHA_POL { get; set; }

        [SugarColumn(ColumnName = "CONCEP_PO")]
        public string CONCEP_PO { get; set; }

        [SugarColumn(ColumnName = "DEBE_HABER")]
        public string DEBE_HABER { get; set; }

        [SugarColumn(ColumnName = "MONTOMOV", IsNullable = true)]
        public double? MONTOMOV { get; set; }

        [SugarColumn(ColumnName = "SALDOCTA", IsNullable = true)]
        public short? NUMDEPTO { get; set; }

        [SugarColumn(ColumnName = "TIPCAMBIO")]
        public double? TIPCAMBIO { get; set; }
        
        [SugarColumn(ColumnName = "CONTRAPAR", IsNullable = true)]
        public short? CONTRAPAR { get; set; }
        
        [SugarColumn(ColumnName = "ORDEN", IsNullable = true)]
        public int? ORDEN { get; set; }
        
        [SugarColumn(ColumnName = "CCOSTOS", IsNullable = true)]
        public int? CCOSTOS { get; set; }
        
        [SugarColumn(ColumnName = "CGRUPOS", IsNullable = true)]
        public int? CGRUPOS { get; set; }
       
        [SugarColumn(ColumnName = "IDINFADIPAR", IsNullable = true)]
        public int? IDINFADIPAR { get; set; }

        [SugarColumn(ColumnName = "IDUUID", IsNullable = true)]
        public int? IDUUID { get; set; }
    }
}
