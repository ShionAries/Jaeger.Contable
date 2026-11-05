using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa los datos necesarios para registrar una partida contable.
    /// </summary>
    public sealed class MovimientoContableRequest {
        public string TipoPoliza { get; set; }
        public string NumeroPoliza { get; set; }
        public double NumeroPartida { get; set; }
        public short Ejercicio { get; set; }
        public short Periodo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Concepto { get; set; }
        public string NumeroCuenta { get; set; }
        public string DebeHaber { get; set; }
        public double Importe { get; set; }
        public double? TipoCambio { get; set; }
        public short? NumeroDepartamento { get; set; }
        public short? Contrapartida { get; set; }
        public int? Orden { get; set; }
        public int? CentroCostos { get; set; }
        public int? Grupo { get; set; }

        public double Debe {
            get {
                return string.Equals(DebeHaber, "D", StringComparison.OrdinalIgnoreCase)
                    ? Importe
                    : 0d;
            }
        }

        public double Haber {
            get {
                return string.Equals(DebeHaber, "H", StringComparison.OrdinalIgnoreCase)
                    ? Importe
                    : 0d;
            }
        }
    }
}
