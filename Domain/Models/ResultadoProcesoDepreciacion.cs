namespace Jaeger.Contable.Domain.Entities {
    public sealed class ResultadoProcesoDepreciacion {
        public short Ejercicio { get; private set; }
        public short Periodo { get; private set; }
        public int ActivosProcesados { get; private set; }
        public double ImporteTotal { get; private set; }
        public string TipoPoliza { get; private set; }
        public string NumeroPoliza { get; private set; }
        public int PartidasGeneradas { get; internal set; }

        public ResultadoProcesoDepreciacion(short ejercicio, short periodo, int activosProcesados, double importeTotal, string tipoPoliza, string numeroPoliza) {
            Ejercicio = ejercicio;
            Periodo = periodo;
            ActivosProcesados = activosProcesados;
            ImporteTotal = importeTotal;
            TipoPoliza = tipoPoliza;
            NumeroPoliza = numeroPoliza;
        }
    }
}
