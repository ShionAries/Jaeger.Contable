using SqlSugar;
namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("CCOSTOS")] public sealed class CcostosEntity {
        [SugarColumn(IsPrimaryKey=true)] public int ID { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
