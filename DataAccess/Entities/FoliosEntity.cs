using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>Modelo de persistencia de la tabla FOLIOS.</summary>
    [SugarTable("FOLIOS")]
    public sealed class FoliosEntity {
        [SugarColumn(IsPrimaryKey = true)] 
        public string TIPPOL { get; set; }
        [SugarColumn(IsPrimaryKey = true)]
        public short EJERCICIO { get; set; }
        public string FOLIO01 { get; set; }
        public string FOLIO02 { get; set; }
        public string FOLIO03 { get; set; }
        public string FOLIO04 { get; set; }
        public string FOLIO05 { get; set; }
        public string FOLIO06 { get; set; }
        public string FOLIO07 { get; set; }
        public string FOLIO08 { get; set; }
        public string FOLIO09 { get; set; }
        public string FOLIO10 { get; set; }
        public string FOLIO11 { get; set; }
        public string FOLIO12 { get; set; }
        public string FOLIO13 { get; set; }
        public short? ASIG01 { get; set; }
        public short? ASIG02 { get; set; }
        public short? ASIG03 { get; set; }
        public short? ASIG04 { get; set; }
        public short? ASIG05 { get; set; }
        public short? ASIG06 { get; set; }
        public short? ASIG07 { get; set; }
        public short? ASIG08 { get; set; }
        public short? ASIG09 { get; set; }
        public short? ASIG10 { get; set; }
        public short? ASIG11 { get; set; }
        public short? ASIG12 { get; set; }
        public short? ASIG13 { get; set; }
        public short? ASIG14 { get; set; }
        public string FOLIO14 { get; set; }
    }
}
