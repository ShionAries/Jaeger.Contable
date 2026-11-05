namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa el siguiente folio disponible para una póliza.
    /// </summary>
    public sealed class FolioContable {
        public string TipoPoliza { get; private set; }
        public short Ejercicio { get; private set; }
        public short Periodo { get; private set; }
        public string NumeroPoliza { get; private set; }

        public FolioContable(string tipoPoliza, short ejercicio, short periodo, string numeroPoliza) {
            TipoPoliza = tipoPoliza;
            Ejercicio = ejercicio;
            Periodo = periodo;
            NumeroPoliza = numeroPoliza;
        }
    }
}
