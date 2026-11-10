using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>Modelo de persistencia de la tabla ADMPER.</summary>
    [SugarTable("ADMPER")]
    public sealed class AdmperEntity {
        [SugarColumn(IsPrimaryKey = true)] public short PERIODO { get; set; }
        [SugarColumn(IsPrimaryKey = true)] public short EJERCICIO { get; set; }
        public short? CERRADO { get; set; }
        public int? ORDENADO { get; set; }
        public short? REQTRASP { get; set; }
        public int? CTPOLIZAS { get; set; }
    }
}
