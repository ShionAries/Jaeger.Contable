using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Construye la balanza de comprobación a partir de SALDOSxx y CUENTAS25.</summary>
    public sealed class BalanzaComprobacionService : IBalanzaComprobacionService {
        private readonly IBalanzaComprobacionRepository _balanzaRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public BalanzaComprobacionService(
            IBalanzaComprobacionRepository balanzaRepository,
            ICuentaRepository cuentaRepository) {
            _balanzaRepository = balanzaRepository ?? throw new ArgumentNullException(nameof(balanzaRepository));
            _cuentaRepository = cuentaRepository ?? throw new ArgumentNullException(nameof(cuentaRepository));
        }

        public async Task<BalanzaComprobacion> GenerarAsync(BalanzaComprobacionRequest request) {
            Validar(request);
            var saldosTask = _balanzaRepository.ObtenerSaldosAsync(request.Ejercicio);
            var cuentasTask = _cuentaRepository.ObtenerTodasAsync();
            await Task.WhenAll(saldosTask, cuentasTask);

            var saldos = (await saldosTask).Where(x => !string.IsNullOrWhiteSpace(x.NumeroCuenta))
                .ToDictionary(x => Normalizar(x.NumeroCuenta), StringComparer.Ordinal);
            var cuentas = (await cuentasTask).Where(x => x != null && !string.IsNullOrWhiteSpace(x.NumCta))
                .OrderBy(x => Normalizar(x.NumCta), StringComparer.Ordinal).ToList();

            var resultado = new BalanzaComprobacion {
                Ejercicio = request.Ejercicio,
                PeriodoInicial = request.PeriodoInicial,
                PeriodoFinal = request.PeriodoFinal,
                Cuentas = new List<BalanzaComprobacionItem>()
            };

            foreach (var cuenta in cuentas) {
                SaldoCuentaEjercicio saldo;
                saldos.TryGetValue(Normalizar(cuenta.NumCta), out saldo);
                var item = CalcularItem(cuenta, saldo, request.PeriodoInicial, request.PeriodoFinal);
                if (!request.IncluirCuentasSinMovimientos && !item.TieneMovimientos &&
                    item.SaldoInicialDeudor == 0m && item.SaldoInicialAcreedor == 0m &&
                    item.SaldoFinalDeudor == 0m && item.SaldoFinalAcreedor == 0m)
                    continue;
                resultado.Cuentas.Add(item);
            }

            if (request.NivelPresentacion > 0)
                AplicarNivelPresentacion(resultado, cuentas, request.NivelPresentacion);

            CalcularTotales(resultado);
            return resultado;
        }

        private static void AplicarNivelPresentacion(
            BalanzaComprobacion resultado, IList<CuentaContable> cuentas, short nivelPresentacion) {
            var indice = cuentas
                .GroupBy(x => Normalizar(x.NumCta), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => x.First(), StringComparer.Ordinal);
            var acumulados = new Dictionary<string, BalanzaComprobacionItem>(StringComparer.Ordinal);

            foreach (var item in resultado.Cuentas) {
                CuentaContable cuenta;
                if (!indice.TryGetValue(Normalizar(item.NumeroCuenta), out cuenta))
                    continue;

                var destino = ObtenerCuentaDestino(cuenta, indice, nivelPresentacion);
                var clave = Normalizar(destino.NumCta);
                BalanzaComprobacionItem acumulado;
                if (!acumulados.TryGetValue(clave, out acumulado)) {
                    acumulado = new BalanzaComprobacionItem {
                        NumeroCuenta = destino.NumCta,
                        NombreCuenta = destino.Nombre,
                        TipoCuenta = destino.Tipo,
                        Nivel = destino.Nivel
                    };
                    acumulados.Add(clave, acumulado);
                }

                acumulado.SaldoInicialDeudor += item.SaldoInicialDeudor;
                acumulado.SaldoInicialAcreedor += item.SaldoInicialAcreedor;
                acumulado.Cargos += item.Cargos;
                acumulado.Abonos += item.Abonos;
                acumulado.SaldoFinalDeudor += item.SaldoFinalDeudor;
                acumulado.SaldoFinalAcreedor += item.SaldoFinalAcreedor;
                acumulado.TieneMovimientos = acumulado.TieneMovimientos || item.TieneMovimientos;
            }

            resultado.Cuentas = acumulados.Values
                .OrderBy(x => Normalizar(x.NumeroCuenta), StringComparer.Ordinal)
                .ToList();

            foreach (var item in resultado.Cuentas) {
                item.SaldoInicialDeudor = Redondear(item.SaldoInicialDeudor);
                item.SaldoInicialAcreedor = Redondear(item.SaldoInicialAcreedor);
                item.Cargos = Redondear(item.Cargos);
                item.Abonos = Redondear(item.Abonos);
                item.SaldoFinalDeudor = Redondear(item.SaldoFinalDeudor);
                item.SaldoFinalAcreedor = Redondear(item.SaldoFinalAcreedor);
            }
        }

        private static CuentaContable ObtenerCuentaDestino(
            CuentaContable cuenta, IDictionary<string, CuentaContable> indice, short nivelPresentacion) {
            var actual = cuenta;
            var visitadas = new HashSet<string>(StringComparer.Ordinal);

            while (actual.Nivel > nivelPresentacion) {
                var numeroActual = Normalizar(actual.NumCta);
                if (!visitadas.Add(numeroActual))
                    break;

                var numeroPadre = Normalizar(actual.CtaPapa);
                CuentaContable padre;
                if (string.IsNullOrEmpty(numeroPadre) || numeroPadre == "-1" ||
                    !indice.TryGetValue(numeroPadre, out padre) || padre.Nivel >= actual.Nivel)
                    break;

                actual = padre;
            }

            return actual;
        }

        private static BalanzaComprobacionItem CalcularItem(
            CuentaContable cuenta, SaldoCuentaEjercicio saldo, short desde, short hasta) {
            decimal saldoInicial = saldo == null ? 0m : saldo.SaldoInicial;
            decimal cargos = 0m;
            decimal abonos = 0m;

            if (saldo != null) {
                for (int periodo = 1; periodo < desde; periodo++)
                    saldoInicial += saldo.Cargos[periodo - 1] - saldo.Abonos[periodo - 1];
                for (int periodo = desde; periodo <= hasta; periodo++) {
                    cargos += saldo.Cargos[periodo - 1];
                    abonos += saldo.Abonos[periodo - 1];
                }
            }

            saldoInicial = Redondear(saldoInicial);
            cargos = Redondear(cargos);
            abonos = Redondear(abonos);
            decimal saldoFinal = Redondear(saldoInicial + cargos - abonos);

            return new BalanzaComprobacionItem {
                NumeroCuenta = cuenta.NumCta,
                NombreCuenta = cuenta.Nombre,
                TipoCuenta = cuenta.Tipo,
                Nivel = cuenta.Nivel,
                SaldoInicialDeudor = saldoInicial > 0m ? saldoInicial : 0m,
                SaldoInicialAcreedor = saldoInicial < 0m ? Math.Abs(saldoInicial) : 0m,
                Cargos = cargos,
                Abonos = abonos,
                SaldoFinalDeudor = saldoFinal > 0m ? saldoFinal : 0m,
                SaldoFinalAcreedor = saldoFinal < 0m ? Math.Abs(saldoFinal) : 0m,
                TieneMovimientos = cargos != 0m || abonos != 0m
            };
        }

        private static void CalcularTotales(BalanzaComprobacion resultado) {
            foreach (var item in resultado.Cuentas) {
                resultado.TotalSaldoInicialDeudor += item.SaldoInicialDeudor;
                resultado.TotalSaldoInicialAcreedor += item.SaldoInicialAcreedor;
                resultado.TotalCargos += item.Cargos;
                resultado.TotalAbonos += item.Abonos;
                resultado.TotalSaldoFinalDeudor += item.SaldoFinalDeudor;
                resultado.TotalSaldoFinalAcreedor += item.SaldoFinalAcreedor;
            }
            resultado.TotalSaldoInicialDeudor = Redondear(resultado.TotalSaldoInicialDeudor);
            resultado.TotalSaldoInicialAcreedor = Redondear(resultado.TotalSaldoInicialAcreedor);
            resultado.TotalCargos = Redondear(resultado.TotalCargos);
            resultado.TotalAbonos = Redondear(resultado.TotalAbonos);
            resultado.TotalSaldoFinalDeudor = Redondear(resultado.TotalSaldoFinalDeudor);
            resultado.TotalSaldoFinalAcreedor = Redondear(resultado.TotalSaldoFinalAcreedor);
        }

        private static void Validar(BalanzaComprobacionRequest request) {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Ejercicio < 1900 || request.Ejercicio > 9999)
                throw new ArgumentOutOfRangeException(nameof(request.Ejercicio));
            if (request.PeriodoInicial < 1 || request.PeriodoInicial > 14)
                throw new ArgumentOutOfRangeException(nameof(request.PeriodoInicial));
            if (request.PeriodoFinal < request.PeriodoInicial || request.PeriodoFinal > 14)
                throw new ArgumentOutOfRangeException(nameof(request.PeriodoFinal));
            if (request.NivelPresentacion < 0 || request.NivelPresentacion > 9)
                throw new ArgumentOutOfRangeException(nameof(request.NivelPresentacion));
        }

        private static string Normalizar(string numero) {
            return numero == null ? string.Empty : numero.Trim();
        }

        private static decimal Redondear(decimal valor) {
            return decimal.Round(valor, 2, MidpointRounding.AwayFromZero);
        }
    }
}
