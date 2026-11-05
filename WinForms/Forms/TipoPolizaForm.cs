using System;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;

namespace Jaeger.Contable.Forms {
    public partial class TipoPolizaForm : Form {
        private readonly ITipoPolizaService _service;

        public TipoPolizaForm(ITipoPolizaService service) {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        private void TipoPolizaForm_Load(object sender, EventArgs e) {

        }
    }
}
