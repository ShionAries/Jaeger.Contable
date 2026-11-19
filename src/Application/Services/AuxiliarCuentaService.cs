using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Genera auxiliares anuales con saldo inicial y saldo acumulado por movimiento.</summary>
    public sealed class AuxiliarCuentaService : IAuxiliarCuentaService {
        private readonly IAuxiliarCuentaRepository _auxiliarRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public AuxiliarCuentaService(IAuxiliarCuentaRepository auxiliarRepository, ICuentaRepository cuentaRepository) {
            _auxiliarRepository = auxiliarRepository ?? throw new ArgumentNullException(nameof(auxiliarRepository));
            _cuentaRepository = cuentaRepository ?? throw new ArgumentNullException(nameof(cuentaRepository));
        }

        public async Task<AuxiliarCuentaResultado> ConsultarAsync(AuxiliarCuentaRequest request) {
            Validar(request);

            var movimientosTask = _auxiliarRepository.ObtenerMovimientosAsync(
                request.Ejercicio, request.CuentaInicial.Trim(), request.CuentaFinal.Trim());
            var saldosTask = _auxiliarRepository.ObtenerSaldosInicialesAsync(
                request.Ejercicio, request.CuentaInicial.Trim(), request.CuentaFinal.Trim());
            var cuentasTask = _cuentaRepository.ObtenerTodasAsync();
            await Task.WhenAll(movimientosTask, saldosTask, cuentasTask);

            var nombres = (await cuentasTask)
                .Where(x => x != null && !string.IsNullOrWhiteSpace(x.NumCta))
                .GroupBy(x => Normalizar(x.NumCta), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => (x.First().Nombre ?? string.Empty).Trim(), StringComparer.Ordinal);
            var saldos = (await saldosTask)
                .Where(x => x != null && !string.IsNullOrWhiteSpace(x.NumeroCuenta))
                .GroupBy(x => Normalizar(x.NumeroCuenta), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => Redondear(x.First().SaldoInicial), StringComparer.Ordinal);
            var movimientos = (await movimientosTask)
                .Where(x => x != null && !string.IsNullOrWhiteSpace(x.NumeroCuenta))
                .OrderBy(x => Normalizar(x.NumeroCuenta), StringComparer.Ordinal)
                .ThenBy(x => x.Periodo)
                .ThenBy(x => x.Fecha)
                .ThenBy(x => x.TipoPoliza, StringComparer.Ordinal)
                .ThenBy(x => x.NumeroPoliza, StringComparer.Ordinal)
                .ThenBy(x => x.NumeroPartida)
                .ToList();
            var movimientosPorCuenta = movimientos
                .GroupBy(x => Normalizar(x.NumeroCuenta), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => x.ToList(), StringComparer.Ordinal);
            var clavesCuentas = new HashSet<string>(saldos.Keys, StringComparer.Ordinal);
            foreach (var clave in movimientosPorCuenta.Keys)
                clavesCuentas.Add(clave);

            var resultado = new AuxiliarCuentaResultado {
                Ejercicio = request.Ejercicio,
                CuentaInicial = request.CuentaInicial.Trim(),
                CuentaFinal = request.CuentaFinal.Trim(),
                Cuentas = new List<AuxiliarCuenta>()
            };

            foreach (var clave in clavesCuentas.OrderBy(x => x, StringComparer.Ordinal)) {
                decimal saldoInicial;
                if (!saldos.TryGetValue(clave, out saldoInicial))
                    saldoInicial = 0m;

                List<AuxiliarMovimiento> listaMovimientos;
                if (!movimientosPorCuenta.TryGetValue(clave, out listaMovimientos))
                    listaMovimientos = new List<AuxiliarMovimiento>();
                if (listaMovimientos.Count == 0 && saldoInicial == 0m)
                    continue;

                string nombre;
                nombres.TryGetValue(clave, out nombre);
                string numeroCuenta = listaMovimientos.Count > 0
                    ? listaMovimientos[0].NumeroCuenta.Trim()
                    : clave;

                var auxiliar = new AuxiliarCuenta {
                    NumeroCuenta = numeroCuenta,
                    NombreCuenta = nombre ?? string.Empty,
                    SaldoInicial = saldoInicial,
                    Movimientos = new List<AuxiliarMovimiento>()
                };

                decimal saldoAcumulado = saldoInicial;
                foreach (var movimiento in listaMovimientos) {
                    string debeHaber = (movimiento.DebeHaber ?? string.Empty).Trim().ToUpperInvariant();
                    decimal importe = Redondear(movimiento.Importe);
                    if (debeHaber == "D") {
                        auxiliar.Cargos += importe;
                        saldoAcumulado += importe;
                    } else if (debeHaber == "H") {
                        auxiliar.Abonos += importe;
                        saldoAcumulado -= importe;
                    } else {
                        throw new InvalidOperationException(string.Format(
                            "El movimiento de la cuenta {0}, póliza {1} contiene un DEBE_HABER inválido.",
                            numeroCuenta, movimiento.NumeroPoliza));
                    }

                    movimiento.DebeHaber = debeHaber;
                    movimiento.Importe = importe;
                    movimiento.SaldoAcumulado = Redondear(saldoAcumulado);
                    auxiliar.Movimientos.Add(movimiento);
                }

                auxiliar.Cargos = Redondear(auxiliar.Cargos);
                auxiliar.Abonos = Redondear(auxiliar.Abonos);
                auxiliar.SaldoFinal = Redondear(saldoAcumulado);
                resultado.TotalCargos += auxiliar.Cargos;
                resultado.TotalAbonos += auxiliar.Abonos;
                resultado.Cuentas.Add(auxiliar);
            }

            resultado.TotalCargos = Redondear(resultado.TotalCargos);
            resultado.TotalAbonos = Redondear(resultado.TotalAbonos);
            return resultado;
        }

        private static void Validar(AuxiliarCuentaRequest request) {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Ejercicio < 1900 || request.Ejercicio > 9999)
                throw new ArgumentOutOfRangeException(nameof(request.Ejercicio));
            if (string.IsNullOrWhiteSpace(request.CuentaInicial))
                throw new ArgumentException("La cuenta inicial es obligatoria.", nameof(request.CuentaInicial));
            if (string.IsNullOrWhiteSpace(request.CuentaFinal))
                throw new ArgumentException("La cuenta final es obligatoria.", nameof(request.CuentaFinal));
            if (string.Compare(request.CuentaInicial.Trim(), request.CuentaFinal.Trim(), StringComparison.Ordinal) > 0)
                throw new ArgumentException("La cuenta inicial no puede ser mayor que la cuenta final.");
        }

        private static string Normalizar(string value) { return (value ?? string.Empty).Trim(); }
        private static decimal Redondear(decimal value) { return decimal.Round(value, 2, MidpointRounding.AwayFromZero); }
    }
}
