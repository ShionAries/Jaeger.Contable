using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa un activo fijo de la tabla ACTIVOS25.
    /// </summary>
    public sealed class ActivoFijo : Abstractions.BasePropertyChangeImplementation {
        #region declaraciones
        private string _CLAVE;
        private short? _TIPO;
        private string _DESCRIP;
        private string _LOCALIZ;
        private double? _MONTORIG;
        private double? _MONTORIGEX;
        private DateTime? _FECHAADQ;
        private double? _MAXDED;
        private double? _VALMER;
        private double? _DEPACU;
        private double? _VIDAUT;
        private string _METDEP;
        private double? _TASDEP;
        private double? _TASDEPFIS;
        private string _STATUS;
        private DateTime? _FECHAELIM;
        private short? _NUMDEPTO;
        private DateTime? _FECHAULTRE;
        private string _NUMSERIE;
        private string _BANDEDINM;
        private DateTime? _FECINIDEP;
        private DateTime? _FECINIDEPF;
        private double? _DEPACUFISC;
        private string _OBSERVACIO;
        private double? _TIPOCAMBIO;
        private string _POLIZASEG;
        private string _COMPASEGU;
        private string _AGENTESEG;
        private string _TELSINIES;
        private string _TIPOCOBER;
        private double? _MONTOASEG;
        private double? _PRIMATOTA;
        private double? _DEDUCIBLE;
        private DateTime? _FECVIGENC;
        private DateTime? _FECPROXMA;
        private DateTime? _FECULTMAN;
        private short? _PERIODOMA;
        private double? _COSTOMANT;
        private string _RESPACTFIJO;
        #endregion

        #region general
        public string Clave {
            get { return this._CLAVE; }
            set {
                this._CLAVE = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer la clave del tipo de activo al que pertenece el activo
        /// </summary>
        public short? Tipo {
            get { return this._TIPO; }
            set {
                this._TIPO = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establcer nombre o descripcion del activo fijo
        /// </summary>
        public string Descripcion {
            get { return this._DESCRIP; }
            set {
                this._DESCRIP = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer lugar fisico donde se encuentra el activo
        /// </summary>
        public string Localizacion {
            get { return this._LOCALIZ; }
            set {
                this._LOCALIZ = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer estado en que se adquirio el activo
        /// </summary>
        public string Status {
            get { return this._STATUS; }
            set {
                this._STATUS = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer numero de serie del activo
        /// </summary>
        public string NumSerie {
            get { return this._NUMSERIE; }
            set {
                this._NUMSERIE = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establcer numero de departamento al que pertenece el activo
        /// </summary>
        public short? IdDepartamento {
            get { return this._NUMDEPTO; }
            set {
                this._NUMDEPTO = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer valor original del activo en moneda base
        /// </summary>
        public double? MontoOriginal {
            get { return this._MONTORIG; }
            set {
                this._MONTORIG = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer valor original del activo en moneda extranjera.
        /// </summary>
        public double? MontoOriginalMonedaExtranjera {
            get { return this._MONTORIGEX; }
            set {
                this._MONTORIGEX = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer fecha de adquisicion del activo
        /// </summary>
        public DateTime? FecAdquisicion {
            get { return this._FECHAADQ; }
            set {
                this._FECHAADQ = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer Monto tope maximo permitido para la depreciacion del activo fijo.
        /// </summary>
        public double? MaximoDeducible {
            get { return this._MAXDED; }
            set {
                this._MAXDED = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer Es el mimo valor que el de la columna Valor original.
        /// </summary>
        public double? ValorMercado {
            get { return this._VALMER; }
            set {
                this._VALMER = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer Porcentaje de vida util del activo.
        /// </summary>
        public double? VidaUtil {
            get { return this._VIDAUT; }
            set {
                this._VIDAUT = value;
                this.OnPropertyChanged();
            }
        }
        #endregion

        #region mantenimiento
        #endregion

        #region seguros
        /// <summary>
        /// obtener o establecer numero de poliza de seguro de activo
        /// </summary>
        public string PolizaSeguro {
            get { return this._POLIZASEG; }
            set {
                this._POLIZASEG = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer empresa aseguradora
        /// </summary>
        public string CompaniaSeguro {
            get { return this._COMPASEGU; }
            set {
                this._COMPASEGU = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer agente de seguro
        /// </summary>
        public string AgenteSeguro {
            get { return this._AGENTESEG; }
            set {
                this._AGENTESEG = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer telefono en caso de siniestro
        /// </summary>
        public string TelefonoSiniestro {
            get { return this._TELSINIES; }
            set {
                this._TELSINIES = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer cobertura que se le da al activo, por ejemplo: completa
        /// </summary>
        public string TipoCobertura {
            get { return this._TIPOCOBER; }
            set {
                this._TIPOCOBER = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer monto por el cual se aseguro el activo
        /// </summary>
        public double? MontoAsegurado {
            get { return this._MONTOASEG; }
            set {
                this._MONTOASEG = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer prima total del activo
        /// </summary>
        public double? PrimaTotal {
            get { return this._PRIMATOTA; }
            set {
                this._PRIMATOTA = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer monto del deducible del seguro del activo
        /// </summary>
        public double? Deducible {
            get { return this._DEDUCIBLE; }
            set {
                this._DEDUCIBLE = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer vigencia de la poliza de seguro del activo
        /// </summary>
        public DateTime? FecVigencia {
            get { return this._FECVIGENC; }
            set {
                this._FECVIGENC = value;
                this.OnPropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// obtenero o establecer depresiacion acumulada
        /// </summary>
        public double? DepresiacionAcumulada {
            get { return this._DEPACU; }
            set {
                this._DEPACU = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Selecciona el tipo de depreciación que deseas aplicar al nuevo activo (Línea recta, Doble saldo declinante, Suma de años dígitos)
        /// </summary>
        public string MetodoDepresiacion {
            get { return this._METDEP; }
            set {
                this._METDEP = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer tasa de depresiacion, Anota el porcentaje anual de la depreciación del activo fijo. Es importante que indiques la tasa de depreciación, pues es la que se utilizará para los cálculos correspondientes. El sistema sugiere el porcentaje asociado al tipo de activo. 
        /// </summary>
        public double? TasaDepresiacion {
            get { return this._TASDEP; }
            set {
                this._TASDEP = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtner o establecer
        /// </summary>
        public double? TasaDepresiacionFiscal {
            get { return this._TASDEPFIS; }
            set {
                this._TASDEPFIS = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer fecha de baja del activo
        /// </summary>
        public DateTime? FechaBaja {
            get { return this._FECHAELIM; }
            set {
                this._FECHAELIM = value;
                this.OnPropertyChanged();
            }
        }
        public DateTime? FECHAULTRE {
            get { return this._FECHAULTRE; }
            set {
                this._FECHAULTRE = value;
                this.OnPropertyChanged();
            }
        }
        public string BANDEDINM {
            get { return this._BANDEDINM; }
            set {
                this._BANDEDINM = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer Deberás capturar la fecha en la que se empezara a depreciar el activo fijo. 
        /// </summary>
        public DateTime? FecInicioDepresiacion {
            get { return this._FECINIDEP; }
            set {
                this._FECINIDEP = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer Deberás capturar la fecha fiscal en la que se empezara a depreciar el activo fijo. 
        /// </summary>
        public DateTime? FecInicioDepresiacionFiscal {
            get { return this._FECINIDEPF; }
            set {
                this._FECINIDEPF = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer depresiacion acumulada fiscal
        /// </summary>
        public double? DepresiacionAcumuladaFiscal {
            get { return this._DEPACUFISC; }
            set {
                this._DEPACUFISC = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer observaciones del activo fijo
        /// </summary>
        public string Nota {
            get { return this._OBSERVACIO; }
            set {
                this._OBSERVACIO = value;
                this.OnPropertyChanged();
            }
        }
        public double? TipoCambio {
            get { return this._TIPOCAMBIO; }
            set {
                this._TIPOCAMBIO = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer fecha del proximo mantenimiento
        /// </summary>
        public DateTime? FecProximoMantto {
            get { return this._FECPROXMA; }
            set {
                this._FECPROXMA = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// ontener o establecer fecha del ultimo mantenimiento
        /// </summary>
        public DateTime? FecUltMantto {
            get { return this._FECULTMAN; }
            set {
                this._FECULTMAN = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer periodo de mantenimiento, Indica el periodo dentro del cual se le debe dar mantenimiento al activo, por ejemplo: cada 2 meses, 6 meses, entre otros. Por omisión se muestra Sin mantto.
        /// </summary>
        public short? PeriodoMantto {
            get { return this._PERIODOMA; }
            set {
                this._PERIODOMA = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer costo de mantenimiento
        /// </summary>
        public double? CostoMantto {
            get { return this._COSTOMANT; }
            set {
                this._COSTOMANT = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer responsable de activo fijo
        /// </summary>
        public string Responsable {
            get { return this._RESPACTFIJO; }
            set {
                this._RESPACTFIJO = value;
                this.OnPropertyChanged();
            }
        }
    }
}
