using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de la tabla AUXILIAR25.
    /// Conserva las columnas y tipos utilizados por el esquema de la base de datos.
    /// </summary>
    [SugarTable("AUXILIAR25")]
    public sealed class Auxiliar25Entity {
        [SugarColumn(IsPrimaryKey = true)]
        public string TIPO_POLI { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public string NUM_POLIZ { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public double NUM_PART { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public short PERIODO { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public short EJERCICIO { get; set; }

        public string NUM_CTA { get; set; }
        public System.DateTime? FECHA_POL { get; set; }
        public string CONCEP_PO { get; set; }
        public string DEBE_HABER { get; set; }
        public double? MONTOMOV { get; set; }
        public short? NUMDEPTO { get; set; }
        public double? TIPCAMBIO { get; set; }
        public short? CONTRAPAR { get; set; }
        public int? ORDEN { get; set; }
        public int? CCOSTOS { get; set; }
        public int? CGRUPOS { get; set; }
        public int? IDINFADIPAR { get; set; }
        public int? IDUUID { get; set; }
    }
}
