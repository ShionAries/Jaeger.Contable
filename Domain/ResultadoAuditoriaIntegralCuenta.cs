using System.Collections.Generic;
using System.Linq;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado integral de las validaciones estructurales y contables de una cuenta.</summary>
    public sealed class ResultadoAuditoriaIntegralCuenta {
        private readonly List<string> errores = new List<string>();
        private readonly List<string> advertencias = new List<string>();
        public string NumeroCuenta { get; private set; }
        public short Ejercicio { get; private set; }
        public short Periodo { get; private set; }
        public bool EstructuraValida { get; set; }
        public bool CtarubValida { get; set; }
        public bool ConciliacionValida { get; set; }
        public bool ActividadContableDetectada { get; set; }
        public bool EsValida { get { return errores.Count == 0; } }
        public IReadOnlyList<string> Errores { get { return errores.AsReadOnly(); } }
        public IReadOnlyList<string> Advertencias { get { return advertencias.AsReadOnly(); } }
        public double CargoMovimientos { get; set; }
        public double AbonoMovimientos { get; set; }
        public double CargoSaldo { get; set; }
        public double AbonoSaldo { get; set; }
        public double DiferenciaCargo { get; set; }
        public double DiferenciaAbono { get; set; }
        public double CargoAcumulado { get; set; }
        public double AbonoAcumulado { get; set; }
        public int CuentasConsideradas { get; set; }
        public int MovimientosConsiderados { get; set; }

        public ResultadoAuditoriaIntegralCuenta(string numeroCuenta, short ejercicio, short periodo) {
            NumeroCuenta = numeroCuenta;
            Ejercicio = ejercicio;
            Periodo = periodo;
        }
        public void AgregarError(string mensaje) { if (!string.IsNullOrWhiteSpace(mensaje)) errores.Add(mensaje); }
        public void AgregarAdvertencia(string mensaje) { if (!string.IsNullOrWhiteSpace(mensaje)) advertencias.Add(mensaje); }
    }

    public sealed class ResultadoAuditoriaIntegralCatalogo {
        private readonly List<ResultadoAuditoriaIntegralCuenta> cuentas = new List<ResultadoAuditoriaIntegralCuenta>();
        public IReadOnlyList<ResultadoAuditoriaIntegralCuenta> Cuentas { get { return cuentas.AsReadOnly(); } }
        public int Total { get { return cuentas.Count; } }
        public int Validas { get { return cuentas.Count(x => x.EsValida); } }
        public int Invalidas { get { return cuentas.Count(x => !x.EsValida); } }
        public void Agregar(ResultadoAuditoriaIntegralCuenta resultado) { if (resultado != null) cuentas.Add(resultado); }
    }
}
