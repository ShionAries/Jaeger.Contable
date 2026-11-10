using System;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de ACTIVOS25.
    /// </summary>
    [SugarTable("ACTIVOS25")]
    public sealed class ActivoFijoEntity {
        [SugarColumn(ColumnName = "CLAVE", IsPrimaryKey = true)]
        public string CLAVE { get; set; }

        [SugarColumn(ColumnName = "Tipo")]
        public short? TIPO { get; set; }

        [SugarColumn(ColumnName = "DESCRIP")]
        public string DESCRIP { get; set; }

        [SugarColumn(ColumnName = "LOCALIZ")]
        public string LOCALIZ { get; set; }

        [SugarColumn(ColumnName = "MONTORIG")]
        public double? MONTORIG { get; set; }

        [SugarColumn(ColumnName = "MONTORIGEX")]
        public double? MONTORIGEX { get; set; }

        [SugarColumn(ColumnName = "FECHAADQ")]
        public DateTime? FECHAADQ { get; set; }

        [SugarColumn(ColumnName = "MAXDED")]
        public double? MAXDED { get; set; }

        [SugarColumn(ColumnName = "VALMER")]
        public double? VALMER { get; set; }

        [SugarColumn(ColumnName = "DEPACU")]
        public double? DEPACU { get; set; }

        [SugarColumn(ColumnName = "VIDAUT")]
        public double? VIDAUT { get; set; }

        [SugarColumn(ColumnName = "METDEP")]
        public string METDEP { get; set; }

        [SugarColumn(ColumnName = "TASDEP")]
        public double? TASDEP { get; set; }

        [SugarColumn(ColumnName = "TASDEPFIS")]
        public double? TASDEPFIS { get; set; }

        [SugarColumn(ColumnName = "STATUS")]
        public string STATUS { get; set; }

        [SugarColumn(ColumnName = "FECHAELIM")]
        public DateTime? FECHAELIM { get; set; }

        [SugarColumn(ColumnName = "NUMDEPTO")]
        public short? NUMDEPTO { get; set; }

        [SugarColumn(ColumnName = "FECHAULTRE")]
        public DateTime? FECHAULTRE { get; set; }

        [SugarColumn(ColumnName = "NUMSERIE")]
        public string NUMSERIE { get; set; }

        [SugarColumn(ColumnName = "BANDEDINM")]
        public string BANDEDINM { get; set; }

        [SugarColumn(ColumnName = "FECINIDEP")]
        public DateTime? FECINIDEP { get; set; }

        [SugarColumn(ColumnName = "FECINIDEPF")]
        public DateTime? FECINIDEPF { get; set; }

        [SugarColumn(ColumnName = "DEPACUFISC")]
        public double? DEPACUFISC { get; set; }

        [SugarColumn(ColumnName = "OBSERVACIO")]
        public string OBSERVACIO { get; set; }

        [SugarColumn(ColumnName = "TIPOCAMBIO")]
        public double? TIPOCAMBIO { get; set; }

        [SugarColumn(ColumnName = "POLIZASEG")]
        public string POLIZASEG { get; set; }

        [SugarColumn(ColumnName = "COMPASEGU")]
        public string COMPASEGU { get; set; }

        [SugarColumn(ColumnName = "AGENTESEG")]
        public string AGENTESEG { get; set; }

        [SugarColumn(ColumnName = "TELSINIES")]
        public string TELSINIES { get; set; }

        [SugarColumn(ColumnName = "TIPOCOBER")]
        public string TIPOCOBER { get; set; }

        [SugarColumn(ColumnName = "MONTOASEG")]
        public double? MONTOASEG { get; set; }

        [SugarColumn(ColumnName = "PRIMATOTA")]
        public double? PRIMATOTA { get; set; }

        [SugarColumn(ColumnName = "DEDUCIBLE")]
        public double? DEDUCIBLE { get; set; }

        [SugarColumn(ColumnName = "FECVIGENC")]
        public DateTime? FECVIGENC { get; set; }

        [SugarColumn(ColumnName = "FECPROXMA")]
        public DateTime? FECPROXMA { get; set; }

        [SugarColumn(ColumnName = "FECULTMAN")]
        public DateTime? FECULTMAN { get; set; }

        [SugarColumn(ColumnName = "PERIODOMA")]
        public short? PERIODOMA { get; set; }

        [SugarColumn(ColumnName = "COSTOMANT")]
        public double? COSTOMANT { get; set; }

        [SugarColumn(ColumnName = "RESPACTFIJO")]
        public string RESPACTFIJO { get; set; }
    }
}
