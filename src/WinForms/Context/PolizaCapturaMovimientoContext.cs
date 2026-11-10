using System;
using Jaeger.Contable.Application.Contracts;

namespace Jaeger.Contable.WinForms.Context {
    /// <summary>
    /// Implementación de las dependencias de la captura de movimientos contables.
    /// </summary>
    public sealed class PolizaCapturaMovimientoContext : IPolizaCapturaMovimientoContext {
        public ICuentaService CuentaService { get; private set; }
        public ICatalogosPartidaService CatalogosPartidaService { get; private set; }
        public IMonedaService MonedaService { get; private set; }

        public PolizaCapturaMovimientoContext(
            ICuentaService cuentaService,
            ICatalogosPartidaService catalogosPartidaService,
            IMonedaService monedaService) {
            CuentaService = cuentaService ?? throw new ArgumentNullException(nameof(cuentaService));
            CatalogosPartidaService = catalogosPartidaService ?? throw new ArgumentNullException(nameof(catalogosPartidaService));
            MonedaService = monedaService ?? throw new ArgumentNullException(nameof(monedaService));
        }
    }
}
