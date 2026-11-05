using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Resultado del registro de una póliza completa.
    /// </summary>
    public sealed class ResultadoRegistroPoliza {
        public string TipoPoliza { get; private set; }
        public string NumeroPoliza { get; private set; }
        public short Ejercicio { get; private set; }
        public short Periodo { get; private set; }
        public int PartidasRegistradas { get; private set; }
        public double TotalDebe { get; private set; }
        public double TotalHaber { get; private set; }
        public bool EstaBalanceada { get; private set; }
        public IReadOnlyList<string> Advertencias { get; private set; }
        public ResultadoRegistroPoliza(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo, int partidasRegistradas, double totalDebe, double totalHaber, bool estaBalanceada, IList<string> advertencias) {
            TipoPoliza = tipoPoliza;
            NumeroPoliza = numeroPoliza;
            Ejercicio = ejercicio;
            Periodo = periodo;
            PartidasRegistradas = partidasRegistradas;
            TotalDebe = totalDebe;
            TotalHaber = totalHaber;
            EstaBalanceada = estaBalanceada;
            Advertencias = new List<string>(advertencias ?? new List<string>()).AsReadOnly();
        }
    }
}
