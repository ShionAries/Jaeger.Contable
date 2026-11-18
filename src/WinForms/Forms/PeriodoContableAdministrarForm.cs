using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    /// <summary>Consulta, crea y administra los periodos contables almacenados en ADMPER.</summary>
    public sealed class PeriodoContableAdministrarForm : Form {
        private readonly IPeriodoContableService _service;
        private readonly NumericUpDown _ejercicio;
        private readonly DataGridView _grid;
        private readonly Button _btnCerrar;
        private readonly Button _btnAbrir;
        private readonly Button _btnActualizar;
        private readonly Button _btnCrearEjercicio;
        private readonly Button _btnSubir;
        private readonly Button _btnBajar;
        private readonly Label _estado;
        private List<PeriodoRow> _rows = new List<PeriodoRow>();

        public PeriodoContableAdministrarForm(IPeriodoContableService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Text = "Periodos contables"; Width = 760; Height = 430; StartPosition = FormStartPosition.CenterParent;

            var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 42, Padding = new Padding(8) };
            top.Controls.Add(new Label { Text = "Ejercicio:", AutoSize = true, Margin = new Padding(3, 7, 3, 3) });
            _ejercicio = new NumericUpDown { Minimum = 1, Maximum = 9999, Width = 90, Value = DateTime.Now.Year };
            top.Controls.Add(_ejercicio);
            _btnActualizar = new Button { Text = "Actualizar", Width = 95 };
            _btnActualizar.Click += async (s,e) => await CargarAsync(); top.Controls.Add(_btnActualizar);
            _btnCrearEjercicio = new Button { Text = "Crear ejercicio", Width = 110 };
            _btnCrearEjercicio.Click += async (s,e) => await CrearEjercicioAsync();
            top.Controls.Add(_btnCrearEjercicio);
            _estado = new Label { AutoSize = true, Margin = new Padding(12, 7, 3, 3) }; top.Controls.Add(_estado);
            Controls.Add(top);

            _grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = false, AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Periodo", HeaderText = "Periodo", Width = 70 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ejercicio", HeaderText = "Ejercicio", Width = 80 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EstadoTexto", HeaderText = "Estado", Width = 100 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CtPolizas", HeaderText = "Pólizas", Width = 90 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ordenado", HeaderText = "Orden", Width = 70 });
            Controls.Add(_grid);

            var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 45, FlowDirection = FlowDirection.RightToLeft, Padding = new Padding(8) };
            _btnAbrir = new Button { Text = "Abrir periodo", Width = 110 }; _btnAbrir.Click += async (s,e) => await CambiarAsync(false); bottom.Controls.Add(_btnAbrir);
            _btnCerrar = new Button { Text = "Cerrar periodo", Width = 110 }; _btnCerrar.Click += async (s,e) => await CambiarAsync(true); bottom.Controls.Add(_btnCerrar);
            _btnBajar = new Button { Text = "Bajar", Width = 75 }; _btnBajar.Click += async (s,e) => await MoverSeleccionadoAsync(1); bottom.Controls.Add(_btnBajar);
            _btnSubir = new Button { Text = "Subir", Width = 75 }; _btnSubir.Click += async (s,e) => await MoverSeleccionadoAsync(-1); bottom.Controls.Add(_btnSubir);
            var cerrar = new Button { Text = "Cerrar ventana", Width = 110 }; cerrar.Click += (s,e) => Close(); bottom.Controls.Add(cerrar);
            Controls.Add(bottom);
            Shown += async (s,e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            try {
                var items = await _service.ObtenerTodosAsync((short)_ejercicio.Value);
                _rows = new List<PeriodoRow>(); foreach (var x in items) _rows.Add(new PeriodoRow(x));
                _grid.DataSource = null;
                _grid.DataSource = _rows;
                _estado.Text = _rows.Count == 0 ? "Sin periodos" : "Periodos cargados";
            } catch (Exception ex) { MostrarError(ex); }
        }

        private async Task CrearEjercicioAsync() {
            short ejercicio = (short)_ejercicio.Value;
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
            }
            catch (Exception ex) {
                MostrarError(ex);
            }
            finally {
                CambiarControles(true);
            }
        }

        private void CambiarControles(bool habilitar) {
            _ejercicio.Enabled = habilitar;
            _btnActualizar.Enabled = habilitar;
            _btnCrearEjercicio.Enabled = habilitar;
            _btnCerrar.Enabled = habilitar;
            _btnAbrir.Enabled = habilitar;
            _btnSubir.Enabled = habilitar;
            _btnBajar.Enabled = habilitar;
            _grid.Enabled = habilitar;
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
            var copia = new List<PeriodoRow>(_rows);
            copia.RemoveAt(indice);
            copia.Insert(nuevoIndice, seleccionado);
            foreach (var row in copia)
                periodos.Add(row.Periodo);

            CambiarControles(false);
            try {
                await _service.ActualizarOrdenAsync((short)_ejercicio.Value, periodos);
                await CargarAsync();
                if (nuevoIndice >= 0 && nuevoIndice < _grid.Rows.Count)
                    _grid.CurrentCell = _grid.Rows[nuevoIndice].Cells[0];
            }
            catch (Exception ex) {
                MostrarError(ex);
            }
            finally {
                CambiarControles(true);
            }
        }

        private async Task CambiarAsync(bool cerrar) {
            var row = ObtenerSeleccionado(); if (row == null) { MessageBox.Show(this, "Selecciona un periodo.", "Periodos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var accion = cerrar ? "cerrar" : "abrir";
            if (MessageBox.Show(this, string.Format("¿Deseas {0} el periodo {1}?", accion, row.Periodo), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try { if (cerrar) await _service.CerrarAsync(row.Ejercicio, row.Periodo); else await _service.AbrirAsync(row.Ejercicio, row.Periodo); await CargarAsync(); } catch (Exception ex) { MostrarError(ex); }
        }

        private PeriodoRow ObtenerSeleccionado() { return _grid.CurrentRow == null ? null : _grid.CurrentRow.DataBoundItem as PeriodoRow; }
        private void MostrarError(Exception ex) { MessageBox.Show(this, ex.Message, "Periodos contables", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        private sealed class PeriodoRow {
            public short Periodo { get; private set; } public short Ejercicio { get; private set; } public string EstadoTexto { get; private set; } public int CtPolizas { get; private set; } public int Ordenado { get; private set; }
            public PeriodoRow(PeriodoContable x) { Periodo=x.Periodo; Ejercicio=x.Ejercicio; EstadoTexto=x.EstaCerrado ? "CERRADO" : "ABIERTO"; CtPolizas=x.CtPolizas; Ordenado=x.Ordenado; }
        }
    }
}
