using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    /// <summary>
    /// Formulario de mantenimiento de DEPTOS, CCOSTOS y CGRUPOS.
    /// </summary>
    public partial class PartidaCatalogoForm : Form {
        private enum Catalogo { Departamentos, CentrosCostos, Grupos }
        private readonly ICatalogosPartidaService _service;
        private List<object> _datos = new List<object>();
        private bool _nuevo;

        public PartidaCatalogoForm(ICatalogosPartidaService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            Construir();
            Shown += async (s, e) => await CargarAsync();
        }

        private void Construir() {
            var lblCatalogo = new Label { Text = "Catálogo:", Left = 12, Top = 16, AutoSize = true };
            _cmbCatalogo.Items.AddRange(new object[] { "Departamentos", "Centros de costos", "Grupos" });
            _cmbCatalogo.SelectedIndex = 0;
            _cmbCatalogo.SelectedIndexChanged += async (s, e) => { _nuevo = false; LimpiarEdicion(); await CargarAsync(); };

            _txtBuscar.TextChanged += (s, e) => Filtrar();
            _grid.AutoGenerateColumns = false;
            _grid.CellDoubleClick += (s, e) => CargarSeleccion();
            _grid.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.Handled = true; CargarSeleccion(); } };

            _btnNuevo.Click += (s, e) => Nuevo();
            _btnGuardar.Click += async (s, e) => await GuardarAsync();
            _btnEliminar.Click += async (s, e) => await EliminarAsync();
            _btnCerrar.Click += (s, e) => Close();

            ActualizarColumnas();
        }

        private Catalogo CatalogoActual { get { return (Catalogo)_cmbCatalogo.SelectedIndex; } }

        private async Task CargarAsync() {
            try {
                switch (CatalogoActual) {
                    case Catalogo.Departamentos:
                        _datos = (await _service.ObtenerDepartamentosAsync()).Cast<object>().ToList();
                        break;
                    case Catalogo.CentrosCostos:
                        _datos = (await _service.ObtenerCentrosCostosAsync()).Cast<object>().ToList();
                        break;
                    default:
                        _datos = (await _service.ObtenerGruposAsync()).Cast<object>().ToList();
                        break;
                }
                ActualizarColumnas();
                Filtrar();
            } catch (Exception ex) { MessageBox.Show(this, ex.Message, "Catálogos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ActualizarColumnas() {
            _grid.Columns.Clear();
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Código", Width = 100, DataPropertyName = CatalogoActual == Catalogo.Departamentos ? "DEPTO" : "ID" });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, DataPropertyName = CatalogoActual == Catalogo.Departamentos ? "DESCRIP" : "DESCRIPCION" });
        }

        private void Filtrar() {
            string q = (_txtBuscar.Text ?? string.Empty).Trim();
            IEnumerable<object> datos = _datos;
            if (!string.IsNullOrEmpty(q)) {
                datos = _datos.Where(x => ObtenerId(x).ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 || ObtenerDescripcion(x).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            _grid.DataSource = datos.ToList();
        }

        private void CargarSeleccion() {
            if (_grid.CurrentRow == null)
                return;
            var item = _grid.CurrentRow.DataBoundItem;
            if (item == null)
                return;
            _txtId.Text = ObtenerId(item).ToString();
            _txtDescripcion.Text = ObtenerDescripcion(item);
            _nuevo = false;
            _txtId.ReadOnly = true;
        }

        private void Nuevo() {
            _nuevo = true;
            _txtId.ReadOnly = false;
            _txtId.Clear();
            _txtDescripcion.Clear();
            _txtId.Focus();
        }

        private async Task GuardarAsync() {
            try {
                int id;
                if (!int.TryParse(_txtId.Text.Trim(), out id))
                    throw new ArgumentException("El código debe ser numérico.");
                if (CatalogoActual == Catalogo.Departamentos) {
                    if (id > short.MaxValue)
                        throw new ArgumentException("El departamento excede el valor permitido.");
                    if (_nuevo)
                        await _service.CrearDepartamentoAsync((short)id, _txtDescripcion.Text);
                    else
                        await _service.ActualizarDepartamentoAsync((short)id, _txtDescripcion.Text);
                } else if (CatalogoActual == Catalogo.CentrosCostos) {
                    if (_nuevo)
                        await _service.CrearCentroCostoAsync(id, _txtDescripcion.Text);
                    else
                        await _service.ActualizarCentroCostoAsync(id, _txtDescripcion.Text);
                } else {
                    if (_nuevo)
                        await _service.CrearGrupoAsync(id, _txtDescripcion.Text);
                    else
                        await _service.ActualizarGrupoAsync(id, _txtDescripcion.Text);
                }
                MessageBox.Show(this, _nuevo ? "Registro creado correctamente." : "Registro actualizado correctamente.", "Catálogos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _nuevo = false;
                _txtId.ReadOnly = true;
                await CargarAsync();
            } catch (ArgumentException ex) { MessageBox.Show(this, ex.Message, "Catálogos", MessageBoxButtons.OK, MessageBoxIcon.Warning); } catch (InvalidOperationException ex) { MessageBox.Show(this, ex.Message, "Catálogos", MessageBoxButtons.OK, MessageBoxIcon.Warning); } catch (Exception ex) { MessageBox.Show(this, "No fue posible guardar el registro: " + ex.Message, "Catálogos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task EliminarAsync() {
            try {
                int id;
                if (!int.TryParse(_txtId.Text.Trim(), out id))
                    throw new ArgumentException("Seleccione un registro para eliminar.");
                if (MessageBox.Show(this, "¿Desea eliminar el registro seleccionado?", "Catálogos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                if (CatalogoActual == Catalogo.Departamentos)
                    await _service.EliminarDepartamentoAsync((short)id);
                else if (CatalogoActual == Catalogo.CentrosCostos)
                    await _service.EliminarCentroCostoAsync(id);
                else
                    await _service.EliminarGrupoAsync(id);
                LimpiarEdicion();
                await CargarAsync();
            } catch (Exception ex) { MessageBox.Show(this, ex.Message, "Catálogos", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void LimpiarEdicion() { _txtId.Clear(); _txtDescripcion.Clear(); _txtId.ReadOnly = false; }
        private static int ObtenerId(object item) { var d = item as Departamento; return d != null ? d.DEPTO : item is CentroCosto ? ((CentroCosto)item).Id : ((GrupoContable)item).Id; }
        private static string ObtenerDescripcion(object item) { var d = item as Departamento; return d != null ? d.DESCRIP ?? string.Empty : item is CentroCosto ? ((CentroCosto)item).Descripcion ?? string.Empty : ((GrupoContable)item).Descripcion ?? string.Empty; }
    }
}
