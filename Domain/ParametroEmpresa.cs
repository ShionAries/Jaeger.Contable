namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Parámetros generales de la empresa y estructura de cuentas.
    /// </summary>
    public class ParametroEmpresa {
        public int IDEMP { get; set; }
        public int DIGCTA1 { get; set; }
        public int DIGCTA2 { get; set; }
        public int DIGCTA3 { get; set; }
        public int DIGCTA4 { get; set; }
        public int DIGCTA5 { get; set; }
        public int DIGCTA6 { get; set; }
        public int DIGCTA7 { get; set; }
        public int DIGCTA8 { get; set; }
        public int DIGCTA9 { get; set; }
        public short NIVELACTU { get; set; }
        public string GUION_SINO { get; set; }
        public string CONTABLINEA { get; set; }

        public int ObtenerDigitos(int nivel) {
            switch (nivel) {
                case 1:
                    return DIGCTA1;
                case 2:
                    return DIGCTA2;
                case 3:
                    return DIGCTA3;
                case 4:
                    return DIGCTA4;
                case 5:
                    return DIGCTA5;
                case 6:
                    return DIGCTA6;
                case 7:
                    return DIGCTA7;
                case 8:
                    return DIGCTA8;
                case 9:
                    return DIGCTA9;
                default:
                    return 0;
            }
        }
    }
}
