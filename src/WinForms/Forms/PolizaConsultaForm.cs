using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.WinForms.Context;
using Jaeger.Contable.WinForms.Forms;

namespace Jaeger.Contable.Forms {
    public partial class PolizaConsultaForm : Form {
        private readonly IPolizaConsultaService _service;
        private readonly ICuentaService _cuentaService;
        private readonly IReversionPolizaService _reversionPolizaService;
        private readonly ITipoPolizaService _tipoPolizaServiceLocal;
        private readonly IPolizaContableService _polizaContableService;
        private readonly IConceptoService _conceptoService;
        private readonly IPeriodoContableService _periodoContableService;
        private readonly IPolizaCapturaMovimientoContext _movimientoContext;
        private readonly IParametroEmpresaService _parametroEmpresaService;
        private readonly IContabilizacionContableService _contabilizacionContableService;
        
        private int _modoConsulta;

        public PolizaConsultaForm(
            IPolizaConsultaService service,
            ITipoPolizaService tipoPolizaService,
            ICuentaService cuentaService,
            IReversionPolizaService reversionPolizaService,
            IPolizaContableService polizaContableService,
            IConceptoService conceptoService,
            IPeriodoContableService periodoContableService,
            IPolizaCapturaMovimientoContext movimientoContext,
            IParametroEmpresaService parametroEmpresaService,
            IContabilizacionContableService contabilizacionContableService) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _cuentaService = cuentaService ?? throw new ArgumentNullException(nameof(cuentaService));
            _reversionPolizaService = reversionPolizaService;
            _tipoPolizaServiceLocal = tipoPolizaService;
            _polizaContableService = polizaContableService ?? throw new ArgumentNullException(nameof(polizaContableService));
            _conceptoService = conceptoService ?? throw new ArgumentNullException(nameof(conceptoService));
            _periodoContableService = periodoContableService ?? throw new ArgumentNullException(nameof(periodoContableService));
            _movimientoContext = movimientoContext ?? throw new ArgumentNullException(nameof(movimientoContext));
            _parametroEmpresaService = parametroEmpresaService ?? throw new ArgumentNullException(nameof(parametroEmpresaService));
            _contabilizacionContableService = contabilizacionContableService ?? throw new ArgumentNullException(nameof(contabilizacionContableService));
            if (tipoPolizaService == null)
                throw new ArgumentNullException(nameof(tipoPolizaService));
            InitializeComponent();
            btnRevertir.Click += async (s, e) => await RevertirSeleccionadaAsync();
            btnRevertir.Enabled = _reversionPolizaService != null;
            ToolBar.Items.Insert(Math.Max(0, ToolBar.Items.Count - 1), btnRevertir);

            btnEditar.Click += async (s, e) => await EditarSeleccionadaAsync();
            btnEliminar.Click += async (s, e) => await EliminarSeleccionadaAsync();
            this.polizas.AutoGenerateColumns = false;
            ActualizarAcciones();
            Load += async (s, e) => await InicializarFiltrosAsync(tipoPolizaService);
            nudEjercicio.ComboBox.SelectedIndexChanged += async (s, e) => await EjercicioSeleccionadoAsync();
            nudPeriodo.ComboBox.SelectedIndexChanged += (s, e) => ActualizarEstadoFiltros();
            cmbTipo.ComboBox.SelectedIndexChanged += (s, e) => ActualizarEstadoFiltros();
        }

        private void PolizaConsultaForm_Load(object sender, EventArgs e) {
            this.periodoToolStripMenuItem.Click += async (s, ev) => await ConsultarPeriodoAsync();
            this.polizaToolStripMenuItem.Click += async (s, ev) => await ConsultarPolizaAsync();
            this.cuentaToolStripMenuItem.Click += async (s, ev) => await SeleccionarCuentaAsync();
        }

        private async Task InicializarFiltrosAsync(ITipoPolizaService tipoPolizaService) {
            try {
                Cursor = Cursors.WaitCursor;
                await CargarEjerciciosAsync();
                await CargarTiposPolizaAsync(tipoPolizaService);
                ActualizarEstadoFiltros();
            } catch (Exception ex) {
                MostrarError(ex);
            } finally {
                Cursor = Cursors.Default;
            }
        }

        private async Task CargarEjerciciosAsync() {
            var ejercicios = await _periodoContableService.ObtenerEjerciciosAsync();
            nudEjercicio.ComboBox.DataSource = null;
            nudEjercicio.ComboBox.Items.Clear();
            foreach (var ejercicio in ejercicios)
                nudEjercicio.ComboBox.Items.Add(ejercicio);

            nudEjercicio.Enabled = ejercicios.Count > 0;
            nudPeriodo.Enabled = false;
            nudPeriodo.ComboBox.DataSource = null;
            nudPeriodo.ComboBox.Items.Clear();

            if (ejercicios.Count == 0)
                throw new InvalidOperationException("No existen ejercicios contables disponibles en ADMPER.");

            nudEjercicio.ComboBox.SelectedIndex = -1;
        }

        private async Task EjercicioSeleccionadoAsync() {
            try {
                if (nudEjercicio.ComboBox.SelectedItem == null) {
                    nudPeriodo.Enabled = false;
                    nudPeriodo.ComboBox.DataSource = null;
                    ActualizarEstadoFiltros();
                    return;
                }

                Cursor = Cursors.WaitCursor;
                short ejercicio = Convert.ToInt16(nudEjercicio.ComboBox.SelectedItem);
                var periodos = await _periodoContableService.ObtenerTodosAsync(ejercicio);
                var items = new List<PeriodoConsultaItem>();
                foreach (var periodo in periodos)
                    items.Add(new PeriodoConsultaItem(periodo.Periodo, ObtenerNombrePeriodo(periodo.Periodo)));

                nudPeriodo.ComboBox.DataSource = items;
                nudPeriodo.ComboBox.DisplayMember = "Nombre";
                nudPeriodo.ComboBox.ValueMember = "Numero";
                nudPeriodo.Enabled = items.Count > 0;
                nudPeriodo.ComboBox.SelectedIndex = -1;
                estado.Text = items.Count == 0
                    ? "El ejercicio seleccionado no tiene periodos contables."
                    : "Seleccione el periodo contable.";
                ActualizarEstadoFiltros();
            } catch (Exception ex) {
                nudPeriodo.Enabled = false;
                nudPeriodo.ComboBox.DataSource = null;
                MostrarError(ex);
            } finally {
                Cursor = Cursors.Default;
            }
        }

        private static string ObtenerNombrePeriodo(short periodo) {
            switch (periodo) {
                case 1: return "01 - Enero";
                case 2: return "02 - Febrero";
                case 3: return "03 - Marzo";
                case 4: return "04 - Abril";
                case 5: return "05 - Mayo";
                case 6: return "06 - Junio";
                case 7: return "07 - Julio";
                case 8: return "08 - Agosto";
                case 9: return "09 - Septiembre";
                case 10: return "10 - Octubre";
                case 11: return "11 - Noviembre";
                case 12: return "12 - Diciembre";
                case 13: return "13 - Ajuste";
                case 14: return "14 - Cierre";
                default: return periodo.ToString("00") + " - Periodo";
            }
        }

        private void ActualizarEstadoFiltros() {
            bool ejercicioSeleccionado = nudEjercicio.ComboBox.SelectedItem != null;
            bool periodoSeleccionado = nudPeriodo.ComboBox.SelectedItem != null;
            bool tipoSeleccionado = cmbTipo.ComboBox.SelectedItem != null;

            nudPeriodo.Enabled = ejercicioSeleccionado;

            bool puedeConsultar = ejercicioSeleccionado && periodoSeleccionado;
            periodoToolStripMenuItem.Enabled = puedeConsultar;
            polizaToolStripMenuItem.Enabled = puedeConsultar && tipoSeleccionado;
            cuentaToolStripMenuItem.Enabled = puedeConsultar && tipoSeleccionado;
        }

        private short ObtenerEjercicioSeleccionado() {
            if (nudEjercicio.ComboBox.SelectedItem == null)
                throw new InvalidOperationException("Seleccione primero el ejercicio contable.");
            return Convert.ToInt16(nudEjercicio.ComboBox.SelectedItem);
        }

        private short ObtenerPeriodoSeleccionado() {
            if (nudPeriodo.ComboBox.SelectedValue == null)
                throw new InvalidOperationException("Seleccione el periodo contable.");
            return Convert.ToInt16(nudPeriodo.ComboBox.SelectedValue);
        }

        private sealed class PeriodoConsultaItem {
            public short Numero { get; private set; }
            public string Nombre { get; private set; }

            public PeriodoConsultaItem(short numero, string nombre) {
                Numero = numero;
                Nombre = nombre;
            }
        }

        private async Task CargarTiposPolizaAsync(ITipoPolizaService servicio) {
            try {
                var tipos = await servicio.ObtenerTodosAsync();
                var _cmbTipo =(ComboBox) cmbTipo.ComboBox;
                _cmbTipo.DataSource = tipos;
                _cmbTipo.DisplayMember = "DESCRIP";
                _cmbTipo.ValueMember = "TIPO";
                _cmbTipo.SelectedIndex = tipos.Count > 0 ? 0 : -1;
                _cmbTipo.Enabled = tipos.Count > 0;
                this.polizaToolStripMenuItem.Enabled = tipos.Count > 0;
                this.cuentaToolStripMenuItem.Enabled = tipos.Count > 0;
                this.periodoToolStripMenuItem.Enabled = tipos.Count > 0;
            } catch (Exception ex) {
                var _cmbTipo = this.cmbTipo.ComboBox as ComboBox;
                _cmbTipo.DataSource = null;
                _cmbTipo.Enabled = false;
                this.polizaToolStripMenuItem.Enabled = false;
                this.cuentaToolStripMenuItem.Enabled = false;
                this.periodoToolStripMenuItem.Enabled = false;
                MessageBox.Show(this, "No fue posible cargar TIPOSPOL: " + ex.Message, "Tipos de póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsulta_ButtonClick(object sender, EventArgs e) {
            ToolStripSplitButton button = (ToolStripSplitButton)sender;
        }

        private void btnConsulta_Click(object sender, EventArgs e) {
            ToolStripMenuItem selectedItem = (ToolStripMenuItem)sender;

            // Cambia dinámicamente el texto del botón principal al de la última opción elegida
            btnConsulta.Text = selectedItem.Text;
            btnConsulta.DefaultItem = selectedItem;
        }

        private async Task SeleccionarCuentaAsync() {
            try {
                Cursor = Cursors.WaitCursor;
                using (var form = new CuentaMovimientoSelectorForm(_cuentaService)) {
                    Cursor = Cursors.Default;
                    if (form.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(form.NumeroCuentaSeleccionada)) {
                        txtCuenta.Text = form.NumeroCuentaSeleccionada;
                        await ConsultarCuentaAsync();
                    }
                }
            } catch (Exception ex) {
                Cursor = Cursors.Default;
                MessageBox.Show(this, "No fue posible cargar las cuentas: " + ex.Message,
                    "Selección de cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                Cursor = Cursors.Default;
            }
        }

        private async Task ConsultarPolizaAsync() {
            try {
                _modoConsulta = 2;
                ValidarTipoNumero();
                var resultado = await _service.ObtenerAsync(Convert.ToString(cmbTipo.ComboBox.SelectedValue), txtNumero.Text.Trim(), ObtenerEjercicioSeleccionado(), ObtenerPeriodoSeleccionado());
                this.polizas.DataSource = resultado == null ? null : new List<PolizaContableConsulta> { resultado };
                this.detalle.DataSource = resultado == null ? null : resultado.Partidas;
                this.estado.Text = resultado == null ? "Póliza no encontrada." : "Póliza consultada correctamente.";
            } catch (Exception ex) {
                MostrarError(ex);
            }
        }

        private async Task ConsultarCuentaAsync() {
            try {
                _modoConsulta = 3;
                if (string.IsNullOrWhiteSpace(txtCuenta.Text))
                    throw new ArgumentException("La cuenta es obligatoria.");
                var resultado = await _service.ObtenerPorCuentaAsync(txtCuenta.Text.Trim(), ObtenerEjercicioSeleccionado(), ObtenerPeriodoSeleccionado());
                this.polizas.DataSource = resultado;
                this.detalle.DataSource = null;
                this.estado.Text = resultado.Count + " póliza(s) encontrada(s).";
            } catch (Exception ex) {
                MostrarError(ex);
            }
        }

        private async Task ConsultarPeriodoAsync() {
            try {
                _modoConsulta = 1;
                var resultado = await _service.ObtenerPorPeriodoAsync(ObtenerEjercicioSeleccionado(), ObtenerPeriodoSeleccionado());
                this.polizas.DataSource = resultado;
                this.detalle.DataSource = null;
                this.estado.Text = resultado.Count + " póliza(s) encontrada(s).";
            } catch (Exception ex) {
                MostrarError(ex);
            }
        }


        private PolizaContableResumen ObtenerResumenSeleccionado()
        {
            if (polizas.CurrentRow == null)
                return null;

            return polizas.CurrentRow.DataBoundItem as PolizaContableResumen;
        }

        private PolizaContableConsulta ObtenerConsultaSeleccionada()
        {
            if (polizas.CurrentRow == null)
                return null;

            return polizas.CurrentRow.DataBoundItem as PolizaContableConsulta;
        }

        private static bool EstaAuditada(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return false;

            string estado = valor.Trim();
            return string.Equals(estado, "S", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(estado, "SI", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(estado, "1", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(estado, "TRUE", StringComparison.OrdinalIgnoreCase);
        }

        private void ActualizarAcciones() {
            object seleccionado = polizas.CurrentRow == null ? null : polizas.CurrentRow.DataBoundItem;
            string logAudita = null;
            if (seleccionado is PolizaContableConsulta)
                logAudita = ((PolizaContableConsulta)seleccionado).LogAudita;
            else if (seleccionado is PolizaContableResumen)
                logAudita = ((PolizaContableResumen)seleccionado).LogAudita;

            bool disponible = seleccionado != null && !EstaAuditada(logAudita);
            if (btnEditar != null)
                btnEditar.Enabled = disponible;
            if (btnEliminar != null)
                btnEliminar.Enabled = disponible;
        }

        private async Task EditarSeleccionadaAsync()
        {
            try
            {
                var resumen = ObtenerResumenSeleccionado();
                var consulta = ObtenerConsultaSeleccionada();
                if (resumen == null && consulta == null)
                    throw new InvalidOperationException("Seleccione una póliza para editar.");

                string tipo = consulta == null ? resumen.TipoPoliza : consulta.TipoPoliza;
                string numero = consulta == null ? resumen.NumeroPoliza : consulta.NumeroPoliza;
                short ejercicio = consulta == null ? resumen.Ejercicio : consulta.Ejercicio;
                short periodo = consulta == null ? resumen.Periodo : consulta.Periodo;
                string logAudita = consulta == null ? resumen.LogAudita : consulta.LogAudita;

                if (EstaAuditada(logAudita))
                    throw new InvalidOperationException("La póliza está auditada y no puede modificarse.");

                Cursor = Cursors.WaitCursor;
                var completa = consulta ?? await _service.ObtenerAsync(tipo, numero, ejercicio, periodo);
                if (completa == null)
                    throw new InvalidOperationException("La póliza seleccionada ya no existe.");

                using (var form = new PolizaCapturaForm(
                    _polizaContableService,
                    _tipoPolizaServiceLocal,
                    _conceptoService,
                    _periodoContableService,
                    _movimientoContext,
                    completa,
                    _parametroEmpresaService,
                    _contabilizacionContableService)) {
                    Cursor = Cursors.Default;
                    if (form.ShowDialog(this) == DialogResult.OK)
                        await RefrescarConsultaActualAsync();
                }
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No fue posible editar la póliza: " + ex.Message,
                    "Editar póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                ActualizarAcciones();
            }
        }

        private async Task EliminarSeleccionadaAsync()
        {
            try
            {
                var resumen = ObtenerResumenSeleccionado();
                var consulta = ObtenerConsultaSeleccionada();
                if (resumen == null && consulta == null)
                    throw new InvalidOperationException("Seleccione una póliza para eliminar.");

                string tipo = consulta == null ? resumen.TipoPoliza : consulta.TipoPoliza;
                string numero = consulta == null ? resumen.NumeroPoliza : consulta.NumeroPoliza;
                short ejercicio = consulta == null ? resumen.Ejercicio : consulta.Ejercicio;
                short periodo = consulta == null ? resumen.Periodo : consulta.Periodo;
                string logAudita = consulta == null ? resumen.LogAudita : consulta.LogAudita;

                if (EstaAuditada(logAudita))
                    throw new InvalidOperationException("La póliza está Auditada y no puede eliminarse.");

                if (MessageBox.Show(this,
                    string.Format("¿Desea eliminar la póliza {0}-{1}?\n\nEsta operación eliminará la póliza y sus partidas y afectará los saldos correspondientes.", tipo, numero),
                    "Eliminar póliza",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;

                Cursor = Cursors.WaitCursor;
                await _polizaContableService.EliminarAsync(tipo, numero, ejercicio, periodo);
                estado.Text = string.Format("Póliza {0}-{1} eliminada correctamente.", tipo, numero);
                await RefrescarConsultaActualAsync();
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No fue posible eliminar la póliza: " + ex.Message,
                    "Eliminar póliza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                ActualizarAcciones();
            }
        }

        private async Task RefrescarConsultaActualAsync()
        {
            switch (_modoConsulta)
            {
                case 1:
                    await ConsultarPeriodoAsync();
                    break;
                case 2:
                    await ConsultarPolizaAsync();
                    break;
                case 3:
                    await ConsultarCuentaAsync();
                    break;
            }
        }

        private async Task RevertirSeleccionadaAsync() {
            try {
                if (_reversionPolizaService == null)
                    throw new InvalidOperationException("El servicio de reversión no está disponible.");

                if (polizas.CurrentRow == null)
                    throw new InvalidOperationException("Seleccione una póliza para revertir.");

                var poliza = polizas.CurrentRow.DataBoundItem as PolizaContableConsulta;
                if (poliza == null)
                    throw new InvalidOperationException("La selección actual no corresponde a una póliza válida.");

                using (var form = new ReversionPolizaForm(_reversionPolizaService,
                    _tipoPolizaServiceLocal, poliza)) {
                    await Task.Yield();
                    if (form.ShowDialog(this) == DialogResult.OK)
                        await ConsultarPolizaAsync();
                }
            } catch (InvalidOperationException ex) {
                MostrarError(ex);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible iniciar la reversión: " + ex.Message, "Reversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarTipoNumero() {
            if (cmbTipo.ComboBox.SelectedValue == null || string.IsNullOrWhiteSpace(Convert.ToString(cmbTipo.ComboBox.SelectedValue)))
                throw new ArgumentException("El tipo de póliza es obligatorio.");
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
                throw new ArgumentException("El número de póliza es obligatorio.");
        }

        private void MostrarError(Exception ex) {
            estado.Text = ex.Message;
            MessageBox.Show(this, ex.Message, "Consulta de pólizas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void polizas_SelectionChanged(object sender, EventArgs e) {
            if (polizas.CurrentRow == null) {
                detalle.DataSource = null;
                ActualizarAcciones();
                return;
            }

            var consulta = polizas.CurrentRow.DataBoundItem as PolizaContableConsulta;
            if (consulta != null)
                detalle.DataSource = consulta.Partidas;
            else
                detalle.DataSource = null;

            ActualizarAcciones();
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
