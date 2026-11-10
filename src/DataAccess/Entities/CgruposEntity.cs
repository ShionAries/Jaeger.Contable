using SqlSugar;
namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("CGRUPOS")] public sealed class CgruposEntity {
        [SugarColumn(IsPrimaryKey=true)] public int ID { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
