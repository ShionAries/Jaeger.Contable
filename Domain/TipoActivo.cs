namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa un tipo de activo del catálogo TIPACTIV.
    /// </summary>
    public sealed class TipoActivo {
        /// <summary>
        /// Clave que se asigna automáticamente al tipo de activo para identificarlo.
        /// </summary>
        public short Clave { get; set; }

        /// <summary>
        /// Nombre del tipo de activo
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Tasa depreciación contable.- Porcentaje de deducción contable anual para el tipo de activo.
        /// </summary>
        public double? DepresiacionNormal { get; set; }

        /// <summary>
        /// Tasa depreciación fiscal.- Porcentaje de deducción fiscal anual para el tipo de activo.
        /// </summary>
        public double? DepresiacionInmediata { get; set; }

        /// <summary>
        /// Máximo deducible.- Cantidad máxima que se puede deducir el activo.
        /// </summary>
        public double? MaximoDepresiacion { get; set; }

        /// <summary>
        /// Método de depreciación.-  Tipo de depreciación que se aplica al tipo de activo.
        /// </summary>
        public string MetodoDepresiacion { get; set; }

        /// <summary>
        /// Porcentaje de depreciación para el  tipo de activo
        /// </summary>
        public double? DepresiacionProyectada { get; set; }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará por la compra de este tipo de activo.
        /// </summary>
        public string CuentaActivo { get; set; }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará al depreciar activos de este tipo
        /// </summary>
        public string CuentaDepresiacion { get; set; }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará con los gastos de depreciación de este tipo de activo
        /// </summary>
        public string CuentaGastos { get; set; }

        public string CuentaGanancias { get; set; }

        public short? Moneda { get; set; }
    }
}
