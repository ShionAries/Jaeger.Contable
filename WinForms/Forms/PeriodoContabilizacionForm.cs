using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Enums;

namespace Jaeger.Contable.WinForms.Forms {
    /// <summary>
    /// Permite seleccionar ejercicio, periodo y criterio para contabilizar pólizas.
    /// </summary>
    public partial class PeriodoContabilizacionForm : Form {
        private readonly IPeriodoContableService _periodoService;
        private readonly IContabilizacionContableService _contabilizacionService;
        private readonly ITipoPolizaService _tipoPolizaService;

        public PeriodoContabilizacionForm(IPeriodoContableService periodoService,
            IContabilizacionContableService contabilizacionService,
            ITipoPolizaService tipoPolizaService) {
            _periodoService = periodoService ?? throw new ArgumentNullException(nameof(periodoService));
            _contabilizacionService = contabilizacionService ?? throw new ArgumentNullException(nameof(contabilizacionService));
            _tipoPolizaService = tipoPolizaService ?? throw new ArgumentNullException(nameof(tipoPolizaService));
            InitializeComponent();

            AcceptButton = _btnContabilizar;
            CancelButton = _btnCancelar;

            Load += async (s, e) => {
                await CargarEjerciciosAsync();
                await CargarTiposPolizaAsync();
            };

            _cmbEjercicio.SelectedIndexChanged += async (s, e) => await CargarPeriodosAsync();
            _cmbPeriodo.SelectedIndexChanged += (s, e) => ActualizarEstado();
            _rdbSoloNoContabilizadas.CheckedChanged += (s, e) => ActualizarEstado();
            _rdbTodas.CheckedChanged += (s, e) => ActualizarEstado();
            _rdbSoloNoContabilizadasTipo.CheckedChanged += (s, e) => ActualizarEstado();
            _cmbTipoPoliza.SelectedIndexChanged += (s, e) => ActualizarEstado();
            _btnContabilizar.Click += async (s, e) => await ContabilizarAsync();
        }

        private async Task CargarEjerciciosAsync() {
            try {
                var ejercicios = await _periodoService.ObtenerEjerciciosAsync();
                _cmbEjercicio.DataSource = null;
                _cmbEjercicio.Items.Clear();
                foreach (var ejercicio in ejercicios)
                    _cmbEjercicio.Items.Add(ejercicio);

                _cmbEjercicio.SelectedIndex = -1;
                _cmbPeriodo.DataSource = null;
                _cmbPeriodo.Items.Clear();
                _cmbPeriodo.Enabled = false;
                ActualizarEstado();

                if (ejercicios.Count == 0)
                    _lblEstado.Text = "No existen ejercicios contables disponibles.";
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible cargar los ejercicios: " + ex.Message,
                    "Contabilización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarTiposPolizaAsync() {
            try {
                var tipos = await _tipoPolizaService.ObtenerTodosAsync();
                var items = new List<TipoPolizaItem>();
                foreach (var tipo in tipos) {
                    if (tipo == null || string.IsNullOrWhiteSpace(tipo.Tipo))
                        continue;
                    items.Add(new TipoPolizaItem(tipo.Tipo.Trim(), tipo.Descripcion));
                }

                _cmbTipoPoliza.DataSource = items;
                _cmbTipoPoliza.DisplayMember = "Nombre";
                _cmbTipoPoliza.ValueMember = "Tipo";
                _cmbTipoPoliza.SelectedIndex = -1;
                ActualizarEstado();
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible cargar los tipos de póliza: " + ex.Message,
                    "Contabilización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarPeriodosAsync() {
            try {
                _cmbPeriodo.DataSource = null;
                _cmbPeriodo.Items.Clear();
                _cmbPeriodo.Enabled = false;
                _btnContabilizar.Enabled = false;

                if (_cmbEjercicio.SelectedItem == null) {
                    _lblEstado.Text = "Seleccione primero el ejercicio.";
                    return;
                }

                short ejercicio = Convert.ToInt16(_cmbEjercicio.SelectedItem);
                var periodos = await _periodoService.ObtenerTodosAsync(ejercicio);
                var items = new List<PeriodoItem>();
                foreach (var periodo in periodos)
                    items.Add(new PeriodoItem(periodo.Periodo, ObtenerNombrePeriodo(periodo.Periodo)));

                _cmbPeriodo.DataSource = items;
                _cmbPeriodo.DisplayMember = "Nombre";
                _cmbPeriodo.ValueMember = "Numero";
                _cmbPeriodo.SelectedIndex = -1;
                _cmbPeriodo.Enabled = items.Count > 0;
                ActualizarEstado();
                _lblEstado.Text = items.Count == 0
                    ? "El ejercicio no tiene periodos contables disponibles."
                    : "Seleccione el periodo y el criterio de contabilización.";
            } catch (Exception ex) {
                _lblEstado.Text = "No fue posible cargar los periodos.";
                MessageBox.Show(this, "No fue posible cargar los periodos: " + ex.Message,
                    "Contabilización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ContabilizarAsync() {
            if (_cmbEjercicio.SelectedItem == null || _cmbPeriodo.SelectedValue == null) {
                MessageBox.Show(this, "Seleccione primero el ejercicio y el periodo.",
                    "Contabilización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_rdbSoloNoContabilizadasTipo.Checked && _cmbTipoPoliza.SelectedValue == null) {
                MessageBox.Show(this, "Seleccione el tipo de póliza que desea contabilizar.",
                    "Contabilización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            short ejercicio = Convert.ToInt16(_cmbEjercicio.SelectedItem);
            short periodo = Convert.ToInt16(_cmbPeriodo.SelectedValue);
            ContabilizacionModoEnum modo = ObtenerModo();
            string tipo = _rdbSoloNoContabilizadasTipo.Checked
                ? Convert.ToString(_cmbTipoPoliza.SelectedValue)
                : null;

            string criterio = ObtenerDescripcionCriterio();
            if (MessageBox.Show(this,
                string.Format("¿Desea contabilizar las pólizas del periodo {0} del ejercicio {1}?{2}{3}",
                    periodo, ejercicio, Environment.NewLine, criterio),
                "Confirmar contabilización", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            CambiarEstado(false);
            try {
                var resultado = await _contabilizacionService.ContabilizarPeriodoAsync(
                    ejercicio, periodo, modo, tipo);
                _lblEstado.Text = string.Format("Procesadas: {0} pólizas, {1} partidas, {2} cuentas.",
                    resultado.PolizasContabilizadas, resultado.PartidasContabilizadas, resultado.CuentasAfectadas);
                MessageBox.Show(this,
                    string.Format("La contabilización terminó correctamente.{0}{1} pólizas procesadas.{0}{2} partidas procesadas.{0}{3} cuentas afectadas.",
                        Environment.NewLine,
                        resultado.PolizasContabilizadas,
                        resultado.PartidasContabilizadas,
                        resultado.CuentasAfectadas),
                    "Contabilización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(this, ex.Message, "Contabilización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(this, "No fue posible contabilizar el periodo: " + ex.Message,
                    "Contabilización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                CambiarEstado(true);
            }
        }

        private ContabilizacionModoEnum ObtenerModo() {
            if (_rdbTodas.Checked)
                return ContabilizacionModoEnum.Todas;
            if (_rdbSoloNoContabilizadasTipo.Checked)
                return ContabilizacionModoEnum.SoloNoContabilizadasTipo;
            return ContabilizacionModoEnum.SoloNoContabilizadas;
        }

        private string ObtenerDescripcionCriterio() {
            if (_rdbTodas.Checked)
                return "Criterio: Todas (contabilizadas y no contabilizadas).";
            if (_rdbSoloNoContabilizadasTipo.Checked)
                return "Criterio: Sólo no contabilizadas de tipo " + Convert.ToString(_cmbTipoPoliza.SelectedValue) + ".";
            return "Criterio: Sólo no contabilizadas.";
        }

        private void CambiarEstado(bool habilitar) {
            _cmbEjercicio.Enabled = habilitar;
            _cmbPeriodo.Enabled = habilitar && _cmbEjercicio.SelectedItem != null;
            _rdbSoloNoContabilizadas.Enabled = habilitar;
            _rdbTodas.Enabled = habilitar;
            _rdbSoloNoContabilizadasTipo.Enabled = habilitar;
            _cmbTipoPoliza.Enabled = habilitar && _rdbSoloNoContabilizadasTipo.Checked;
            _btnCancelar.Enabled = habilitar;
            _btnContabilizar.Enabled = habilitar && PuedeContabilizar();
        }

        private void ActualizarEstado() {
            bool tipoRequerido = _rdbSoloNoContabilizadasTipo.Checked;
            _cmbTipoPoliza.Enabled = _btnCancelar.Enabled && tipoRequerido;
            if (_btnCancelar.Enabled)
                _btnContabilizar.Enabled = PuedeContabilizar();
        }

        private bool PuedeContabilizar() {
            if (_cmbEjercicio.SelectedItem == null || _cmbPeriodo.SelectedItem == null)
                return false;
            if (_rdbSoloNoContabilizadasTipo.Checked && _cmbTipoPoliza.SelectedItem == null)
                return false;
            return true;
        }

        private static string ObtenerNombrePeriodo(short periodo) {
            switch (periodo) {
                case 1:
                    return "01 - Enero";
                case 2:
                    return "02 - Febrero";
                case 3:
                    return "03 - Marzo";
                case 4:
                    return "04 - Abril";
                case 5:
                    return "05 - Mayo";
                case 6:
                    return "06 - Junio";
                case 7:
                    return "07 - Julio";
                case 8:
                    return "08 - Agosto";
                case 9:
                    return "09 - Septiembre";
                case 10:
                    return "10 - Octubre";
                case 11:
                    return "11 - Noviembre";
                case 12:
                    return "12 - Diciembre";
                case 13:
                    return "13 - Ajuste";
                case 14:
                    return "14 - Cierre";
                default:
                    return periodo.ToString("00") + " - Periodo";
            }
        }

        private sealed class PeriodoItem {
            public short Numero { get; private set; }
            public string Nombre { get; private set; }

            public PeriodoItem(short numero, string nombre) {
                Numero = numero;
                Nombre = nombre;
            }
        }

        private sealed class TipoPolizaItem {
            public string Tipo { get; private set; }
            public string Nombre { get; private set; }

            public TipoPolizaItem(string tipo, string descripcion) {
                Tipo = tipo;
                Nombre = string.IsNullOrWhiteSpace(descripcion)
                    ? tipo
                    : tipo + " - " + descripcion.Trim();
            }
        }
    }
}
