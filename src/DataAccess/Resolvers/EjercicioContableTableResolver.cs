using System;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Resolvers {
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

        public string ObtenerTablaActivos(short ejercicio) {
            return ObtenerTabla("ACTIVOS", ejercicio);
        }

        private static string ObtenerTabla(string prefijo, short ejercicio) {
            if (ejercicio < 1900 || ejercicio > 9999)
                throw new ArgumentOutOfRangeException("ejercicio", "El ejercicio contable no es válido.");
            return prefijo + (ejercicio % 100).ToString("00");
        }
    }
}
