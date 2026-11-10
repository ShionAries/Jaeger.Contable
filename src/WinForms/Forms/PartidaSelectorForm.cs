using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.WinForms.Forms {
    public partial class PartidaSelectorForm : Form {
        public enum TipoCatalogo { CentroCosto, Grupo }
        private readonly ICatalogosPartidaService _service;
        private readonly TipoCatalogo _tipo;
        private List<CentroCosto> _centros = new List<CentroCosto>();
        private List<GrupoContable> _grupos = new List<GrupoContable>();
        public int ValorSeleccionado { get; private set; }
        public string DescripcionSeleccionada { get; private set; }

        public PartidaSelectorForm(ICatalogosPartidaService service, TipoCatalogo tipo) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _tipo = tipo;
            InitializeComponent();
            Text = tipo == TipoCatalogo.CentroCosto ? "Seleccionar centro de costos" : "Seleccionar grupo";
            
            _grid.Dock = DockStyle.Fill;
            _grid.ReadOnly = true;
            _grid.AutoGenerateColumns = false;
            _grid.RowHeadersVisible = false;
            _grid.AllowUserToResizeRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "ID", Width = 20 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", DataPropertyName = "DESCRIPCION", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            
            _txtBuscar.TextChanged += (s, e) => Filtrar();
            _grid.CellDoubleClick += (s, e) => Aceptar();
            Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            if (_tipo == TipoCatalogo.CentroCosto)
                _centros = (await _service.ObtenerCentrosCostosAsync()).ToList();
            else
                _grupos = (await _service.ObtenerGruposAsync()).ToList();
            Filtrar();
        }
        
        private void Filtrar() {
            var q = (_txtBuscar.Text ?? string.Empty).Trim();
            if (_tipo == TipoCatalogo.CentroCosto) {
                _grid.DataSource = string.IsNullOrEmpty(q)
                    ? _centros.ToList()
                    : _centros.Where(x => x.Id.ToString().Contains(q) ||
                        (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            } else {
                _grid.DataSource = string.IsNullOrEmpty(q)
                    ? _grupos.ToList()
                    : _grupos.Where(x => x.Id.ToString().Contains(q) ||
                        (x.Descripcion ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
        }

        private void Aceptar() {
            if (_grid.CurrentRow == null)
                return;
            var id = Convert.ToInt32(_grid.CurrentRow.Cells[0].Value);
            ValorSeleccionado = id;
            DescripcionSeleccionada = Convert.ToString(_grid.CurrentRow.Cells[1].Value) ?? string.Empty;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
