using System;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de la cabecera de una póliza de POLIZAS25.
    /// </summary>
    [SugarTable("POLIZAS25")]
    public sealed class PolizaEntity {
        [SugarColumn(IsPrimaryKey = true)] 
        public string TIPO_POLI { get; set; }
        [SugarColumn(IsPrimaryKey = true)] 
        public string NUM_POLIZ { get; set; }
        [SugarColumn(IsPrimaryKey = true)] 
        public short PERIODO { get; set; }
        [SugarColumn(IsPrimaryKey = true)] 
        public int EJERCICIO { get; set; }
        public DateTime? FECHA_POL { get; set; }
        public string CONCEP_PO { get; set; }
        public int? NUM_PART { get; set; }
        public string LOGAUDITA { get; set; }
        public string CONTABILIZ { get; set; }
        public short? NUMPARCUA { get; set; }
        public short? TIENEDOCUMENTOS { get; set; }
        public int? PROCCONTAB { get; set; }
        public string ORIGEN { get; set; }
        public string UUID { get; set; }
        public int? ESPOLIZAPRIVADA { get; set; }
        public string UUIDOP { get; set; }
        public string DOC_SIGO { get; set; }
        public string UUIDXML { get; set; }
        public string UUIDSAE { get; set; }
    }
}
