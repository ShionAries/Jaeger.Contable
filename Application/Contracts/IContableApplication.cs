using System;

namespace Jaeger.Contable.Application.Contracts {
    public interface IContableApplication : IDisposable {
        ICuentaService CuentaService { get; }
        IMotorContableService MotorContableService { get; }
        IAuditoriaCuentasService AuditoriaCuentasService { get; }
        IAuditoriaCtarubService AuditoriaCtarubService { get; }
        IPolizaConsultaService PolizaConsultaService { get; }
        IPolizaContableService PolizaContableService { get; }
        ITipoPolizaService TipoPolizaService { get; }
        ICatalogosPartidaService CatalogosPartidaService { get; }
        IConceptoService ConceptoService { get; }
        IRangoService RangoService { get; }
        IReversionPolizaService ReversionPolizaService { get; }
        IMonedaService MonedaService { get; }
        ITipoActivoService TipoActivoService { get; }
        IActivoFijoService ActivoFijoService { get; }
        IActivoFijoHistoricoService ActivoFijoHistoricoService { get; }
        IDepreciacionActivoService DepreciacionActivoService { get; }
        IConciliacionCuentaService ConciliacionCuentaService { get; }
        IAcumulacionCuentaService AcumulacionCuentaService { get; }
        IConfiguracionCuentaService ConfiguracionCuentaService { get; }
        IPeriodoContableService PeriodoContableService { get; }
        IContabilizacionContableService ContabilizacionContableService { get; }
        IParametroEmpresaService ParametroEmpresaService { get; }
        IFolioContableService FolioContableService { get; }
        IBalanzaComprobacionService BalanzaComprobacionService { get; }
    }
}
