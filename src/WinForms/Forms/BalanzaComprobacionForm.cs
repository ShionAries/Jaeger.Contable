using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    /// <summary>Consulta la balanza de comprobación por ejercicio y rango de períodos.</summary>
    public sealed class BalanzaComprobacionForm : Form {
        private readonly IBalanzaComprobacionService _service;
        private readonly NumericUpDown _ejercicio;
        private readonly NumericUpDown _periodoInicial;
        private readonly NumericUpDown _periodoFinal;
        private readonly CheckBox _incluirSinMovimientos;
        private readonly ComboBox _nivelPresentacion;
        private readonly Button _consultar;
        private readonly DataGridView _grid;
        private readonly Label _totales;

        public BalanzaComprobacionForm(IBalanzaComprobacionService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Text = "Balanza de comprobación";
            StartPosition = FormStartPosition.CenterParent;
            Width = 1180;
            Height = 680;
            MinimumSize = new Size(900, 500);

            var filtros = new FlowLayoutPanel {
                Dock = DockStyle.Top,
                Height = 48,
                Padding = new Padding(8),
                WrapContents = false
            };
            filtros.Controls.Add(new Label { Text = "Ejercicio:", AutoSize = true, Margin = new Padding(4, 8, 2, 0) });
            _ejercicio = new NumericUpDown { Minimum = 1900, Maximum = 9999, Value = DateTime.Today.Year, Width = 85 };
            filtros.Controls.Add(_ejercicio);
            filtros.Controls.Add(new Label { Text = "Período inicial:", AutoSize = true, Margin = new Padding(12, 8, 2, 0) });
            _periodoInicial = new NumericUpDown { Minimum = 1, Maximum = 14, Value = 1, Width = 55 };
            filtros.Controls.Add(_periodoInicial);
            filtros.Controls.Add(new Label { Text = "Período final:", AutoSize = true, Margin = new Padding(12, 8, 2, 0) });
            _periodoFinal = new NumericUpDown { Minimum = 1, Maximum = 14, Value = Math.Min(DateTime.Today.Month, 12), Width = 55 };
            filtros.Controls.Add(_periodoFinal);
            _incluirSinMovimientos = new CheckBox {
                Text = "Incluir cuentas sin movimientos",
                AutoSize = true,
                Checked = false,
                Margin = new Padding(14, 7, 4, 0)
            };
            filtros.Controls.Add(_incluirSinMovimientos);
            filtros.Controls.Add(new Label { Text = "Presentación:", AutoSize = true, Margin = new Padding(12, 8, 2, 0) });
            _nivelPresentacion = new ComboBox {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 125,
                Margin = new Padding(2, 2, 2, 2)
            };
            _nivelPresentacion.Items.Add("Todos los niveles");
            for (short nivel = 1; nivel <= 9; nivel++)
                _nivelPresentacion.Items.Add("Hasta nivel " + nivel);
            _nivelPresentacion.SelectedIndex = 0;
            filtros.Controls.Add(_nivelPresentacion);
            _consultar = new Button { Text = "Consultar", Width = 95, Height = 27, Margin = new Padding(12, 2, 2, 2) };
            _consultar.Click += Consultar_Click;
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
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            };
            CrearColumnas();

            _totales = new Label {
                Dock = DockStyle.Bottom,
                Height = 58,
                Padding = new Padding(10),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font(Font, FontStyle.Bold)
            };

            Controls.Add(_grid);
            Controls.Add(_totales);
            Controls.Add(filtros);
        }

        private void CrearColumnas() {
            AgregarColumna("NumeroCuenta", "Cuenta", 150, DataGridViewContentAlignment.MiddleLeft);
            AgregarColumna("NombreCuenta", "Nombre", 220, DataGridViewContentAlignment.MiddleLeft);
            AgregarColumna("TipoCuenta", "Tipo", 50, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("Nivel", "Nivel", 55, DataGridViewContentAlignment.MiddleCenter);
            AgregarColumna("SaldoInicialDeudor", "Saldo inicial deudor", 115, DataGridViewContentAlignment.MiddleRight, true);
            AgregarColumna("SaldoInicialAcreedor", "Saldo inicial acreedor", 120, DataGridViewContentAlignment.MiddleRight, true);
            AgregarColumna("Cargos", "Cargos", 110, DataGridViewContentAlignment.MiddleRight, true);
            AgregarColumna("Abonos", "Abonos", 110, DataGridViewContentAlignment.MiddleRight, true);
            AgregarColumna("SaldoFinalDeudor", "Saldo final deudor", 115, DataGridViewContentAlignment.MiddleRight, true);
            AgregarColumna("SaldoFinalAcreedor", "Saldo final acreedor", 120, DataGridViewContentAlignment.MiddleRight, true);
        }

        private void AgregarColumna(string propiedad, string titulo, int ancho,
            DataGridViewContentAlignment alineacion, bool moneda = false) {
            var columna = new DataGridViewTextBoxColumn {
                DataPropertyName = propiedad,
                HeaderText = titulo,
                Name = propiedad,
                Width = ancho,
                SortMode = DataGridViewColumnSortMode.Automatic,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = alineacion }
            };
            if (moneda) {
                columna.DefaultCellStyle.Format = "N2";
                columna.DefaultCellStyle.FormatProvider = CultureInfo.CurrentCulture;
            }
            _grid.Columns.Add(columna);
        }

        private async void Consultar_Click(object sender, EventArgs e) {
            if (_periodoFinal.Value < _periodoInicial.Value) {
                MessageBox.Show(this, "El período final no puede ser menor que el período inicial.",
                    "Balanza de comprobación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _consultar.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try {
                var request = new BalanzaComprobacionRequest {
                    Ejercicio = Convert.ToInt16(_ejercicio.Value),
                    PeriodoInicial = Convert.ToInt16(_periodoInicial.Value),
                    PeriodoFinal = Convert.ToInt16(_periodoFinal.Value),
                    IncluirCuentasSinMovimientos = _incluirSinMovimientos.Checked,
                    NivelPresentacion = Convert.ToInt16(_nivelPresentacion.SelectedIndex)
                };
                BalanzaComprobacion resultado = await _service.GenerarAsync(request);
                _grid.DataSource = resultado.Cuentas.ToList();
                _totales.Text = string.Format(CultureInfo.CurrentCulture,
                    "Totales     Saldo inicial: {0:N2} / {1:N2}     Cargos: {2:N2}     Abonos: {3:N2}     Saldo final: {4:N2} / {5:N2}",
                    resultado.TotalSaldoInicialDeudor, resultado.TotalSaldoInicialAcreedor,
                    resultado.TotalCargos, resultado.TotalAbonos,
                    resultado.TotalSaldoFinalDeudor, resultado.TotalSaldoFinalAcreedor);
                var nivelTexto = request.NivelPresentacion == 0
                    ? "todos los niveles"
                    : "hasta nivel " + request.NivelPresentacion;
                Text = string.Format("Balanza de comprobación {0} | períodos {1:00} a {2:00} | {3} | {4:N0} cuentas",
                    resultado.Ejercicio, resultado.PeriodoInicial, resultado.PeriodoFinal,
                    nivelTexto, resultado.Cuentas.Count);
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Balanza de comprobación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                Cursor = Cursors.Default;
                _consultar.Enabled = true;
            }
        }
    }
}
