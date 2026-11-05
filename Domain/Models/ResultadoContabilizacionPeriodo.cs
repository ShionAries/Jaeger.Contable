using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado de la contabilización de las pólizas de un periodo.</summary>
    public sealed class ResultadoContabilizacionPeriodo {
        public short Ejercicio { get; private set; }
        public short Periodo { get; private set; }
        public int PolizasContabilizadas { get; private set; }
        public int PartidasContabilizadas { get; private set; }
        public int CuentasAfectadas { get; private set; }

        public ResultadoContabilizacionPeriodo(
            short ejercicio,
            short periodo,
            int polizasContabilizadas,
            int partidasContabilizadas,
            int cuentasAfectadas) {
            Ejercicio = ejercicio;
            Periodo = periodo;
            PolizasContabilizadas = polizasContabilizadas;
            PartidasContabilizadas = partidasContabilizadas;
            CuentasAfectadas = cuentasAfectadas;
        }
    }
}
