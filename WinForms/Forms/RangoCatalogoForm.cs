using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    public partial class RangoCatalogoForm : Form {
        private readonly IRangoService _service;
        private List<RubroContableModel> _datos = new List<RubroContableModel>();
        private bool _IsNew;

        public RangoCatalogoForm(IRangoService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            Shown += async (s, e) => await CargarAsync();
        }

        private void RangoCatalogoForm_Load(object sender, EventArgs e) {
            AcceptButton = btnGuardar;
            this.gridRangos.AutoGenerateColumns = false;
            txtBuscar.TextChanged += (s, ev) => Filtrar();
            gridRangos.CellDoubleClick += (s, ev) => CargarSeleccion();
            btnNuevo.Click += (s, ev) => Nuevo();
            btnGuardar.Click += async (s, ev) => await GuardarAsync();
            btnEliminar.Click += async (s, ev) => await EliminarAsync();
            btnCerrar.Click += (s, ev) => Close();
        }

        private async Task CargarAsync() {
            try {
                _datos = await _service.ListarRangosAsync();
                Filtrar();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtrar() {
            string q = (txtBuscar.Text ?? string.Empty).Trim();
            gridRangos.DataSource = string.IsNullOrEmpty(q) ? _datos.ToList() : _datos.Where(x => x.Rango.ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 || (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        private void CargarSeleccion() {
            var item = gridRangos.CurrentRow == null ? null : gridRangos.CurrentRow.DataBoundItem as RubroContableModel;
            if (item == null)
                return;
            txtId.Text = item.Rango.ToString();
            txtDescripcion.Text = item.Descripcion;
            txtId.ReadOnly = true;
            _IsNew = false;
        }

        private void Nuevo() {
            _IsNew = true;
            txtId.ReadOnly = false;
            txtId.Clear();
            txtDescripcion.Clear();
            txtId.Focus();
        }

        private async Task GuardarAsync() {
            try {
                int id;
                if (!int.TryParse(txtId.Text.Trim(), out id))
                    throw new ArgumentException("El rango debe ser numérico.");
                if (_IsNew)
                    await _service.CrearAsync(id, txtDescripcion.Text);
                else
                    await _service.ActualizarAsync(id, txtDescripcion.Text);
                MessageBox.Show(this, _IsNew ? "Rango creado correctamente." : "Rango actualizado correctamente.", "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _IsNew = false;
                txtId.ReadOnly = true;
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible guardar el rango: " + ex.Message, "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarAsync() {
            try {
                int id;
                if (!int.TryParse(txtId.Text.Trim(), out id))
                    throw new ArgumentException("Seleccione un rango.");
                if (MessageBox.Show(this, "¿Desea eliminar el rango seleccionado?", "Rangos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                await _service.EliminarAsync(id);
                Limpiar();
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar() {
            txtId.Clear();
            txtDescripcion.Clear();
            txtId.ReadOnly = false;
            _IsNew = false;
        }
    }
}
