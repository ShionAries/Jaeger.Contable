namespace Jaeger.Contable.Domain.Models {
    public sealed class PeriodoItem {
        public short Numero { get; private set; }
        public string Nombre { get; private set; }

        public PeriodoItem(short numero, string nombre) {
            Numero = numero;
            Nombre = nombre;
        }
    }
}
