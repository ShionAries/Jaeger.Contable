using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado completo de la balanza de comprobación.</summary>
    public sealed class BalanzaComprobacion {
        public short Ejercicio { get; set; }
        public short PeriodoInicial { get; set; }
        public short PeriodoFinal { get; set; }
        public IList<BalanzaComprobacionItem> Cuentas { get; set; }
        public decimal TotalSaldoInicialDeudor { get; set; }
        public decimal TotalSaldoInicialAcreedor { get; set; }
        public decimal TotalCargos { get; set; }
        public decimal TotalAbonos { get; set; }
        public decimal TotalSaldoFinalDeudor { get; set; }
        public decimal TotalSaldoFinalAcreedor { get; set; }
    }
}
