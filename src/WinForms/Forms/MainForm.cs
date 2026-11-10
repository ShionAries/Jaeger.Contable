using System;
using System.Windows.Forms;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Forms;
using Jaeger.Contable.WinForms.Context;
using Jaeger.Contable.WinForms.Forms;

namespace Jaeger.Contable {
    /// <summary>
    /// Ventana principal de la aplicación contable.
    /// Coordina la interfaz y delega la creación de formularios a la navegación.
    /// </summary>
    public partial class MainForm : Form {
        private readonly IContableApplication _application;

        public MainForm(IContableApplication navigation) {
            InitializeComponent();
            this._application = navigation ?? throw new ArgumentNullException(nameof(navigation));
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.Create();
        }

        private void Create() {
            this.mCuentasCuentas.Click += (s, e) => this.OpenForm(new CuentaContableCatalogoForm(_application.CuentaService, _application.MotorContableService));

            this.mPolizasConsulta.Click += (s, e) => {
                var context = new PolizaCapturaMovimientoContext(_application.CuentaService, _application.CatalogosPartidaService, _application.MonedaService);
                var form = new PolizaConsultaForm(
                               _application.PolizaConsultaService,
                               _application.TipoPolizaService,
                               _application.CuentaService,
                               _application.ReversionPolizaService,
                               _application.PolizaContableService,
                               _application.ConceptoService,
                               _application.PeriodoContableService,
                               context,
                               _application.ParametroEmpresaService,
                               _application.ContabilizacionContableService);
                this.OpenForm(form);
            };

            this.mBalanzaComprobacion.Click += (s, e) => {
                if (!EnsureAvailable(_application.BalanzaComprobacionService, this,
                    "El servicio de balanza de comprobación no está disponible.", "Balanza de comprobación"))
                    return;
                this.OpenForm(new BalanzaComprobacionForm(_application.BalanzaComprobacionService));
            };

            this.mPolizasCaptura.Click += (s, e) => {
                var movimientoContext = new PolizaCapturaMovimientoContext(_application.CuentaService, _application.CatalogosPartidaService, _application.MonedaService);
                using (var form = new PolizaCapturaForm(_application.PolizaContableService, _application.TipoPolizaService, _application.ConceptoService, _application.PeriodoContableService, movimientoContext, null, _application.ParametroEmpresaService, _application.ContabilizacionContableService))
                    form.ShowDialog(this);
            };

            this.mContabilizarPeriodo.Click += (s, e) => {
                if (!EnsureAvailable(_application.ContabilizacionContableService, this, "El servicio de contabilización no está disponible.", "Contabilización"))
                    return;
                using (var form = new PeriodoContabilizacionForm(_application.PeriodoContableService, _application.ContabilizacionContableService, _application.TipoPolizaService))
                    form.ShowDialog(this);
            };

            this.mConceptos.Click += (s, e) => {
                if (!EnsureAvailable(_application.ConceptoService, this, "El servicio de conceptos no está disponible.", "Conceptos"))
                    return;
                using (var form = new ConceptoPolizaCatalogoForm(_application.ConceptoService))
                    form.ShowDialog(this);
            };

            this.mCatalogosPartida.Click += (s, e) => {
                if (!EnsureAvailable(_application.CatalogosPartidaService, this, "El servicio de catálogos de partidas no está disponible.", "Catálogos"))
                    return;
                using (var form = new PeriodoContableMantenimientoForm(_application.PeriodoContableService))
                    form.ShowDialog(this);
            };

            this.mTiposPoliza.Click += (s, e) => {
                if (!EnsureAvailable(_application.TipoPolizaService, this, "El servicio de tipos de póliza no está disponible.", "Tipos de póliza"))
                    return;
                using (var form = new TipoPolizaCatalogoForm(_application.TipoPolizaService))
                    form.ShowDialog(this);
            };

            this.mRangos.Click += (s, e) => {
                if (!EnsureAvailable(_application.RangoService, this, "El servicio de rangos no está disponible.", "Rangos"))
                    return;
                using (var form = new RangoCatalogoForm(_application.RangoService))
                    form.ShowDialog(this);
            };

            this.mMonedas.Click += (s, e) => {
                if (!EnsureAvailable(_application.MonedaService, this, "El servicio de monedas no está disponible.", "Monedas"))
                    return;
                using (var form = new MonedaCatalogoForm(_application.MonedaService))
                    form.ShowDialog(this);
            };

            this.mTiposActivo.Click += (s, e) => {
                if (!EnsureAvailable(_application.TipoActivoService, this, "El servicio de tipos de activo no está disponible.", "Tipos de activo"))
                    return;
                using (var form = new ActivoFijoTipoCatalogoForm(_application.TipoActivoService))
                    form.ShowDialog(this);
            };

            this.mActivosFijos.Click += (s, e) => {
                if (!EnsureAvailable(_application.ActivoFijoService, this, "El servicio de activos fijos no está disponible.", "Activos fijos"))
                    return;
                using (var form = new ActivoFijoCatalogoForm(_application.ActivoFijoService, _application.TipoActivoService))
                    form.ShowDialog(this);
            };

            this.mHistoricoActivos.Click += (s, e) => {
                if (!EnsureAvailable(_application.ActivoFijoHistoricoService, this, "El servicio histórico de activos no está disponible.", "Consulta histórica"))
                    return;
                using (var form = new ActivoFijoHistoricoForm(_application.ActivoFijoHistoricoService))
                    form.ShowDialog(this);
            };

            this.mDepreciacionActivos.Click += (s, e) => {
                if (!EnsureAvailable(_application.DepreciacionActivoService, this, "El servicio de control de depreciación no está disponible.", "Depreciación"))
                    return;
                using (var form = new DepreciacionActivosForm(_application.DepreciacionActivoService))
                    form.ShowDialog(this);
            };

            this.mAuditoriaCuentas.Click += async (s, e) => {
                await _application.MotorContableService.InicializarAsync(1);
                var resultado = await _application.AuditoriaCuentasService.AuditarAsync();
                using (var form = new AuditoriaCuentasForm(resultado, _application.MotorContableService))
                    form.ShowDialog(this);
                //return string.Format("Auditoría: {0} válidas, {1} con errores de {2} cuentas.", resultado.Validas, resultado.Invalidas, resultado.Total);
            };

            this.mAuditoriaRubros.Click += async (s, e) => {
                await _application.MotorContableService.InicializarAsync(1);
                var resultado = await _application.AuditoriaCtarubService.AuditarAsync();
                using (var form = new AuditoriaCtarubForm(resultado, _application.MotorContableService))
                    form.ShowDialog(this);
                //return string.Format("Auditoría CTARUB: {0} válidas, {1} con errores de {2} relaciones.", resultado.Validas, resultado.Invalidas, resultado.Total);
            };

            this.mSalir.Click += (s, e) => Close();
        }

        private void OpenForm(Form form) {
            if (form == null)
                throw new ArgumentNullException(nameof(form));
            form.MdiParent = this;
            form.Show();
        }

        private static bool EnsureAvailable<T>(T service, Form owner, string message, string title) where T : class {
            if (service != null)
                return true;
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}
