using System;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.ValueObjects;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Centraliza las validaciones de formato y consistencia de una póliza
    /// que pueden resolverse antes de iniciar una transacción de base de datos.
    /// </summary>
    public sealed class PolizaContableValidator : Contracts.IPolizaContableValidator {
        public void ValidarCabecera(PolizaContableRequest request) {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.TipoPoliza))
                throw new ArgumentException("El tipo de póliza es obligatorio.", nameof(request.TipoPoliza));

            if (request.TipoPoliza.Trim().Length > 2)
                throw new ArgumentException("El tipo de póliza no puede exceder 2 caracteres.", nameof(request.TipoPoliza));

            if (request.NumeroPoliza != null && request.NumeroPoliza.Trim().Length > 5)
                throw new ArgumentException("El número de póliza no puede exceder 5 caracteres.", nameof(request.NumeroPoliza));

            if (request.Ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.Ejercicio));

            if (request.Periodo < 1 || request.Periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(request.Periodo));

            if (request.Partidas == null)
                throw new ArgumentNullException(nameof(request.Partidas));

            if (request.Partidas.Count == 0)
                throw new ArgumentException("La póliza debe contener al menos una partida.", nameof(request.Partidas));

            if (request.Partidas.Count > 99999)
                throw new ArgumentException("La póliza excede la cantidad máxima de partidas soportada.", nameof(request.Partidas));

            if (request.Concepto != null && request.Concepto.Length > 120)
                throw new ArgumentException("El concepto no puede exceder 120 caracteres.", nameof(request.Concepto));
        }

        public void ValidarPartida(MovimientoContableRequest partida, int numeroPartida) {
            if (partida == null)
                throw new ArgumentException(string.Format("La partida {0} no puede ser nula.", numeroPartida));

            if (string.IsNullOrWhiteSpace(partida.NumeroCuenta))
                throw new ArgumentException(string.Format("La cuenta de la partida {0} es obligatoria.", numeroPartida));

            if (partida.NumeroCuenta.Trim().Length > 21)
                throw new ArgumentException(string.Format("La cuenta de la partida {0} no puede exceder 21 caracteres.", numeroPartida));

            if (string.IsNullOrWhiteSpace(partida.DebeHaber))
                throw new ArgumentException(string.Format("DEBE_HABER de la partida {0} es obligatorio.", numeroPartida));

            if (!string.Equals(partida.DebeHaber.Trim(), "D", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(partida.DebeHaber.Trim(), "H", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format("DEBE_HABER de la partida {0} debe ser 'D' o 'H'.", numeroPartida));

            if (!ImporteContable.EsValido(partida.Importe))
                throw new ArgumentException(string.Format("El importe de la partida {0} debe ser un valor finito mayor que cero.", numeroPartida));

            if (partida.TipoCambio.HasValue &&
                (double.IsNaN(partida.TipoCambio.Value) || double.IsInfinity(partida.TipoCambio.Value) || partida.TipoCambio.Value <= 0))
                throw new ArgumentException(string.Format("El tipo de cambio de la partida {0} debe ser finito y mayor que cero.", numeroPartida));

            if (partida.NumeroDepartamento.HasValue && partida.NumeroDepartamento.Value < 0)
                throw new ArgumentException(string.Format("El departamento de la partida {0} no puede ser negativo.", numeroPartida));

            if (partida.CentroCostos.HasValue && partida.CentroCostos.Value <= 0)
                throw new ArgumentException(string.Format("El centro de costos de la partida {0} debe ser mayor que cero.", numeroPartida));

            if (partida.Grupo.HasValue && partida.Grupo.Value <= 0)
                throw new ArgumentException(string.Format("El grupo de la partida {0} debe ser mayor que cero.", numeroPartida));

            if (partida.Concepto != null && partida.Concepto.Length > 120)
                throw new ArgumentException(string.Format("El concepto de la partida {0} no puede exceder 120 caracteres.", numeroPartida));
        }

        public void ValidarBalance(double totalDebe, double totalHaber) {
            if (double.IsNaN(totalDebe) || double.IsInfinity(totalDebe) ||
                double.IsNaN(totalHaber) || double.IsInfinity(totalHaber))
                throw new InvalidOperationException("Los totales de la póliza no son numéricamente válidos.");

            if (!ImporteContable.SonIguales(totalDebe, totalHaber))
                throw new InvalidOperationException(string.Format(
                    "La póliza no está balanceada. Debe={0}, Haber={1}.",
                    totalDebe,
                    totalHaber));
        }
    }
}
