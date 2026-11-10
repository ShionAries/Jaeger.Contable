using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    public partial class AuditoriaCuentasForm : Form {
        private readonly ResultadoAuditoriaCuentas _resultado;
        private readonly IMotorContableService _motor;
        private bool _mostrarSoloErrores;
        private readonly Button _cerrar;

        public AuditoriaCuentasForm(ResultadoAuditoriaCuentas resultado, IMotorContableService motor) {
            _resultado = resultado ?? throw new ArgumentNullException(nameof(resultado));
            _motor = motor ?? throw new ArgumentNullException(nameof(motor));
            InitializeComponent();
                        
            _soloErrores.Click += SoloErrores_Click;



            _grid.Dock = DockStyle.Fill;
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.AutoGenerateColumns = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.MultiSelect = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cuenta", DataPropertyName = "NumeroCuenta", FillWeight = 28 });
            _grid.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Válida", DataPropertyName = "EsValida", FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Errores", DataPropertyName = "TextoErrores", FillWeight = 60 });
            _grid.SelectionChanged += Grid_SelectionChanged;

            _cerrar = new Button { Text = "Cerrar", DialogResult = DialogResult.OK, Width = 90, Anchor = AnchorStyles.Bottom | AnchorStyles.Right };
            _cerrar.Location = new Point(ClientSize.Width - 105, ClientSize.Height - 38);
            _cerrar.Click += (s, e) => Close();

            Resize += (s, e) => _cerrar.Location = new Point(ClientSize.Width - 105, ClientSize.Height - 38);

            Cargar();
        }

        private void Cargar() {
            ActualizarResumen();
            ActualizarGrid();
        }

        private void ActualizarGrid() {
            var datos = _resultado.Cuentas
                .Where(x => !_mostrarSoloErrores || !x.EsValida)
                .Select(x => new FilaAuditoria {
                    NumeroCuenta = _motor.AplicarMascara(x.NumeroCuenta),
                    EsValida = x.EsValida,
                    TextoErrores = x.EsValida ? string.Empty : string.Join(" | ", x.Errores)
                })
                .ToList();
            _grid.DataSource = datos;
            if (_grid.Rows.Count > 0)
                _grid.Rows[0].Selected = true;
        }

        private void ActualizarResumen() {
            _resumen.Text = string.Format(
                "Total: {0}    Válidas: {1}    Con errores: {2}",
                _resultado.Total, _resultado.Validas, _resultado.Invalidas);
        }

        private void SoloErrores_Click(object sender, EventArgs e) {
            _mostrarSoloErrores = !_mostrarSoloErrores;
            _soloErrores.Text = _mostrarSoloErrores ? "Mostrar todas" : "Mostrar solo errores";
            ActualizarGrid();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e) {
            if (_grid.CurrentRow == null) {
                _detalle.Text = string.Empty;
                return;
            }

            var fila = _grid.CurrentRow.DataBoundItem as FilaAuditoria;
            if (fila == null) {
                _detalle.Text = string.Empty;
                return;
            }

            var numeroFisico = _resultado.Cuentas
                .FirstOrDefault(x => string.Equals(
                    _motor.AplicarMascara(x.NumeroCuenta), fila.NumeroCuenta,
                    StringComparison.Ordinal));
            _detalle.Text = numeroFisico == null || numeroFisico.EsValida
                ? "Sin errores."
                : string.Join(Environment.NewLine, numeroFisico.Errores.Select(x => "• " + x));
        }

        private sealed class FilaAuditoria {
            public string NumeroCuenta { get; set; }
            public bool EsValida { get; set; }
            public string TextoErrores { get; set; }
        }
    }
}
