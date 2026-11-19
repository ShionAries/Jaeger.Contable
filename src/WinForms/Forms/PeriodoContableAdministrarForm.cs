using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    /// <summary>
    /// Consulta, crea y administra los periodos contables almacenados en ADMPER.
    /// </summary>
    public partial class PeriodoContableAdministrarForm : Form {
        private readonly IPeriodoContableService _service;
        private List<PeriodoContable> _rows = new List<PeriodoContable>();

        public PeriodoContableAdministrarForm(IPeriodoContableService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
            Text = "Periodos contables";
            StartPosition = FormStartPosition.CenterParent;

            Ejercicio.Minimum = 1;
            Ejercicio.Maximum = 9999;
            Ejercicio.Value = DateTime.Now.Year;

            btnActualizar.Click += async (s, e) => await CargarAsync();

            btnCrearEjercicio.Click += async (s, e) => await CrearEjercicioAsync();

            gridData.ReadOnly = true;
            gridData.AutoGenerateColumns = false;
            gridData.AllowUserToAddRows = false;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var periodoColumn = this.gridData.Columns["Periodo"] as DataGridViewComboBoxColumn;
            periodoColumn.DataPropertyName = "Periodo";
            periodoColumn.ValueMember = "Numero";
            periodoColumn.DisplayMember = "Nombre";
            for (short i = 1; i <= 14; i++)
                periodoColumn.Items.Add(new Domain.Models.PeriodoItem(i, ObtenerNombrePeriodo(i)));

            btnAbrirPeriodo.Click += async (s, e) => await CambiarAsync(false);

            btnCerrarPeriodo.Click += async (s, e) => await CambiarAsync(true);

            btnBajar.Click += async (s, e) => await MoverSeleccionadoAsync(1);
            
            btnSubir.Click += async (s, e) => await MoverSeleccionadoAsync(-1);

            btnCerrar.Click += (s, e) => Close();

            Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            try {
                _rows = await _service.ObtenerTodosAsync((short)Ejercicio.Value);
                gridData.DataSource = null;
                gridData.DataSource = _rows;
                lblEstado.Text = _rows.Count == 0 ? "Sin periodos" : "Periodos cargados";
            } catch (Exception ex) { MostrarError(ex); }
        }

        private async Task CrearEjercicioAsync() {
            short ejercicio = (short)Ejercicio.Value;
            if (MessageBox.Show(this,
                string.Format("Se crearán los periodos faltantes (01 a 14) del ejercicio {0}. Los registros existentes no se modificarán. ¿Deseas continuar?", ejercicio),
                "Crear ejercicio contable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            CambiarControles(false);
            try {
                int creados = await _service.CrearEjercicioAsync(ejercicio);
                await CargarAsync();
                MessageBox.Show(this,
                    creados == 0
                        ? string.Format("El ejercicio {0} ya cuenta con sus 14 periodos.", ejercicio)
                        : string.Format("Se crearon {0} periodos para el ejercicio {1}.", creados, ejercicio),
                    "Periodos contables", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MostrarError(ex);
            } finally {
                CambiarControles(true);
            }
        }

        private void CambiarControles(bool habilitar) {
            Ejercicio.Enabled = habilitar;
            btnActualizar.Enabled = habilitar;
            btnCrearEjercicio.Enabled = habilitar;
            btnCerrarPeriodo.Enabled = habilitar;
            btnAbrirPeriodo.Enabled = habilitar;
            btnSubir.Enabled = habilitar;
            btnBajar.Enabled = habilitar;
            gridData.Enabled = habilitar;
        }

        private async Task MoverSeleccionadoAsync(int desplazamiento) {
            var seleccionado = ObtenerSeleccionado();
            if (seleccionado == null)
                return;

            int indice = _rows.IndexOf(seleccionado);
            int nuevoIndice = indice + desplazamiento;
            if (nuevoIndice < 0 || nuevoIndice >= _rows.Count)
                return;

            var periodos = new List<short>();
            var copia = new List<PeriodoContable>(_rows);
            copia.RemoveAt(indice);
            copia.Insert(nuevoIndice, seleccionado);
            foreach (var row in copia)
                periodos.Add(row.Periodo);

            CambiarControles(false);
            try {
                await _service.ActualizarOrdenAsync((short)Ejercicio.Value, periodos);
                await CargarAsync();
                if (nuevoIndice >= 0 && nuevoIndice < gridData.Rows.Count)
                    gridData.CurrentCell = gridData.Rows[nuevoIndice].Cells[0];
            } catch (Exception ex) {
                MostrarError(ex);
            } finally {
                CambiarControles(true);
            }
        }

        private async Task CambiarAsync(bool cerrar) {
            var row = ObtenerSeleccionado();
            if (row == null) {
                MessageBox.Show(this, "Selecciona un periodo.", "Periodos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var accion = cerrar ? "cerrar" : "abrir";
            if (MessageBox.Show(this, string.Format("¿Deseas {0} el periodo {1}?", accion, row.Periodo), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try {
                if (cerrar)
                    await _service.CerrarAsync(row.Ejercicio, row.Periodo);
                else
                    await _service.AbrirAsync(row.Ejercicio, row.Periodo);
                await CargarAsync();
            } catch (Exception ex) { MostrarError(ex); }
        }

        private PeriodoContable ObtenerSeleccionado() {
            return gridData.CurrentRow == null ? null : gridData.CurrentRow.DataBoundItem as PeriodoContable;
        }

        private void MostrarError(Exception ex) {
            MessageBox.Show(this, ex.Message, "Periodos contables", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
