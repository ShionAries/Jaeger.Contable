namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa la relación entre un rubro y una cuenta.
    /// </summary>
    public class CuentaRubro : Abstractions.BasePropertyChangeImplementation {
        #region declaraciones
        private int _RUBRO { get; set; }
        private string _CUENTA { get; set; }
        private string _SEGPAPA { get; set; }
        #endregion

        public int Rubro {
            get { return _RUBRO; }
            set {
                _RUBRO = value;
                OnPropertyChanged();
            }
        }
        public string Cuenta {
            get { return _CUENTA; }
            set {
                _CUENTA = value;
                OnPropertyChanged();
            }
        }
        public string SegPapa {
            get { return _SEGPAPA; }
            set {
                _SEGPAPA = value;
                OnPropertyChanged();
            }
        }
    }
}
