using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Forms;

namespace Jaeger.Contable.WinForms.Forms {
    public partial class ConceptoSelectorPolizaForm : Form {
        private readonly IConceptoService _service;
        private List<Concepto> _conceptos = new List<Concepto>();
        public Concepto ConceptoSeleccionado { get; private set; }

        public ConceptoSelectorPolizaForm(IConceptoService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            Text = "Seleccionar concepto de póliza";
            _txtBuscar.TextChanged += (s, e) => Filtrar();

            _grid.AutoGenerateColumns = false;
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.MultiSelect = false;
            _grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            _grid.RowHeadersVisible = false;
            _grid.AllowUserToResizeRows = false;
            
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdConcepto", HeaderText = "Código", Width = 50 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Descripción", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            _grid.CellDoubleClick += (s, e) => Seleccionar();
            _grid.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.Handled = true; Seleccionar(); } };

            _btnNuevo.Click += async (s, e) => await CrearConceptoAsync();
            _btnAceptar.Click += (s, e) => Seleccionar();

            AcceptButton = _btnAceptar;
            CancelButton = _btnCancelar;
            Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            try {
                _txtBuscar.Enabled = false;
                _conceptos = await _service.ObtenerTodosAsync() ?? new List<Concepto>();
                _txtBuscar.Enabled = true;
                Filtrar();
                if (_grid.Rows.Count > 0)
                    _grid.Rows[0].Selected = true;
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible cargar CONCEPTO: " + ex.Message, "Conceptos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void Filtrar() {
            var texto = (_txtBuscar.Text ?? string.Empty).Trim();
            var datos = string.IsNullOrEmpty(texto)
                ? _conceptos
                : _conceptos.Where(x => x.Descripcion != null && x.Descripcion.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 || x.IdConcepto.ToString().IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            _grid.DataSource = null;
            _grid.DataSource = datos;
        }

        private async Task CrearConceptoAsync() {
            using (var form = new ConceptoPolizaCatalogoForm(_service)) {
                form.ShowDialog(this);
            }
            try {
                _conceptos = await _service.ObtenerTodosAsync() ?? new List<Concepto>();
                Filtrar();
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible actualizar los conceptos: " + ex.Message, "Conceptos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Seleccionar() {
            if (_grid.CurrentRow == null) {
                MessageBox.Show(this, "Seleccione un concepto.", "Conceptos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConceptoSeleccionado = _grid.CurrentRow.DataBoundItem as Concepto;
            if (ConceptoSeleccionado == null)
                return;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
