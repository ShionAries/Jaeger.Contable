using System.ComponentModel;
namespace Jaeger.Contable.Domain.Entities {
    /// <summary>
    /// Representa una cuenta contable del catálogo CUENTAS25.
    /// </summary>
    public class CuentaContable : Abstractions.BasePropertyChangeImplementation, INotifyPropertyChanged {
        #region declaraciones
        private string numCta;
        private string status;
        private string tipo;
        private string nombre;
        private string deptsino;
        private short bandmulti;
        private string bandajt;
        private string ctaPapa;
        private string ctaRaiz;
        private short nivel;
        private string ctaComp;
        private short naturaleza;
        private string rfc;
        private string codagrup;
        private short capturacheque;
        private short capturauuid;
        private int banco;
        private string ctabancaria;
        private string capcheqtipomov;
        private int noincluirxml;
        private string idfiscal;
        private short esflujodeefectivo;
        private string bancodextranjero;
        private string rfcflujO;
        #endregion

        public CuentaContable() : base() {
            this.status = "A";
            this.tipo = "D";
            this.deptsino = "N";
        }

        /// <summary>
        /// obtener o establecer numero de cuenta contable
        /// </summary>
        public string NumCta {
            get {
                return numCta;
            }
            set {
                numCta = value;
                OnPropertyChanged();
            }
        }

        public string Status {
            get { return status; }
            set {
                status = value;
                OnPropertyChanged();
            }
        }
        
        public string Tipo {
            get { return tipo; }
            set {
                tipo = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// obtener o establecer nombre o descripcion de la cuenta
        /// </summary>
        public string Nombre {
            get { return nombre; }
            set {
                nombre = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// es de departamento o no
        /// </summary>
        public string DeptoSiNo {
            get { return deptsino; }
            set {
                deptsino = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// obteneri establecer bandera para indicar si maneja multimoneda
        /// </summary>
        public short BandMulti {
            get { return bandmulti; }
            set {
                bandmulti = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Indica si afecta poliza de ajuste cambiario
        /// </summary>
        public string BandAjt {
            get { return bandajt; }
            set {
                bandajt = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// cuenta papa
        /// </summary>
        public string CtaPapa {
            get { return ctaPapa; }
            set {
                ctaPapa = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// cuenta raiz
        /// </summary>
        public string CtaRaiz {
            get { return ctaRaiz; }
            set {
                ctaRaiz = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// nivel
        /// </summary>
        public short Nivel {
            get { return nivel; }
            set {
                nivel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// cuenta contrapartida
        /// </summary>
        public string CtaComp {
            get { return ctaComp; }
            set {
                ctaComp = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// naturaleza de la cuenta
        /// </summary>
        public short Naturaleza {
            get { return naturaleza; }
            set {
                naturaleza = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// RFC
        /// </summary>
        public string RFC {
            get { return rfc; }
            set {
                rfc = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// codigo de agrupacion
        /// </summary>
        public string CodAgrup {
            get { return codagrup; }
            set {
                codagrup = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// indica si se captura formas de pag
        /// </summary>
        public short CapturaCheque {
            get { return capturacheque; }
            set {
                capturacheque = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Indica si se captura comprobantes
        /// </summary>
        public short CapturaUUID {
            get { return capturauuid; }
            set {
                capturauuid = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// banco capturado en la forma de pago
        /// </summary>
        public int Banco {
            get { return banco; }
            set {
                banco = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Cuenta bancaria capturada en la forma de pago
        /// </summary>
        public string CtaBancaria {
            get { return ctabancaria; }
            set {
                ctabancaria = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// tipo de movimiento
        /// </summary>
        public string CapturaChequeTipoMovimiento {
            get { return capcheqtipomov; }
            set {
                capcheqtipomov = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// indica que no se incluira al general el xml de contabilidad
        /// </summary>
        public int NoIncluirXML {
            get { return noincluirxml; }
            set {
                noincluirxml = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// identificador Fiscal
        /// </summary>
        public string IdFiscal {
            get { return idfiscal; }
            set {
                idfiscal = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// indica si es flujo de efectivo
        /// </summary>
        public short EsFlujoEfectivo {
            get { return esflujodeefectivo; }
            set {
                esflujodeefectivo = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// banco extranjero
        /// </summary>
        public string BancoExtranjero {
            get { return bancodextranjero; }
            set {
                bancodextranjero = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// RFCEmisor Cuenta ordenante o RFCEmisor cuenta beneficiario
        /// </summary>
        public string RfcFlujo {
            get { return rfcflujO; }
            set {
                rfcflujO = value;
                OnPropertyChanged();
            }
        }
        
        public string Descriptor {
            get {
                return string.IsNullOrWhiteSpace(NumCta) ? Nombre : NumCta + " - " + Nombre;
            }
        }
    }
}
