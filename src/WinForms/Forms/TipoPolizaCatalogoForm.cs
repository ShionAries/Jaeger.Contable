using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    public partial class TipoPolizaCatalogoForm : Form {
        private readonly ITipoPolizaService _service;
        private List<TipoPoliza> _datos = new List<TipoPoliza>();
        private bool _nuevo;

        public TipoPolizaCatalogoForm(ITipoPolizaService service) {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Shown += async (s, e) => await CargarAsync();
        }

        private void TipoPolizaCatalogoForm_Load(object sender, EventArgs e) {
            txtBuscar.TextChanged += (s, ev) => Filtrar();
            grid.CellDoubleClick += (s, ev) => CargarSeleccion();
            grid.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { ev.Handled = true; CargarSeleccion(); } };

            btnNuevo.Click += (s, ev) => Nuevo();
            btnGuardar.Click += async (s, ev) => await GuardarAsync();
            btnEliminar.Click += async (s, ev) => await EliminarAsync();
            btnCerrar.Click += (s, ev) => Close();
            AcceptButton = btnGuardar;
            CancelButton = btnCerrar;
        }

        private async Task CargarAsync() {
            try {
                _datos = await _service.ObtenerTodosAsync();
                Filtrar();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtrar() {
            string q = (txtBuscar.Text ?? string.Empty).Trim();
            grid.DataSource = string.IsNullOrEmpty(q)
                ? _datos.ToList()
                : _datos.Where(x => (x.Tipo ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 || (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        private void CargarSeleccion() {
            var item = grid.CurrentRow == null ? null : grid.CurrentRow.DataBoundItem as TipoPoliza;
            if (item == null)
                return;
            txtTipo.Text = item.Tipo;
            txtDescripcion.Text = item.Descripcion;
            numClassAt.Value = item.ClaveSAT.HasValue ? item.ClaveSAT.Value : 0;
            txtTipo.ReadOnly = true;
            _nuevo = false;
        }

        private void Nuevo() {
            _nuevo = true;
            txtTipo.ReadOnly = false;
            txtTipo.Clear();
            txtDescripcion.Clear();
            numClassAt.Value = 0;
            txtTipo.Focus();
        }

        private async Task GuardarAsync() {
            try {
                int? classAt = numClassAt.Value == 0 ? (int?)null : Decimal.ToInt32(numClassAt.Value);
                if (_nuevo)
                    await _service.CrearAsync(txtTipo.Text, txtDescripcion.Text, classAt);
                else
                    await _service.ActualizarAsync(txtTipo.Text, txtDescripcion.Text, classAt);
                MessageBox.Show(this, _nuevo ? "Tipo de póliza creado correctamente." : "Tipo de póliza actualizado correctamente.", "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _nuevo = false;
                txtTipo.ReadOnly = true;
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible guardar el tipo de póliza: " + ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarAsync() {
            try {
                if (string.IsNullOrWhiteSpace(txtTipo.Text))
                    throw new ArgumentException("Seleccione un tipo de póliza.");
                if (MessageBox.Show(this, "¿Desea eliminar el tipo de póliza seleccionado?", "Tipos de póliza", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                await _service.EliminarAsync(txtTipo.Text);
                Limpiar();
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar() {
            txtTipo.Clear();
            txtDescripcion.Clear();
            numClassAt.Value = 0;
            txtTipo.ReadOnly = false;
            _nuevo = false;
        }
    }
}
