using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa el estado administrativo de un periodo contable según ADMPER.
    /// </summary>
    public sealed class PeriodoContable {
        public short Periodo { get; private set; }
        public short Ejercicio { get; private set; }
        public short Cerrado { get; private set; }
        public int Ordenado { get; private set; }
        public short ReqTrasp { get; private set; }
        public int CtPolizas { get; private set; }

        public bool EstaCerrado {
            get { return Cerrado != 0; }
        }

        public PeriodoContable(short periodo, short ejercicio, short cerrado, int ordenado, short reqTrasp, int ctPolizas) {
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo));
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));

            Periodo = periodo;
            Ejercicio = ejercicio;
            Cerrado = cerrado;
            Ordenado = ordenado;
            ReqTrasp = reqTrasp;
            CtPolizas = ctPolizas;
        }
    }
}
