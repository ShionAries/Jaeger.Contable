using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa el estado administrativo de un periodo contable según ADMPER.
    /// </summary>
    public sealed class PeriodoContable {
        /// <summary>
        /// Muestra el mes del ejercicio de trabajo en el  sistema
        /// </summary>
        public short Periodo { get; private set; }

        /// <summary>
        /// Muestra el año de trabajo en el sistema.
        /// </summary>
        public short Ejercicio { get; private set; }

        /// <summary>
        /// Indica si el periodo está auditado. Si el cuadro quiere decir que está auditado
        /// </summary>
        public short Cerrado { get; private set; }

        public int Ordenado { get; private set; }

        /// <summary>
        /// Al estar marcado el cuadro significa que el periodo requiere traspaso de saldos
        /// </summary>
        public short ReqTrasp { get; private set; }

        /// <summary>
        /// Al estar marcado se indica que en el periodo correspondiente se encuentran pólizas que no se han contabilizado
        /// </summary>
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
