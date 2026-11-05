namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa un tipo de póliza configurado en TIPOSPOL.
    /// </summary>
    public sealed class TipoPoliza : Abstractions.BasePropertyChangeImplementation {
        #region
        private string _Tipo;
        private string _Descripcion;
        private int? _ClaveSAT;
        #endregion

        /// <summary>
        /// obtener o establecer indice
        /// </summary>
        public string Tipo {
            get { return this._Tipo; }
            set {
                this._Tipo = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer descripcion
        /// </summary>
        public string Descripcion {
            get { return this._Descripcion; }
            set {
                this._Descripcion = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer clave SAT
        /// </summary>
        public int? ClaveSAT {
            get { return this._ClaveSAT; }
            set {
                this._ClaveSAT = value;
                this.OnPropertyChanged();
            }
        }
    }
}
