using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.WinForms.Context;

namespace Jaeger.Contable.WinForms.Forms {
    public partial class ActivoFijoHistoricoForm : Form {
        private readonly IActivoFijoHistoricoService _service;
        private List<ActivoFijo> _datos = new List<ActivoFijo>();

        public ActivoFijoHistoricoForm(IActivoFijoHistoricoService service) {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Text = "Consulta histórica de activos fijos";
            StartPosition = FormStartPosition.CenterParent;
            CrearControles();
            Load += async (s, e) => await CargarAsync();
        }

        private void CrearControles() {
            
            _cmbTabla.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbTabla.Items.Add(new ItemTabla(24, "ACTIVOS24"));
            _cmbTabla.Items.Add(new ItemTabla(25, "ACTIVOS25"));
            _cmbTabla.SelectedIndex = 1;
            _cmbTabla.SelectedIndexChanged += async (s, e) => await CargarAsync();

            _txtBuscar.Width = 300;
            _txtBuscar.TextChanged += (s, e) => Filtrar();

            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridData.ColumnText("Clave", "Clave");
            gridData.ColumnText("Tipo", "Tipo");
            gridData.ColumnText("Descripcion", "Descripción");
            gridData.ColumnText("FecAdquisicion", "Adquisición", "d");
            gridData.ColumnText("MontoOriginal", "Monto original", "N2");
            gridData.ColumnText("DepresiacionAcumulada", "Dep. acumulada", "N2");
            gridData.ColumnText("Status", "Status");
            gridData.ColumnText("NumSerie", "Serie");
        }

        private async Task CargarAsync() {
            try {
                var item = _cmbTabla.SelectedItem as ItemTabla;
                if (item == null)
                    return;
                _datos = await _service.ObtenerAsync(item.Valor);
                Filtrar();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Consulta histórica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtrar() {
            var q = (_txtBuscar.Text ?? string.Empty).Trim();
            var datos = string.IsNullOrEmpty(q) ? _datos : _datos.Where(x =>
                (x.Clave ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                (x.NumSerie ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            gridData.DataSource = datos;
        }

        private sealed class ItemTabla {
            public short Valor { get; private set; }
            private readonly string _texto;
            public ItemTabla(short valor, string texto) { Valor = valor; _texto = texto; }
            public override string ToString() { return _texto; }
        }
    }
}
