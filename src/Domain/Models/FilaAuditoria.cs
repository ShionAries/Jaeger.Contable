namespace Jaeger.Contable.Domain.Models {
    internal sealed class FilaAuditoria {
        public int Rubro { get; set; }
        public string Cuenta { get; set; }
        public string SegPapa { get; set; }
        public bool EsValida { get; set; }
        public string TextoErrores { get; set; }
    }
}
