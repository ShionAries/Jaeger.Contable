using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Models;

namespace Jaeger.Contable.WinForms.Forms {
    public partial class AuditoriaCtarubForm : Form {
        private readonly ResultadoAuditoriaCtarub _resultado;
        private readonly IMotorContableService _motor;
        private readonly Button _cerrar;
        private bool _mostrarSoloErrores;

        public AuditoriaCtarubForm(ResultadoAuditoriaCtarub resultado, IMotorContableService motor) {
            InitializeComponent();
            _resultado = resultado ?? throw new ArgumentNullException(nameof(resultado));
            _motor = motor ?? throw new ArgumentNullException(nameof(motor));

            _soloErrores.Click += SoloErrores_Click;

            _grid.AutoGenerateColumns = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.MultiSelect = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Rubro", DataPropertyName = "Rubro", FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cuenta", DataPropertyName = "Cuenta", FillWeight = 28 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SEGPAPA", DataPropertyName = "SegPapa", FillWeight = 28 });
            _grid.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Válida", DataPropertyName = "EsValida", FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Errores", DataPropertyName = "TextoErrores", FillWeight = 50 });
            _grid.SelectionChanged += Grid_SelectionChanged;

            _detalle.ReadOnly = true;
            _detalle.ScrollBars = ScrollBars.Vertical;
            _detalle.BackColor = SystemColors.Window;
            _cerrar = new Button {
                Text = "Cerrar",
                DialogResult = DialogResult.OK,
                Width = 90,
                Location = new Point(ClientSize.Width - 105, ClientSize.Height - 38)
            };
            _cerrar.Click += (s, e) => Close();

            Resize += (s, e) => _cerrar.Location = new Point(ClientSize.Width - 105, ClientSize.Height - 38);
            Cargar();
        }

        private void Cargar() {
            ActualizarResumen();
            ActualizarGrid();
        }

        private void ActualizarGrid() {
            var datos = _resultado.Relaciones.Where(x => !_mostrarSoloErrores || !x.EsValida).Select(x => new FilaAuditoria {
                Rubro = x.Rubro,
                Cuenta = _motor.AplicarMascara(x.Cuenta),
                SegPapa = x.SegPapa,
                EsValida = x.EsValida,
                TextoErrores = x.EsValida ? string.Empty : string.Join(" | ", x.Errores)
            }).ToList();
            _grid.DataSource = datos;
            if (_grid.Rows.Count > 0)
                _grid.Rows[0].Selected = true;
        }

        private void ActualizarResumen() {
            _resumen.Text = string.Format("Total: {0}    Válidas: {1}    Con errores: {2}", _resultado.Total, _resultado.Validas, _resultado.Invalidas);
        }

        private void SoloErrores_Click(object sender, EventArgs e) {
            _mostrarSoloErrores = !_mostrarSoloErrores;
            _soloErrores.Text = _mostrarSoloErrores ? "Mostrar todas" : "Mostrar solo errores";
            ActualizarGrid();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e) {
            if (_grid.CurrentRow == null) { _detalle.Text = string.Empty; return; }
            var fila = _grid.CurrentRow.DataBoundItem as FilaAuditoria;
            if (fila == null) { _detalle.Text = string.Empty; return; }
            var item = _resultado.Relaciones.FirstOrDefault(x => x.Rubro == fila.Rubro && string.Equals(_motor.AplicarMascara(x.Cuenta), fila.Cuenta, StringComparison.Ordinal));
            _detalle.Text = item == null || item.EsValida ? "Sin errores." : string.Join(Environment.NewLine, item.Errores.Select(x => "• " + x));
        }
    }
}
