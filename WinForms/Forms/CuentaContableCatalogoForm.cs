using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Forms {
    public partial class CuentaContableCatalogoForm : Form {
        private readonly ICuentaService _cuentaService;
        private readonly IMotorContableService _motorContableService;
        
        private List<RangoCuentaModel> _cuentas;
        private bool _cargandoCatalogo;

        public CuentaContableCatalogoForm(
            ICuentaService cuentaService,
            IMotorContableService motorContableService,
            IPolizaConsultaService polizaConsultaService = null,
            IPolizaContableService polizaContableService = null) {
            InitializeComponent();
            _cuentaService = cuentaService ?? throw new ArgumentNullException(nameof(cuentaService));
            _motorContableService = motorContableService ?? throw new ArgumentNullException(nameof(motorContableService));
        }

        private async void CuentaContableCatalogoForm_Load(object sender, EventArgs e) {
            await CargarCatalogoAsync();
        }

        private async Task CargarCatalogoAsync(int? rangoSeleccionado = null, string cuentaSeleccionada = null) {
            if (_cargandoCatalogo)
                return;

            _cargandoCatalogo = true;
            try {
                await _motorContableService.InicializarAsync(1);

                _cuentas = await _cuentaService.Lista1();
                var rangos = await _cuentaService.ListarEstructuraRangosActivosAsync();

                grdRubros.DataSource = null;
                grdRubros.DataSource = rangos;

                if (grdRubros.Rows.Count == 0) {
                    LimpiarArbol();
                    return;
                }

                var indice = 0;
                if (rangoSeleccionado.HasValue) {
                    for (var i = 0; i < grdRubros.Rows.Count; i++) {
                        var item = grdRubros.Rows[i].DataBoundItem as RubroContableModel;
                        if (item != null && item.Rango == rangoSeleccionado.Value) {
                            indice = i;
                            break;
                        }
                    }
                }

                grdRubros.ClearSelection();
                grdRubros.Rows[indice].Selected = true;
                grdRubros.CurrentCell = grdRubros.Rows[indice].Cells[0];

                MostrarRangoSeleccionado(
                    grdRubros.Rows[indice].DataBoundItem as RubroContableModel);

                if (!string.IsNullOrWhiteSpace(cuentaSeleccionada))
                    SeleccionarCuentaEnArbol(cuentaSeleccionada);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Configuración contable",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show(
                    "No fue posible cargar el catálogo: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                _cargandoCatalogo = false;
            }
        }

        private void PolizaGrid_SelectionChanged(object sender, EventArgs e) {
            if (_cargandoCatalogo)
                return;

            var rango = grdRubros.CurrentRow == null
                ? null
                : grdRubros.CurrentRow.DataBoundItem as RubroContableModel;

            if (rango == null) {
                LimpiarArbol();
                return;
            }

            MostrarRangoSeleccionado(rango);
        }

        private void MostrarRangoSeleccionado(RubroContableModel rango) {
            tvCuentas.BeginUpdate();
            try {
                tvCuentas.Nodes.Clear();

                if (rango == null) {
                    statusLabel.Text = "Seleccione un rango para consultar sus cuentas.";
                    return;
                }

                statusLabel.Text = string.Format("Rango seleccionado: {0} - {1}", rango.Rango, rango.Descripcion);

                var cuentas = (_cuentas ?? new List<RangoCuentaModel>())
                    .Where(x => x.Rango == rango.Rango)
                    .ToList();

                ConstruirJerarquiaTreeView(cuentas);
            } finally {
                tvCuentas.EndUpdate();
            }
        }

        private void LimpiarArbol() {
            tvCuentas.BeginUpdate();
            try {
                tvCuentas.Nodes.Clear();
                statusLabel.Text =
                    "Seleccione un rango para consultar sus cuentas.";
            } finally {
                tvCuentas.EndUpdate();
            }
        }

        private void ConstruirJerarquiaTreeView(List<RangoCuentaModel> cuentas) {
            var nodos = new Dictionary<string, TreeNode>(StringComparer.Ordinal);

            foreach (var cuenta in cuentas) {
                if (cuenta == null || string.IsNullOrWhiteSpace(cuenta.NumCta))
                    continue;

                var numero = NormalizarNumero(cuenta.NumCta);
                if (nodos.ContainsKey(numero))
                    continue;

                nodos.Add(numero, new TreeNode {
                    Text = $"{_motorContableService.AplicarMascara(cuenta.NumCta)} {cuenta.Nombre}",
                    Tag = cuenta
                });
            }

            foreach (var cuenta in cuentas.OrderBy(x => x.Nivel).ThenBy(x => x.NumCta)) {
                if (cuenta == null)
                    continue;

                TreeNode actual;
                if (!nodos.TryGetValue(NormalizarNumero(cuenta.NumCta), out actual))
                    continue;

                if (cuenta.Status.Equals("B"))
                    actual.ForeColor = System.Drawing.Color.Red;
                
                var padre = NormalizarNumero(cuenta.CtaPapa);
                TreeNode nodoPadre;

                if (padre.Length > 0 &&
                    padre != "-1" &&
                    nodos.TryGetValue(padre, out nodoPadre)) {
                    nodoPadre.Nodes.Add(actual);
                } else {
                    tvCuentas.Nodes.Add(actual);
                }
            }
        }

        private void SeleccionarCuentaEnArbol(string numeroCuenta) {
            var numeroNormalizado = NormalizarNumero(numeroCuenta);
            if (numeroNormalizado.Length == 0)
                return;

            TreeNode encontrado = BuscarNodo(tvCuentas.Nodes, numeroNormalizado);
            if (encontrado == null)
                return;

            var nodo = encontrado;
            while (nodo.Parent != null) {
                nodo.Parent.Expand();
                nodo = nodo.Parent;
            }

            encontrado.EnsureVisible();
            tvCuentas.SelectedNode = encontrado;
            encontrado.EnsureVisible();
            statusLabel.Text = string.Format(
                "Cuenta generada: {0}",
                _motorContableService.AplicarMascara(numeroNormalizado));
        }

        private static TreeNode BuscarNodo(TreeNodeCollection nodos, string numeroCuenta) {
            foreach (TreeNode nodo in nodos) {
                var cuenta = nodo.Tag as RangoCuentaModel;
                if (cuenta != null &&
                    string.Equals(NormalizarNumero(cuenta.NumCta), numeroCuenta, StringComparison.Ordinal))
                    return nodo;

                var encontrado = BuscarNodo(nodo.Nodes, numeroCuenta);
                if (encontrado != null)
                    return encontrado;
            }

            return null;
        }

        private async void Desactivar_Click(object sender, EventArgs e) {
            var cuenta = tvCuentas.SelectedNode == null
                ? null
                : tvCuentas.SelectedNode.Tag as RangoCuentaModel;

            if (cuenta == null) {
                MessageBox.Show("Seleccione una cuenta para desactivar.", "Cuenta contable",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!string.Equals(cuenta.Status, "A", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("La cuenta seleccionada ya está inactiva.", "Cuenta contable",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmar = MessageBox.Show(
                string.Format("¿Desea desactivar la cuenta {0} - {1}?",
                    _motorContableService.AplicarMascara(cuenta.NumCta), cuenta.Nombre),
                "Confirmar desactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            try {
                var resultado = await _cuentaService.DesactivarCuentaAsync(cuenta.NumCta);
                if (!resultado)
                    throw new InvalidOperationException("No fue posible desactivar la cuenta.");

                await CargarCatalogoAsync(ObtenerRangoSeleccionado().Rango);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Desactivar cuenta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show("No fue posible desactivar la cuenta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Reactivar_Click(object sender, EventArgs e) {
            var cuenta = tvCuentas.SelectedNode == null
                ? null
                : tvCuentas.SelectedNode.Tag as RangoCuentaModel;

            if (cuenta == null) {
                MessageBox.Show("Seleccione una cuenta para reactivar.", "Cuenta contable",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.Equals(cuenta.Status, "A", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("La cuenta seleccionada ya está activa.", "Cuenta contable",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmar = MessageBox.Show(
                string.Format("¿Desea reactivar la cuenta {0} - {1}?",
                    _motorContableService.AplicarMascara(cuenta.NumCta), cuenta.Nombre),
                "Confirmar reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            try {
                var resultado = await _cuentaService.ReactivarCuentaAsync(cuenta.NumCta);
                if (!resultado)
                    throw new InvalidOperationException("No fue posible reactivar la cuenta.");

                await CargarCatalogoAsync(ObtenerRangoSeleccionado().Rango);
            } catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Reactivar cuenta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                MessageBox.Show("No fue posible reactivar la cuenta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Agregar_Click(object sender, EventArgs e) {
            var rango = ObtenerRangoSeleccionado();
            if (rango == null) {
                MessageBox.Show(
                    "Seleccione un rango antes de agregar una cuenta.",
                    "Cuenta contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try {
                var nodo = tvCuentas.SelectedNode;
                var padre = nodo == null ? null : nodo.Tag as RangoCuentaModel;

                CuentaContable nueva;

                if (padre == null) {
                    nueva = new CuentaContable {
                        Nivel = 1,
                        CtaPapa = "-1",
                        Status = "A",
                        Tipo = "D",
                        DeptoSiNo = "N"
                    };
                } else {
                    if (!string.Equals(padre.Tipo, "A",
                        StringComparison.OrdinalIgnoreCase)) {
                        MessageBox.Show(
                            "Solo una cuenta acumulativa puede tener cuentas hijas.",
                            "Cuenta contable", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    if (!string.Equals(padre.Status, "A", StringComparison.OrdinalIgnoreCase)) {
                        MessageBox.Show(
                            "No se pueden registrar cuentas hijas de una cuenta inactiva.",
                            "Cuenta contable", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    var nivel = (short)(padre.Nivel + 1);

                    nueva = new CuentaContable {
                        CtaPapa = padre.NumCta,
                        CtaRaiz = padre.CtaRaiz,
                        Nivel = nivel,
                        Status = "A",
                        Tipo = "D",
                        DeptoSiNo = "N"
                    };
                }

                using (var form = new CuentaContableForm(
                    _cuentaService,
                    _motorContableService,
                    nueva,
                    true,
                    rango.Rango)) {

                    if (form.ShowDialog(this) == DialogResult.OK)
                        await CargarCatalogoAsync(rango.Rango, nueva.NumCta);
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message, "Aviso de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void Editar_Click(object sender, EventArgs e) {
            var cuenta = tvCuentas.SelectedNode == null
                ? null
                : tvCuentas.SelectedNode.Tag as RangoCuentaModel;

            if (cuenta == null) {
                MessageBox.Show(
                    "Seleccione una cuenta para editar.",
                    "Cuenta contable", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var rango = ObtenerRangoSeleccionado();
            if (rango == null)
                return;

            var copia = CopiarCuenta(cuenta);

            using (var form = new CuentaContableForm(
                _cuentaService,
                _motorContableService,
                copia,
                false,
                rango.Rango)) {

                if (form.ShowDialog(this) == DialogResult.OK)
                    await CargarCatalogoAsync(rango.Rango, copia.NumCta);
            }
        }

        private RubroContableModel ObtenerRangoSeleccionado() {
            return grdRubros.CurrentRow == null
                ? null
                : grdRubros.CurrentRow.DataBoundItem as RubroContableModel;
        }

        private static CuentaContable CopiarCuenta(CuentaContable origen) {
            return new CuentaContable {
                NumCta = origen.NumCta,
                Status = origen.Status,
                Tipo = origen.Tipo,
                Nombre = origen.Nombre,
                DeptoSiNo = origen.DeptoSiNo,
                BandMulti = origen.BandMulti,
                BandAjt = origen.BandAjt,
                CtaPapa = origen.CtaPapa,
                CtaRaiz = origen.CtaRaiz,
                Nivel = origen.Nivel,
                CtaComp = origen.CtaComp,
                Naturaleza = origen.Naturaleza,
                RFC = origen.RFC,
                CodAgrup = origen.CodAgrup,
                CapturaCheque = origen.CapturaCheque,
                CapturaUUID = origen.CapturaUUID,
                Banco = origen.Banco,
                CtaBancaria = origen.CtaBancaria,
                CapturaChequeTipoMovimiento = origen.CapturaChequeTipoMovimiento,
                NoIncluirXML = origen.NoIncluirXML,
                IdFiscal = origen.IdFiscal,
                EsFlujoEfectivo = origen.EsFlujoEfectivo,
                BancoExtranjero = origen.BancoExtranjero,
                RfcFlujo = origen.RfcFlujo
            };
        }

        private static string NormalizarNumero(string numero) {
            return string.IsNullOrWhiteSpace(numero)
                ? string.Empty
                : numero.Trim();
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
