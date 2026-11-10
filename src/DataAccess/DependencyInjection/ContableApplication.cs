using System;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Application.Services;
using Jaeger.Contable.DataAccess.Configuration;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Repositories;
using Jaeger.Contable.DataAccess.Resolvers;

namespace Jaeger.Contable.DataAccess.DependencyInjection {
    public sealed class ContableApplication : IContableApplication, IDisposable {
        private readonly MariaDbContext context;
        private bool disposed;

        public ICuentaService CuentaService { get; private set; }
        public IMotorContableService MotorContableService { get; private set; }
        public IAuditoriaCuentasService AuditoriaCuentasService { get; private set; }
        public IAuditoriaCtarubService AuditoriaCtarubService { get; private set; }
        public IPolizaConsultaService PolizaConsultaService { get; private set; }
        public IPolizaContableService PolizaContableService { get; private set; }
        public ITipoPolizaService TipoPolizaService { get; private set; }
        public ICatalogosPartidaService CatalogosPartidaService { get; private set; }
        public IConceptoService ConceptoService { get; private set; }
        public IRangoService RangoService { get; private set; }
        public IReversionPolizaService ReversionPolizaService { get; private set; }
        public IMonedaService MonedaService { get; private set; }
        public IActivoFijoTipoService TipoActivoService { get; private set; }
        public IActivoFijoService ActivoFijoService { get; private set; }
        public IActivoFijoHistoricoService ActivoFijoHistoricoService { get; private set; }
        public IDepreciacionActivoService DepreciacionActivoService { get; private set; }
        public IConciliacionCuentaService ConciliacionCuentaService { get; private set; }
        public IAcumulacionCuentaService AcumulacionCuentaService { get; private set; }
        public IConfiguracionCuentaService ConfiguracionCuentaService { get; private set; }
        public IPeriodoContableService PeriodoContableService { get; private set; }
        public IContabilizacionContableService ContabilizacionContableService { get; private set; }
        public IParametroEmpresaService ParametroEmpresaService { get; private set; }
        public IFolioContableService FolioContableService { get; private set; }
        public IBalanzaComprobacionService BalanzaComprobacionService { get; private set; }

        public ContableApplication(string connectionString) {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("La cadena de conexión de Jaeger.Contable es obligatoria.", nameof(connectionString));

            context = new MariaDbContext(connectionString);
            var tableResolver = new EjercicioContableTableResolver();

            var cuentaRepository = new CuentaRepository(context);
            var parametroRepository = new ParametroEmpresaRepository(context);
            var ctarubRepository = new CuentaRubroRepository(context);
            var rangoRepository = new RubroContableRepository(context);
            var historialCuentaRepository = new HistorialCuentaRepository(context);
            var estadoContableCuentaRepository = new EstadoContableCuentaRepository(context, tableResolver);
            var configuracionRepository = new ConfiguracionCuentaRepository(context);
            var acumulacionRepository = new AcumulacionCuentaRepository(context, tableResolver);
            var conciliacionRepository = new ConciliacionCuentaRepository(context, tableResolver);
            var contabilizacionRepository = new ContabilizacionContableRepository(context, tableResolver);
            var periodoRepository = new PeriodoContableRepository(context);
            var movimientoRepository = new MovimientoContableRepository(context);
            var catalogosPartidaRepository = new CatalogosPartidaRepository(context);
            var tipoPolizaRepository = new TipoPolizaRepository(context);
            var conceptoRepository = new ConceptoRepository(context);
            var monedaRepository = new MonedaRepository(context);
            var tipoActivoRepository = new ActivoFijoTipoRepository(context);
            var activoFijoRepository = new ActivoFijoRepository(context, tableResolver);
            var activoFijoHistoricoRepository = new ActivoFijoHistoricoRepository(context);
            var folioRepository = new FolioContableRepository(context);
            var depreciacionRepository = new DepreciacionActivoRepository(context, tableResolver, folioRepository, periodoRepository);
            var polizaRepository = new PolizaContableRepository(context, folioRepository, periodoRepository, tableResolver);
            var polizaConsultaRepository = new PolizaConsultaRepository(context, tableResolver);
            var balanzaRepository = new BalanzaComprobacionRepository(context, tableResolver);
            var reversionRepository = new ReversionPolizaRepository(context);

            ConfiguracionCuentaService = new ConfiguracionCuentaService(configuracionRepository);
            ConciliacionCuentaService = new ConciliacionCuentaService(conciliacionRepository);
            AcumulacionCuentaService = new AcumulacionCuentaService(cuentaRepository, acumulacionRepository);
            PeriodoContableService = new PeriodoContableService(periodoRepository);
            ContabilizacionContableService = new ContabilizacionContableService(contabilizacionRepository, PeriodoContableService);
            ParametroEmpresaService = new ParametroEmpresaService(parametroRepository);
            RangoService = new RangoService(rangoRepository);
            ConceptoService = new ConceptoService(conceptoRepository);
            MonedaService = new MonedaService(monedaRepository);
            TipoActivoService = new ActivoFijoTipoService(tipoActivoRepository);
            ActivoFijoService = new ActivoFijoService(activoFijoRepository);
            ActivoFijoHistoricoService = new ActivoFijoHistoricoService(activoFijoHistoricoRepository);
            TipoPolizaService = new TipoPolizaService(tipoPolizaRepository);
            CatalogosPartidaService = new CatalogosPartidaService(catalogosPartidaRepository);
            FolioContableService = new FolioContableService(folioRepository);

            var validador = new ValidadorJerarquiaCuenta(cuentaRepository, ConfiguracionCuentaService, 1);
            AuditoriaCuentasService = new AuditoriaCuentasService(cuentaRepository, validador);
            AuditoriaCtarubService = new AuditoriaCtarubService(ctarubRepository, cuentaRepository, rangoRepository, ConfiguracionCuentaService, 1);

            MotorContableService = new MotorContableService(cuentaRepository, ConfiguracionCuentaService);
            CuentaService = new CuentaService(cuentaRepository, parametroRepository, MotorContableService, historialCuentaRepository, estadoContableCuentaRepository, 1);

            var motorMovimiento = new MotorMovimientoContableService(CuentaService, PeriodoContableService);
            DepreciacionActivoService = new DepreciacionActivoService(activoFijoRepository, TipoActivoService, tipoActivoRepository, depreciacionRepository, periodoRepository);
            var polizaValidator = new PolizaContableValidator();
            PolizaContableService = new PolizaContableService(motorMovimiento, polizaRepository, PeriodoContableService, TipoPolizaService, CatalogosPartidaService, polizaValidator);

            PolizaConsultaService = new PolizaConsultaService(polizaConsultaRepository);
            BalanzaComprobacionService = new BalanzaComprobacionService(balanzaRepository, cuentaRepository);
            ReversionPolizaService = new ReversionPolizaService(PeriodoContableService, reversionRepository, FolioContableService);
        }

        public static IContableApplication Create() {
            var provider = new AppConfigConnectionStringProvider();
            return new ContableApplication(provider.GetConnectionString());
        }

        public void Dispose() {
            if (disposed)
                return;

            disposed = true;
            if (context != null)
                context.Dispose();
        }
    }
}
