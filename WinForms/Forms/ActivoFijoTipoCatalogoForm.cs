using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.WinForms.Context;

namespace Jaeger.Contable.WinForms.Forms {
    /// <summary>
    /// Formulario de mantenimiento del catálogo TIPACTIV.
    /// </summary>
    public partial class ActivoFijoTipoCatalogoForm : Form {
        private readonly IActivoFijoTipoService _service;
        private List<ActivoFijoTipo> _datos = new List<ActivoFijoTipo>();
        private bool _nuevo;

        public ActivoFijoTipoCatalogoForm(IActivoFijoTipoService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            Text = "Catálogo de tipos de activo";
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AllowUserToDeleteRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridData.MultiSelect = false;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridData.ColumnText("CLAVE", "Clave");
            gridData.ColumnText("Descripcion", "Descripción");
            gridData.AddColumnNumeric("DepresiacionNormal", "Ded. normal", "N4");
            gridData.AddColumnNumeric("DepresiacionInmediata", "Ded. inmediata", "N4");
            gridData.AddColumnNumeric("MaximoDepresiacion", "Máx. ded.", "N4");
            gridData.ColumnText("MetodoDepresiacion", "Método");
            gridData.AddColumnNumeric("DepresiacionProyectada", "Dep. proyectada", "N4");
            gridData.ColumnText("Moneda", "Moneda");

            gridData.CellDoubleClick += (s, e) => CargarSeleccion();
            gridData.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.Handled = true; CargarSeleccion(); } };

            numClave.Minimum = 0;
            numClave.Maximum = short.MaxValue;

            txtDescripcion.MaxLength = 20;

            txtMetodo.MaxLength = 1;

            numMoneda.Minimum = 0;
            numMoneda.Maximum = short.MaxValue;

            AgregarCampoDecimal(numDedNormal);
            AgregarCampoDecimal(numDedImed);
            AgregarCampoDecimal(numMaxDepresiacion);
            AgregarCampoDecimal(numDepProyectada);

            txtCtaActivo.MaxLength = 21;
            txtCtaDepre.MaxLength = 21;
            txtCtaGastos.MaxLength = 21;
            txtCtaGan.MaxLength = 21;

            btnNuevo.Click += (s, e) => Nuevo();
            btnGuardar.Click += async (s, e) => await GuardarAsync();
            btnEliminar.Click += async (s, e) => await EliminarAsync();
            btnCerrar.Click += (s, e) => Close();
            AcceptButton = btnGuardar;
            Shown += async (s, e) => await CargarAsync();
        }

        private void AgregarCampoDecimal(NumericUpDown control) {
            control.DecimalPlaces = 6;
            control.Maximum = 999999999999999m;
            control.Minimum = -999999999999999m;
            control.Increment = 0.000001m;
            control.ThousandsSeparator = true;
            control.TextAlign = HorizontalAlignment.Right;
        }

        private async Task CargarAsync() {
            try {
                _datos = await _service.ObtenerTodosAsync();
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
            numDedNormal.Value = ToDecimal(item.DepresiacionNormal);
            numDedImed.Value = ToDecimal(item.DepresiacionInmediata);
            numMaxDepresiacion.Value = ToDecimal(item.MaximoDepresiacion);
            txtMetodo.Text = item.MetodoDepresiacion ?? string.Empty;
            numDepProyectada.Value = ToDecimal(item.DepresiacionProyectada);
            txtCtaActivo.Text = item.CuentaActivo ?? string.Empty;
            txtCtaDepre.Text = item.CuentaDepresiacion ?? string.Empty;
            txtCtaGastos.Text = item.CuentaGastos ?? string.Empty;
            txtCtaGan.Text = item.CuentaGanancias ?? string.Empty;
            numMoneda.Value = item.Moneda ?? 0;
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

        private ActivoFijoTipo ObtenerModelo() {
            return new ActivoFijoTipo {
                Clave = Convert.ToInt16(numClave.Value),
                Descripcion = txtDescripcion.Text,
                DepresiacionNormal = ToNullableDouble(numDedNormal.Value),
                DepresiacionInmediata = ToNullableDouble(numDedImed.Value),
                MaximoDepresiacion = ToNullableDouble(numMaxDepresiacion.Value),
                MetodoDepresiacion = txtMetodo.Text,
                DepresiacionProyectada = ToNullableDouble(numDepProyectada.Value),
                CuentaActivo = txtCtaActivo.Text,
                CuentaDepresiacion = txtCtaDepre.Text,
                CuentaGastos = txtCtaGastos.Text,
                CuentaGanancias = txtCtaGan.Text,
                Moneda = numMoneda.Value == 0 ? (short?)null : Convert.ToInt16(numMoneda.Value)
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

        private static decimal ToDecimal(double? value) {
            if (!value.HasValue || double.IsNaN(value.Value) || double.IsInfinity(value.Value))
                return 0m;
            if (value.Value > (double)decimal.MaxValue)
                return decimal.MaxValue;
            if (value.Value < (double)decimal.MinValue)
                return decimal.MinValue;
            return Convert.ToDecimal(value.Value);
        }

        private static double? ToNullableDouble(decimal value) {
            return Convert.ToDouble(value);
        }
    }
}
