using System.Collections.Generic;

namespace Jaeger.Contable.Domain.Entities {
    public sealed class ResultadoAuditoriaCtarubItem {
        private readonly List<string> _errores = new List<string>();
        public int Rubro { get; private set; }
        public string Cuenta { get; private set; }
        public string SegPapa { get; private set; }
        public IReadOnlyList<string> Errores { get { return _errores.AsReadOnly(); } }
        public bool EsValida { get { return _errores.Count == 0; } }
        public ResultadoAuditoriaCtarubItem(int rubro, string cuenta, string segPapa) { Rubro = rubro; Cuenta = cuenta; SegPapa = segPapa; }
        public void AgregarError(string error) { if (!string.IsNullOrWhiteSpace(error)) _errores.Add(error); }
    }
}
