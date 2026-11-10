using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    public partial class CuentaMovimientoSelectorForm : Form {
        private readonly ICuentaService _cuentaService;
        private List<CuentaContable> _cuentas = new List<CuentaContable>();
        public string NumeroCuentaSeleccionada { get; private set; }
        public string DescripcionCuentaSeleccionada { get; private set; }

        public CuentaMovimientoSelectorForm(ICuentaService cuentaService) {
            _cuentaService = cuentaService ?? throw new ArgumentNullException(nameof(cuentaService));
            InitializeComponent();

            KeyPreview = true;
            AcceptButton = null;
            CancelButton = null;

            _txtBuscar.TextChanged += (s, e) => Filtrar();
            _txtBuscar.KeyDown += Buscar_KeyDown;

            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToResizeRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.MultiSelect = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _grid.ShowRowErrors = false;
            _grid.RowHeadersVisible = false;

            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cuenta", DataPropertyName = "NumCta", FillWeight = 30 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", FillWeight = 55 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nivel", DataPropertyName = "NIVEL", FillWeight = 10 });
            _grid.CellDoubleClick += (s, e) => {
                if (e.RowIndex >= 0)
                    Aceptar();
            };

            _btnAceptar.Click += (s, e) => Aceptar();
            _btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            try {
                _btnAceptar.Enabled = false;
                Cursor = Cursors.WaitCursor;
                var cuentas = await _cuentaService.ObtenerCuentasActivasAsync();
                _cuentas = cuentas
                    .Where(x => x != null &&
                                !string.IsNullOrWhiteSpace(x.NumCta) &&
                                string.Equals(x.Tipo, "D", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.NumCta, StringComparer.Ordinal)
                    .ToList();
                Filtrar();
                if (_grid.Rows.Count > 0) {
                    _grid.ClearSelection();
                    _grid.Rows[0].Selected = true;
                    _grid.CurrentCell = _grid.Rows[0].Cells[0];
                }
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Cuentas contables", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible cargar las cuentas: " + ex.Message, "Cuentas contables", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            } finally {
                Cursor = Cursors.Default;
                _btnAceptar.Enabled = true;
            }
        }

        private void Filtrar() {
            var texto = (_txtBuscar.Text ?? string.Empty).Trim();
            IEnumerable<CuentaContable> consulta = _cuentas;
            if (!string.IsNullOrWhiteSpace(texto)) {
                consulta = _cuentas.Where(x =>
                    (x.NumCta ?? string.Empty).IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (x.Nombre ?? string.Empty).IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            _grid.DataSource = consulta.ToList();
            if (_grid.Rows.Count > 0) {
                _grid.ClearSelection();
                _grid.Rows[0].Selected = true;
                _grid.CurrentCell = _grid.Rows[0].Cells[0];
            }
        }

        private void Buscar_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && _grid.Rows.Count > 0) {
                Aceptar();
                e.Handled = true;
            }
        }

        private void Aceptar() {
            if (_grid.CurrentRow == null) {
                MessageBox.Show(this, "Seleccione una cuenta.", "Cuentas contables", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cuenta = _grid.CurrentRow.DataBoundItem as CuentaContable;
            if (cuenta == null || string.IsNullOrWhiteSpace(cuenta.NumCta)) {
                MessageBox.Show(this, "La cuenta seleccionada no es válida.", "Cuentas contables", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NumeroCuentaSeleccionada = cuenta.NumCta.Trim();
            DescripcionCuentaSeleccionada = (cuenta.Nombre ?? string.Empty).Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
