using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo mínimo de persistencia de HISTOR requerido para validar monedas con historial.
    /// </summary>
    [SugarTable("HISTOR")]
    public sealed class MonedaHistorialEntity {
        [SugarColumn(ColumnName = "MONEDA")]
        public int? IdMoneda { get; set; }

        [SugarColumn(ColumnName = "FECHA")]
        public System.DateTime? Fecha { get; set; }

        [SugarColumn(ColumnName = "TIPCAMBIO")]
        public double? TipoCambio { get; set; }
    }
}
