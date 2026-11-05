using System.ComponentModel;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa un rubro del catálogo RANGOS.
    /// </summary>
    public class RubroContableModel : Abstractions.BasePropertyChangeImplementation, INotifyPropertyChanged {
        private int _RANGO;
        private string _DESCRIP;

        /// <summary>
        /// constructor
        /// </summary>
        public RubroContableModel() : base() { }

        /// <summary>
        /// obtener o establecer rango
        /// </summary>
        public int Rango {
            get { return this._RANGO; }
            set {
                this._RANGO = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// obtener o establecer descripcion
        /// </summary>
        public string Descripcion {
            get { return this._DESCRIP; }
            set {
                this._DESCRIP = value;
                this.OnPropertyChanged();
            }
        }

        public string Descriptor {
            get {
                return $"{this.Rango} {this.Descripcion}";
            }
        }
    }
}
