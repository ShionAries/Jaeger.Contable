namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Parámetros para generar una balanza de comprobación.</summary>
    public sealed class BalanzaComprobacionRequest {
        public short Ejercicio { get; set; }
        public short PeriodoInicial { get; set; }
        public short PeriodoFinal { get; set; }
        public bool IncluirCuentasSinMovimientos { get; set; }

        /// <summary>
        /// Nivel máximo de presentación. Cero conserva el detalle completo.
        /// Los niveles inferiores se acumulan en su cuenta padre.
        /// </summary>
        public short NivelPresentacion { get; set; }
    }
}
