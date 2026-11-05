using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de la tabla TIPACTIV.
    /// </summary>
    [SugarTable("TIPACTIV")]
    public sealed class TipActivoEntity {
        /// <summary>
        /// Clave que se asigna automáticamente al tipo de activo para identificarlo.
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public short CLAVE { get; set; }

        /// <summary>
        /// Nombre del tipo de activo
        /// </summary>
        [SugarColumn(ColumnName = "DESCRIP", Length = 20)]
        public string DESCRIP { get; set; }

        /// <summary>
        /// Tasa depreciación contable.- Porcentaje de deducción contable anual para el tipo de activo.
        /// </summary>
        public double? DEDNORMAL { get; set; }

        /// <summary>
        /// Tasa depreciación fiscal.- Porcentaje de deducción fiscal anual para el tipo de activo.
        /// </summary>
        public double? DEDIMED { get; set; }

        /// <summary>
        /// Máximo deducible.- Cantidad máxima que se puede deducir el activo.
        /// </summary>
        [SugarColumn(ColumnName = "MAXDED")]
        public double? MAXDED { get; set; }

        /// <summary>
        /// Método de depreciación.-  Tipo de depreciación que se aplica al tipo de activo.
        /// </summary>
        [SugarColumn(ColumnName = "METODODEP", Length = 1)]
        public string METODODEP { get; set; }

        /// <summary>
        /// Porcentaje de depreciación para el  tipo de activo
        /// </summary>
        [SugarColumn(ColumnName = "DEPPROY")]
        public double? DEPPROY { get; set; }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará por la compra de este tipo de activo.
        /// </summary>
        [SugarColumn(ColumnName = "CTAAACTV", Length = 21)]
        public string CTAAACTV { get; set; }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará al depreciar activos de este tipo
        /// </summary>
        [SugarColumn(ColumnName = "CTADEPRE", Length = 21)]
        public string CTADEPRE { get; set; }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará con los gastos de depreciación de este tipo de activo
        /// </summary>
        [SugarColumn(ColumnName = "CTAGASTOS", Length = 21)]
        public string CTAGASTOS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(ColumnName = "CTAPERGAN", Length = 21)]
        public string CTAPERGAN { get; set; }

        [SugarColumn(ColumnName = "QUEMONEDA")]
        public short? QUEMONEDA { get; set; }
    }
}
