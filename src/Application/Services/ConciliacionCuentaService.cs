using System;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Concilia movimientos de AUXILIAR25 contra los importes mensuales de SALDOS25.
    /// </summary>
    public sealed class ConciliacionCuentaService : Contracts.IConciliacionCuentaService {
        private readonly IConciliacionCuentaRepository _repository;
        public ConciliacionCuentaService(IConciliacionCuentaRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ConciliacionCuenta> ConciliarAsync(string numeroCuenta, short ejercicio, short periodo) {
            if (string.IsNullOrWhiteSpace(numeroCuenta)) throw new ArgumentException("La cuenta es obligatoria.", nameof(numeroCuenta));
            if (ejercicio <= 0) throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14) throw new ArgumentOutOfRangeException(nameof(periodo));

            var movimientos = await _repository.ObtenerMovimientosAsync(numeroCuenta.Trim(), ejercicio, periodo);
            var saldo = await _repository.ObtenerSaldoAsync(numeroCuenta.Trim(), ejercicio, periodo);
            var departamental = await _repository.TieneSaldosDepartamentalesAsync(numeroCuenta.Trim(), ejercicio, periodo);

            return new ConciliacionCuenta {
                NumeroCuenta = numeroCuenta.Trim(),
                Ejercicio = ejercicio,
                Periodo = periodo,
                CargoMovimientos = movimientos.Where(x => EsCargo(x.DebeHaber)).Sum(x => x.Importe),
                AbonoMovimientos = movimientos.Where(x => !EsCargo(x.DebeHaber)).Sum(x => x.Importe),
                CargoSaldo = saldo.Cargo,
                AbonoSaldo = saldo.Abono,
                TieneSaldoDepartamental = departamental
            };
        }

        private static bool EsCargo(string debeHaber) {
            return string.Equals(debeHaber, "D", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(debeHaber, "1", StringComparison.OrdinalIgnoreCase);
        }
    }
}
