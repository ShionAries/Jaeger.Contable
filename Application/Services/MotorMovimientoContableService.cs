using System;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Centraliza las reglas de negocio que deben cumplirse antes de registrar
    /// un movimiento en AUXILIAR25.
    /// </summary>
    public sealed class MotorMovimientoContableService : IMotorMovimientoContableService {
        private readonly ICuentaService _cuentaService;
        private readonly IPeriodoContableService _periodoService;

        public MotorMovimientoContableService(ICuentaService cuentaService, IPeriodoContableService periodoService) {
            _cuentaService = cuentaService ?? throw new ArgumentNullException(nameof(cuentaService));
            _periodoService = periodoService ?? throw new ArgumentNullException(nameof(periodoService));
        }

        public async Task<ResultadoValidacionMovimiento> ValidarAsync(MovimientoCuenta movimiento) {
            var resultado = new ResultadoValidacionMovimiento();

            if (movimiento == null) {
                resultado.AgregarError("El movimiento es obligatorio.");
                return resultado;
            }

            if (string.IsNullOrWhiteSpace(movimiento.NumeroCuenta)) {
                resultado.AgregarError("El número de cuenta es obligatorio.");
                return resultado;
            }

            if (movimiento.Ejercicio <= 0)
                resultado.AgregarError("El ejercicio debe ser mayor que cero.");

            if (movimiento.Periodo < 1 || movimiento.Periodo > 14)
                resultado.AgregarError("El periodo debe estar entre 1 y 14.");

            if (!EsDebeHaberValido(movimiento.DebeHaber))
                resultado.AgregarError("DEBE_HABER debe ser 'D' o 'H'.");

            if (double.IsNaN(movimiento.Importe) || double.IsInfinity(movimiento.Importe))
                resultado.AgregarError("El importe no es numéricamente válido.");
            else if (movimiento.Importe <= 0)
                resultado.AgregarError("El importe debe ser mayor que cero.");

            if (!resultado.EsValido)
                return resultado;

            try {
                await _periodoService.ValidarRegistroAsync(movimiento.Ejercicio, movimiento.Periodo);
            }
            catch (Exception ex) {
                resultado.AgregarError(ex.Message);
                return resultado;
            }

            var cuenta = await _cuentaService.ValidarCuentaParaMovimientoAsync(
                movimiento.NumeroCuenta);

            foreach (var error in cuenta.Errores)
                resultado.AgregarError(error);

            return resultado;
        }

        public async Task<MovimientoCuenta> PrepararAsync(MovimientoCuenta movimiento) {
            if (movimiento == null)
                throw new ArgumentNullException(nameof(movimiento));

            var resultado = await ValidarAsync(movimiento);
            if (!resultado.EsValido)
                throw new InvalidOperationException(
                    "El movimiento no puede registrarse: " + string.Join(" ", resultado.Errores));

            return new MovimientoCuenta {
                NumeroCuenta = movimiento.NumeroCuenta.Trim(),
                Ejercicio = movimiento.Ejercicio,
                Periodo = movimiento.Periodo,
                DebeHaber = NormalizarDebeHaber(movimiento.DebeHaber),
                Importe = movimiento.Importe
            };
        }

        private static bool EsDebeHaberValido(string valor) {
            return string.Equals(valor, "D", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(valor, "H", StringComparison.OrdinalIgnoreCase);
        }

        private static string NormalizarDebeHaber(string valor) {
            return string.Equals(valor, "D", StringComparison.OrdinalIgnoreCase)
                ? "D"
                : "H";
        }
    }
}
