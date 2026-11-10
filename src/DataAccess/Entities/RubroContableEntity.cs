using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {

    [SugarTable("rangos")]
    public class RubroContableEntity {
        [SugarColumn(ColumnName = "RANGO", IsPrimaryKey = true)]
        public int Rango { get; set; }

        [SugarColumn(ColumnName = "DESCRIP", IsNullable = true, Length = 100)]
        public string Descripcion { get; set; }
    }
}
