namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Resultado de la conciliación entre movimientos y saldos almacenados.
    /// </summary>
    public sealed class ConciliacionCuenta {
        public string NumeroCuenta { get; set; }
        
        public short Ejercicio { get; set; }
        
        public short Periodo { get; set; }
        
        public double CargoMovimientos { get; set; }
        
        public double AbonoMovimientos { get; set; }
        
        public double CargoSaldo { get; set; }
        
        public double AbonoSaldo { get; set; }
        
        public double DiferenciaCargo {
            get {
                return CargoSaldo - CargoMovimientos;
            }
        }
        
        public double DiferenciaAbono {
            get {
                return AbonoSaldo - AbonoMovimientos;
            }
        }
        
        public bool Conciliado {
            get {
                return System.Math.Abs(DiferenciaCargo) < 0.000001 && System.Math.Abs(DiferenciaAbono) < 0.000001;
            }
        }

        public bool TieneSaldoDepartamental { get; set; }
    }
}
