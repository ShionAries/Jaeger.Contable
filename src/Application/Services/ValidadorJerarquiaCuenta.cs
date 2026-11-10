using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Valida la consistencia entre NUM_CTA, NIVEL, CTA_PAPA y CTA_RAIZ.
    /// </summary>
    public sealed class ValidadorJerarquiaCuenta : IValidadorJerarquiaCuenta {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IConfiguracionCuentaService _configuracionService;
        private readonly int _idEmpresa;

        public ValidadorJerarquiaCuenta(
            ICuentaRepository cuentaRepository,
            IConfiguracionCuentaService configuracionService,
            int idEmpresa) {
            _cuentaRepository = cuentaRepository ?? throw new ArgumentNullException(nameof(cuentaRepository));
            _configuracionService = configuracionService ?? throw new ArgumentNullException(nameof(configuracionService));
            _idEmpresa = idEmpresa;
        }

        public async Task<ResultadoValidacionCuenta> ValidarAsync(CuentaContable cuenta) {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));

            var cuentas = new List<CuentaContable> { cuenta };
            if (cuenta.Nivel > 1 && !string.IsNullOrWhiteSpace(cuenta.CtaPapa)) {
                var padre = await _cuentaRepository.ObtenerPorNumeroAsync(cuenta.CtaPapa);
                if (padre != null)
                    cuentas.Add(padre);
            }

            var resultados = await ValidarInternamenteAsync(cuentas);
            var auditoria = resultados.Cuentas.First(x => string.Equals(
                NormalizarNumero(x.NumeroCuenta),
                NormalizarNumero(cuenta.NumCta),
                StringComparison.Ordinal));

            var resultado = new ResultadoValidacionCuenta();
            foreach (var error in auditoria.Errores)
                resultado.AgregarError(error);

            return resultado;
        }

        public async Task<ResultadoAuditoriaCuentas> ValidarTodasAsync(IReadOnlyList<CuentaContable> cuentas) {
            if (cuentas == null)
                throw new ArgumentNullException(nameof(cuentas));

            return await ValidarInternamenteAsync(cuentas);
        }

        private async Task<ResultadoAuditoriaCuentas> ValidarInternamenteAsync(IReadOnlyList<CuentaContable> cuentas) {
            var resultado = new ResultadoAuditoriaCuentas();
            var configuracion = await _configuracionService.ObtenerAsync(_idEmpresa);
            if (configuracion == null) {
                foreach (var cuenta in cuentas ?? new List<CuentaContable>()) {
                    var item = new ResultadoAuditoriaCuenta(cuenta == null ? string.Empty : cuenta.NumCta);
                    item.AgregarError("No existe configuración de PARAMEMP para la empresa configurada.");
                    resultado.Agregar(item);
                }
                return resultado;
            }

            EstructuraCuenta estructura;
            try {
                estructura = EstructuraCuenta.Crear(configuracion);
            } catch (Exception ex) {
                foreach (var cuenta in cuentas ?? new List<CuentaContable>()) {
                    var item = new ResultadoAuditoriaCuenta(cuenta == null ? string.Empty : cuenta.NumCta);
                    item.AgregarError("No fue posible crear la estructura de cuenta: " + ex.Message);
                    resultado.Agregar(item);
                }
                return resultado;
            }

            var indice = new Dictionary<string, CuentaContable>(StringComparer.Ordinal);
            var duplicados = new HashSet<string>(StringComparer.Ordinal);
            foreach (var cuenta in cuentas) {
                if (cuenta == null)
                    continue;

                var numero = NormalizarNumero(cuenta.NumCta);
                if (numero.Length == 0)
                    continue;

                if (indice.ContainsKey(numero))
                    duplicados.Add(numero);
                else
                    indice.Add(numero, cuenta);
            }

            foreach (var cuenta in cuentas) {
                if (cuenta == null)
                    continue;

                var item = new ResultadoAuditoriaCuenta(cuenta.NumCta);
                ValidarCuenta(cuenta, estructura, indice, duplicados, item);
                resultado.Agregar(item);
            }

            return resultado;
        }

        private static void ValidarCuenta(
            CuentaContable cuenta,
            EstructuraCuenta estructura,
            IDictionary<string, CuentaContable> indice,
            ISet<string> duplicados,
            ResultadoAuditoriaCuenta resultado) {

            var numero = NormalizarNumero(cuenta.NumCta);
            if (numero.Length == 0) {
                resultado.AgregarError("NUM_CTA es obligatorio.");
                return;
            }

            if (duplicados.Contains(numero))
                resultado.AgregarError("NUM_CTA está duplicado en el conjunto auditado.");

            try {
                estructura.NormalizarFisica(numero);
                var nivelFisico = estructura.ObtenerNivelFisico(numero);
                if (cuenta.Nivel != nivelFisico)
                    resultado.AgregarError("NIVEL no coincide con el indicador físico de NUM_CTA.");

                var logica = estructura.ObtenerCuentaLogicaDesdeFisica(numero);
                ValidarJerarquia(cuenta, estructura, indice, logica, resultado);
            } catch (Exception ex) {
                resultado.AgregarError(ex.Message);
            }
        }

        private static void ValidarJerarquia(
            CuentaContable cuenta,
            EstructuraCuenta estructura,
            IDictionary<string, CuentaContable> indice,
            string logica,
            ResultadoAuditoriaCuenta resultado) {

            if (cuenta.Nivel == 1) {
                if (!string.Equals((cuenta.CtaPapa ?? string.Empty).Trim(), "-1", StringComparison.Ordinal))
                    resultado.AgregarError("Una cuenta raíz debe tener CTA_PAPA = -1.");

                if (!string.Equals((cuenta.CtaRaiz ?? string.Empty).Trim(), cuenta.NumCta.Trim(), StringComparison.Ordinal))
                    resultado.AgregarError("Una cuenta raíz debe tener CTA_RAIZ igual a NUM_CTA.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cuenta.CtaPapa)) {
                resultado.AgregarError("Una cuenta distinta del nivel 1 requiere CTA_PAPA.");
                return;
            }

            CuentaContable padre;
            if (!indice.TryGetValue(NormalizarNumero(cuenta.CtaPapa), out padre)) {
                resultado.AgregarError("CTA_PAPA no existe en CUENTAS25.");
                return;
            }

            if (padre.Nivel + 1 != cuenta.Nivel)
                resultado.AgregarError("NIVEL no corresponde al nivel de CTA_PAPA.");

            if (!string.Equals(padre.Tipo, "A", StringComparison.OrdinalIgnoreCase))
                resultado.AgregarError("CTA_PAPA debe ser una cuenta acumulativa (TIPO = A).");

            if (!string.Equals((cuenta.CtaRaiz ?? string.Empty).Trim(), (padre.CtaRaiz ?? string.Empty).Trim(), StringComparison.Ordinal))
                resultado.AgregarError("CTA_RAIZ no coincide con la raíz de CTA_PAPA.");

            try {
                var padreNumero = NormalizarNumero(padre.NumCta);
                estructura.NormalizarFisica(padreNumero);
                var padreLogico = estructura.ObtenerCuentaLogicaDesdeFisica(padreNumero);
                var longitudPadre = estructura.ObtenerLongitudLogica(padre.Nivel);
                var longitudEsperada = estructura.ObtenerLongitudLogica(cuenta.Nivel - 1);

                if (longitudPadre != longitudEsperada)
                    resultado.AgregarError("La longitud lógica de CTA_PAPA no coincide con PARAMEMP.");

                if (logica.Length < padreLogico.Length ||
                    !logica.StartsWith(padreLogico, StringComparison.Ordinal))
                    resultado.AgregarError("NUM_CTA no pertenece al segmento lógico de CTA_PAPA.");
            } catch (Exception ex) {
                resultado.AgregarError("No fue posible validar la relación lógica con CTA_PAPA: " + ex.Message);
            }
        }

        private static string NormalizarNumero(string value) {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return new string(value.Trim().Where(char.IsDigit).ToArray());
        }
    }
}
