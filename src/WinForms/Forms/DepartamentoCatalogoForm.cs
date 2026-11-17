using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    public partial class DepartamentoCatalogoForm : Form {
        private readonly Application.Contracts.IDepartamentoService _service;
        private List<Departamento> _datos = new List<Departamento>();
        private bool IsNuevo;
        public DepartamentoCatalogoForm(Application.Contracts.IDepartamentoService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            Text = "Catálogo de Departamentos";
            txtBuscar.TextChanged += (s, e) => Filtrar();

            gridData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AllowUserToDeleteRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridData.MultiSelect = false;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridData.CellDoubleClick += (s, e) => CargarSeleccion();
            gridData.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) {
                    e.Handled = true;
                    CargarSeleccion();
                }
            };

            CodigoDepto.Maximum = short.MaxValue;
            CodigoDepto.Minimum = 0;

            txtNombre.MaxLength = 20;

            btnNuevo.Click += (s, e) => Nuevo();
            btnGuardar.Click += async (s, e) => await GuardarAsync();
            btnEliminar.Click += async (s, e) => await EliminarAsync();
            btnCerrar.Click += (s, e) => Close();

            AcceptButton = btnGuardar;
            Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            try {
                _datos = await _service.ObtenerTodosAsync();
                Filtrar();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Departamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtrar() {
            string q = (txtBuscar.Text ?? string.Empty).Trim();
            var datos = string.IsNullOrEmpty(q)
                ? _datos
                : _datos.Where(x => x.IdDepartamento.ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                    || (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            gridData.DataSource = datos;
        }

        private void CargarSeleccion() {
            var item = gridData.CurrentRow == null ? null : gridData.CurrentRow.DataBoundItem as Departamento;
            if (item == null)
                return;

            CodigoDepto.Value = item.IdDepartamento;
            txtNombre.Text = item.Descripcion ?? string.Empty;
            
            CodigoDepto.Enabled = false;
            IsNuevo = false;
        }

        private void Nuevo() {
            Limpiar();
            IsNuevo = true;
            CodigoDepto.Enabled = true;
            CodigoDepto.Focus();
        }

        private async Task GuardarAsync() {
            try {
                var moneda = ObtenerModelo();
                if (IsNuevo)
                    await _service.CrearAsync(moneda);
                else
                    await _service.ActualizarAsync(moneda);

                MessageBox.Show(this, IsNuevo ? "Departamento creado correctamente." : "Departamento actualizado correctamente.", "Departamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsNuevo = false;
                CodigoDepto.Enabled = false;
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Departamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Departamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible guardar el departamento: " + ex.Message, "Departamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarAsync() {
            try {
                short codigo = Convert.ToInt16(CodigoDepto.Value);
                if (MessageBox.Show(this, "¿Desea eliminar el departamento seleccionado?", "Departamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                await _service.EliminarAsync(codigo);
                Limpiar();
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Departamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Departamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Departamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Departamento ObtenerModelo() {
            return new Departamento {
                IdDepartamento= Convert.ToInt16(CodigoDepto.Value),
                Descripcion = txtNombre.Text,
            };
        }

        private void Limpiar() {
            CodigoDepto.Value = 0;
            txtNombre.Clear();
        }
    }
}
