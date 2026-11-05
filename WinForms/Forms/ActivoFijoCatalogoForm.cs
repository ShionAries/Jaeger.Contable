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
        private readonly ITipoActivoService _tipoActivoService;
        private List<ActivoFijo> _datos = new List<ActivoFijo>();
        private List<TipoActivo> _tipos = new List<TipoActivo>();
        private bool _nuevo;
        private bool _cargandoTipo;

        public ActivoFijoCatalogoForm(IActivoFijoService service, ITipoActivoService tipoActivoService) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _tipoActivoService = tipoActivoService ?? throw new ArgumentNullException(nameof(tipoActivoService));
            InitializeComponent();
            ConfiguraComponent();
            Shown += async (s, e) => { await CargarTiposAsync(); await CargarAsync(); };
        }

        private void ConfiguraComponent() {
            _txtBuscar.TextChanged += (s, e) => Filtrar();

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

            _txtClave.MaxLength = 16;
            _cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbTipo.SelectedIndexChanged += (s, e) => AplicarParametrosTipoSeleccionado();
            _txtDescripcion.MaxLength = 30;
            _txtLocaliz.MaxLength = 9;
            _txtStatus.MaxLength = 1;
            _txtSerie.MaxLength = 24;
            _numDepto.Maximum = short.MaxValue;
            _txtBand.MaxLength = 1;
            _dtFechaAdq.Format = DateTimePickerFormat.Short;

            this._numTipoCambio.ToNumericUpDown(6);
            this._numMontoOrig.ToNumericUpDown(4);
            this._numMontoOrigEx.ToNumericUpDown(4);
            this._numValMer.ToNumericUpDown(4);
            this._numVida.ToNumericUpDown(4);
            _txtObserv.Multiline = true;
            _txtObserv.Height = 55;
            _txtObserv.MaxLength = 250;
            _txtMetDep.MaxLength = 1;

            this._numTasDep.ToNumericUpDown(6);
            this._numTasDepFis.ToNumericUpDown(6);
            this._numMaxDed.ToNumericUpDown(4);
            this._numDepAcu.ToNumericUpDown(4);
            this._numDepFis.ToNumericUpDown(4);

            _dtIniDep.Format = DateTimePickerFormat.Short;
            _dtIniDepFis.Format = DateTimePickerFormat.Short;
            _dtFechaEliminacion.Format = DateTimePickerFormat.Short;
            _txtPolizaSeg.MaxLength = 20;
            _txtCompAseg.MaxLength = 40;
            _txtAgente.MaxLength = 40;
            _txtTel.MaxLength = 15;
            _txtCobertura.MaxLength = 20;

            this._numMontoAseg.ToNumericUpDown(4);
            this._numPrima.ToNumericUpDown(4);
            this._numDeducible.ToNumericUpDown(4);

            _dtVigencia.Format = DateTimePickerFormat.Short;
            _dtProxMan.Format = DateTimePickerFormat.Short;
            _dtUltMan.Format = DateTimePickerFormat.Short;
            _numPeriodoMan.Maximum = short.MaxValue;

            this._numCostoMan.ToNumericUpDown(4);
            _txtResponsable.MaxLength = 60;

            _btnNuevo.Click += (s, e) => Nuevo();
            _btnGuardar.Click += async (s, e) => await GuardarAsync();
            _btnEliminar.Click += async (s, e) => await EliminarAsync();
            _btnCerrar.Click += (s, e) => Close();
            CancelButton = _btnCerrar;
            AcceptButton = _btnGuardar;
            Nuevo();
        }

        private async Task CargarTiposAsync() {
            _tipos = await _tipoActivoService.ObtenerTodosAsync() ?? new List<TipoActivo>();
            _cmbTipo.DataSource = null;
            _cmbTipo.DisplayMember = "Descripcion";
            _cmbTipo.ValueMember = "Clave";
            _cmbTipo.DataSource = _tipos;
            _cmbTipo.SelectedIndex = -1;
        }

        private void AplicarParametrosTipoSeleccionado() {
            if (_cargandoTipo || _cmbTipo.SelectedItem == null)
                return;

            var tipo = _cmbTipo.SelectedItem as TipoActivo;
            if (tipo == null)
                return;

            _numMaxDed.Value = D(tipo.MaximoDepresiacion);
            _txtMetDep.Text = tipo.MetodoDepresiacion ?? string.Empty;
        }

        private void SeleccionarTipo(short? clave, bool aplicarParametros) {
            _cargandoTipo = true;
            try {
                if (!clave.HasValue) {
                    _cmbTipo.SelectedIndex = -1;
                    return;
                }

                for (int i = 0; i < _tipos.Count; i++) {
                    if (_tipos[i].Clave == clave.Value) {
                        _cmbTipo.SelectedIndex = i;
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
            string q = (_txtBuscar.Text ?? string.Empty).Trim();
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
            _txtClave.Enabled = false;
        }

        private void CargarModelo(ActivoFijo x) {
            _txtClave.Text = x.Clave ?? "";
            SeleccionarTipo(x.Tipo, false);
            _txtDescripcion.Text = x.Descripcion ?? "";
            _txtLocaliz.Text = x.Localizacion ?? "";
            _numMontoOrig.Value = D(x.MontoOriginal);
            _numMontoOrigEx.Value = D(x.MontoOriginalMonedaExtranjera);
            _dtFechaAdq.SetFecha(x.FecAdquisicion);
            _numMaxDed.Value = D(x.MaximoDeducible);
            _numValMer.Value = D(x.ValorMercado);
            _numDepAcu.Value = D(x.DepresiacionAcumulada);
            _numVida.Value = D(x.VidaUtil);
            _txtMetDep.Text = x.MetodoDepresiacion ?? "";
            _numTasDep.Value = D(x.TasaDepresiacion);
            _numTasDepFis.Value = D(x.TasaDepresiacionFiscal);
            _txtStatus.Text = x.Status ?? "";
            _numDepto.Value = x.IdDepartamento ?? 0;
            _txtSerie.Text = x.NumSerie ?? "";
            _txtBand.Text = x.BANDEDINM ?? "";
            _dtIniDep.SetFecha(x.FecInicioDepresiacion);
            _dtIniDepFis.SetFecha(x.FecInicioDepresiacionFiscal);
            _numDepFis.Value = D(x.DepresiacionAcumuladaFiscal);
            _dtFechaEliminacion.SetFecha(x.FechaBaja);
            _txtObserv.Text = x.Nota ?? "";
            _numTipoCambio.Value = D(x.TipoCambio);
            _txtPolizaSeg.Text = x.PolizaSeguro ?? "";
            _txtCompAseg.Text = x.CompaniaSeguro ?? "";
            _txtAgente.Text = x.AgenteSeguro ?? "";
            _txtTel.Text = x.TelefonoSiniestro ?? "";
            _txtCobertura.Text = x.TipoCobertura ?? "";
            _numMontoAseg.Value = D(x.MontoAsegurado);
            _numPrima.Value = D(x.PrimaTotal);
            _numDeducible.Value = D(x.Deducible);
            _dtVigencia.SetFecha(x.FecVigencia);
            _dtProxMan.SetFecha(x.FecProximoMantto);
            _dtUltMan.SetFecha(x.FecUltMantto);
            _numPeriodoMan.Value = x.PeriodoMantto ?? 0;
            _numCostoMan.Value = D(x.CostoMantto);
            _txtResponsable.Text = x.Responsable ?? "";
        }

        private void Nuevo() {
            _nuevo = true;
            _txtClave.Enabled = true;
            _txtClave.Clear();
            SeleccionarTipo(null, false);
            _txtDescripcion.Clear();
            _txtLocaliz.Clear();
            _numMontoOrig.Value = 0;
            _numMontoOrigEx.Value = 0;
            _dtFechaAdq.SetFecha(null);
            _numMaxDed.Value = 0;
            _numValMer.Value = 0;
            _numDepAcu.Value = 0;
            _numVida.Value = 0;
            _txtMetDep.Clear();
            _numTasDep.Value = 0;
            _numTasDepFis.Value = 0;
            _txtStatus.Clear();
            _numDepto.Value = 0;
            _txtSerie.Clear();
            _txtBand.Clear();
            _dtIniDep.SetFecha(null);
            _dtIniDepFis.SetFecha(null);
            _dtFechaEliminacion.SetFecha(null);
            _numDepFis.Value = 0;
            _txtObserv.Clear();
            _numTipoCambio.Value = 0;
            _txtPolizaSeg.Clear();
            _txtCompAseg.Clear();
            _txtAgente.Clear();
            _txtTel.Clear();
            _txtCobertura.Clear();
            _numMontoAseg.Value = 0;
            _numPrima.Value = 0;
            _numDeducible.Value = 0;
            _dtVigencia.SetFecha(null);
            _dtProxMan.SetFecha(null);
            _dtUltMan.SetFecha(null);
            _numPeriodoMan.Value = 0;
            _numCostoMan.Value = 0;
            _txtResponsable.Clear();
            _txtClave.Focus();
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
                _txtClave.Enabled = false;
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
            if (_nuevo || string.IsNullOrWhiteSpace(_txtClave.Text))
                return;
            if (MessageBox.Show(this, "¿Desea eliminar el activo fijo seleccionado?", "Activos fijos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try {
                await _service.EliminarAsync(_txtClave.Text);
                Nuevo();
                await CargarAsync();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Activos fijos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private ActivoFijo Modelo() {
            return new ActivoFijo {
                Clave = _txtClave.Text,
                Tipo = _cmbTipo.SelectedItem is TipoActivo ? (short?)((TipoActivo)_cmbTipo.SelectedItem).Clave : null,
                Descripcion = _txtDescripcion.Text,
                Localizacion = _txtLocaliz.Text,
                MontoOriginal = Convert.ToDouble(_numMontoOrig.Value),
                MontoOriginalMonedaExtranjera = Convert.ToDouble(_numMontoOrigEx.Value),
                FecAdquisicion = _dtFechaAdq.GetFecha(),
                MaximoDeducible = Convert.ToDouble(_numMaxDed.Value),
                ValorMercado = Convert.ToDouble(_numValMer.Value),
                DepresiacionAcumulada = Convert.ToDouble(_numDepAcu.Value),
                VidaUtil = Convert.ToDouble(_numVida.Value),
                MetodoDepresiacion = _txtMetDep.Text,
                TasaDepresiacion = Convert.ToDouble(_numTasDep.Value),
                TasaDepresiacionFiscal = Convert.ToDouble(_numTasDepFis.Value),
                Status = _txtStatus.Text,
                IdDepartamento = _numDepto.Value == 0 ? (short?)null : Convert.ToInt16(_numDepto.Value),
                NumSerie = _txtSerie.Text,
                BANDEDINM = _txtBand.Text,
                FecInicioDepresiacion = _dtIniDep.GetFecha(),
                FecInicioDepresiacionFiscal = _dtIniDepFis.GetFecha(),
                FechaBaja = _dtFechaEliminacion.GetFecha(),
                DepresiacionAcumuladaFiscal = Convert.ToDouble(_numDepFis.Value),
                Nota = _txtObserv.Text,
                TipoCambio = Convert.ToDouble(_numTipoCambio.Value),
                PolizaSeguro = _txtPolizaSeg.Text,
                CompaniaSeguro = _txtCompAseg.Text,
                AgenteSeguro = _txtAgente.Text,
                TelefonoSiniestro = _txtTel.Text,
                TipoCobertura = _txtCobertura.Text,
                MontoAsegurado = Convert.ToDouble(_numMontoAseg.Value),
                PrimaTotal = Convert.ToDouble(_numPrima.Value),
                Deducible = Convert.ToDouble(_numDeducible.Value),
                FecVigencia = _dtVigencia.GetFecha(),
                FecProximoMantto = _dtProxMan.GetFecha(),
                FecUltMantto = _dtUltMan.GetFecha(),
                PeriodoMantto = _numPeriodoMan.Value == 0 ? (short?)null : Convert.ToInt16(_numPeriodoMan.Value),
                CostoMantto = Convert.ToDouble(_numCostoMan.Value),
                Responsable = _txtResponsable.Text
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
