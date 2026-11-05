using System;
using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Calcula el siguiente número de cuenta disponible de acuerdo con la estructura definida en PARAMEMP.
    /// </summary>
    public sealed class GeneradorNumeroCuenta {
        private readonly EstructuraCuenta _estructura;

        public GeneradorNumeroCuenta(EstructuraCuenta estructura) {
            _estructura = estructura ?? throw new ArgumentNullException(nameof(estructura));
        }

        /// <summary>
        /// Calcula el siguiente número físico sin reservarlo ni persistirlo.
        /// </summary>
        public string Generar(IEnumerable<CuentaContable> existentes, CuentaContable padre, short nivel) {
            if (existentes == null)
                throw new ArgumentNullException(nameof(existentes));
            if (nivel < 1 || nivel > _estructura.NivelActual)
                throw new ArgumentOutOfRangeException(nameof(nivel),
                    "El nivel solicitado no está habilitado en PARAMEMP.");

            var digitosNivel = _estructura.ObtenerDigitos(nivel);
            if (digitosNivel < 1 || digitosNivel > 9)
                throw new InvalidOperationException(
                    string.Format("PARAMEMP.DIGCTA{0} no permite generar un consecutivo válido.", nivel));

            if (nivel > 1) {
                if (padre == null)
                    throw new InvalidOperationException("La cuenta padre es obligatoria.");
                if (!string.Equals(padre.Tipo, "A", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("La cuenta padre debe ser acumulativa.");
                if (padre.Nivel + 1 != nivel)
                    throw new InvalidOperationException("El nivel solicitado no corresponde al nivel del padre.");
            }

            var maximoPermitido = (long)Math.Pow(10, digitosNivel) - 1L;
            var maximoActual = 0L;

            foreach (var existente in existentes) {
                if (existente == null)
                    continue;

                if (existente.Nivel != nivel)
                    throw new InvalidOperationException(
                        string.Format("La cuenta '{0}' tiene un NIVEL inconsistente.", existente.NumCta));

                try {
                    var logico = _estructura.ObtenerCuentaLogicaDesdeFisica(existente.NumCta);
                    var segmentos = _estructura.ObtenerSegmentos(logico, existente.Nivel);
                    var valor = long.Parse(segmentos[nivel - 1]);

                    if (valor > maximoActual)
                        maximoActual = valor;
                } catch (Exception ex) {
                    throw new InvalidOperationException(
                        string.Format("La cuenta existente '{0}' no coincide con la estructura de PARAMEMP.", existente.NumCta),
                        ex);
                }
            }

            if (maximoActual >= maximoPermitido)
                throw new InvalidOperationException(
                    string.Format("Se agotó la capacidad del nivel {0}.", nivel));

            var siguiente = maximoActual + 1L;
            var prefijo = nivel == 1
                ? string.Empty
                : _estructura.ObtenerCuentaLogicaDesdeFisica(padre.NumCta);

            var logicoNuevo = prefijo + siguiente.ToString(new string('0', digitosNivel));
            return _estructura.ConvertirALongitudFisica(logicoNuevo, nivel);
        }
    }
}
