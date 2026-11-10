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
    /// Formulario de mantenimiento de ACTIVOS25.
    /// </summary>
    public partial class ActivoFijoCatalogoForm : Form {
        private readonly IActivoFijoService _service;
        private readonly IActivoFijoTipoService _tipoActivoService;
        private List<ActivoFijo> _datos = new List<ActivoFijo>();
        private List<ActivoFijoTipo> _tipos = new List<ActivoFijoTipo>();
        private bool _nuevo;
        private bool _cargandoTipo;

        public ActivoFijoCatalogoForm(IActivoFijoService service, IActivoFijoTipoService tipoActivoService) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _tipoActivoService = tipoActivoService ?? throw new ArgumentNullException(nameof(tipoActivoService));
            InitializeComponent();
            ConfiguraComponent();
            Shown += async (s, e) => { await CargarTiposAsync(); await CargarAsync(); };
        }

        private void ConfiguraComponent() {
            txtBuscar.TextChanged += (s, e) => Filtrar();

            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AllowUserToDeleteRows = false;
            gridData.AllowUserToResizeRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridData.MultiSelect = false;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridData.ColumnText("Clave", "Clave");
            gridData.ColumnComboBox("Tipo", "Tipo", "CLAVE", "Descrip");
            gridData.ColumnText("Descripcion", "Descripción");
            gridData.ColumnText("MontoOriginal", "Monto orig.", "N4");
            gridData.ColumnText("FecAdquisicion", "Adquisición", "d");
            gridData.ColumnText("Status", "Estatus");
            gridData.ColumnText("NumSerie", "Serie");
            gridData.ColumnText("TipoCambio", "T. cambio", "N6");
            gridData.CellDoubleClick += (s, e) => CargarSeleccion();
            gridData.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.Handled = true; CargarSeleccion(); } };

            txtClave.MaxLength = 16;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.SelectedIndexChanged += (s, e) => AplicarParametrosTipoSeleccionado();
            txtDescripcion.MaxLength = 30;
            txtLocaliz.MaxLength = 9;
            txtStatus.MaxLength = 1;
            txtSerie.MaxLength = 24;
            txtBand.MaxLength = 1;
            dtFechaAdq.Format = DateTimePickerFormat.Short;

            this.numTipoCambio.ToNumericUpDown(6);
            this.numMontoOrig.ToNumericUpDown(4);
            this.numMontoOrigEx.ToNumericUpDown(4);
            this.numValMer.ToNumericUpDown(4);
            this.numVida.ToNumericUpDown(4);
            txtObserv.Multiline = true;
            txtObserv.Height = 55;
            txtObserv.MaxLength = 250;
            txtMetDep.MaxLength = 1;

            this.numTasDep.ToNumericUpDown(6);
            this.numTasDepFis.ToNumericUpDown(6);
            this.numMaxDed.ToNumericUpDown(4);
            this.numDepAcu.ToNumericUpDown(4);
            this.numDepFis.ToNumericUpDown(4);

            dtIniDep.Format = DateTimePickerFormat.Short;
            dtIniDepFis.Format = DateTimePickerFormat.Short;
            dtFechaEliminacion.Format = DateTimePickerFormat.Short;
            txtPolizaSeg.MaxLength = 20;
            txtCompAseg.MaxLength = 40;
            txtAgente.MaxLength = 40;
            txtTelefono.MaxLength = 15;
            txtCobertura.MaxLength = 20;

            this.numMontoAseg.ToNumericUpDown(4);
            this.numPrima.ToNumericUpDown(4);
            this.numDeducible.ToNumericUpDown(4);

            dtVigencia.Format = DateTimePickerFormat.Short;
            _dtProxMan.Format = DateTimePickerFormat.Short;
            dtUltMan.Format = DateTimePickerFormat.Short;
            numPeriodoMan.Maximum = short.MaxValue;

            this.numCostoMan.ToNumericUpDown(4);
            txtResponsable.MaxLength = 60;

            btnNuevo.Click += (s, e) => Nuevo();
            btnGuardar.Click += async (s, e) => await GuardarAsync();
            btnEliminar.Click += async (s, e) => await EliminarAsync();
            btnCerrar.Click += (s, e) => Close();
            CancelButton = btnCerrar;
            AcceptButton = btnGuardar;
            Nuevo();
        }

        private async Task CargarTiposAsync() {
            _tipos = await _tipoActivoService.ObtenerTodosAsync() ?? new List<ActivoFijoTipo>();
            cmbTipo.DataSource = null;
            cmbTipo.DisplayMember = "Descripcion";
            cmbTipo.ValueMember = "Clave";
            cmbTipo.DataSource = _tipos;
            cmbTipo.SelectedIndex = -1;
        }

        private void AplicarParametrosTipoSeleccionado() {
            if (_cargandoTipo || cmbTipo.SelectedItem == null)
                return;

            var tipo = cmbTipo.SelectedItem as ActivoFijoTipo;
            if (tipo == null)
                return;

            numMaxDed.Value = D(tipo.MaximoDepresiacion);
            txtMetDep.Text = tipo.MetodoDepresiacion ?? string.Empty;
        }

        private void SeleccionarTipo(short? clave, bool aplicarParametros) {
            _cargandoTipo = true;
            try {
                if (!clave.HasValue) {
                    cmbTipo.SelectedIndex = -1;
                    return;
                }

                for (int i = 0; i < _tipos.Count; i++) {
                    if (_tipos[i].Clave == clave.Value) {
                        cmbTipo.SelectedIndex = i;
                        break;
                    }
                }
            } finally {
                _cargandoTipo = false;
            }

            if (aplicarParametros)
                AplicarParametrosTipoSeleccionado();
        }

        private async Task CargarAsync() {
            try {
                _datos = await _service.ObtenerTodosAsync();
                Filtrar();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Activos fijos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtrar() {
            string q = (txtBuscar.Text ?? string.Empty).Trim();
            gridData.DataSource = string.IsNullOrEmpty(q) ? _datos : _datos.Where(x => (x.Clave ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 || (x.Descripcion ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 || (x.NumSerie ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            var combo = gridData.Columns["Tipo"] as DataGridViewComboBoxColumn;
            if (combo != null) {
                combo.DataSource = _tipos;
                combo.DisplayMember = "Descripcion";
                combo.ValueMember = "Clave";
            }
        }

        private void CargarSeleccion() {
            var x = gridData.CurrentRow == null ? null : gridData.CurrentRow.DataBoundItem as ActivoFijo;
            if (x == null)
                return;
            CargarModelo(x);
            _nuevo = false;
            txtClave.Enabled = false;
        }

        private void CargarModelo(ActivoFijo x) {
            txtClave.Text = x.Clave ?? "";
            SeleccionarTipo(x.Tipo, false);
            txtDescripcion.Text = x.Descripcion ?? "";
            txtLocaliz.Text = x.Localizacion ?? "";
            numMontoOrig.Value = D(x.MontoOriginal);
            numMontoOrigEx.Value = D(x.MontoOriginalMonedaExtranjera);
            dtFechaAdq.SetFecha(x.FecAdquisicion);
            numMaxDed.Value = D(x.MaximoDeducible);
            numValMer.Value = D(x.ValorMercado);
            numDepAcu.Value = D(x.DepresiacionAcumulada);
            numVida.Value = D(x.VidaUtil);
            txtMetDep.Text = x.MetodoDepresiacion ?? "";
            numTasDep.Value = D(x.TasaDepresiacion);
            numTasDepFis.Value = D(x.TasaDepresiacionFiscal);
            txtStatus.Text = x.Status ?? "";
           // _numDepto.Value = x.IdDepartamento ?? 0;
            txtSerie.Text = x.NumSerie ?? "";
            txtBand.Text = x.BANDEDINM ?? "";
            dtIniDep.SetFecha(x.FecInicioDepresiacion);
            dtIniDepFis.SetFecha(x.FecInicioDepresiacionFiscal);
            numDepFis.Value = D(x.DepresiacionAcumuladaFiscal);
            dtFechaEliminacion.SetFecha(x.FechaBaja);
            txtObserv.Text = x.Nota ?? "";
            numTipoCambio.Value = D(x.TipoCambio);
            txtPolizaSeg.Text = x.PolizaSeguro ?? "";
            txtCompAseg.Text = x.CompaniaSeguro ?? "";
            txtAgente.Text = x.AgenteSeguro ?? "";
            txtTelefono.Text = x.TelefonoSiniestro ?? "";
            txtCobertura.Text = x.TipoCobertura ?? "";
            numMontoAseg.Value = D(x.MontoAsegurado);
            numPrima.Value = D(x.PrimaTotal);
            numDeducible.Value = D(x.Deducible);
            dtVigencia.SetFecha(x.FecVigencia);
            _dtProxMan.SetFecha(x.FecProximoMantto);
            dtUltMan.SetFecha(x.FecUltMantto);
            numPeriodoMan.Value = x.PeriodoMantto ?? 0;
            numCostoMan.Value = D(x.CostoMantto);
            txtResponsable.Text = x.Responsable ?? "";
        }

        private void Nuevo() {
            _nuevo = true;
            txtClave.Enabled = true;
            txtClave.Clear();
            SeleccionarTipo(null, false);
            txtDescripcion.Clear();
            txtLocaliz.Clear();
            numMontoOrig.Value = 0;
            numMontoOrigEx.Value = 0;
            dtFechaAdq.SetFecha(null);
            numMaxDed.Value = 0;
            numValMer.Value = 0;
            numDepAcu.Value = 0;
            numVida.Value = 0;
            txtMetDep.Clear();
            numTasDep.Value = 0;
            numTasDepFis.Value = 0;
            txtStatus.Clear();
           // _numDepto.Value = 0;
            txtSerie.Clear();
            txtBand.Clear();
            dtIniDep.SetFecha(null);
            dtIniDepFis.SetFecha(null);
            dtFechaEliminacion.SetFecha(null);
            numDepFis.Value = 0;
            txtObserv.Clear();
            numTipoCambio.Value = 0;
            txtPolizaSeg.Clear();
            txtCompAseg.Clear();
            txtAgente.Clear();
            txtTelefono.Clear();
            txtCobertura.Clear();
            numMontoAseg.Value = 0;
            numPrima.Value = 0;
            numDeducible.Value = 0;
            dtVigencia.SetFecha(null);
            _dtProxMan.SetFecha(null);
            dtUltMan.SetFecha(null);
            numPeriodoMan.Value = 0;
            numCostoMan.Value = 0;
            txtResponsable.Clear();
            txtClave.Focus();
        }

        private async Task GuardarAsync() {
            try {
                var x = Modelo();
                if (_nuevo)
                    await _service.CrearAsync(x);
                else
                    await _service.ActualizarAsync(x);
                MessageBox.Show(this, "Activo fijo guardado correctamente.", "Activos fijos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _nuevo = false;
                txtClave.Enabled = false;
                await CargarAsync();
            } catch (ArgumentException ex) {
                MessageBox.Show(this, ex.Message, "Activos fijos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Activos fijos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible guardar el activo fijo: " + ex.Message, "Activos fijos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarAsync() {
            if (_nuevo || string.IsNullOrWhiteSpace(txtClave.Text))
                return;
            if (MessageBox.Show(this, "¿Desea eliminar el activo fijo seleccionado?", "Activos fijos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try {
                await _service.EliminarAsync(txtClave.Text);
                Nuevo();
                await CargarAsync();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Activos fijos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private ActivoFijo Modelo() {
            return new ActivoFijo {
                Clave = txtClave.Text,
                Tipo = cmbTipo.SelectedItem is ActivoFijoTipo ? (short?)((ActivoFijoTipo)cmbTipo.SelectedItem).Clave : null,
                Descripcion = txtDescripcion.Text,
                Localizacion = txtLocaliz.Text,
                MontoOriginal = Convert.ToDouble(numMontoOrig.Value),
                MontoOriginalMonedaExtranjera = Convert.ToDouble(numMontoOrigEx.Value),
                FecAdquisicion = dtFechaAdq.GetFecha(),
                MaximoDeducible = Convert.ToDouble(numMaxDed.Value),
                ValorMercado = Convert.ToDouble(numValMer.Value),
                DepresiacionAcumulada = Convert.ToDouble(numDepAcu.Value),
                VidaUtil = Convert.ToDouble(numVida.Value),
                MetodoDepresiacion = txtMetDep.Text,
                TasaDepresiacion = Convert.ToDouble(numTasDep.Value),
                TasaDepresiacionFiscal = Convert.ToDouble(numTasDepFis.Value),
                Status = txtStatus.Text,
                //IdDepartamento = _numDepto.Value == 0 ? (short?)null : Convert.ToInt16(_numDepto.Value),
                NumSerie = txtSerie.Text,
                BANDEDINM = txtBand.Text,
                FecInicioDepresiacion = dtIniDep.GetFecha(),
                FecInicioDepresiacionFiscal = dtIniDepFis.GetFecha(),
                FechaBaja = dtFechaEliminacion.GetFecha(),
                DepresiacionAcumuladaFiscal = Convert.ToDouble(numDepFis.Value),
                Nota = txtObserv.Text,
                TipoCambio = Convert.ToDouble(numTipoCambio.Value),
                PolizaSeguro = txtPolizaSeg.Text,
                CompaniaSeguro = txtCompAseg.Text,
                AgenteSeguro = txtAgente.Text,
                TelefonoSiniestro = txtTelefono.Text,
                TipoCobertura = txtCobertura.Text,
                MontoAsegurado = Convert.ToDouble(numMontoAseg.Value),
                PrimaTotal = Convert.ToDouble(numPrima.Value),
                Deducible = Convert.ToDouble(numDeducible.Value),
                FecVigencia = dtVigencia.GetFecha(),
                FecProximoMantto = _dtProxMan.GetFecha(),
                FecUltMantto = dtUltMan.GetFecha(),
                PeriodoMantto = numPeriodoMan.Value == 0 ? (short?)null : Convert.ToInt16(numPeriodoMan.Value),
                CostoMantto = Convert.ToDouble(numCostoMan.Value),
                Responsable = txtResponsable.Text
            };
        }

        private static decimal D(double? x) {
            if (!x.HasValue || double.IsNaN(x.Value) || double.IsInfinity(x.Value))
                return 0m;
            if (x.Value > (double)decimal.MaxValue)
                return decimal.MaxValue;
            if (x.Value < (double)decimal.MinValue)
                return decimal.MinValue;
            return Convert.ToDecimal(x.Value);
        }
    }
}
