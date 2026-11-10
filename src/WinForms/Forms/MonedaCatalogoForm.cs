using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    /// <summary>
    /// Formulario de mantenimiento del catálogo MONEDAS.
    /// </summary>
    public partial class MonedaCatalogoForm : Form {
        private readonly IMonedaService _service;
        private List<Moneda> _datos = new List<Moneda>();
        private bool IsNuevo;

        public MonedaCatalogoForm(IMonedaService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            Text = "Catálogo de monedas";
            txtBuscar.TextChanged += (s, e) => Filtrar();

            gridData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AllowUserToDeleteRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridData.MultiSelect = false;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridData.Columns.Add(CrearColumna("IdMoneda", "Código", 60));
            gridData.Columns.Add(CrearColumna("Nombre", "Nombre", 180));
            gridData.Columns.Add(CrearColumna("Prefijo", "Prefijo", 80));
            gridData.Columns.Add(CrearColumna("Fecha", "Fecha", 110, "dd/MM/yyyy"));
            gridData.Columns.Add(CrearColumna("TipoCambio", "Tipo cambio", 100, "N6"));
            gridData.Columns.Add(CrearColumna("Monto", "Monto", 100, "N6"));
            gridData.Columns.Add(CrearColumna("DESPAUTO", "Desp. auto", 80));
            gridData.Columns.Add(CrearColumna("CveSAT", "SAT", 80));
            gridData.CellDoubleClick += (s, e) => CargarSeleccion();
            gridData.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) {
                    e.Handled = true;
                    CargarSeleccion();
                }
            };

            numMoneda.Maximum = short.MaxValue;
            numMoneda.Minimum = 0;

            txtNombre.MaxLength = 20;

            txtPrefijo.MaxLength = 4;

            chkFecha.CheckedChanged += (s, e) => dtFecha.Enabled = chkFecha.Checked;

            dtFecha.Format = DateTimePickerFormat.Short;
            dtFecha.Enabled = false;

            ConfigurarDecimal(numTipoCambio, 6);

            ConfigurarDecimal(numMonto, 6);

            txtDespAuto.MaxLength = 1;

            txtClassSat.MaxLength = 3;

            btnNuevo.Click += (s, e) => Nuevo();
            btnGuardar.Click += async (s, e) => await GuardarAsync();
            btnEliminar.Click += async (s, e) => await EliminarAsync();
            btnCerrar.Click += (s, e) => Close();

            AcceptButton = btnGuardar;
            Shown += async (s, e) => await CargarAsync();
        }

        private static DataGridViewTextBoxColumn CrearColumna(string propiedad, string titulo, int minimo, string formato = null) {
            return new DataGridViewTextBoxColumn {
                DataPropertyName = propiedad,
                HeaderText = titulo,
                Name = propiedad,
                MinimumWidth = minimo,
                ReadOnly = true,
                DefaultCellStyle = { Format = formato }
            };
        }

        private static void ConfigurarDecimal(NumericUpDown control, int decimales) {
            control.DecimalPlaces = decimales;
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
                MessageBox.Show(this, ex.Message, "Monedas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtrar() {
            string q = (txtBuscar.Text ?? string.Empty).Trim();
            var datos = string.IsNullOrEmpty(q)
                ? _datos
                : _datos.Where(x => x.IdMoneda.ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                    || (x.Nombre ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                    || (x.Prefijo ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            gridData.DataSource = datos;
        }

        private void CargarSeleccion() {
            var item = gridData.CurrentRow == null ? null : gridData.CurrentRow.DataBoundItem as Moneda;
            if (item == null)
                return;

            numMoneda.Value = item.IdMoneda;
            txtNombre.Text = item.Nombre ?? string.Empty;
            txtPrefijo.Text = item.Prefijo ?? string.Empty;
            chkFecha.Checked = item.Fecha.HasValue;
            dtFecha.Value = item.Fecha ?? DateTime.Today;
            numTipoCambio.Value = ToDecimal(item.TipoCambio);
            numMonto.Value = ToDecimal(item.Monto);
            txtDespAuto.Text = item.DESPAUTO ?? string.Empty;
            txtClassSat.Text = item.CveSAT ?? string.Empty;
            numMoneda.Enabled = false;
            IsNuevo = false;
        }

        private void Nuevo() {
            Limpiar();
            IsNuevo = true;
            numMoneda.Enabled = true;
            numMoneda.Focus();
        }

        private async Task GuardarAsync() {
            try {
                var moneda = ObtenerModelo();
                if (IsNuevo)
                    await _service.CrearAsync(moneda);
                else
                    await _service.ActualizarAsync(moneda);

                MessageBox.Show(this, IsNuevo ? "Moneda creada correctamente." : "Moneda actualizada correctamente.", "Monedas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsNuevo = false;
                numMoneda.Enabled = false;
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Monedas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Monedas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible guardar la moneda: " + ex.Message, "Monedas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarAsync() {
            try {
                short codigo = Convert.ToInt16(numMoneda.Value);
                if (MessageBox.Show(this, "¿Desea eliminar la moneda seleccionada?", "Monedas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                await _service.EliminarAsync(codigo);
                Limpiar();
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Monedas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Monedas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Monedas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Moneda ObtenerModelo() {
            return new Moneda {
                IdMoneda = Convert.ToInt16(numMoneda.Value),
                Nombre = txtNombre.Text,
                Prefijo = txtPrefijo.Text,
                Fecha = chkFecha.Checked ? dtFecha.Value.Date : (DateTime?)null,
                TipoCambio = Convert.ToDouble(numTipoCambio.Value),
                Monto = Convert.ToDouble(numMonto.Value),
                DESPAUTO = txtDespAuto.Text,
                CveSAT = txtClassSat.Text
            };
        }

        private static decimal ToDecimal(double? valor) {
            if (!valor.HasValue)
                return 0m;
            if (valor.Value > (double)decimal.MaxValue || valor.Value < (double)decimal.MinValue)
                return 0m;
            return Convert.ToDecimal(valor.Value);
        }

        private void Limpiar() {
            numMoneda.Value = 0;
            txtNombre.Clear();
            txtPrefijo.Clear();
            chkFecha.Checked = false;
            dtFecha.Value = DateTime.Today;
            numTipoCambio.Value = 0;
            numMonto.Value = 0;
            txtDespAuto.Clear();
            txtClassSat.Clear();
        }
    }
}
