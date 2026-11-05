using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable {
    public sealed class ReversionPolizaForm : Form {
        private readonly IReversionPolizaService _service;
        private readonly PolizaContableConsulta _poliza;
        private readonly ITipoPolizaService _tipoService;
        private ComboBox _cmbTipo;
        private TextBox _txtNumero;
        private TextBox _txtMotivo;
        private DateTimePicker _fecha;
        private Button _btnAceptar;
        private Button _btnCancelar;

        public ReversionPolizaForm(IReversionPolizaService service, ITipoPolizaService tipoService, PolizaContableConsulta poliza) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _tipoService = tipoService ?? throw new ArgumentNullException(nameof(tipoService));
            _poliza = poliza ?? throw new ArgumentNullException(nameof(poliza));
            ConstruirInterfaz();
            Load += async (s, e) => await CargarTiposAsync();
        }

        private void ConstruirInterfaz() {
            Text = "Revertir póliza";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            ClientSize = new System.Drawing.Size(430, 245);

            Controls.Add(new Label { Text = "Póliza original:", AutoSize = true, Location = new System.Drawing.Point(20, 20) });
            Controls.Add(new Label { Text = _poliza.TipoPoliza + " - " + _poliza.NumeroPoliza, AutoSize = true, Location = new System.Drawing.Point(130, 20) });
            Controls.Add(new Label { Text = "Tipo nueva:", AutoSize = true, Location = new System.Drawing.Point(20, 55) });
            _cmbTipo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Location = new System.Drawing.Point(130, 52), Width = 250 };
            Controls.Add(_cmbTipo);
            Controls.Add(new Label { Text = "Número:", AutoSize = true, Location = new System.Drawing.Point(20, 88) });
            _txtNumero = new TextBox { Location = new System.Drawing.Point(130, 85), Width = 120, Text = string.Empty };
            Controls.Add(_txtNumero);
            Controls.Add(new Label { Text = "Fecha:", AutoSize = true, Location = new System.Drawing.Point(20, 121) });
            _fecha = new DateTimePicker { Location = new System.Drawing.Point(130, 118), Width = 180, Value = _poliza.Fecha ?? DateTime.Now };
            Controls.Add(_fecha);
            Controls.Add(new Label { Text = "Motivo:", AutoSize = true, Location = new System.Drawing.Point(20, 154) });
            _txtMotivo = new TextBox { Location = new System.Drawing.Point(130, 151), Width = 250, MaxLength = 120 };
            Controls.Add(_txtMotivo);
            _btnAceptar = new Button { Text = "Revertir", Location = new System.Drawing.Point(220, 195), Width = 75 };
            _btnCancelar = new Button { Text = "Cancelar", Location = new System.Drawing.Point(305, 195), Width = 75, DialogResult = DialogResult.Cancel };
            _btnAceptar.Click += async (s, e) => await RevertirAsync();
            Controls.Add(_btnAceptar); Controls.Add(_btnCancelar);
            AcceptButton = _btnAceptar; CancelButton = _btnCancelar;
        }

        private async Task CargarTiposAsync() {
            try {
                var tipos = await _tipoService.ObtenerTodosAsync();
                _cmbTipo.DataSource = tipos;
                _cmbTipo.DisplayMember = "DESCRIP";
                _cmbTipo.ValueMember = "TIPO";
                if (tipos.Count > 0) {
                    int indice = tipos.FindIndex(x => string.Equals(x.Tipo, _poliza.TipoPoliza, StringComparison.OrdinalIgnoreCase));
                    _cmbTipo.SelectedIndex = indice >= 0 ? indice : 0;
                }
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible cargar TIPOSPOL: " + ex.Message, "Reversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _btnAceptar.Enabled = false;
            }
        }

        private async Task RevertirAsync() {
            try {
                if (_cmbTipo.SelectedValue == null)
                    throw new InvalidOperationException("Seleccione el tipo de póliza para la reversión.");

                if (MessageBox.Show(this, "La póliza original no será eliminada. Se registrará una póliza inversa. ¿Desea continuar?",
                    "Confirmar reversión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                _btnAceptar.Enabled = false;
                Cursor = Cursors.WaitCursor;
                var resultado = await _service.RevertirAsync(new PolizaReversionRequest {
                    TipoPolizaOriginal = _poliza.TipoPoliza,
                    NumeroPolizaOriginal = _poliza.NumeroPoliza,
                    Ejercicio = _poliza.Ejercicio,
                    Periodo = _poliza.Periodo,
                    TipoPolizaNueva = Convert.ToString(_cmbTipo.SelectedValue),
                    NumeroPolizaNueva = string.IsNullOrWhiteSpace(_txtNumero.Text) ? null : _txtNumero.Text.Trim(),
                    Fecha = _fecha.Value,
                    Motivo = _txtMotivo.Text.Trim()
                });

                MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
                    "Reversión registrada correctamente.\nNueva póliza: {0}-{1}\nPartidas: {2}\nImporte revertido: {3:N2}",
                    resultado.TipoPolizaNueva, resultado.NumeroPolizaNueva, resultado.Partidas, resultado.ImporteRevertido),
                    "Reversión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Reversión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Reversión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible revertir la póliza: " + ex.Message, "Reversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                Cursor = Cursors.Default;
                _btnAceptar.Enabled = true;
            }
        }
    }
}
