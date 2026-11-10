namespace Jaeger.Contable.Domain.Interfaces.Repositories {
    public interface IEjercicioContableTableResolver {
        string ObtenerTablaPolizas(short ejercicio);
        string ObtenerTablaAuxiliar(short ejercicio);
        string ObtenerTablaSaldos(short ejercicio);
        string ObtenerTablaSaldosDepartamentales(short ejercicio);
        string ObtenerTablaActivos(short ejercicio);
    }
}
