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
    public partial class TipoActivoCatalogoForm : Form {
        private readonly ITipoActivoService _service;
        private List<TipoActivo> _datos = new List<TipoActivo>();
        private bool _nuevo;

        public TipoActivoCatalogoForm(ITipoActivoService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            Text = "Catálogo de tipos de activo";
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.AutoGenerateColumns = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.MultiSelect = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            _grid.ColumnText("CLAVE", "Clave");
            _grid.ColumnText("Descripcion", "Descripción");
            _grid.AddColumnNumeric("DepresiacionNormal", "Ded. normal", "N4");
            _grid.AddColumnNumeric("DepresiacionInmediata", "Ded. inmediata", "N4");
            _grid.AddColumnNumeric("MaximoDepresiacion", "Máx. ded.", "N4");
            _grid.ColumnText("MetodoDepresiacion", "Método");
            _grid.AddColumnNumeric("DepresiacionProyectada", "Dep. proyectada", "N4");
            _grid.ColumnText("Moneda", "Moneda");

            _grid.CellDoubleClick += (s, e) => CargarSeleccion();
            _grid.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.Handled = true; CargarSeleccion(); } };

            _numClave.Minimum = 0;
            _numClave.Maximum = short.MaxValue;

            _txtDescripcion.MaxLength = 20;

            _txtMetodo.MaxLength = 1;

            _numMoneda.Minimum = 0;
            _numMoneda.Maximum = short.MaxValue;

            AgregarCampoDecimal(_numDedNormal);
            AgregarCampoDecimal(_numDedImed);
            AgregarCampoDecimal(_numMaxDed);
            AgregarCampoDecimal(_numDepProy);

            _txtCtaActivo.MaxLength = 21;
            _txtCtaDepre.MaxLength = 21;
            _txtCtaGastos.MaxLength = 21;
            _txtCtaGan.MaxLength = 21;

            _btnNuevo.Click += (s, e) => Nuevo();
            _btnGuardar.Click += async (s, e) => await GuardarAsync();
            _btnEliminar.Click += async (s, e) => await EliminarAsync();
            _btnCerrar.Click += (s, e) => Close();
            AcceptButton = _btnGuardar;
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
            string q = (_txtBuscar.Text ?? string.Empty).Trim();
            _grid.DataSource = string.IsNullOrEmpty(q)
                ? _datos
                : _datos.Where(x => x.Clave.ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                    || (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                    || (x.MetodoDepresiacion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        private void CargarSeleccion() {
            var item = _grid.CurrentRow == null ? null : _grid.CurrentRow.DataBoundItem as TipoActivo;
            if (item == null)
                return;
            _numClave.Value = item.Clave;
            _txtDescripcion.Text = item.Descripcion ?? string.Empty;
            _numDedNormal.Value = ToDecimal(item.DepresiacionNormal);
            _numDedImed.Value = ToDecimal(item.DepresiacionInmediata);
            _numMaxDed.Value = ToDecimal(item.MaximoDepresiacion);
            _txtMetodo.Text = item.MetodoDepresiacion ?? string.Empty;
            _numDepProy.Value = ToDecimal(item.DepresiacionProyectada);
            _txtCtaActivo.Text = item.CuentaActivo ?? string.Empty;
            _txtCtaDepre.Text = item.CuentaDepresiacion ?? string.Empty;
            _txtCtaGastos.Text = item.CuentaGastos ?? string.Empty;
            _txtCtaGan.Text = item.CuentaGanancias ?? string.Empty;
            _numMoneda.Value = item.Moneda ?? 0;
            _numClave.Enabled = false;
            _nuevo = false;
        }

        private void Nuevo() {
            Limpiar();
            _nuevo = true;
            _numClave.Enabled = true;
            _numClave.Focus();
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
                _numClave.Enabled = false;
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
                await _service.EliminarAsync(Convert.ToInt16(_numClave.Value));
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

        private TipoActivo ObtenerModelo() {
            return new TipoActivo {
                Clave = Convert.ToInt16(_numClave.Value),
                Descripcion = _txtDescripcion.Text,
                DepresiacionNormal = ToNullableDouble(_numDedNormal.Value),
                DepresiacionInmediata = ToNullableDouble(_numDedImed.Value),
                MaximoDepresiacion = ToNullableDouble(_numMaxDed.Value),
                MetodoDepresiacion = _txtMetodo.Text,
                DepresiacionProyectada = ToNullableDouble(_numDepProy.Value),
                CuentaActivo = _txtCtaActivo.Text,
                CuentaDepresiacion = _txtCtaDepre.Text,
                CuentaGastos = _txtCtaGastos.Text,
                CuentaGanancias = _txtCtaGan.Text,
                Moneda = _numMoneda.Value == 0 ? (short?)null : Convert.ToInt16(_numMoneda.Value)
            };
        }

        private void Limpiar() {
            _numClave.Value = 0;
            _txtDescripcion.Clear();
            _numDedNormal.Value = 0;
            _numDedImed.Value = 0;
            _numMaxDed.Value = 0;
            _txtMetodo.Clear();
            _numDepProy.Value = 0;
            _txtCtaActivo.Clear();
            _txtCtaDepre.Clear();
            _txtCtaGastos.Clear();
            _txtCtaGan.Clear();
            _numMoneda.Value = 0;
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
