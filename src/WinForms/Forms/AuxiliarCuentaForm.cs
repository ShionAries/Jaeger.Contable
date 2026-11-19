using System;
using System.Collections.Generic;
using System.Globalization;

using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    /// <summary>Consulta los auxiliares de un rango de cuentas para todo el ejercicio.</summary>
    public sealed class AuxiliarCuentaForm : Form {
        private readonly IAuxiliarCuentaService _service;
        private readonly ICuentaService _cuentaService;
        private readonly NumericUpDown _ejercicio;
        private readonly TextBox _cuentaInicial;
        private readonly TextBox _cuentaFinal;
        private readonly Button _seleccionarInicial;
        private readonly Button _seleccionarFinal;
        private readonly Button _consultar;
        private readonly DataGridView _grid;
        private readonly Label _resumen;

        public AuxiliarCuentaForm(IAuxiliarCuentaService service, ICuentaService cuentaService) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _cuentaService = cuentaService ?? throw new ArgumentNullException(nameof(cuentaService));
            Text = "Auxiliar de cuentas";
            StartPosition = FormStartPosition.CenterParent;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new System.Drawing.Size(1050, 600);

            var filtros = new FlowLayoutPanel {
                Dock = DockStyle.Top,
                AutoSize = true,
                WrapContents = true,
                Padding = new Padding(8),
                FlowDirection = FlowDirection.LeftToRight
            };

            filtros.Controls.Add(new Label { Text = "Ejercicio:", AutoSize = true, Margin = new Padding(3, 8, 3, 0) });
            _ejercicio = new NumericUpDown {
                Minimum = 1900,
                Maximum = 9999,
                Value = Math.Max(1900, Math.Min(9999, DateTime.Today.Year)),
                Width = 75,
                Margin = new Padding(2, 3, 12, 2)
            };
            filtros.Controls.Add(_ejercicio);

            filtros.Controls.Add(new Label { Text = "Cuenta inicial:", AutoSize = true, Margin = new Padding(3, 8, 3, 0) });
            _cuentaInicial = new TextBox { Width = 135, ReadOnly = true, Margin = new Padding(2, 3, 2, 2) };
            filtros.Controls.Add(_cuentaInicial);
            _seleccionarInicial = new Button { Text = "...", Width = 32, Height = 24, Margin = new Padding(2, 2, 12, 2) };
            _seleccionarInicial.Click += (s, e) => SeleccionarCuenta(_cuentaInicial);
            filtros.Controls.Add(_seleccionarInicial);

            filtros.Controls.Add(new Label { Text = "Cuenta final:", AutoSize = true, Margin = new Padding(3, 8, 3, 0) });
            _cuentaFinal = new TextBox { Width = 135, ReadOnly = true, Margin = new Padding(2, 3, 2, 2) };
            filtros.Controls.Add(_cuentaFinal);
            _seleccionarFinal = new Button { Text = "...", Width = 32, Height = 24, Margin = new Padding(2, 2, 12, 2) };
            _seleccionarFinal.Click += (s, e) => SeleccionarCuenta(_cuentaFinal);
            filtros.Controls.Add(_seleccionarFinal);

            _consultar = new Button { Text = "Consultar", Width = 95, Height = 27, Margin = new Padding(4, 2, 2, 2) };
            _consultar.Click += async (s, e) => await ConsultarAsync();
            filtros.Controls.Add(_consultar);

            _grid = new DataGridView {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
                BackgroundColor = System.Drawing.SystemColors.Window
            };
            CrearColumnas();
            _grid.CellFormatting += Grid_CellFormatting;

            _resumen = new Label {
                Dock = DockStyle.Bottom,
                Height = 42,
                Padding = new Padding(10),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Font = new System.Drawing.Font(Font, System.Drawing.FontStyle.Bold)
            };

            Controls.Add(_grid);
            Controls.Add(_resumen);
            Controls.Add(filtros);
        }

        private void SeleccionarCuenta(TextBox destino) {
            using (var selector = new CuentaContableSelectorForm(_cuentaService, false)) {
                if (selector.ShowDialog(this) == DialogResult.OK)
                    destino.Text = selector.NumeroCuentaSeleccionada;
            }
        }

        private async Task ConsultarAsync() {
            string inicial = (_cuentaInicial.Text ?? string.Empty).Trim();
            string final = (_cuentaFinal.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(inicial) || string.IsNullOrWhiteSpace(final)) {
                MessageBox.Show(this, "Seleccione la cuenta inicial y la cuenta final.",
                    "Auxiliar de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.Compare(inicial, final, StringComparison.Ordinal) > 0) {
                MessageBox.Show(this, "La cuenta inicial no puede ser mayor que la cuenta final.",
                    "Auxiliar de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CambiarEstadoControles(false);
            Cursor = Cursors.WaitCursor;
            try {
                var request = new AuxiliarCuentaRequest {
                    Ejercicio = Convert.ToInt16(_ejercicio.Value),
                    CuentaInicial = inicial,
                    CuentaFinal = final
                };
                AuxiliarCuentaResultado resultado = await _service.ConsultarAsync(request);
                _grid.DataSource = CrearFilas(resultado);
                _resumen.Text = string.Format(CultureInfo.CurrentCulture,
                    "Ejercicio {0} (períodos 01 a 14) | Cuentas: {1:N0} | Cargos: {2:N2} | Abonos: {3:N2} | Solo pólizas contabilizadas",
                    resultado.Ejercicio, resultado.Cuentas.Count, resultado.TotalCargos, resultado.TotalAbonos);
                Text = string.Format("Auxiliar de cuentas {0} | {1} a {2}",
                    resultado.Ejercicio, resultado.CuentaInicial, resultado.CuentaFinal);
                if (resultado.Cuentas.Count == 0)
                    MessageBox.Show(this, "No se encontraron movimientos ni saldos iniciales para el rango seleccionado.",
                        "Auxiliar de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Auxiliar de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                Cursor = Cursors.Default;
                CambiarEstadoControles(true);
            }
        }

        private static List<AuxiliarVistaRow> CrearFilas(AuxiliarCuentaResultado resultado) {
            var filas = new List<AuxiliarVistaRow>();
            foreach (var cuenta in resultado.Cuentas) {
                filas.Add(new AuxiliarVistaRow {
                    TipoRegistro = "Saldo inicial",
                    NumeroCuenta = cuenta.NumeroCuenta,
                    NombreCuenta = cuenta.NombreCuenta,
                    Concepto = "SALDO INICIAL",
                    Saldo = cuenta.SaldoInicial
                });

                foreach (var movimiento in cuenta.Movimientos) {
                    filas.Add(new AuxiliarVistaRow {
                        TipoRegistro = "Movimiento",
                        NumeroCuenta = cuenta.NumeroCuenta,
                        NombreCuenta = cuenta.NombreCuenta,
                        Fecha = movimiento.Fecha,
                        Periodo = movimiento.Periodo,
                        TipoPoliza = movimiento.TipoPoliza,
                        NumeroPoliza = movimiento.NumeroPoliza,
                        NumeroPartida = movimiento.NumeroPartida,
                        Concepto = movimiento.Concepto,
                        DebeHaber = movimiento.DebeHaber,
                        Importe = movimiento.Importe,
                        Saldo = movimiento.SaldoAcumulado,
                        NumeroDepartamento = movimiento.NumeroDepartamento
                    });
                }

                filas.Add(new AuxiliarVistaRow {
                    TipoRegistro = "Saldo final",
                    NumeroCuenta = cuenta.NumeroCuenta,
                    NombreCuenta = cuenta.NombreCuenta,
                    Concepto = "SALDO FINAL",
                    Saldo = cuenta.SaldoFinal
                });
            }
            return filas;
        }

        private void CrearColumnas() {
            AgregarColumna("NumeroCuenta", "Cuenta", 125);
            AgregarColumna("NombreCuenta", "Nombre", 180);
            AgregarColumna("Fecha", "Fecha", 85, "d");
            AgregarColumna("Periodo", "Período", 55, "00");
            AgregarColumna("TipoPoliza", "Tipo póliza", 75);
            AgregarColumna("NumeroPoliza", "Póliza", 85);
            AgregarColumna("NumeroPartida", "Partida", 65, "0.##");
            AgregarColumna("Concepto", "Concepto", 220);
            AgregarColumna("DebeHaber", "D/H", 45);
            AgregarColumna("Importe", "Importe", 100, "N2");
            AgregarColumna("Saldo", "Saldo acumulado", 115, "N2");
            AgregarColumna("NumeroDepartamento", "Depto.", 60);
        }

        private void AgregarColumna(string propiedad, string titulo, int ancho, string formato = null) {
            var columna = new DataGridViewTextBoxColumn {
                DataPropertyName = propiedad,
                HeaderText = titulo,
                Name = propiedad,
                Width = ancho,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            if (!string.IsNullOrWhiteSpace(formato))
                columna.DefaultCellStyle.Format = formato;
            _grid.Columns.Add(columna);
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex < 0)
                return;
            var fila = _grid.Rows[e.RowIndex].DataBoundItem as AuxiliarVistaRow;
            if (fila == null)
                return;
            if (fila.TipoRegistro == "Saldo inicial" || fila.TipoRegistro == "Saldo final") {
                e.CellStyle.Font = new System.Drawing.Font(_grid.Font, System.Drawing.FontStyle.Bold);
                e.CellStyle.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void CambiarEstadoControles(bool habilitado) {
            _ejercicio.Enabled = habilitado;
            _cuentaInicial.Enabled = habilitado;
            _cuentaFinal.Enabled = habilitado;
            _seleccionarInicial.Enabled = habilitado;
            _seleccionarFinal.Enabled = habilitado;
            _consultar.Enabled = habilitado;
        }

        private sealed class AuxiliarVistaRow {
            public string TipoRegistro { get; set; }
            public string NumeroCuenta { get; set; }
            public string NombreCuenta { get; set; }
            public DateTime? Fecha { get; set; }
            public short? Periodo { get; set; }
            public string TipoPoliza { get; set; }
            public string NumeroPoliza { get; set; }
            public double? NumeroPartida { get; set; }
            public string Concepto { get; set; }
            public string DebeHaber { get; set; }
            public decimal? Importe { get; set; }
            public decimal Saldo { get; set; }
            public short? NumeroDepartamento { get; set; }
        }
    }
}
