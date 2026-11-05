using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    /// <summary>
    /// Ejecuta el proceso masivo de depreciación para un ejercicio y periodo.
    /// </summary>
    public sealed class DepreciacionActivosForm : Form {
        private readonly IDepreciacionActivoService _service;

        private readonly NumericUpDown _nudEjercicio;
        private readonly NumericUpDown _nudPeriodo;
        private readonly Button _btnEjecutar;
        private readonly Label _lblEstado;

        public DepreciacionActivosForm(IDepreciacionActivoService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            Text = "Depreciación de activos";
            StartPosition = FormStartPosition.CenterParent;
            Width = 760;
            Height = 260;
            MinimizeBox = false;
            MaximizeBox = false;

            var panel = new TableLayoutPanel {
                Dock = DockStyle.Top,
                Height = 120,
                ColumnCount = 4,
                RowCount = 2,
                Padding = new Padding(12)
            };

            panel.ColumnStyles.Add(
                new ColumnStyle(SizeType.AutoSize));

            panel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 110));

            panel.ColumnStyles.Add(
                new ColumnStyle(SizeType.AutoSize));

            panel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            panel.Controls.Add(
                new Label {
                    Text = "Ejercicio:",
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                },
                0,
                0);

            _nudEjercicio = new NumericUpDown {
                Minimum = 1900,
                Maximum = 9999,
                Value = DateTime.Now.Year,
                Width = 100
            };

            panel.Controls.Add(
                _nudEjercicio,
                1,
                0);

            panel.Controls.Add(
                new Label {
                    Text = "Periodo:",
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                },
                0,
                1);

            _nudPeriodo = new NumericUpDown {
                Minimum = 1,
                Maximum = 14,
                Value = DateTime.Now.Month > 14
                    ? 14
                    : DateTime.Now.Month,
                Width = 100
            };

            panel.Controls.Add(
                _nudPeriodo,
                1,
                1);

            _btnEjecutar = new Button {
                Text = "Ejecutar depreciación",
                Width = 190,
                Height = 32,
                Anchor = AnchorStyles.Left
            };

            _btnEjecutar.Click += async delegate {
                await EjecutarAsync();
            };

            panel.Controls.Add(
                _btnEjecutar,
                2,
                0);

            panel.SetRowSpan(
                _btnEjecutar,
                2);

            _lblEstado = new Label {
                Text = "Seleccione el ejercicio y periodo.",
                Dock = DockStyle.Fill,
                Padding = new Padding(12),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Controls.Add(_lblEstado);
            Controls.Add(panel);
        }

        private async Task EjecutarAsync() {
            short ejercicio = (short)_nudEjercicio.Value;
            short periodo = (short)_nudPeriodo.Value;

            DialogResult confirmacion = MessageBox.Show(
                this,
                string.Format(
                    "¿Desea ejecutar la depreciación del ejercicio {0}, periodo {1}?",
                    ejercicio,
                    periodo),
                "Depreciación de activos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            try {
                _btnEjecutar.Enabled = false;

                _lblEstado.Text =
                    "Procesando depreciación...";

                ResultadoProcesoDepreciacion resultado =
                    await _service.EjecutarAsync(
                        ejercicio,
                        periodo);

                if (resultado.PartidasGeneradas == 0) {
                    _lblEstado.Text =
                        "No existen activos pendientes de depreciar " +
                        "en el periodo seleccionado.";

                    MessageBox.Show(
                        this,
                        _lblEstado.Text,
                        "Depreciación de activos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                _lblEstado.Text = string.Format(
                    "Póliza {0} {1} generada. " +
                    "Activos: {2}. " +
                    "Partidas: {3}. " +
                    "Importe: {4:N2}.",
                    resultado.TipoPoliza,
                    resultado.NumeroPoliza,
                    resultado.ActivosProcesados,
                    resultado.PartidasGeneradas,
                    resultado.ImporteTotal);

                MessageBox.Show(
                    this,
                    _lblEstado.Text,
                    "Depreciación de activos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            } catch (InvalidOperationException ex) {
                _lblEstado.Text = ex.Message;

                MessageBox.Show(
                    this,
                    ex.Message,
                    "Depreciación de activos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            } catch (Exception ex) {
                _lblEstado.Text =
                    "No fue posible ejecutar la depreciación.";

                MessageBox.Show(
                    this,
                    ex.Message,
                    "Depreciación de activos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } finally {
                _btnEjecutar.Enabled = true;
            }
        }
    }
}