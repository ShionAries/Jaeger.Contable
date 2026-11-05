using SqlSugar;
namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("DEPTOS")] 
    public sealed class DeptoEntity {
        [SugarColumn(ColumnName = "DEPTO", IsPrimaryKey=true)] 
        public short IdDepto { get; set; }
        [SugarColumn(ColumnName = "DESCRIP")]
        public string Descripcion { get; set; }
    }
}
