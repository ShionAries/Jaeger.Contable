using System.Collections.Generic;
using System.Linq;

namespace Jaeger.Contable.Domain.Entities {
    public sealed class ResultadoAuditoriaCtarub {
        private readonly List<ResultadoAuditoriaCtarubItem> _relaciones = new List<ResultadoAuditoriaCtarubItem>();
        public IReadOnlyList<ResultadoAuditoriaCtarubItem> Relaciones { get { return _relaciones.AsReadOnly(); } }
        public int Total { get { return _relaciones.Count; } }
        public int Validas { get { return _relaciones.Count(x => x.EsValida); } }
        public int Invalidas { get { return _relaciones.Count(x => !x.EsValida); } }
        public void Agregar(ResultadoAuditoriaCtarubItem item) { if (item != null) _relaciones.Add(item); }
    }
}
