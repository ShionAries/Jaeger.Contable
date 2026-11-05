using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    public partial class ConceptoPolizaCatalogoForm : Form {
        private readonly IConceptoService _service;
        private List<Concepto> _conceptos = new List<Concepto>();
        private int? _conceptoActual;

        public ConceptoPolizaCatalogoForm(IConceptoService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            btnNuevo.Click += async (s, e) => await NuevoAsync();
            btnGuardar.Click += async (s, e) => await GuardarAsync();
            btnEliminar.Click += async (s, e) => await EliminarAsync();
            gridData.CellDoubleClick += (s, e) => CargarSeleccionado();
            gridData.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) {
                    e.Handled = true;
                    CargarSeleccionado();
                }
            };
            btnCerrar.Click += (s, e) => Close();
            Shown += async (s, e) => await CargarAsync();
        }

        private void ConceptoPolizaCatalogoForm_Load(object sender, EventArgs e) {

        }

        private async Task CargarAsync() {
            try {
                _conceptos = await _service.ObtenerTodosAsync() ?? new List<Concepto>();
                RefrescarGrid();
                PrepararNuevo();
            } catch (Exception ex) {
                MostrarError(ex);
            }
        }

        private async Task NuevoAsync() {
            try {
                int siguiente = await _service.ObtenerSiguienteNumeroAsync();
                _conceptoActual = null;
                txtCodigo.Text = siguiente.ToString();
                txtDescripcion.Text = string.Empty;
                txtDescripcion.Focus();
            } catch (Exception ex) {
                MostrarError(ex);
            }
        }

        private async Task GuardarAsync() {
            try {
                if (!_conceptoActual.HasValue) {
                    var nuevo = await _service.CrearAsync(txtDescripcion.Text);
                    _conceptoActual = nuevo.IdConcepto;
                    txtCodigo.Text = nuevo.IdConcepto.ToString();
                    await RecargarAsync();
                    MessageBox.Show(this, "Concepto creado correctamente.", "Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                await _service.ActualizarAsync(_conceptoActual.Value, txtDescripcion.Text);
                await RecargarAsync();
                MessageBox.Show(this, "Concepto actualizado correctamente.", "Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MostrarError(ex);
            }
        }

        private async Task EliminarAsync() {
            try {
                if (!_conceptoActual.HasValue)
                    throw new InvalidOperationException("Seleccione un concepto para eliminar.");

                if (MessageBox.Show(
                    this,
                    "¿Desea eliminar el concepto " + _conceptoActual.Value + "?",
                    "Eliminar concepto",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                await _service.EliminarAsync(_conceptoActual.Value);
                await RecargarAsync();
                MessageBox.Show(this, "Concepto eliminado correctamente.", "Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MostrarError(ex);
            }
        }

        private async Task RecargarAsync() {
            _conceptos = await _service.ObtenerTodosAsync() ?? new List<Concepto>();
            RefrescarGrid();
        }

        private void RefrescarGrid() {
            gridData.DataSource = null;
            gridData.DataSource = _conceptos;
        }

        private void CargarSeleccionado() {
            if (gridData.CurrentRow == null)
                return;

            var concepto = gridData.CurrentRow.DataBoundItem as Concepto;
            if (concepto == null)
                return;

            _conceptoActual = concepto.IdConcepto;
            txtCodigo.Text = concepto.IdConcepto.ToString();
            txtDescripcion.Text = concepto.Descripcion ?? string.Empty;
            txtDescripcion.Focus();
        }

        private void PrepararNuevo() {
            _conceptoActual = null;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void MostrarError(Exception ex) {
            MessageBox.Show(this, ex.Message, "Conceptos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
