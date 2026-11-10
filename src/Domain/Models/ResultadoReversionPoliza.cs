namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado del registro de una póliza de reversión.</summary>
    public sealed class ResultadoReversionPoliza {
        public string TipoPolizaOriginal { get; private set; }
        public string NumeroPolizaOriginal { get; private set; }
        public string TipoPolizaNueva { get; private set; }
        public string NumeroPolizaNueva { get; private set; }
        public short Ejercicio { get; private set; }
        public short Periodo { get; private set; }
        public int Partidas { get; private set; }
        public double ImporteRevertido { get; private set; }

        public ResultadoReversionPoliza(string tipoOriginal, string numeroOriginal,
            string tipoNueva, string numeroNueva, short ejercicio, short periodo,
            int partidas, double importeRevertido) {
            TipoPolizaOriginal = tipoOriginal;
            NumeroPolizaOriginal = numeroOriginal;
            TipoPolizaNueva = tipoNueva;
            NumeroPolizaNueva = numeroNueva;
            Ejercicio = ejercicio;
            Periodo = periodo;
            Partidas = partidas;
            ImporteRevertido = importeRevertido;
        }
    }
}
