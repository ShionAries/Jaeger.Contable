using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    /// <summary>Permite seleccionar un rango disponible para asociarlo a una cuenta.</summary>
    public partial class RangoSeleccionForm : Form {
        private IList<RubroContableModel> _dataSource;
        public RubroContableModel RangoSeleccionado { get; private set; }

        public RangoSeleccionForm(IList<RubroContableModel> rangos) {
            this.InitializeComponent();
            if (rangos == null)
                throw new ArgumentNullException(nameof(rangos));
            this._dataSource = rangos;

            Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync() {
            foreach (var rango in this._dataSource)
                lista.Items.Add(rango);

            if (lista.Items.Count > 0)
                lista.SelectedIndex = 0;
        }

        private void Aceptar_Click(object sender, EventArgs e) {
            RangoSeleccionado = lista.SelectedItem as RubroContableModel;
            if (RangoSeleccionado == null)
                DialogResult = DialogResult.None;
        }
    }
}
