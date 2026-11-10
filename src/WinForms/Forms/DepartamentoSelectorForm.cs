using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    public partial class DepartamentoSelectorForm : Form {
        private readonly ICatalogosPartidaService _service;
        private System.Collections.Generic.List<Departamento> _datos = new System.Collections.Generic.List<Departamento>();
        public short ValorSeleccionado { get; private set; }
        public string DescripcionSeleccionada { get; private set; }

        public DepartamentoSelectorForm(ICatalogosPartidaService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            gridData.ReadOnly = true;
            gridData.AutoGenerateColumns = false;
            gridData.RowHeadersVisible = false;
            gridData.AllowUserToResizeRows = false;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridData.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Código", DataPropertyName = "DEPTO", Width = 30 });
            gridData.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", DataPropertyName = "DESCRIP", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            Controls.Add(gridData);
            Controls.Add(txtBuscar);
            txtBuscar.TextChanged += (s, e) => Filtrar();
            gridData.CellDoubleClick += (s, e) => Aceptar();
            Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            _datos = (await _service.ObtenerDepartamentosAsync()).ToList();
            Filtrar();
        }
        
        private void Filtrar() {
            var q = (txtBuscar.Text ?? string.Empty).Trim();
            gridData.DataSource = string.IsNullOrEmpty(q)
                ? _datos.ToList()
                : _datos.Where(x => x.IdDepartamento.ToString().Contains(q) ||
                    (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        
        private void Aceptar() {
            var x = gridData.CurrentRow == null ? null : gridData.CurrentRow.DataBoundItem as Departamento;
            if (x == null)
                return;
            ValorSeleccionado = x.IdDepartamento;
            DescripcionSeleccionada = x.Descripcion ?? string.Empty;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
