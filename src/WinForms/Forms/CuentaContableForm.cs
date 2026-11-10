using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    public partial class CuentaContableForm : Form {
        private const short NaturalezaDeudora = 0;
        private const short NaturalezaAcreedora = 1;
        private readonly ICuentaService _cuentaService;
        private readonly IMotorContableService _motorContableService;
        private readonly CuentaContable _model;
        private readonly bool _esNueva;
        private readonly int? _rangoRaiz;

        public CuentaContableForm(ICuentaService cuentaService, IMotorContableService motorContableService, CuentaContable model, bool esNueva, int? rangoRaiz = null) {

            _cuentaService = cuentaService ?? throw new ArgumentNullException(nameof(cuentaService));
            _motorContableService = motorContableService ?? throw new ArgumentNullException(nameof(motorContableService));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _esNueva = esNueva;
            _rangoRaiz = rangoRaiz;

            InitializeComponent();
            ConfigurarInterfaz();
        }

        private void ConfigurarInterfaz() {
            Text = _esNueva ? "Agregar cuenta" : "Editar cuenta";

            txtNoCuenta.Visible = true;
            txtNoCuenta.ReadOnly = true;
            txtNoCuenta.BackColor = SystemColors.Control;

            Aceptar.Visible = false;
            maskedCuentaPadre.ReadOnly = true;
            maskedCuentaPadre.BackColor = SystemColors.Window;

            Acumulativa.CheckedChanged += Tipo_CheckedChanged;
            Detalle.CheckedChanged += Tipo_CheckedChanged;
            checkAfectaPolizaAjuste.CheckedChanged += AfectaPolizaAjuste_CheckedChanged;
            radioNaturalezaAcreedora.CheckedChanged += Naturaleza_CheckedChanged;
            radioNaturalezaDeudora.CheckedChanged += Naturaleza_CheckedChanged;
            buttonAsociarCuenta.Click += AsociarCuenta_Click;
            buttonDesasocuarCeunta.Click += DesasociarCuenta_Click;
        }

        private async void CuentaContableForm_Load(object sender, EventArgs e) {
            try {
                await _motorContableService.InicializarAsync(1);

                maskedCuentaPadre.Mask = _motorContableService.ObtenerMascara();
                maskedCuentaPadre.Text = _motorContableService.AplicarMascara(_model.CtaPapa);
                textContraPartida.Mask = _motorContableService.ObtenerMascara();
                txtNoCuenta.Mask = _motorContableService.ObtenerMascara();

                textDescripcion.MaxLength = 40;
                textContraPartida.MaxLength = 21;
                textIdFiscal.MaxLength = 40;
                textRFC.MaxLength = 30;
                comboCodigoAgrupador.MaxLength = 10;

                if (_esNueva) {
                    _model.Status = "A";
                    _model.DeptoSiNo = string.IsNullOrWhiteSpace(_model.DeptoSiNo) ? "N" : _model.DeptoSiNo;

                    if (_model.Tipo != "A" && _model.Tipo != "D")
                        _model.Tipo = "D";
                }

                CargarControlesDesdeModelo();

                if (_esNueva)
                    await MostrarPrevisualizacionNumeroAsync();
                else
                    await CargarRangosAsync();

                textDescripcion.Focus();
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Configuración contable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private async Task MostrarPrevisualizacionNumeroAsync() {
            try {
                var numero = await _cuentaService.GenerarSiguienteNumeroCuentaAsync(
                    _model.CtaPapa, _model.Nivel);

                txtNoCuenta.Text = _motorContableService.AplicarMascara(numero);
            } catch (Exception ex) {
                txtNoCuenta.Text = string.Empty;
                MessageBox.Show(
                    "No fue posible calcular la previsualización del número de cuenta: " + ex.Message,
                    "Cuenta contable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void CargarControlesDesdeModelo() {
            txtNoCuenta.Text = _esNueva
                ? string.Empty
                : _model.NumCta;
            textDescripcion.Text = _model.Nombre ?? string.Empty;
            textContraPartida.Text = _model.CtaComp ?? string.Empty;
            textIdFiscal.Text = _model.IdFiscal ?? string.Empty;
            textRFC.Text = _model.RFC ?? string.Empty;
            comboCodigoAgrupador.Text = _model.CodAgrup ?? string.Empty;

            checkAfectaPolizaAjuste.Checked = string.Equals(_model.BandAjt, "S", StringComparison.OrdinalIgnoreCase);

            EsDepartamental.Checked = string.Equals(_model.DeptoSiNo, "S", StringComparison.OrdinalIgnoreCase);

            checkCapturaFormaPago.Checked = _model.CapturaCheque != 0;
            checkCapturaComprobantes.Checked = _model.CapturaUUID != 0;

            Acumulativa.Checked =
                string.Equals(_model.Tipo, "A",
                    StringComparison.OrdinalIgnoreCase);

            Detalle.Checked =
                string.Equals(_model.Tipo, "D",
                    StringComparison.OrdinalIgnoreCase);

            radioNaturalezaAcreedora.Checked = _model.Naturaleza == NaturalezaAcreedora;
            radioNaturalezaDeudora.Checked = _model.Naturaleza == NaturalezaDeudora;
        }

        private void GuardarControlesEnModelo() {
            if (!_esNueva)
                _model.NumCta = this.txtNoCuenta.Text.Trim();

            _model.Nombre = textDescripcion.Text.Trim();
            _model.CtaComp = Normalizar(textContraPartida.Text);
            _model.IdFiscal = Normalizar(textIdFiscal.Text);
            _model.RFC = Normalizar(textRFC.Text);
            _model.CodAgrup = Normalizar(comboCodigoAgrupador.Text);

            _model.BandAjt = checkAfectaPolizaAjuste.Checked ? "S" : "N";
            _model.DeptoSiNo = EsDepartamental.Checked ? "S" : "N";
            _model.CapturaCheque = checkCapturaFormaPago.Checked ? (short)1 : (short)0;
            _model.CapturaUUID = checkCapturaComprobantes.Checked ? (short)1 : (short)0;
            _model.Tipo = Acumulativa.Checked ? "A" : "D";

            if (radioNaturalezaAcreedora.Checked)
                _model.Naturaleza = NaturalezaAcreedora;
            else if (radioNaturalezaDeudora.Checked)
                _model.Naturaleza = NaturalezaDeudora;
        }

        private async Task CargarRangosAsync() {
            try {
                var rangos = await _cuentaService.ObtenerRangosPorCuentaAsync(_model.NumCta);
                listRubros.DataSource = null;
                listRubros.DisplayMember = "Descripcion";
                listRubros.ValueMember = "Rango";
                listRubros.DataSource = rangos;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void AsociarCuenta_Click(object sender, EventArgs e) {
            try {
                var rangos = await _cuentaService.ListarRangosDisponiblesParaCuentaAsync(_model.NumCta);
                if (rangos.Count == 0) {
                    MessageBox.Show("La cuenta ya está asociada a todos los rangos disponibles.",
                        "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var dialogo = new RangoSeleccionForm(rangos)) {
                    if (dialogo.ShowDialog(this) != DialogResult.OK || dialogo.RangoSeleccionado == null)
                        return;

                    var rango = dialogo.RangoSeleccionado.Rango;
                    var asociado = await _cuentaService.AsociarCuentaRangoAsync(_model.NumCta, rango);
                    if (!asociado) {
                        MessageBox.Show("La cuenta ya estaba asociada al rango seleccionado.",
                            "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    await CargarRangosAsync();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Asociar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void DesasociarCuenta_Click(object sender, EventArgs e) {
            var rango = listRubros.SelectedItem as RubroContableModel;
            if (rango == null) {
                MessageBox.Show("Seleccione un rango asociado.",
                    "Rangos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmar = MessageBox.Show(
                string.Format("¿Desea desasociar la cuenta del rango '{0}'?", rango.Descripcion),
                "Confirmar desasociación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            try {
                var eliminado = await _cuentaService.DesasociarCuentaRangoAsync(_model.NumCta, rango.Rango);
                if (!eliminado)
                    throw new InvalidOperationException("La relación no existe o ya fue eliminada.");

                await CargarRangosAsync();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Desasociar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Tipo_CheckedChanged(object sender, EventArgs e) {
            if (Acumulativa.Checked)
                _model.Tipo = "A";
            else if (Detalle.Checked)
                _model.Tipo = "D";
        }

        private void AfectaPolizaAjuste_CheckedChanged(object sender, EventArgs e) {
            _model.BandAjt = checkAfectaPolizaAjuste.Checked ? "S" : "N";
        }

        private void Naturaleza_CheckedChanged(object sender, EventArgs e) {
            if (radioNaturalezaAcreedora.Checked)
                _model.Naturaleza = NaturalezaAcreedora;
            else if (radioNaturalezaDeudora.Checked)
                _model.Naturaleza = NaturalezaDeudora;
        }

        private async void Guardar_Click(object sender, EventArgs e) {
            if (!ValidarCaptura())
                return;

            try {
                bool guardado;

                GuardarControlesEnModelo();

                if (_esNueva && _rangoRaiz.HasValue)
                    guardado = await _cuentaService.RegistrarCuentaEnRangoAsync(
                        _model, _rangoRaiz.Value);
                else if (_esNueva)
                    guardado = await _cuentaService.RegistrarCuentaAsync(_model);
                else
                    guardado = await _cuentaService.ActualizarCuentaAsync(_model);

                if (!guardado)
                    throw new InvalidOperationException(
                        "La operación no modificó ningún registro.");

                DialogResult = DialogResult.OK;
                Close();
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Error al guardar la cuenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private bool ValidarCaptura() {
            if (string.IsNullOrWhiteSpace(textDescripcion.Text)) {
                MessageBox.Show(
                    "La descripción de la cuenta es obligatoria.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textDescripcion.Focus();
                return false;
            }

            if (textDescripcion.Text.Trim().Length > 40) {
                MessageBox.Show(
                    "La descripción no puede exceder 40 caracteres.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textDescripcion.Focus();
                return false;
            }

            if (_model.Nivel < 1) {
                MessageBox.Show(
                    "El nivel de la cuenta no es válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textContraPartida.Text) &&
                textContraPartida.Text.Trim().Length > 21) {
                MessageBox.Show(
                    "La cuenta de contrapartida no puede exceder 21 caracteres.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textContraPartida.Focus();
                return false;
            }

            if (textRFC.Text.Trim().Length > 30 ||
                textIdFiscal.Text.Trim().Length > 40 ||
                comboCodigoAgrupador.Text.Trim().Length > 10) {
                MessageBox.Show(
                    "Uno de los datos fiscales excede la longitud permitida.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private static string Normalizar(string value) {
            return string.IsNullOrWhiteSpace(value)
                ? null
                : value.Trim();
        }

        private void Cancelar_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Aceptar_Click(object sender, EventArgs e) {
            Guardar.PerformClick();
        }

        private void Ayuda_Click(object sender, EventArgs e) {
            MessageBox.Show(
                "El número de cuenta se genera automáticamente según PARAMEMP. " +
                "El número mostrado al agregar es una previsualización; el número definitivo " +
                "se asigna de forma transaccional al guardar. " +
                "La cuenta padre y el nivel se determinan desde el catálogo. " +
                "En edición el número, nivel y cuenta padre no pueden modificarse.",
                "Ayuda",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
