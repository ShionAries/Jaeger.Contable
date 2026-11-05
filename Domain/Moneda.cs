using System;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa una moneda del catálogo MONEDAS.
    /// </summary>
    public sealed class Moneda : Domain.Abstractions.BasePropertyChangeImplementation {
        #region declaraciones
        private short _MONEDA;
        private string _Nombre;
        private string _Prefijo;
        private DateTime? _Fecha;
        private double? _TipoCambio;
        private double? _Monto;
        private string _DESPAUTO;
        private string _CveSAT;
        #endregion

        public short IdMoneda {
            get { return this._MONEDA; }
            set {
                this._MONEDA = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer nombre de la moneda
        /// </summary>
        public string Nombre {
            get { return this._Nombre; }
            set {
                this._Nombre = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer Prefijo utilizado para la moneda
        /// </summary>
        public string Prefijo {
            get { return this._Prefijo; }
            set {
                this._Prefijo = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer fecha
        /// </summary>
        public DateTime? Fecha {
            get {
                if (this._Fecha >= new DateTime(1900, 1, 1))
                    return this._Fecha;
                return null;
            }
            set {
                this._Fecha = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer tipo de cambio
        /// </summary>
        public double? TipoCambio {
            get { return this._TipoCambio; }
            set {
                this._TipoCambio = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer monto
        /// </summary>
        public double? Monto {
            get { return this._Monto; }
            set {
                this._Monto = value;
                this.OnPropertyChanged();
            }
        }

        public string DESPAUTO {
            get { return this._DESPAUTO; }
            set {
                this._DESPAUTO = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer clave SAT
        /// </summary>
        public string CveSAT {
            get { return this._CveSAT; }
            set {
                this._CveSAT = value;
                this.OnPropertyChanged();
            }
        }
    }
}
