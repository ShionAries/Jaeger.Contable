namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa un tipo de activo del catálogo TIPACTIV.
    /// </summary>
    public sealed class ActivoFijoTipo : Abstractions.BasePropertyChangeImplementation {
        #region declaraciones privadas
        private short _Clave;
        private string _Descripcion;
        private double? _DepresiacionNormal;
        private double? _DepresiacionInmediata;
        private double? _MaximoDepresiacion;
        private string _MetodoDepresiacion;
        private double? _DepresiacionProyectada;
        private string _CuentaActivo;
        private string _CuentaDepresiacion;
        private string _CuentaGastos;
        private string _CuentaGanancias;
        private int? _Moneda;
        #endregion

        /// <summary>
        /// Clave que se asigna automáticamente al tipo de activo para identificarlo.
        /// </summary>
        public short Clave {
            get { return _Clave; }
            set {
                this._Clave = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Nombre del tipo de activo
        /// </summary>
        public string Descripcion {
            get { return _Descripcion; }
            set {
                this._Descripcion = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Tasa depreciación contable.- Porcentaje de deducción contable anual para el tipo de activo.
        /// </summary>
        public double? DepresiacionNormal {
            get { return _DepresiacionNormal; }
            set {
                this._DepresiacionNormal = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Tasa depreciación fiscal.- Porcentaje de deducción fiscal anual para el tipo de activo.
        /// </summary>
        public double? DepresiacionInmediata {
            get { return _DepresiacionInmediata; }
            set {
                this._DepresiacionInmediata = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Máximo deducible.- Cantidad máxima que se puede deducir el activo.
        /// </summary>
        public double? MaximoDepresiacion {
            get { return _MaximoDepresiacion; }
            set {
                this._MaximoDepresiacion = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Método de depreciación.-  Tipo de depreciación que se aplica al tipo de activo.
        /// </summary>
        public string MetodoDepresiacion {
            get { return _MetodoDepresiacion; }
            set {
                this._MetodoDepresiacion = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Porcentaje de depreciación para el  tipo de activo
        /// </summary>
        public double? DepresiacionProyectada {
            get { return _DepresiacionProyectada; }
            set {
                this._DepresiacionProyectada = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará por la compra de este tipo de activo.
        /// </summary>
        public string CuentaActivo {
            get { return _CuentaActivo; }
            set {
                this._CuentaActivo = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará al depreciar activos de este tipo
        /// </summary>
        public string CuentaDepresiacion {
            get { return _CuentaDepresiacion; }
            set {
                this._CuentaDepresiacion = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Anota o elige la cuenta contable que se afectará con los gastos de depreciación de este tipo de activo
        /// </summary>
        public string CuentaGastos {
            get { return _CuentaGastos; }
            set {
                this._CuentaGastos = value;
                this.OnPropertyChanged();
            }
        }

        public string CuentaGanancias {
            get { return _CuentaGanancias; }
            set {
                this._CuentaGanancias = value;
                this.OnPropertyChanged();
            }
        }

        public int? IdMoneda {
            get { return _Moneda; }
            set {
                this._Moneda = value;
                this.OnPropertyChanged();
            }
        }
    }
}
