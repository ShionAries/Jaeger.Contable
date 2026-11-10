using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.ValueObjects;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Calcula acumulados jerárquicos sin modificar SALDOS25 ni SALDOSDP25.
    /// </summary>
    public sealed class AcumulacionCuentaService : Contracts.IAcumulacionCuentaService {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IAcumulacionCuentaRepository _movimientoRepository;

        public AcumulacionCuentaService(
            ICuentaRepository cuentaRepository,
            IAcumulacionCuentaRepository movimientoRepository) {
            _cuentaRepository = cuentaRepository ?? throw new ArgumentNullException(nameof(cuentaRepository));
            _movimientoRepository = movimientoRepository ?? throw new ArgumentNullException(nameof(movimientoRepository));
        }

        public async Task<AcumuladoCuenta> CalcularAsync(
            string numeroCuenta, short ejercicio, short? periodo) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException("La cuenta es obligatoria.", nameof(numeroCuenta));
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo.HasValue && (periodo.Value < 1 || periodo.Value > 14))
                throw new ArgumentOutOfRangeException(nameof(periodo));

            var numero = numeroCuenta.Trim();
            var cuenta = await _cuentaRepository.ObtenerPorNumeroAsync(numero);
            if (cuenta == null)
                throw new InvalidOperationException("La cuenta no existe.");

            var cuentas = await _cuentaRepository.ObtenerTodasAsync();
            var consideradas = ObtenerSubarbol(cuenta, cuentas);
            var numeros = consideradas
                .Select(x => x.NumCta)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.Ordinal)
                .ToList();

            var movimientos = await _movimientoRepository.ObtenerMovimientosAsync(numeros, ejercicio, periodo);
            double cargo = 0;
            double abono = 0;

            foreach (var movimiento in movimientos) {
                var importe = ImporteContable.Redondear(Math.Abs(movimiento.Importe));
                if (string.Equals(movimiento.DebeHaber, "D", StringComparison.OrdinalIgnoreCase))
                    cargo += importe;
                else if (string.Equals(movimiento.DebeHaber, "H", StringComparison.OrdinalIgnoreCase))
                    abono += importe;
                else
                    throw new InvalidOperationException(
                        string.Format("El movimiento de {0} contiene un DEBE_HABER no válido: '{1}'.",
                            movimiento.NumeroCuenta, movimiento.DebeHaber));
            }

            return new AcumuladoCuenta {
                NumeroCuenta = numero,
                Ejercicio = ejercicio,
                Periodo = periodo,
                Cargo = cargo,
                Abono = abono,
                CuentasConsideradas = numeros.Count,
                MovimientosConsiderados = movimientos.Count
            };
        }

        private static List<CuentaContable> ObtenerSubarbol(CuentaContable raiz, List<CuentaContable> todas) {
            var resultado = new List<CuentaContable> { raiz };
            var pendientes = new Queue<string>();
            pendientes.Enqueue(raiz.NumCta.Trim());
            var visitadas = new HashSet<string>(StringComparer.Ordinal) { raiz.NumCta.Trim() };

            while (pendientes.Count > 0) {
                var padre = pendientes.Dequeue();
                foreach (var hijo in todas.Where(x => x != null &&
                    !string.IsNullOrWhiteSpace(x.CtaPapa) &&
                    string.Equals(x.CtaPapa.Trim(), padre, StringComparison.Ordinal))) {

                    var numero = hijo.NumCta == null ? string.Empty : hijo.NumCta.Trim();
                    if (string.IsNullOrEmpty(numero) || !visitadas.Add(numero))
                        continue;

                    resultado.Add(hijo);
                    pendientes.Enqueue(numero);
                }
            }

            return resultado;
        }
    }
}
