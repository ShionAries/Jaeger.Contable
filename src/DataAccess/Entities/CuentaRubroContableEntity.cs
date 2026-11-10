using SqlSugar;
namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("ctarub")]
    public class CuentaRubroContableEntity {
        public CuentaRubroContableEntity() { }

        [SugarColumn(ColumnName = "RUBRO", IsPrimaryKey = true)]
        public int Rubro { get; set; }

        [SugarColumn(ColumnName = "CUENTA", IsPrimaryKey = true, Length = 21)]
        public string Cuenta { get; set; }
        
        [SugarColumn(ColumnName = "SEGPAPA", IsNullable = true, Length = 21)]
        public string SegPapa { get; set; }
    }
}
