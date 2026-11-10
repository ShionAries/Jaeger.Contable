using System;

namespace Jaeger.Contable.DataAccess.Configuration {
    /// <summary>
    /// Resuelve los nombres físicos de las tablas contables por ejercicio.
    /// </summary>
    public interface IEjercicioContableTableResolver {
        string ObtenerTablaPolizas(short ejercicio);
        string ObtenerTablaAuxiliar(short ejercicio);
        string ObtenerTablaSaldos(short ejercicio);
        string ObtenerTablaSaldosDepartamentales(short ejercicio);
    }

    /// <summary>
    /// Implementa la resolución controlada de tablas contables por ejercicio.
    /// Las tablas utilizan el nombre base seguido de los dos últimos dígitos del ejercicio.
    /// </summary>
    public sealed class EjercicioContableTableResolver : IEjercicioContableTableResolver {
        public string ObtenerTablaPolizas(short ejercicio) {
            return ObtenerTabla("POLIZAS", ejercicio);
        }

        public string ObtenerTablaAuxiliar(short ejercicio) {
            return ObtenerTabla("AUXILIAR", ejercicio);
        }

        public string ObtenerTablaSaldos(short ejercicio) {
            return ObtenerTabla("SALDOS", ejercicio);
        }

        public string ObtenerTablaSaldosDepartamentales(short ejercicio) {
            return ObtenerTabla("SALDOSDP", ejercicio);
        }

        private static string ObtenerTabla(string prefijo, short ejercicio) {
            if (ejercicio < 1900 || ejercicio > 9999)
                throw new ArgumentOutOfRangeException(
                    nameof(ejercicio),
                    "El ejercicio contable debe estar entre 1900 y 9999.");

            return prefijo + (ejercicio % 100).ToString("00");
        }
    }
}
