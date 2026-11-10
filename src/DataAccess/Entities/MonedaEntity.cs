using System;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    /// <summary>
    /// Modelo de persistencia de la tabla MONEDAS.
    /// </summary>
    [SugarTable("MONEDAS")]
    public sealed class MonedaEntity {
        [SugarColumn(ColumnName = "Moneda", IsPrimaryKey = true, IsNullable = false)] 
        public short IdMoneda { get; set; }

        /// <summary>
        /// obtener o establecer nombre de la moneda
        /// </summary>
        [SugarColumn(ColumnName = "Nombre", IsNullable = true, Length = 20)] 
        public string Nombre { get; set; }

        /// <summary>
        /// obtener o establecer Prefijo utilizado para la moneda
        /// </summary>
        [SugarColumn(ColumnName = "Prefijo", IsNullable = true, Length = 4)] 
        public string Prefijo { get; set; }
        
        /// <summary>
        /// obtener o establecer fecha
        /// </summary>
        [SugarColumn(ColumnName = "Fecha", IsNullable = true)] 
        public DateTime? Fecha { get; set; }

        /// <summary>
        /// obtener o establecer tipo de cambio
        /// </summary>
        [SugarColumn(ColumnName = "TipoCambio", IsNullable = true)] 
        public double? TipoCambio { get; set; }
        
        /// <summary>
        /// obtener o establecer monto
        /// </summary>
        [SugarColumn(ColumnName = "Monto", IsNullable = true)] 
        public double? Monto { get; set; }
        
        [SugarColumn(ColumnName = "DespAuto", IsNullable = true, Length = 1)] 
        public string DESPAUTO { get; set; }

        /// <summary>
        /// obtener o establecer clave SAT
        /// </summary>
        [SugarColumn(ColumnName = "ClasSAT", IsNullable = true, Length = 3)] 
        public string CveSAT { get; set; }
    }
}
