using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Value object que encapsula la estructura lógica y física de NUM_CTA.
    /// </summary>
    public sealed class EstructuraCuenta {
        public const int LongitudFisica = 21;
        private const int IndicadorNivel = 3;
        private readonly int[] _digitos;

        public int NivelActual { get; private set; }
        public bool UtilizaGuion { get; private set; }

        private EstructuraCuenta(int[] digitos, int nivelActual, bool utilizaGuion) {
            _digitos = digitos;
            NivelActual = nivelActual;
            UtilizaGuion = utilizaGuion;
        }

        public static EstructuraCuenta Crear(ParametroEmpresa p) {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            return Crear(new ConfiguracionNiveles(
                new[] { p.DIGCTA1, p.DIGCTA2, p.DIGCTA3, p.DIGCTA4, p.DIGCTA5,
                        p.DIGCTA6, p.DIGCTA7, p.DIGCTA8, p.DIGCTA9 },
                string.Equals(p.GUION_SINO, "S", StringComparison.OrdinalIgnoreCase),
                p.NIVELACTU));
        }

        public static EstructuraCuenta Crear(ConfiguracionNiveles configuracion) {
            if (configuracion == null)
                throw new ArgumentNullException(nameof(configuracion));

            var digitos = configuracion.DigitosPorNivel.ToArray();
            return new EstructuraCuenta(
                digitos,
                configuracion.NivelActual,
                configuracion.UsarGuiones);
        }

        public int ObtenerDigitos(int nivel) {
            if (nivel < 1 || nivel > NivelActual)
                throw new ArgumentOutOfRangeException(nameof(nivel));
            return _digitos[nivel - 1];
        }

        public int ObtenerLongitudLogica(int nivel) {
            if (nivel < 1 || nivel > NivelActual)
                throw new ArgumentOutOfRangeException(nameof(nivel));
            var total = 0;
            for (var i = 0; i < nivel; i++)
                total += _digitos[i];
            return total;
        }

        public IList<string> ObtenerSegmentos(string cuentaLogica, int nivel) {
            if (string.IsNullOrWhiteSpace(cuentaLogica))
                throw new ArgumentException("La cuenta lógica es obligatoria.", nameof(cuentaLogica));
            if (nivel < 1 || nivel > NivelActual)
                throw new ArgumentOutOfRangeException(nameof(nivel));
            var digits = SoloDigitos(cuentaLogica);
            var required = ObtenerLongitudLogica(nivel);
            if (digits.Length < required)
                digits = digits.PadRight(required, '0');
            if (digits.Length > required)
                digits = digits.Substring(0, required);
            var result = new List<string>();
            var offset = 0;
            for (var i = 1; i <= nivel; i++) {
                var len = ObtenerDigitos(i);
                result.Add(digits.Substring(offset, len));
                offset += len;
            }
            return result;
        }

        public string ConvertirALongitudFisica(string cuentaLogica, int nivel) {
            if (nivel < 1 || nivel > NivelActual)
                throw new ArgumentOutOfRangeException(nameof(nivel));
            var digits = SoloDigitos(cuentaLogica);
            var logicalLength = ObtenerLongitudLogica(nivel);
            if (digits.Length != logicalLength)
                throw new ArgumentException("La longitud lógica no corresponde al nivel indicado.", nameof(cuentaLogica));
            return digits + new string('0', LongitudFisica - IndicadorNivel - digits.Length) + nivel.ToString("D3");
        }

        public string ObtenerCuentaLogicaDesdeFisica(string cuentaFisica) {
            var digits = NormalizarFisica(cuentaFisica);
            var nivel = ObtenerNivelFisico(digits);
            return digits.Substring(0, ObtenerLongitudLogica(nivel));
        }

        public string NormalizarFisica(string cuentaFisica) {
            if (string.IsNullOrWhiteSpace(cuentaFisica))
                throw new ArgumentException("La cuenta física es obligatoria.", nameof(cuentaFisica));

            var digits = SoloDigitos(cuentaFisica);
            if (digits.Length != LongitudFisica)
                throw new ArgumentException("NUM_CTA debe tener exactamente 21 dígitos.", nameof(cuentaFisica));

            var nivel = int.Parse(digits.Substring(LongitudFisica - IndicadorNivel, IndicadorNivel));
            if (nivel < 1 || nivel > NivelActual)
                throw new InvalidOperationException("El indicador físico de nivel no es válido.");

            var longitudLogica = ObtenerLongitudLogica(nivel);
            var relleno = LongitudFisica - IndicadorNivel - longitudLogica;
            if (relleno < 0)
                throw new InvalidOperationException("La estructura configurada excede la longitud física de NUM_CTA.");

            var esperado = digits.Substring(longitudLogica, relleno);
            if (esperado.Any(c => c != '0'))
                throw new ArgumentException("NUM_CTA contiene dígitos fuera de la longitud lógica configurada.", nameof(cuentaFisica));

            return digits;
        }

        public int ObtenerNivelFisico(string cuentaFisica) {
            var digits = SoloDigitos(cuentaFisica);
            if (digits.Length != LongitudFisica)
                throw new ArgumentException("NUM_CTA debe tener exactamente 21 dígitos.", nameof(cuentaFisica));
            var value = int.Parse(digits.Substring(LongitudFisica - IndicadorNivel, IndicadorNivel));
            if (value < 1 || value > NivelActual)
                throw new InvalidOperationException("El indicador físico de nivel no es válido.");
            return value;
        }

        public string Formatear(string cuentaFisica) {
            var logical = ObtenerCuentaLogicaDesdeFisica(cuentaFisica);
            var nivel = ObtenerNivelFisico(cuentaFisica);
            var segmentos = ObtenerSegmentos(logical, nivel);
            return UtilizaGuion ? string.Join("-", segmentos) : logical;
        }

        private static string SoloDigitos(string value) {
            var result = new string(value.Where(char.IsDigit).ToArray());
            if (result.Length == 0)
                throw new ArgumentException("La cuenta debe contener dígitos.", nameof(value));
            return result;
        }
    }
}
