using System.Collections.Generic;
using System.Linq;

namespace Jaeger.Contable.Domain.Entities {
    /// <summary>Resultado consolidado de la auditoría del catálogo CUENTAS25.</summary>
    public sealed class ResultadoAuditoriaCuentas {
        private readonly List<ResultadoAuditoriaCuenta> _cuentas;

        public ResultadoAuditoriaCuentas() {
            _cuentas = new List<ResultadoAuditoriaCuenta>();
        }

        public IReadOnlyList<ResultadoAuditoriaCuenta> Cuentas {
            get { return _cuentas.AsReadOnly(); }
        }

        public int Total {
            get { return _cuentas.Count; }
        }

        public int Validas {
            get { return _cuentas.Count(x => x.EsValida); }
        }

        public int Invalidas {
            get { return Total - Validas; }
        }

        public void Agregar(ResultadoAuditoriaCuenta resultado) {
            if (resultado != null)
                _cuentas.Add(resultado);
        }
    }
}
