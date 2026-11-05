using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Valida y ejecuta la depreciación mensual sobre las tablas del ejercicio indicado.</summary>
    public sealed class DepreciacionActivoService : IDepreciacionActivoService {
        private readonly IActivoFijoRepository _activoRepository;
        private readonly ITipoActivoService _tipoActivoService;
        private readonly ITipoActivoRepository _tipoActivoRepository;
        private readonly IDepreciacionActivoRepository _depreciacionRepository;
        private readonly IPeriodoContableRepository _periodoRepository;

        public DepreciacionActivoService(
            IActivoFijoRepository activoRepository,
            ITipoActivoService tipoActivoService,
            ITipoActivoRepository tipoActivoRepository,
            IDepreciacionActivoRepository depreciacionRepository,
            IPeriodoContableRepository periodoRepository) {
            _activoRepository = activoRepository ?? throw new ArgumentNullException(nameof(activoRepository));
            _tipoActivoService = tipoActivoService ?? throw new ArgumentNullException(nameof(tipoActivoService));
            _tipoActivoRepository = tipoActivoRepository ?? throw new ArgumentNullException(nameof(tipoActivoRepository));
            _depreciacionRepository = depreciacionRepository ?? throw new ArgumentNullException(nameof(depreciacionRepository));
            _periodoRepository = periodoRepository ?? throw new ArgumentNullException(nameof(periodoRepository));
        }

        public async Task<List<ResultadoValidacionDepreciacion>> ValidarTodosAsync(short ejercicio) {
            ValidarEjercicio(ejercicio);
            List<ActivoFijo> activos = await _activoRepository.ObtenerTodosAsync(ejercicio);
            var resultados = new List<ResultadoValidacionDepreciacion>();
            foreach (ActivoFijo activo in activos) resultados.Add(await ValidarInternoAsync(activo));
            return resultados;
        }

        public async Task<ResultadoValidacionDepreciacion> ValidarAsync(short ejercicio, string clave) {
            ValidarEjercicio(ejercicio);
            if (string.IsNullOrWhiteSpace(clave)) throw new ArgumentException("La clave del activo es obligatoria.", nameof(clave));
            ActivoFijo activo = await _activoRepository.ObtenerAsync(ejercicio, clave.Trim());
            if (activo == null) throw new InvalidOperationException("El activo fijo no existe.");
            return await ValidarInternoAsync(activo);
        }

        public async Task<ResultadoProcesoDepreciacion> EjecutarAsync(short ejercicio, short periodo) {
            ValidarEjercicio(ejercicio);
            if (periodo < 1 || periodo > 14) throw new ArgumentOutOfRangeException(nameof(periodo));

            PeriodoContable estado = await _periodoRepository.ObtenerAsync(ejercicio, periodo);
            if (estado == null) throw new InvalidOperationException("El periodo no existe en ADMPER.");
            if (estado.EstaCerrado) throw new InvalidOperationException("El periodo está cerrado y no permite registrar la depreciación.");

            DateTime fechaCorte = FechaFinPeriodo(ejercicio, periodo);
            List<ActivoFijo> activos = await _activoRepository.ObtenerTodosAsync(ejercicio);
            var movimientos = new List<DepreciacionMovimiento>();
            var tipos = new Dictionary<short, TipoActivo>();

            foreach (ActivoFijo activo in activos) {
                if (!DebeDepreciarse(activo, fechaCorte)) continue;
                if (!activo.Tipo.HasValue) continue;

                TipoActivo tipo;
                if (!tipos.TryGetValue(activo.Tipo.Value, out tipo)) {
                    tipo = await _tipoActivoService.ObtenerAsync(activo.Tipo.Value);
                    if (tipo == null) throw new InvalidOperationException("El tipo de activo " + activo.Tipo.Value + " no existe en TIPACTIV.");
                    tipos.Add(activo.Tipo.Value, tipo);
                }

                if (!string.Equals(activo.MetodoDepresiacion, "L", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(tipo.MetodoDepresiacion, "L", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("El activo " + activo.Clave + " utiliza un método de depreciación no implementado: " + (activo.MetodoDepresiacion ?? tipo.MetodoDepresiacion) + ".");

                string cuentaGasto = NormalizarCuenta(tipo.CuentaGastos, "CTAGASTOS", activo.Clave);
                string cuentaDepreciacion = NormalizarCuenta(tipo.CuentaDepresiacion, "CTADEPRE", activo.Clave);
                double baseDepreciable = ObtenerBaseDepreciable(activo);
                double acumulada = Math.Max(0, activo.DepresiacionAcumulada ?? 0);
                double restante = Math.Max(0, baseDepreciable - acumulada);
                if (restante <= 0) continue;

                double tasa = activo.TasaDepresiacion.HasValue && activo.TasaDepresiacion.Value > 0 ? activo.TasaDepresiacion.Value : (tipo.DepresiacionNormal ?? 0);
                if (tasa <= 0) continue;

                double importe = Math.Round(Math.Min(restante, baseDepreciable * tasa / 100.0 / 12.0), 2, MidpointRounding.AwayFromZero);
                if (importe <= 0) continue;

                movimientos.Add(new DepreciacionMovimiento {
                    ClaveActivo = activo.Clave,
                    NuevaDepreciacionAcumulada = Math.Round(acumulada + importe, 2, MidpointRounding.AwayFromZero),
                    CuentaGasto = cuentaGasto,
                    CuentaDepreciacion = cuentaDepreciacion,
                    NumeroDepartamento = activo.IdDepartamento.HasValue && activo.IdDepartamento.Value > 0 ? activo.IdDepartamento : (short?)null,
                    Importe = importe,
                    Concepto = activo.Descripcion
                });
            }

            return await _depreciacionRepository.EjecutarAsync(ejercicio, periodo, movimientos);
        }

        private static void ValidarEjercicio(short ejercicio) {
            if (ejercicio < 1900 || ejercicio > 9999)
                throw new ArgumentOutOfRangeException(nameof(ejercicio), "El ejercicio contable no es válido.");
        }

        private static bool DebeDepreciarse(ActivoFijo activo, DateTime fechaCorte) {
            if (activo == null || string.IsNullOrWhiteSpace(activo.Clave)) return false;
            if (!activo.FecInicioDepresiacion.HasValue || activo.FecInicioDepresiacion.Value.Date > fechaCorte.Date) return false;
            if (activo.FechaBaja.HasValue && activo.FechaBaja.Value.Date <= fechaCorte.Date) return false;
            if (activo.MontoOriginal.GetValueOrDefault() <= 0) return false;
            return true;
        }

        private static double ObtenerBaseDepreciable(ActivoFijo activo) {
            double original = Math.Max(0, activo.MontoOriginal ?? 0);
            double maximo = activo.MaximoDeducible.GetValueOrDefault();
            if (maximo > 0) return Math.Min(original, maximo);
            return original;
        }

        private static string NormalizarCuenta(string cuenta, string campo, string activo) {
            if (string.IsNullOrWhiteSpace(cuenta))
                throw new InvalidOperationException(campo + " no está configurada para el activo " + activo + ".");
            return cuenta.Trim();
        }

        private async Task<ResultadoValidacionDepreciacion> ValidarInternoAsync(ActivoFijo activo) {
            var observaciones = new List<string>();
            if (activo.Tipo.HasValue) {
                TipoActivo tipo = await _tipoActivoService.ObtenerAsync(activo.Tipo.Value);
                if (tipo == null) observaciones.Add("El tipo de activo no existe en TIPACTIV.");
                else {
                    if (string.IsNullOrWhiteSpace(tipo.MetodoDepresiacion)) observaciones.Add("TIPACTIV no tiene METODODEP configurado.");
                    await ValidarReferenciasTipoAsync(tipo, observaciones);
                    ValidarNumericosTipo(tipo, observaciones);
                }
            } else observaciones.Add("El activo no tiene TIPO asignado.");

            if (!activo.MontoOriginal.HasValue || activo.MontoOriginal.Value <= 0) observaciones.Add("MONTORIG debe ser mayor que cero.");
            if (!activo.FecAdquisicion.HasValue) observaciones.Add("FECHAADQ no está configurada.");
            if (!activo.FecInicioDepresiacion.HasValue) observaciones.Add("FECINIDEP no está configurada.");
            if (!activo.VidaUtil.HasValue || activo.VidaUtil.Value <= 0) observaciones.Add("VIDAUT debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(activo.MetodoDepresiacion)) observaciones.Add("METDEP no está configurado en la tabla de activos del ejercicio seleccionado.");
            ValidarNumerico(activo.MontoOriginal, "MONTORIG", observaciones); ValidarNumerico(activo.MontoOriginalMonedaExtranjera, "MONTORIGEX", observaciones);
            ValidarNumerico(activo.MaximoDeducible, "MAXDED", observaciones); ValidarNumerico(activo.ValorMercado, "VALMER", observaciones); ValidarNumerico(activo.DepresiacionAcumulada, "DEPACU", observaciones);
            ValidarNumerico(activo.VidaUtil, "VIDAUT", observaciones); ValidarNumerico(activo.TasaDepresiacion, "TASDEP", observaciones); ValidarNumerico(activo.TasaDepresiacionFiscal, "TASDEPFIS", observaciones); ValidarNumerico(activo.DepresiacionAcumuladaFiscal, "DEPACUFISC", observaciones);
            if (activo.TasaDepresiacion.HasValue && activo.TasaDepresiacion.Value < 0) observaciones.Add("TASDEP no puede ser negativa.");
            if (activo.TasaDepresiacionFiscal.HasValue && activo.TasaDepresiacionFiscal.Value < 0) observaciones.Add("TASDEPFIS no puede ser negativa.");
            if (activo.DepresiacionAcumulada.HasValue && activo.DepresiacionAcumulada.Value < 0) observaciones.Add("DEPACU no puede ser negativo.");
            if (activo.DepresiacionAcumuladaFiscal.HasValue && activo.DepresiacionAcumuladaFiscal.Value < 0) observaciones.Add("DEPACUFISC no puede ser negativo.");
            return new ResultadoValidacionDepreciacion(activo.Clave, observaciones.Count == 0, observaciones);
        }

        private async Task ValidarReferenciasTipoAsync(TipoActivo tipo, IList<string> observaciones) {
            string[] cuentas = { tipo.CuentaActivo, tipo.CuentaDepresiacion, tipo.CuentaGastos, tipo.CuentaGanancias };
            string[] nombres = { "CTAAACTV", "CTADEPRE", "CTAGASTOS", "CTAPERGAN" };
            for (int i = 0; i < cuentas.Length; i++) if (!string.IsNullOrWhiteSpace(cuentas[i]) && !await _tipoActivoRepository.ExisteCuentaAsync(cuentas[i].Trim())) observaciones.Add(nombres[i] + " referencia una cuenta inexistente: " + cuentas[i].Trim() + ".");
            if (tipo.Moneda.HasValue && !await _tipoActivoRepository.ExisteMonedaAsync(tipo.Moneda.Value)) observaciones.Add("QUEMONEDA referencia una moneda inexistente: " + tipo.Moneda.Value + ".");
        }

        private static void ValidarNumericosTipo(TipoActivo tipo, IList<string> observaciones) {
            ValidarNumerico(tipo.DepresiacionNormal, "TIPACTIV.DEDNORMAL", observaciones); ValidarNumerico(tipo.DepresiacionInmediata, "TIPACTIV.DEDIMED", observaciones); ValidarNumerico(tipo.MaximoDepresiacion, "TIPACTIV.MAXDED", observaciones); ValidarNumerico(tipo.DepresiacionProyectada, "TIPACTIV.DEPPROY", observaciones);
        }

        private static void ValidarNumerico(double? valor, string nombre, IList<string> observaciones) {
            if (valor.HasValue && (double.IsNaN(valor.Value) || double.IsInfinity(valor.Value))) observaciones.Add(nombre + " contiene un valor no finito.");
        }

        private static DateTime FechaFinPeriodo(short ejercicio, short periodo) {
            if (periodo <= 12) return new DateTime(ejercicio, periodo, DateTime.DaysInMonth(ejercicio, periodo));
            return new DateTime(ejercicio, 12, 31);
        }
    }
}
