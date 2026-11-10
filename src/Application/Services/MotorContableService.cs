using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Aplica la estructura configurada en PARAMEMP y calcula números de cuenta.
    /// </summary>
    public sealed class MotorContableService : IMotorContableService {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IConfiguracionCuentaService _configuracionService;
        private ConfiguracionNiveles _configuracion;

        public MotorContableService(
            ICuentaRepository cuentaRepository,
            IConfiguracionCuentaService configuracionService) {

            _cuentaRepository = cuentaRepository ?? throw new ArgumentNullException(nameof(cuentaRepository));
            _configuracionService = configuracionService ?? throw new ArgumentNullException(nameof(configuracionService));
        }

        public async Task InicializarAsync(int idEmpresa) {
            _configuracion = await _configuracionService.ObtenerAsync(idEmpresa);
        }

        public string ObtenerMascara() {
            ValidarConfiguracionCargada();
            return _configuracion.GenerarMascara();
        }

        public string AplicarMascara(string entradaSinFormato) {
            ValidarConfiguracionCargada();

            if (string.IsNullOrWhiteSpace(entradaSinFormato))
                return string.Empty;

            var digitos = new string(entradaSinFormato.Where(char.IsDigit).ToArray());
            if (digitos.Length > _configuracion.TotalDigitosLogicos)
                digitos = digitos.Substring(0, _configuracion.TotalDigitosLogicos);

            var segmentos = new List<string>();
            var indice = 0;

            foreach (var longitud in _configuracion.DigitosPorNivel.Take(_configuracion.NivelActual)) {
                if (longitud <= 0)
                    continue;

                var cantidad = Math.Min(longitud, Math.Max(0, digitos.Length - indice));
                var segmento = cantidad > 0
                    ? digitos.Substring(indice, cantidad)
                    : string.Empty;

                segmentos.Add(segmento.PadRight(longitud, '0'));
                indice += cantidad;
            }

            return _configuracion.UsarGuiones
                ? string.Join("-", segmentos)
                : string.Concat(segmentos);
        }

        /// <summary>Calcula un número disponible para mostrar una previsualización.
        /// La reserva definitiva se realiza al registrar la cuenta.</summary>
        public async Task<string> GenerarSiguienteCuentaDinamicaAsync(string ctaPapa, short nivel) {
            ValidarConfiguracionCargada();

            var estructura = EstructuraCuenta.Crear(_configuracion);
            CuentaContable padre = null;

            if (nivel > 1) {
                if (string.IsNullOrWhiteSpace(ctaPapa))
                    throw new InvalidOperationException("La cuenta padre es obligatoria.");

                padre = await _cuentaRepository.ObtenerPorNumeroAsync(ctaPapa.Trim());
                if (padre == null)
                    throw new InvalidOperationException("La cuenta padre no existe.");
            }

            var existentes = nivel == 1
                ? await _cuentaRepository.ObtenerRaicesAsync()
                : await _cuentaRepository.ObtenerPorPadreAsync(padre.NumCta);

            var generador = new GeneradorNumeroCuenta(estructura);
            return generador.Generar(existentes, padre, nivel);
        }

        //public Task<string> GenerarSiguienteCuentaDinamicaAsync(CuentaContable cuenta) {
        //    if (cuenta == null)
        //        throw new ArgumentNullException(nameof(cuenta));

        //    return GenerarSiguienteCuentaDinamicaAsync(cuenta.CtaPapa, cuenta.Nivel);
        //}

        private void ValidarConfiguracionCargada() {
            if (_configuracion == null)
                throw new InvalidOperationException(
                    "La configuración de cuentas aún no ha sido cargada desde PARAMEMP.");
        }

        public string AplicarMascaraSinInicializar(string entradaSinFormato) {
            return AplicarMascara(entradaSinFormato);
        }
    }
}
