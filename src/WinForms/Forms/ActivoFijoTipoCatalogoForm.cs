using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.WinForms.Context;

namespace Jaeger.Contable.WinForms.Forms {
    /// <summary>
    /// Formulario de mantenimiento del catálogo TIPACTIV.
    /// </summary>
    public partial class ActivoFijoTipoCatalogoForm : Form {
        private readonly IActivoFijoTipoService _service;
        private readonly ICuentaService _cuentaService;
        private List<ActivoFijoTipo> _datos = new List<ActivoFijoTipo>();
        private List<Moneda> _monedas = new List<Moneda>();
        private bool _nuevo;
        private bool _catalogosCargados;

        public ActivoFijoTipoCatalogoForm(IActivoFijoTipoService service, ICuentaService cuentaService) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _cuentaService = cuentaService ?? throw new ArgumentNullException(nameof(cuentaService));
            InitializeComponent();
            Text = "Catálogo de tipos de activo";
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AllowUserToDeleteRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridData.MultiSelect = false;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var colMoneda = gridData.Columns["IdMoneda"] as DataGridViewComboBoxColumn;
            colMoneda.DisplayMember = "Nombre";
            colMoneda.ValueMember = "IdMoneda";
            colMoneda.DataPropertyName = "IdMoneda";

            gridData.CellDoubleClick += (s, e) => CargarSeleccion();
            gridData.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.Handled = true; CargarSeleccion(); } };

            numClave.Minimum = 0;
            numClave.Maximum = short.MaxValue;

            txtDescripcion.MaxLength = 20;

            txtMetodo.MaxLength = 1;

            numMoneda.Minimum = 0;
            numMoneda.Maximum = short.MaxValue;

            numDedNormal.ToNumericUpDown(4);
            numDedImed.ToNumericUpDown(4);
            numMaxDepresiacion.ToNumericUpDown(4);
            numDepProyectada.ToNumericUpDown(4);

            txtCtaActivo.MaxLength = 21;
            txtCtaDepre.MaxLength = 21;
            txtCtaGastos.MaxLength = 21;
            txtCtaGan.MaxLength = 21;

            btnNuevo.Click += (s, e) => Nuevo();
            btnGuardar.Click += async (s, e) => await GuardarAsync();
            btnEliminar.Click += async (s, e) => await EliminarAsync();
            btnCuentaActivo.Click += btnCuenta_Click;
            btnCuentaDepresia.Click += btnCuenta_Click;
            btnCuentaGanancia.Click += btnCuenta_Click;
            btnCuentaGastos.Click += btnCuenta_Click;
            btnCerrar.Click += (s, e) => Close();
            AcceptButton = btnGuardar;
            Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            try {
                await CargarCatalogosAsync();
                _datos = await _service.ObtenerTodosAsync();
                var monedas = await _service.ObtenerMonedasAsync();

                Filtrar();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Tipos de activo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtrar() {
            string q = (txtBuscar.Text ?? string.Empty).Trim();
            gridData.DataSource = string.IsNullOrEmpty(q)
                ? _datos
                : _datos.Where(x => x.Clave.ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                    || (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                    || (x.MetodoDepresiacion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        private void CargarSeleccion() {
            var item = gridData.CurrentRow == null ? null : gridData.CurrentRow.DataBoundItem as ActivoFijoTipo;
            if (item == null)
                return;
            numClave.Value = item.Clave;
            txtDescripcion.Text = item.Descripcion ?? string.Empty;
            numDedNormal.Value = GridViewExtensions.SetValueDecimal(item.DepresiacionNormal);
            numDedImed.Value = GridViewExtensions.SetValueDecimal(item.DepresiacionInmediata);
            numMaxDepresiacion.Value = GridViewExtensions.SetValueDecimal(item.MaximoDepresiacion);
            txtMetodo.Text = item.MetodoDepresiacion ?? string.Empty;
            numDepProyectada.Value = GridViewExtensions.SetValueDecimal(item.DepresiacionProyectada);
            txtCtaActivo.Text = item.CuentaActivo ?? string.Empty;
            txtCtaDepre.Text = item.CuentaDepresiacion ?? string.Empty;
            txtCtaGastos.Text = item.CuentaGastos ?? string.Empty;
            txtCtaGan.Text = item.CuentaGanancias ?? string.Empty;
            numMoneda.Value = item.IdMoneda ?? 0;
            numClave.Enabled = false;
            _nuevo = false;
        }

        private void Nuevo() {
            Limpiar();
            _nuevo = true;
            numClave.Enabled = true;
            numClave.Focus();
        }

        private async Task GuardarAsync() {
            try {
                var modelo = ObtenerModelo();
                if (_nuevo)
                    await _service.CrearAsync(modelo);
                else
                    await _service.ActualizarAsync(modelo);
                MessageBox.Show(this, _nuevo ? "Tipo de activo creado correctamente." : "Tipo de activo actualizado correctamente.", "Tipos de activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _nuevo = false;
                numClave.Enabled = false;
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Tipos de activo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Tipos de activo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible guardar el tipo de activo: " + ex.Message, "Tipos de activo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarAsync() {
            if (MessageBox.Show(this, "¿Desea eliminar el tipo de activo seleccionado?", "Tipos de activo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try {
                await _service.EliminarAsync(Convert.ToInt16(numClave.Value));
                Limpiar();
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Tipos de activo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Tipos de activo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible eliminar el tipo de activo: " + ex.Message, "Tipos de activo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarCatalogosAsync() {
            if (_catalogosCargados)
                return;

            var monedas = await _service.ObtenerMonedasAsync();
            _monedas = (monedas ?? new List<Moneda>())
                .OrderBy(x => x.Nombre)
                .ToList();

            ActualizarCatalogoCombo("IdMoneda", _monedas);
            _catalogosCargados = true;
        }

        private void btnCuenta_Click(object sender, EventArgs e) {
            var button = sender as Button;
            if (button == null)
                return;

            using (var form = new CuentaContableSelectorForm(_cuentaService)) {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;
                if (sender == btnCuentaActivo)
                    txtCtaActivo.Text = form.NumeroCuentaSeleccionada ?? string.Empty;
                else if (sender == btnCuentaDepresia)
                    txtCtaDepre.Text = form.NumeroCuentaSeleccionada ?? string.Empty;
                else if (sender == btnCuentaGastos)
                    txtCtaGastos.Text = form.NumeroCuentaSeleccionada ?? string.Empty;
                else if (sender == btnCuentaGanancia)
                    txtCtaGan.Text = form.NumeroCuentaSeleccionada ?? string.Empty;
            }
        }

        private ActivoFijoTipo ObtenerModelo() {
            return new ActivoFijoTipo {
                Clave = Convert.ToInt16(numClave.Value),
                Descripcion = txtDescripcion.Text,
                DepresiacionNormal = GridViewExtensions.ToNullableDouble(numDedNormal.Value),
                DepresiacionInmediata = GridViewExtensions.ToNullableDouble(numDedImed.Value),
                MaximoDepresiacion = GridViewExtensions.ToNullableDouble(numMaxDepresiacion.Value),
                MetodoDepresiacion = txtMetodo.Text,
                DepresiacionProyectada = GridViewExtensions.ToNullableDouble(numDepProyectada.Value),
                CuentaActivo = txtCtaActivo.Text,
                CuentaDepresiacion = txtCtaDepre.Text,
                CuentaGastos = txtCtaGastos.Text,
                CuentaGanancias = txtCtaGan.Text,
                IdMoneda = numMoneda.Value == 0 ? (short?)null : Convert.ToInt16(numMoneda.Value)
            };
        }

        private void Limpiar() {
            numClave.Value = 0;
            txtDescripcion.Clear();
            numDedNormal.Value = 0;
            numDedImed.Value = 0;
            numMaxDepresiacion.Value = 0;
            txtMetodo.Clear();
            numDepProyectada.Value = 0;
            txtCtaActivo.Clear();
            txtCtaDepre.Clear();
            txtCtaGastos.Clear();
            txtCtaGan.Clear();
            numMoneda.Value = 0;
        }

        private void ActualizarCatalogoCombo(string nombreColumna, object fuente) {
            var columna = this.gridData.Columns[nombreColumna] as DataGridViewComboBoxColumn;
            if (columna == null)
                return;

            columna.DataSource = null;
            columna.DataSource = fuente;
        }
    }
}
