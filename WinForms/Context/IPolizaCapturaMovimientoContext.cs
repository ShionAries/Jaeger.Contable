using Jaeger.Contable.Application.Contracts;

namespace Jaeger.Contable.WinForms.Context {
    /// <summary>
    /// Expone las dependencias necesarias para la captura de una partida contable.
    /// </summary>
    public interface IPolizaCapturaMovimientoContext {
        ICuentaService CuentaService { get; }
        ICatalogosPartidaService CatalogosPartidaService { get; }
        IMonedaService MonedaService { get; }
    }
}
