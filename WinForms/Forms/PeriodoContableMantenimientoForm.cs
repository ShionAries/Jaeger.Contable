using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    /// <summary>Consulta y administra el estado CERRADO de ADMPER.</summary>
    public sealed class PeriodoContableMantenimientoForm : Form {
        private readonly IPeriodoContableService _service;
        private readonly NumericUpDown _ejercicio;
        private readonly DataGridView _grid;
        private readonly Button _btnCerrar;
        private readonly Button _btnAbrir;
        private readonly Button _btnActualizar;
        private readonly Label _estado;

        public PeriodoContableMantenimientoForm(IPeriodoContableService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Text = "Periodos contables"; Width = 760; Height = 430; StartPosition = FormStartPosition.CenterParent;

            var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 42, Padding = new Padding(8) };
            top.Controls.Add(new Label { Text = "Ejercicio:", AutoSize = true, Margin = new Padding(3, 7, 3, 3) });
            _ejercicio = new NumericUpDown { Minimum = 1, Maximum = 9999, Width = 90, Value = DateTime.Now.Year };
            top.Controls.Add(_ejercicio);
            _btnActualizar = new Button { Text = "Actualizar", Width = 95 };
            _btnActualizar.Click += async (s,e) => await CargarAsync(); top.Controls.Add(_btnActualizar);
            _estado = new Label { AutoSize = true, Margin = new Padding(12, 7, 3, 3) }; top.Controls.Add(_estado);
            Controls.Add(top);

            _grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = false, AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Periodo", HeaderText = "Periodo", Width = 70 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ejercicio", HeaderText = "Ejercicio", Width = 80 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EstadoTexto", HeaderText = "Estado", Width = 100 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CtPolizas", HeaderText = "Pólizas", Width = 90 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ordenado", HeaderText = "Ordenado", Width = 90 });
            Controls.Add(_grid);

            var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 45, FlowDirection = FlowDirection.RightToLeft, Padding = new Padding(8) };
            _btnAbrir = new Button { Text = "Abrir periodo", Width = 110 }; _btnAbrir.Click += async (s,e) => await CambiarAsync(false); bottom.Controls.Add(_btnAbrir);
            _btnCerrar = new Button { Text = "Cerrar periodo", Width = 110 }; _btnCerrar.Click += async (s,e) => await CambiarAsync(true); bottom.Controls.Add(_btnCerrar);
            var cerrar = new Button { Text = "Cerrar ventana", Width = 110 }; cerrar.Click += (s,e) => Close(); bottom.Controls.Add(cerrar);
            Controls.Add(bottom);
            Shown += async (s,e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            try {
                var items = await _service.ObtenerTodosAsync((short)_ejercicio.Value);
                var rows = new List<PeriodoRow>(); foreach (var x in items) rows.Add(new PeriodoRow(x));
                _grid.DataSource = rows; _estado.Text = rows.Count == 0 ? "Sin periodos" : "Periodos cargados";
            } catch (Exception ex) { MostrarError(ex); }
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
