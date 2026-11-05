using System;

namespace Jaeger.Contable.Domain.ValueObjects {
    /// <summary>
    /// Centraliza las reglas de precisión utilizadas para importes contables.
    /// </summary>
    public static class ImporteContable {
        public const int Decimales = 2;
        public const double Tolerancia = 0.005d;

        public static bool EsValido(double importe) {
            return !double.IsNaN(importe) && !double.IsInfinity(importe) && importe > 0d;
        }

        public static double Redondear(double importe) {
            return Math.Round(importe, Decimales, MidpointRounding.AwayFromZero);
        }

        public static bool SonIguales(double primero, double segundo) {
            return Math.Abs(Redondear(primero) - Redondear(segundo)) < Tolerancia;
        }
    }
}
