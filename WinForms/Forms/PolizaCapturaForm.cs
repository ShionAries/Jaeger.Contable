using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.ValueObjects;
using Jaeger.Contable.WinForms.Context;
using Jaeger.Contable.WinForms.Forms;

namespace Jaeger.Contable.Forms {
    public partial class PolizaCapturaForm : Form {
        private readonly IPolizaContableService _service;
        private readonly IConceptoService _conceptoService;
        private readonly IPeriodoContableService _periodoService;
        private readonly IPolizaCapturaMovimientoContext _movimientoContext;
        private readonly IParametroEmpresaService _parametroEmpresaService;
        private readonly IContabilizacionContableService _contabilizacionContableService;
        private readonly List<MovimientoContableRequest> _partidas = new List<MovimientoContableRequest>();
        private readonly PolizaContableConsulta _polizaInicial;
        private readonly bool _modoEdicion;
        private bool _modificado;
        private bool _inicializando;
        private bool _guardando;
        private bool _periodoValido;
        private bool _puedeEditar = true;
        private int _versionValidacionPeriodo;
        private readonly BindingSource _partidasBindingSource = new BindingSource();

        public PolizaCapturaForm(IPolizaContableService service, ITipoPolizaService tipoPolizaService, IConceptoService conceptoService, IPeriodoContableService periodoService, IPolizaCapturaMovimientoContext movimientoContext, PolizaContableConsulta polizaInicial = null, IParametroEmpresaService parametroEmpresaService = null, IContabilizacionContableService contabilizacionContableService = null) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            if (tipoPolizaService == null)
                throw new ArgumentNullException(nameof(tipoPolizaService));
            _conceptoService = conceptoService ?? throw new ArgumentNullException(nameof(conceptoService));
            _periodoService = periodoService ?? throw new ArgumentNullException(nameof(periodoService));
            _movimientoContext = movimientoContext ?? throw new ArgumentNullException(nameof(movimientoContext));
            _parametroEmpresaService = parametroEmpresaService ?? throw new ArgumentNullException(nameof(parametroEmpresaService));
            _contabilizacionContableService = contabilizacionContableService ?? throw new ArgumentNullException(nameof(contabilizacionContableService));
            _polizaInicial = polizaInicial;
            _modoEdicion = polizaInicial != null;
            InitializeComponent();
            _inicializando = true;
            _periodoValido = false;
            gridPartidas.AutoGenerateColumns = false;
            _partidasBindingSource.DataSource = _partidas;
            gridPartidas.DataSource = _partidasBindingSource;
            gridPartidas.CellDoubleClick += gridPartidas_CellDoubleClick;
            txtConcepto.TextChanged += (s, e) => { MarcarModificado(); ActualizarEstadoFormulario(); };
            cmbTipo.SelectedValueChanged += (s, e) => { MarcarModificado(); ActualizarEstadoFormulario(); };
            datFecha.ValueChanged += async (s, e) => {
                MarcarModificado();
                await ValidarPeriodoSeleccionadoAsync();
            };
            FormClosing += PolizaCapturaForm_FormClosing;
            RefrescarPartidas();
            Load += async (s, e) => {
                await InicializarAsync(tipoPolizaService);
                await ValidarPeriodoSeleccionadoAsync();
                _inicializando = false;
                _modificado = false;
                ActualizarEstadoFormulario();
            };
        }

        private async Task InicializarAsync(ITipoPolizaService servicio) {
            await CargarTiposPolizaAsync(servicio);
            if (!_modoEdicion || _polizaInicial == null)
                return;

            if (EstaAuditada(_polizaInicial.LogAudita)) {
                _puedeEditar = false;
                lblEstado.Text = "La póliza está auditada y no puede modificarse.";
                MessageBox.Show(this,
                    "La póliza está auditada y no puede modificarse.",
                    "Póliza",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                BeginInvoke(new Action(CerrarEdicionBloqueada));
                return;
            }

            txtNumero.Text = _polizaInicial.NumeroPoliza ?? string.Empty;
            txtConcepto.Text = _polizaInicial.Concepto ?? string.Empty;
            if (_polizaInicial.Fecha.HasValue)
                datFecha.Value = _polizaInicial.Fecha.Value;

            if (!string.IsNullOrWhiteSpace(_polizaInicial.TipoPoliza))
                cmbTipo.SelectedValue = _polizaInicial.TipoPoliza.Trim();

            _partidas.Clear();
            if (_polizaInicial.Partidas != null) {
                foreach (var partida in _polizaInicial.Partidas)
                    _partidas.Add(CopiarPartida(partida));
            }

            RenumerarPartidas();
            Text = "Editar póliza";
            btnGuardar.Text = "Actualizar";
            txtNumero.ReadOnly = true;
            cmbTipo.Enabled = false;
            RefrescarPartidas();
        }

        private static MovimientoContableRequest CopiarPartida(MovimientoContableRequest partida) {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            return new MovimientoContableRequest {
                TipoPoliza = partida.TipoPoliza,
                NumeroPoliza = partida.NumeroPoliza,
                NumeroPartida = partida.NumeroPartida,
                Ejercicio = partida.Ejercicio,
                Periodo = partida.Periodo,
                Fecha = partida.Fecha,
                Concepto = partida.Concepto,
                NumeroCuenta = partida.NumeroCuenta,
                DebeHaber = partida.DebeHaber,
                Importe = partida.Importe,
                TipoCambio = partida.TipoCambio,
                NumeroDepartamento = partida.NumeroDepartamento,
                Contrapartida = partida.Contrapartida,
                Orden = partida.Orden,
                CentroCostos = partida.CentroCostos,
                Grupo = partida.Grupo
            };
        }

        private async Task CargarTiposPolizaAsync(ITipoPolizaService servicio) {
            try {
                var tipos = await servicio.ObtenerTodosAsync();
                cmbTipo.DataSource = tipos;
                cmbTipo.DisplayMember = "DESCRIP";
                cmbTipo.ValueMember = "TIPO";
                cmbTipo.SelectedIndex = tipos.Count > 0 ? 0 : -1;
                cmbTipo.Enabled = tipos.Count > 0;
                if (tipos.Count == 0) {
                    lblEstado.Text = "No existen tipos de póliza configurados en TIPOSPOL.";
                    btnGuardar.Enabled = false;
                }
            } catch (Exception ex) {
                cmbTipo.DataSource = null;
                cmbTipo.Enabled = false;
                btnGuardar.Enabled = false;
                MessageBox.Show(this, "No fue posible cargar TIPOSPOL: " + ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GuardarAsync() {
            try {
                if (!_puedeEditar)
                    throw new InvalidOperationException("La póliza está auditada y no puede modificarse.");
                var request = CrearRequest();
                btnGuardar.Enabled = false;
                Cursor = Cursors.WaitCursor;

                _guardando = true;
                ActualizarEstadoFormulario();

                if (_modoEdicion) {
                    await _service.ActualizarAsync(request);
                    lblEstado.Text = string.Format("Actualizada: {0}-{1}", request.TipoPoliza, request.NumeroPoliza);
                    MessageBox.Show(this,
                        string.Format("Póliza {0} actualizada correctamente.", request.NumeroPoliza),
                        "Póliza",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                } else {
                    var parametro = await _parametroEmpresaService.ObtenerAsync(1);
                    bool contabilizarEnLinea = string.Equals(
                        parametro.CONTABLINEA, "S", StringComparison.OrdinalIgnoreCase);
                    var resultado = await _service.RegistrarAsync(request);
                    txtNumero.Text = resultado.NumeroPoliza;

                    if (contabilizarEnLinea) {
                        try {
                            await _contabilizacionContableService.ContabilizarPolizaAsync(
                                resultado.TipoPoliza,
                                resultado.NumeroPoliza,
                                resultado.Ejercicio,
                                resultado.Periodo);
                            lblEstado.Text = string.Format("Registrada y contabilizada: {0}-{1}", resultado.TipoPoliza, resultado.NumeroPoliza);
                            MessageBox.Show(this,
                                string.Format("Póliza {0} registrada y contabilizada correctamente.\nDebe: {1:N2}\nHaber: {2:N2}", resultado.NumeroPoliza, resultado.TotalDebe, resultado.TotalHaber),
                                "Póliza",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        } catch (Exception ex) {
                            _modificado = false;
                            lblEstado.Text = string.Format("Registrada, pendiente de contabilización: {0}-{1}", resultado.TipoPoliza, resultado.NumeroPoliza);
                            MessageBox.Show(this,
                                string.Format("La póliza {0} fue registrada, pero no pudo contabilizarse automáticamente.\n\n{1}\n\nPuede contabilizarla posteriormente mediante la opción de contabilización por período.", resultado.NumeroPoliza, ex.Message),
                                "Contabilización",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            DialogResult = DialogResult.OK;
                            Close();
                            return;
                        }
                    } else {
                        lblEstado.Text = string.Format("Registrada: {0}-{1}", resultado.TipoPoliza, resultado.NumeroPoliza);
                        MessageBox.Show(this,
                            string.Format("Póliza {0} registrada correctamente.\nDebe: {1:N2}\nHaber: {2:N2}\n\nLa póliza queda pendiente de contabilización por periodo.", resultado.NumeroPoliza, resultado.TotalDebe, resultado.TotalHaber),
                            "Póliza",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }

                _modificado = false;
                DialogResult = DialogResult.OK;
                Close();
            } catch (InvalidOperationException ex) {
                MostrarError(ex);
            } catch (ArgumentException ex) {
                MostrarError(ex);
            } catch (Exception ex) {
                MessageBox.Show(this,
                    (_modoEdicion ? "No fue posible actualizar la póliza: " : "No fue posible registrar la póliza: ") + ex.Message,
                    "Póliza",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } finally {
                _guardando = false;
                Cursor = Cursors.Default;
                if (!IsDisposed)
                    ActualizarEstadoFormulario();
            }
        }

        private PolizaContableRequest CrearRequest() {
            DateTime fecha = datFecha.Value;
            if (_modoEdicion && _polizaInicial != null &&
                (fecha.Year != _polizaInicial.Ejercicio || fecha.Month != _polizaInicial.Periodo))
                throw new ArgumentException("La fecha de una póliza existente debe permanecer dentro del mismo ejercicio y periodo.");

            return new PolizaContableRequest {
                TipoPoliza = cmbTipo.SelectedValue == null ? string.Empty : Convert.ToString(cmbTipo.SelectedValue),
                NumeroPoliza = string.IsNullOrWhiteSpace(txtNumero.Text) ? null : txtNumero.Text.Trim(),
                Ejercicio = (short)fecha.Year,
                Periodo = (short)fecha.Month,
                Fecha = fecha,
                Concepto = txtConcepto.Text == null ? string.Empty : txtConcepto.Text.Trim(),
                Partidas = _partidas.Select(CopiarPartida).ToList()
            };
        }

        private void RefrescarPartidas() {
            _partidasBindingSource.ResetBindings(false);
            var debe = _partidas.Where(x => string.Equals(x.DebeHaber, "D", StringComparison.OrdinalIgnoreCase)).Sum(x => x.Importe);
            var haber = _partidas.Where(x => string.Equals(x.DebeHaber, "H", StringComparison.OrdinalIgnoreCase)).Sum(x => x.Importe);
            lblDebe.Text = string.Format("Debe: {0:N2}", debe);
            lblHaber.Text = string.Format("Haber: {0:N2}", haber);
            lblEstado.Text = ImporteContable.SonIguales(debe, haber)
                ? "Póliza balanceada."
                : "Póliza pendiente de balancear.";
            ActualizarEstadoFormulario();
        }

        private void ActualizarEstadoFormulario() {
            double debe = _partidas
                .Where(x => string.Equals(x.DebeHaber, "D", StringComparison.OrdinalIgnoreCase))
                .Sum(x => x.Importe);
            double haber = _partidas
                .Where(x => string.Equals(x.DebeHaber, "H", StringComparison.OrdinalIgnoreCase))
                .Sum(x => x.Importe);

            bool encabezadoValido =
                cmbTipo.SelectedValue != null &&
                !string.IsNullOrWhiteSpace(txtConcepto.Text);

            bool balanceada = _partidas.Count > 0 &&
                ImporteContable.SonIguales(debe, haber);

            bool puedeModificar = _puedeEditar && !_guardando && !_inicializando;
            bool puedeGuardar = puedeModificar && _periodoValido && encabezadoValido && balanceada &&
                (!_modoEdicion || _modificado);

            btnGuardar.Enabled = puedeGuardar;
            btnAgregarPartida.Enabled = puedeModificar;
            btnRemoverPartida.Enabled = puedeModificar && _partidas.Count > 0;
            btnDuplicarPartida.Enabled = puedeModificar && _partidas.Count > 0;
            btnConcepto.Enabled = puedeModificar;
            btnCerrar.Enabled = !_guardando;
            datFecha.Enabled = puedeModificar;
            txtConcepto.ReadOnly = !puedeModificar;

            if (!_modoEdicion)
                cmbTipo.Enabled = puedeModificar && cmbTipo.DataSource != null;
            else
                cmbTipo.Enabled = false;
        }

        private static bool EstaAuditada(string valor) {
            if (string.IsNullOrWhiteSpace(valor))
                return false;

            string estado = valor.Trim();
            return string.Equals(estado, "S", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(estado, "SI", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(estado, "1", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(estado, "TRUE", StringComparison.OrdinalIgnoreCase);
        }

        private void CerrarEdicionBloqueada() {
            if (IsDisposed || Disposing)
                return;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MostrarError(Exception ex) {
            lblEstado.Text = ex.Message;
            MessageBox.Show(this, ex.Message, "Captura de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool ValidarEncabezado() {
            if (cmbTipo.SelectedValue == null ||
                string.IsNullOrWhiteSpace(Convert.ToString(cmbTipo.SelectedValue))) {
                MessageBox.Show(this, "Seleccione el tipo de póliza.", "Captura de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConcepto.Text)) {
                MessageBox.Show(this, "Capture o seleccione el concepto de la póliza.", "Captura de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConcepto.Focus();
                return false;
            }

            if (!_periodoValido) {
                MessageBox.Show(this, "La fecha seleccionada no pertenece a un periodo contable abierto en ADMPER.", "Captura de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                datFecha.Focus();
                return false;
            }

            if (_partidas.Count == 0) {
                MessageBox.Show(this, "La póliza debe contener al menos una partida.", "Captura de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            double debe = _partidas.Where(x => string.Equals(x.DebeHaber, "D", StringComparison.OrdinalIgnoreCase)).Sum(x => x.Importe);
            double haber = _partidas.Where(x => string.Equals(x.DebeHaber, "H", StringComparison.OrdinalIgnoreCase)).Sum(x => x.Importe);

            if (!ImporteContable.SonIguales(debe, haber)) {
                MessageBox.Show(this, string.Format("La póliza no está balanceada. Debe: {0:N2}, Haber: {1:N2}.", debe, haber), "Captura de póliza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async Task ValidarPeriodoSeleccionadoAsync() {
            int version = ++_versionValidacionPeriodo;
            _periodoValido = false;
            ActualizarEstadoFormulario();

            DateTime fecha = datFecha.Value;
            short ejercicio = (short)fecha.Year;
            short periodo = (short)fecha.Month;

            if (_modoEdicion && _polizaInicial != null &&
                (ejercicio != _polizaInicial.Ejercicio || periodo != _polizaInicial.Periodo)) {
                _periodoValido = false;
                lblEstado.Text = "La fecha de una póliza existente debe permanecer dentro del mismo ejercicio y periodo.";
                ActualizarEstadoFormulario();
                return;
            }

            try {
                await _periodoService.ValidarRegistroAsync(ejercicio, periodo);
                if (version != _versionValidacionPeriodo || IsDisposed)
                    return;

                _periodoValido = true;
                lblEstado.Text = string.Format("Periodo {0}/{1} abierto para captura.", periodo, ejercicio);
                ActualizarEstadoFormulario();
            } catch (Exception ex) {
                if (version != _versionValidacionPeriodo || IsDisposed)
                    return;

                _periodoValido = false;
                lblEstado.Text = ex.Message;
            } finally {
                if (!IsDisposed)
                    ActualizarEstadoFormulario();
            }
        }

        private void btnConcepto_Click(object sender, EventArgs e) {
            if (!_puedeEditar || _guardando || _inicializando)
                return;

            try {
                using (var form = new ConceptoSelectorPolizaForm(_conceptoService)) {
                    if (form.ShowDialog(this) == DialogResult.OK && form.ConceptoSeleccionado != null) {
                        txtConcepto.Text = form.ConceptoSeleccionado.Descripcion ?? string.Empty;
                        ActualizarEstadoFormulario();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible seleccionar el concepto: " + ex.Message, "Concepto de póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e) {
            if (!ValidarEncabezado())
                return;

            await this.GuardarAsync();
        }

        private void btnAgregarPartida_Click(object sender, EventArgs e) {
            if (!_puedeEditar || _guardando || _inicializando)
                return;

            try {
                if (string.IsNullOrWhiteSpace(txtConcepto.Text)) {
                    MessageBox.Show(this, "Capture o seleccione primero el concepto de la póliza.", "Partidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConcepto.Focus();
                    return;
                }

                using (var form = new PolizaCapturaMovimientoForm(
                    _movimientoContext,
                    txtConcepto.Text.Trim())) {
                    if (form.ShowDialog(this) != DialogResult.OK || form.Movimiento == null)
                        return;

                    AgregarPartida(form.Movimiento);
                    _modificado = true;
                    RefrescarPartidas();
                    SeleccionarUltimaPartida();
                }
            } catch (ArgumentException ex) {
                MostrarErrorPartida(ex.Message);
            } catch (InvalidOperationException ex) {
                MostrarErrorPartida(ex.Message);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible agregar la partida: " + ex.Message,
                    "Partidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDuplicarPartida_Click(object sender, EventArgs e) {
            if (!_puedeEditar || _guardando || _inicializando)
                return;

            try {
                int indice = ObtenerIndicePartidaSeleccionada();
                if (indice < 0) {
                    MessageBox.Show(this, "Seleccione una partida para duplicarla.", "Partidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var copia = CopiarPartida(_partidas[indice]);
                int nuevoIndice = indice + 1;
                _partidas.Insert(nuevoIndice, copia);
                RenumerarPartidas();
                _modificado = true;
                RefrescarPartidas();
                SeleccionarPartida(nuevoIndice);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible duplicar la partida: " + ex.Message,
                    "Partidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverPartida_Click(object sender, EventArgs e) {
            if (!_puedeEditar || _guardando || _inicializando)
                return;

            try {
                int indice = ObtenerIndicePartidaSeleccionada();
                if (indice < 0) {
                    MessageBox.Show(this, "Seleccione una partida.", "Partidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show(this, "¿Desea eliminar la partida seleccionada?",
                    "Eliminar partida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                EliminarPartida(indice);
                _modificado = true;
                RefrescarPartidas();

                if (_partidas.Count > 0)
                    SeleccionarPartida(Math.Min(indice, _partidas.Count - 1));
            } catch (ArgumentOutOfRangeException ex) {
                MostrarErrorPartida(ex.Message);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible eliminar la partida: " + ex.Message,
                    "Partidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarPartida(MovimientoContableRequest partida) {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            _partidas.Add(partida);
            RenumerarPartidas();
        }

        private void EditarPartida(int indice, MovimientoContableRequest partida) {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (indice < 0 || indice >= _partidas.Count)
                throw new ArgumentOutOfRangeException(nameof(indice));

            var original = _partidas[indice];
            if (original == null)
                throw new InvalidOperationException("La partida seleccionada no es válida.");

            partida.TipoPoliza = original.TipoPoliza;
            partida.NumeroPoliza = original.NumeroPoliza;
            partida.NumeroPartida = original.NumeroPartida;
            partida.Ejercicio = original.Ejercicio;
            partida.Periodo = original.Periodo;
            partida.Contrapartida = original.Contrapartida;
            partida.Orden = original.Orden;
            partida.Fecha = original.Fecha;

            _partidas[indice] = partida;
            RenumerarPartidas();
        }

        private void EliminarPartida(int indice) {
            if (indice < 0 || indice >= _partidas.Count)
                throw new ArgumentOutOfRangeException(nameof(indice));

            _partidas.RemoveAt(indice);
            RenumerarPartidas();
        }

        private void RenumerarPartidas() {
            for (int i = 0; i < _partidas.Count; i++)
                _partidas[i].NumeroPartida = i + 1;
        }

        private int ObtenerIndicePartidaSeleccionada() {
            if (gridPartidas.SelectedRows == null || gridPartidas.SelectedRows.Count == 0)
                return -1;

            var fila = gridPartidas.SelectedRows[0];
            if (fila == null || fila.IsNewRow)
                return -1;

            var partida = fila.DataBoundItem as MovimientoContableRequest;
            if (partida != null) {
                int indicePartida = _partidas.IndexOf(partida);
                if (indicePartida >= 0)
                    return indicePartida;
            }

            int indice = fila.Index;
            return indice >= 0 && indice < _partidas.Count ? indice : -1;
        }

        private void SeleccionarPartida(int indice) {
            if (indice < 0 || indice >= gridPartidas.Rows.Count || gridPartidas.Columns.Count == 0)
                return;

            var fila = gridPartidas.Rows[indice];
            if (fila == null || fila.IsNewRow)
                return;

            gridPartidas.ClearSelection();
            fila.Selected = true;
            gridPartidas.CurrentCell = fila.Cells[0];
            if (indice < gridPartidas.RowCount)
                gridPartidas.FirstDisplayedScrollingRowIndex = indice;
        }

        private void SeleccionarUltimaPartida() {
            if (_partidas.Count == 0 || gridPartidas.Rows.Count == 0)
                return;

            int indice = Math.Min(
                _partidas.Count - 1,
                gridPartidas.Rows.Count - 1);

            if (indice >= 0)
                SeleccionarPartida(indice);
        }

        private void MostrarErrorPartida(string mensaje) {
            MessageBox.Show(this, mensaje, "Partidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridPartidas_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (!_puedeEditar || _guardando || _inicializando)
                return;

            int indice = e == null ? -1 : e.RowIndex;

            if (indice < 0 || indice >= _partidas.Count)
                return;

            try {
                var partida = _partidas[indice];
                if (partida == null)
                    return;

                using (var form = new PolizaCapturaMovimientoForm(
                    _movimientoContext,
                    txtConcepto.Text.Trim(),
                    partida)) {
                    if (form.ShowDialog(this) != DialogResult.OK || form.Movimiento == null)
                        return;

                    EditarPartida(indice, form.Movimiento);
                    _modificado = true;
                    RefrescarPartidas();
                    SeleccionarPartida(indice);
                }
            } catch (ArgumentException ex) {
                MostrarErrorPartida(ex.Message);
            } catch (InvalidOperationException ex) {
                MostrarErrorPartida(ex.Message);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible modificar la partida: " + ex.Message,
                    "Partidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarcarModificado() {
            if (!_inicializando && !_guardando)
                _modificado = true;
        }

        private void PolizaCapturaForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (_guardando) {
                e.Cancel = true;
                return;
            }

            if (!_modificado || DialogResult == DialogResult.OK)
                return;

            var resultado = MessageBox.Show(this,
                "Hay cambios sin guardar en la póliza. ¿Desea cerrar sin guardar?",
                "Captura de póliza",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resultado != DialogResult.Yes)
                e.Cancel = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
