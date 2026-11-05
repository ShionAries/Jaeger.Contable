using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa la estructura configurable de niveles de una cuenta contable.
    /// </summary>
    public sealed class ConfiguracionNiveles {
        private readonly List<int> _digitosPorNivel;

        public ConfiguracionNiveles(IEnumerable<int> digitosPorNivel, bool usarGuiones, int nivelActual) {
            if (digitosPorNivel == null)
                throw new ArgumentNullException(nameof(digitosPorNivel));

            _digitosPorNivel = digitosPorNivel.Take(9).ToList();
            while (_digitosPorNivel.Count < 9)
                _digitosPorNivel.Add(0);

            if (nivelActual < 1 || nivelActual > 9)
                throw new ArgumentOutOfRangeException(nameof(nivelActual));

            for (int i = 0; i < 9; i++) {
                if (_digitosPorNivel[i] < 0)
                    throw new ArgumentException("Los dígitos de cada nivel no pueden ser negativos.", nameof(digitosPorNivel));

                if (i + 1 <= nivelActual && _digitosPorNivel[i] == 0)
                    throw new ArgumentException(
                        string.Format("El nivel {0} debe tener al menos un dígito.", i + 1),
                        nameof(digitosPorNivel));

                if (i + 1 > nivelActual && _digitosPorNivel[i] != 0)
                    throw new ArgumentException("Los niveles posteriores al nivel actual deben tener cero dígitos.", nameof(digitosPorNivel));

                if (_digitosPorNivel[i] > 9)
                    throw new ArgumentException(
                        string.Format("El nivel {0} no puede tener más de 9 dígitos.", i + 1),
                        nameof(digitosPorNivel));
            }

            if (_digitosPorNivel.Take(nivelActual).Sum() > 18)
                throw new ArgumentException("La longitud lógica máxima permitida es de 18 dígitos.", nameof(digitosPorNivel));

            NivelActual = nivelActual;
            UsarGuiones = usarGuiones;
        }

        public IReadOnlyList<int> DigitosPorNivel { get { return _digitosPorNivel.AsReadOnly(); } }

        public int NivelActual { get; private set; }
        
        public bool UsarGuiones { get; private set; }
        
        public int TotalDigitosLogicos { get { return _digitosPorNivel.Take(NivelActual).Sum(); } }

        public string GenerarMascara() {
            var segmentos = _digitosPorNivel.Take(NivelActual)
                .Where(x => x > 0)
                .Select(x => new string('0', x))
                .ToList();

            return UsarGuiones ? string.Join("-", segmentos) : string.Concat(segmentos);
        }
    }
}
