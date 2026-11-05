using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.WinForms.Context;
using Jaeger.Contable.WinForms.Forms;

namespace Jaeger.Contable {
    public partial class PolizaCapturaMovimientoForm : Form {
        private ToolTip _toolTip = new ToolTip();
        private readonly IPolizaCapturaMovimientoContext _context;
        private readonly string _conceptoPoliza;
        private bool _cargandoMonedas;

        public MovimientoContableRequest Movimiento { get; private set; }

        public PolizaCapturaMovimientoForm(IPolizaCapturaMovimientoContext context, string conceptoPoliza, MovimientoContableRequest movimientoInicial = null) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _conceptoPoliza = conceptoPoliza == null ? string.Empty : conceptoPoliza.Trim();
            InitializeComponent();
            InicializarDebeHaber();
            txtConcepto.ReadOnly = false;
            txtConcepto.Text = _conceptoPoliza;
            this.btnCuenta.Click += (s, e) => SeleccionarCuenta();

            CrearCamposDescripcion();
            CrearSelectorMoneda();

            btnDepto.Click += (s, e) => SeleccionarDepartamento();
            btnCosto.Click += (s, e) => SeleccionarCentroCosto();
            btnGrupo.Click += (s, e) => SeleccionarGrupo();

            CrearToolTips();

            Load += async (s, e) => {
                await CargarMonedasAsync();

                if (movimientoInicial != null)
                    await CargarMovimientoInicialAsync(movimientoInicial);
            };
        }

        private void CrearSelectorMoneda() {
            cmbMoneda.SelectedIndexChanged += async (s, e) => await MonedaSeleccionadaAsync();

            txtTipoCambio.DecimalPlaces = 6;
            txtTipoCambio.Increment = 0.000001M;
        }

        private async Task CargarMonedasAsync() {
            try {
                _cargandoMonedas = true;
                var monedas = await _context.MonedaService.ObtenerTodosAsync();
                cmbMoneda.DataSource = monedas;
                cmbMoneda.ValueMember = "IdMoneda";
                cmbMoneda.FormattingEnabled = true;
                cmbMoneda.Format += (s, e) => {
                    var moneda = e.ListItem as Moneda;
                    if (moneda != null)
                        e.Value = string.Format("{0} - {1}", moneda.IdMoneda, moneda.Nombre ?? string.Empty);
                };
                cmbMoneda.SelectedIndex = -1;
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible cargar MONEDAS: " + ex.Message, "Moneda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } finally {
                _cargandoMonedas = false;
            }
        }

        private async Task MonedaSeleccionadaAsync() {
            if (_cargandoMonedas || cmbMoneda == null || cmbMoneda.SelectedIndex < 0 || cmbMoneda.SelectedValue == null)
                return;

            try {
                short moneda;
                if (!short.TryParse(Convert.ToString(cmbMoneda.SelectedValue), out moneda))
                    return;

                var tipoCambio = await _context.MonedaService.ObtenerTipoCambioAsync(moneda);
                if (!tipoCambio.HasValue)
                    return;

                if (tipoCambio.Value > (double)txtTipoCambio.Maximum)
                    throw new InvalidOperationException("El tipo de cambio de la moneda excede el máximo permitido por la captura.");

                txtTipoCambio.Value = Convert.ToDecimal(tipoCambio.Value);
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SeleccionarDepartamento() {
            using (var form =
                new DepartamentoSelectorForm(_context.CatalogosPartidaService)) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    txtDepartamento.Text =
                        form.ValorSeleccionado.ToString(
                            CultureInfo.CurrentCulture);

                    MostrarDescripcion(
                        txtDescripcionDepartamento,
                        form.DescripcionSeleccionada);
                    _toolTip.SetToolTip(
                        txtDepartamento,
                        form.DescripcionSeleccionada ?? string.Empty);
                }
            }

        }

        private void SeleccionarCentroCosto() {
            using (var form =
                new PartidaSelectorForm(
                    _context.CatalogosPartidaService,
                    PartidaSelectorForm.TipoCatalogo.CentroCosto)) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    txtCentroCostos.Text =
                        form.ValorSeleccionado.ToString(
                            CultureInfo.CurrentCulture);

                    MostrarDescripcion(
                        txtDescripcionCentroCostos,
                        form.DescripcionSeleccionada);
                    _toolTip.SetToolTip(
                        txtCentroCostos,
                        form.DescripcionSeleccionada ?? string.Empty);
                }
            }
        }

        private void SeleccionarGrupo() {
            using (var form =
                new PartidaSelectorForm(
                    _context.CatalogosPartidaService,
                    PartidaSelectorForm.TipoCatalogo.Grupo)) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    txtGrupo.Text =
                        form.ValorSeleccionado.ToString(
                            CultureInfo.CurrentCulture);

                    MostrarDescripcion(
                        txtDescripcionGrupo,
                        form.DescripcionSeleccionada);
                    _toolTip.SetToolTip(
                        txtGrupo,
                        form.DescripcionSeleccionada ?? string.Empty);
                }
            }
        }

        private void InicializarDebeHaber() {
            if (cmbDebeHaber.Items.Count == 0)
                cmbDebeHaber.Items.AddRange(new object[] { "D", "H" });

            if (cmbDebeHaber.SelectedIndex < 0)
                cmbDebeHaber.SelectedIndex = 0;
        }

        private void PolizaCapturaMovimientoForm_Load(object sender, EventArgs e) {
            InicializarDebeHaber();
        }

        private async Task<bool> AgregarPartidaAsync() {
            try {
                var cuenta = NormalizarCuenta(txtNoCuenta.Text);
                if (string.IsNullOrWhiteSpace(cuenta))
                    throw new ArgumentException("La cuenta es obligatoria.");

                double importe;
                if (!double.TryParse(txtImporte.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out importe) &&
                    !double.TryParse(txtImporte.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out importe))
                    throw new ArgumentException("El importe no tiene un formato válido.");

                if (importe <= 0 || double.IsNaN(importe) || double.IsInfinity(importe))
                    throw new ArgumentException("El importe debe ser mayor que cero.");

                short? departamento = ParseNullableShort(txtDepartamento.Text, "Departamento");
                double? tipoCambio = ParseNullableDouble(txtTipoCambio.Text, "Tipo cambio");
                int? centroCostos = ParseNullableInt(txtCentroCostos.Text, "Centro de costos");
                int? grupo = ParseNullableInt(txtGrupo.Text, "Grupo");

                string debeHaber = cmbDebeHaber.Text == null
                    ? string.Empty
                    : cmbDebeHaber.Text.Trim().ToUpperInvariant();

                if (debeHaber != "D" && debeHaber != "H")
                    throw new ArgumentException("Debe/Haber debe ser D o H.");

                var validacion = await _context.CuentaService
                    .ValidarCuentaParaMovimientoAsync(cuenta);

                if (!validacion.EsValida)
                    throw new InvalidOperationException(
                        "La cuenta no puede recibir movimientos:" +
                        Environment.NewLine +
                        string.Join(Environment.NewLine, validacion.Errores));

                Movimiento = new MovimientoContableRequest {
                    NumeroCuenta = cuenta,
                    DebeHaber = debeHaber,
                    Importe = importe,
                    NumeroDepartamento = departamento,
                    TipoCambio = tipoCambio,
                    CentroCostos = centroCostos,
                    Grupo = grupo,
                    Concepto = txtConcepto.Text == null ? string.Empty : txtConcepto.Text.Trim()
                };

                return true;
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Cuenta contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private static short? ParseNullableShort(string valor, string campo) {
            if (string.IsNullOrWhiteSpace(valor))
                return null;
            short resultado;
            if (!short.TryParse(valor.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out resultado) &&
                !short.TryParse(valor.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out resultado))
                throw new ArgumentException(campo + " no tiene un formato válido.");
            return resultado;
        }

        private static int? ParseNullableInt(string valor, string campo) {
            if (string.IsNullOrWhiteSpace(valor))
                return null;
            int resultado;
            if (!int.TryParse(valor.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out resultado) &&
                !int.TryParse(valor.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out resultado))
                throw new ArgumentException(campo + " no tiene un formato válido.");
            return resultado;
        }

        private static double? ParseNullableDouble(string valor, string campo) {
            if (string.IsNullOrWhiteSpace(valor))
                return null;
            double resultado;
            if (!double.TryParse(valor.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out resultado) &&
                !double.TryParse(valor.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out resultado))
                throw new ArgumentException(campo + " no tiene un formato válido.");
            if (double.IsNaN(resultado) || double.IsInfinity(resultado) || resultado <= 0)
                throw new ArgumentException(campo + " debe ser mayor que cero.");
            return resultado;
        }

        private static string NormalizarCuenta(string valor) {
            return string.IsNullOrWhiteSpace(valor) ? string.Empty : new string(valor.Trim().Where(char.IsDigit).ToArray());
        }

        private async void btnAceptar_Click(object sender, EventArgs e) {
            btnAceptar.Enabled = false;

            try {
                if (!await AgregarPartidaAsync())
                    return;

                DialogResult = DialogResult.OK;
                Close();
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this,
                    "No fue posible validar la partida: " + ex.Message,
                    "Movimiento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } finally {
                if (!IsDisposed)
                    btnAceptar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        private void CrearToolTips() {
            _toolTip = new ToolTip {
                AutoPopDelay = 8000,
                InitialDelay = 300,
                ReshowDelay = 100,
                ShowAlways = true
            };

            _toolTip.SetToolTip(
                txtNoCuenta,
                "Cuenta contable seleccionada.");

            _toolTip.SetToolTip(
                txtDepartamento,
                "Departamento seleccionado.");

            _toolTip.SetToolTip(
                txtCentroCostos,
                "Centro de costos seleccionado.");

            _toolTip.SetToolTip(
                txtGrupo,
                "Grupo seleccionado.");
        }

        private void SeleccionarCuenta() {
            try {
                Cursor = Cursors.WaitCursor;

                using (var form = new CuentaMovimientoSelectorForm(_context.CuentaService)) {
                    Cursor = Cursors.Default;

                    if (form.ShowDialog(this) != DialogResult.OK)
                        return;

                    if (string.IsNullOrWhiteSpace(form.NumeroCuentaSeleccionada))
                        return;

                    txtNoCuenta.Text = form.NumeroCuentaSeleccionada;

                    MostrarDescripcion(
                        txtDescripcionCuenta,
                        form.DescripcionCuentaSeleccionada);
                    _toolTip.SetToolTip(
                        txtNoCuenta,
                        form.DescripcionCuentaSeleccionada ?? string.Empty);

                    txtNoCuenta.Focus();
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    this,
                    "No fue posible seleccionar la cuenta: " + ex.Message,
                    "Selección de cuenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } finally {
                Cursor = Cursors.Default;
            }
        }

        private async Task CargarMovimientoInicialAsync(
    MovimientoContableRequest movimiento) {
            txtNoCuenta.Text = movimiento.NumeroCuenta ?? string.Empty;

            InicializarDebeHaber();

            var debeHaber = string.Equals(
                movimiento.DebeHaber,
                "H",
                StringComparison.OrdinalIgnoreCase)
                ? "H"
                : "D";

            cmbDebeHaber.SelectedItem = debeHaber;
            if (cmbDebeHaber.SelectedIndex < 0)
                cmbDebeHaber.SelectedIndex = 0;

            txtImporte.Text =
                movimiento.Importe.ToString(
                    "0.00",
                    CultureInfo.CurrentCulture);

            txtDepartamento.Text =
                movimiento.NumeroDepartamento.HasValue
                    ? movimiento.NumeroDepartamento.Value.ToString(
                        CultureInfo.CurrentCulture)
                    : string.Empty;

            txtTipoCambio.Text =
                movimiento.TipoCambio.HasValue
                    ? movimiento.TipoCambio.Value.ToString(
                        "0.########",
                        CultureInfo.CurrentCulture)
                    : string.Empty;

            txtCentroCostos.Text =
                movimiento.CentroCostos.HasValue
                    ? movimiento.CentroCostos.Value.ToString(
                        CultureInfo.CurrentCulture)
                    : string.Empty;

            txtGrupo.Text =
                movimiento.Grupo.HasValue
                    ? movimiento.Grupo.Value.ToString(
                        CultureInfo.CurrentCulture)
                    : string.Empty;

            txtConcepto.Text = string.IsNullOrWhiteSpace(movimiento.Concepto)
                ? _conceptoPoliza
                : movimiento.Concepto;

            await CargarDescripcionesAsync(movimiento);
        }
        private async Task CargarDescripcionesAsync(
            MovimientoContableRequest movimiento) {
            try {
                if (!string.IsNullOrWhiteSpace(movimiento.NumeroCuenta)) {
                    var cuenta = await _context.CuentaService
                        .ObtenerPorNumeroAsync(movimiento.NumeroCuenta);

                    if (cuenta != null) {
                        MostrarDescripcion(
                            txtDescripcionCuenta,
                            cuenta.Nombre);
                        _toolTip.SetToolTip(
                            txtNoCuenta,
                            cuenta.Nombre ?? string.Empty);
                    }
                }

                if (movimiento.NumeroDepartamento.HasValue) {
                    var departamentos = await _context.CatalogosPartidaService
                        .ObtenerDepartamentosAsync();

                    var departamento = departamentos.FirstOrDefault(x =>
                        x.DEPTO == movimiento.NumeroDepartamento.Value);

                    if (departamento != null) {
                        MostrarDescripcion(
                            txtDescripcionDepartamento,
                            departamento.DESCRIP);
                    }
                }

                if (movimiento.CentroCostos.HasValue) {
                    var centros = await _context.CatalogosPartidaService
                        .ObtenerCentrosCostosAsync();

                    var centro = centros.FirstOrDefault(x =>
                        x.Id == movimiento.CentroCostos.Value);

                    if (centro != null) {
                        MostrarDescripcion(
                            txtDescripcionCentroCostos,
                            centro.Descripcion);
                    }
                }

                if (movimiento.Grupo.HasValue) {
                    var grupos = await _context.CatalogosPartidaService
                        .ObtenerGruposAsync();

                    var grupo = grupos.FirstOrDefault(x =>
                        x.Id == movimiento.Grupo.Value);

                    if (grupo != null) {
                        MostrarDescripcion(
                            txtDescripcionGrupo,
                            grupo.Descripcion);
                    }
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(
                    "No fue posible cargar las descripciones de los catálogos: "
                    + ex.Message);
            }
        }

        private void CrearCamposDescripcion() {
            //var encabezado = new Label {
            //    Text = "Descripción",
            //    AutoSize = true,
            //    Location = new System.Drawing.Point(310, 0)
            //};

            //Controls.Add(encabezado);

            //_txtDescripcionCuenta = CrearDescripcion(
            //    "txtDescripcionCuenta", 310, 12);
            //_txtDescripcionDepartamento = CrearDescripcion(
            //    "txtDescripcionDepartamento", 310, 65);
            //_txtDescripcionCentroCostos = CrearDescripcion(
            //    "txtDescripcionCentroCostos", 310, 170);
            //_txtDescripcionGrupo = CrearDescripcion(
            //    "txtDescripcionGrupo", 310, 196);

            _toolTip.SetToolTip(
                txtDescripcionCuenta,
                "Descripción de la cuenta contable seleccionada.");
            _toolTip.SetToolTip(
                txtDescripcionDepartamento,
                "Descripción del departamento seleccionado.");
            _toolTip.SetToolTip(
                txtDescripcionCentroCostos,
                "Descripción del centro de costos seleccionado.");
            _toolTip.SetToolTip(
                txtDescripcionGrupo,
                "Descripción del grupo seleccionado.");
        }

        private TextBox CrearDescripcion(string nombre, int x, int y) {
            var text = new TextBox {
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(215, 20),
                ReadOnly = true,
                TabStop = false,
                Name = nombre
            };

            Controls.Add(text);
            return text;
        }

        private static void MostrarDescripcion(
            TextBox control,
            string descripcion) {
            if (control == null)
                return;

            control.Text = descripcion ?? string.Empty;
        }

    }
}
