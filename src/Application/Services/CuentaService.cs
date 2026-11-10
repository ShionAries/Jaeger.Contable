using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Orquesta las operaciones de negocio del catálogo de cuentas.
    /// </summary>
    public sealed class CuentaService : ICuentaService {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IParametroEmpresaRepository _parametroRepository;
        private readonly IMotorContableService _motor;
        private readonly IHistorialCuentaRepository _historialCuentaRepository;
        private readonly IEstadoContableCuentaRepository _estadoContableCuentaRepository;
        
        private readonly int _idEmpresa;

        public CuentaService(
            ICuentaRepository cuentaRepository,
            IParametroEmpresaRepository parametroRepository,
            IMotorContableService motorContableService,
            IHistorialCuentaRepository historialCuentaRepository,
            IEstadoContableCuentaRepository estadoContableCuentaRepository,
            
            int idEmpresa) {

            _cuentaRepository = cuentaRepository ?? throw new ArgumentNullException(nameof(cuentaRepository));
            _parametroRepository = parametroRepository ?? throw new ArgumentNullException(nameof(parametroRepository));
            _motor = motorContableService ?? throw new ArgumentNullException(nameof(motorContableService));
            _historialCuentaRepository = historialCuentaRepository ?? throw new ArgumentNullException(nameof(historialCuentaRepository));
            _estadoContableCuentaRepository = estadoContableCuentaRepository ?? throw new ArgumentNullException(nameof(estadoContableCuentaRepository));
            

            if (idEmpresa <= 0)
                throw new ArgumentOutOfRangeException(nameof(idEmpresa));

            _idEmpresa = idEmpresa;
        }

        public Task<List<CuentaContable>> ObtenerCuentasActivasAsync() {
            return _cuentaRepository.ObtenerActivasAsync();
        }

        public Task<List<RangoConCuentasDto>> ListarEstructuraRangosCuentasAsync() {
            return _cuentaRepository.ObtenerRangosConCuentasAsync();
        }

        public Task<List<RubroContableModel>> ListarEstructuraRangosActivosAsync() {
            return _cuentaRepository.ObtenerRangosActivosAsync();
        }

        public Task<string> GenerarSiguienteNumeroCuentaAsync(string cuentaPadre, short nivel) {
            return _motor.GenerarSiguienteCuentaDinamicaAsync(cuentaPadre, nivel);
        }

        public async Task<bool> RegistrarCuentaAsync(CuentaContable cuenta) {
            NormalizarYValidar(cuenta, false);

            var estructura = EstructuraCuenta.Crear(
                await _parametroRepository.ObtenerAsync(_idEmpresa));

            await NormalizarYValidarContrapartidaAsync(cuenta, estructura, _cuentaRepository);

            if (cuenta.Nivel > estructura.NivelActual)
                throw new ArgumentException("El nivel de la cuenta no está habilitado en PARAMEMP.");

            if (cuenta.Nivel > 1) {
                if (string.IsNullOrWhiteSpace(cuenta.CtaPapa))
                    throw new ArgumentException("La cuenta padre es obligatoria.");

                cuenta.CtaPapa = estructura.NormalizarFisica(cuenta.CtaPapa);
                var padre = await _cuentaRepository.ObtenerPorNumeroAsync(cuenta.CtaPapa);
                ValidarPadre(padre, cuenta.Nivel, estructura);
            } else {
                cuenta.CtaPapa = "-1";
            }

            return await _cuentaRepository.RegistrarNuevaAsync(cuenta, estructura);
        }

        public async Task<bool> ActualizarCuentaAsync(CuentaContable cuenta) {
            NormalizarYValidar(cuenta, true);

            var estructura = EstructuraCuenta.Crear(
                await _parametroRepository.ObtenerAsync(_idEmpresa));

            cuenta.NumCta = estructura.NormalizarFisica(cuenta.NumCta);

            var actual = await _cuentaRepository.ObtenerPorNumeroAsync(cuenta.NumCta);
            if (actual == null)
                throw new InvalidOperationException("La cuenta que se desea actualizar no existe.");

            if (cuenta.Nivel != actual.Nivel ||
                !string.Equals(Normalizar(cuenta.CtaPapa), Normalizar(actual.CtaPapa), StringComparison.Ordinal)) {
                throw new InvalidOperationException(
                    "El número, nivel y cuenta padre de una cuenta existente no pueden modificarse.");
            }

            if (cuenta.Naturaleza != 0 && cuenta.Naturaleza != 1)
                throw new ArgumentException("La naturaleza debe ser Deudora (0) o Acreedora (1).");

            // El estado se administra exclusivamente mediante Desactivar/ReactivarCuentaAsync.
            cuenta.Status = actual.Status;

            if (!string.IsNullOrWhiteSpace(cuenta.CtaComp)) {
                cuenta.CtaComp = estructura.NormalizarFisica(cuenta.CtaComp);

                if (string.Equals(cuenta.CtaComp, cuenta.NumCta, StringComparison.Ordinal))
                    throw new InvalidOperationException(
                        "La cuenta de contrapartida no puede ser la misma cuenta.");

                if (!await _cuentaRepository.ExisteAsync(cuenta.CtaComp))
                    throw new InvalidOperationException(
                        "La cuenta de contrapartida no existe en CUENTAS25.");
            }

            var hijos = await _cuentaRepository.ObtenerHijosAsync(cuenta.NumCta);

            await ValidarCambiosEstructuralesAsync(cuenta, actual, hijos);

            cuenta.CtaPapa = actual.CtaPapa;
            cuenta.CtaRaiz = actual.CtaRaiz;
            cuenta.Nivel = actual.Nivel;

            return await _cuentaRepository.ActualizarAsync(cuenta);
        }

        private async Task ValidarCambiosEstructuralesAsync(
            CuentaContable nueva,
            CuentaContable actual,
            List<CuentaContable> hijos) {

            var cambioTipo = !string.Equals(
                NormalizarMayusculas(nueva.Tipo),
                NormalizarMayusculas(actual.Tipo),
                StringComparison.Ordinal);

            var cambioNaturaleza = nueva.Naturaleza != actual.Naturaleza;

            if (string.Equals(nueva.Tipo, "D", StringComparison.OrdinalIgnoreCase) && hijos.Count > 0)
                throw new InvalidOperationException(
                    "Una cuenta con cuentas hijas no puede convertirse en cuenta de detalle.");

            if (!cambioTipo && !cambioNaturaleza)
                return;

            var estado = await _estadoContableCuentaRepository.ObtenerEstadoAsync(nueva.NumCta);

            if (!estado.TieneActividadContable)
                return;

            if (cambioTipo)
                throw new InvalidOperationException(
                    "No se puede cambiar el tipo A/D de una cuenta que tiene movimientos o saldos contables.");

            if (cambioNaturaleza)
                throw new InvalidOperationException(
                    "No se puede cambiar la naturaleza de una cuenta que tiene movimientos o saldos contables.");
        }

        private static async Task NormalizarYValidarContrapartidaAsync(
            CuentaContable cuenta,
            EstructuraCuenta estructura,
            ICuentaRepository repository) {

            if (string.IsNullOrWhiteSpace(cuenta.CtaComp))
                return;

            cuenta.CtaComp = estructura.NormalizarFisica(cuenta.CtaComp);

            if (string.Equals(cuenta.CtaComp, cuenta.NumCta, StringComparison.Ordinal))
                throw new InvalidOperationException(
                    "La cuenta de contrapartida no puede ser la misma cuenta.");

            if (!await repository.ExisteAsync(cuenta.CtaComp))
                throw new InvalidOperationException(
                    "La cuenta de contrapartida no existe en CUENTAS25.");
        }

        public Task<List<RangoCuentaModel>> Lista1() {
            return _cuentaRepository.Lista1();
        }

        public async Task<bool> RegistrarCuentaEnRangoAsync(CuentaContable cuenta, int rango) {
            NormalizarYValidar(cuenta, false);

            if (rango <= 0)
                throw new ArgumentOutOfRangeException(nameof(rango),
                    "El rango contable debe ser mayor que cero.");

            var estructura = EstructuraCuenta.Crear(
                await _parametroRepository.ObtenerAsync(_idEmpresa));

            await NormalizarYValidarContrapartidaAsync(cuenta, estructura, _cuentaRepository);

            if (cuenta.Nivel > estructura.NivelActual)
                throw new ArgumentException(
                    "El nivel de la cuenta no está habilitado en PARAMEMP.");

            if (cuenta.Nivel > 1) {
                if (string.IsNullOrWhiteSpace(cuenta.CtaPapa))
                    throw new ArgumentException("La cuenta padre es obligatoria.");

                cuenta.CtaPapa = estructura.NormalizarFisica(cuenta.CtaPapa);
                var padre = await _cuentaRepository.ObtenerPorNumeroAsync(cuenta.CtaPapa);
                ValidarPadre(padre, cuenta.Nivel, estructura);
            } else {
                cuenta.CtaPapa = "-1";
            }

            return await _cuentaRepository.RegistrarNuevaEnRangoAsync(
                cuenta, estructura, rango);
        }

        public async Task<bool> RegistrarCuentaRaizAsync(CuentaContable cuenta, int rango) {
            NormalizarYValidar(cuenta, false);

            if (rango <= 0)
                throw new ArgumentOutOfRangeException(nameof(rango),
                    "El rango contable debe ser mayor que cero.");

            var estructura = EstructuraCuenta.Crear(
                await _parametroRepository.ObtenerAsync(_idEmpresa));

            cuenta.Nivel = 1;
            cuenta.CtaPapa = "-1";

            await NormalizarYValidarContrapartidaAsync(cuenta, estructura, _cuentaRepository);

            return await _cuentaRepository.RegistrarNuevaEnRangoAsync(
                cuenta, estructura, rango);
        }

        public async Task<bool> DesactivarCuentaAsync(string numeroCuenta) {
            var numero = Normalizar(numeroCuenta);
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("El número de cuenta es obligatorio.", nameof(numeroCuenta));

            var cuenta = await _cuentaRepository.ObtenerPorNumeroAsync(numero);
            if (cuenta == null)
                throw new InvalidOperationException("La cuenta no existe.");

            if (string.Equals(cuenta.Status, "B", StringComparison.OrdinalIgnoreCase))
                return true;

            if (await _historialCuentaRepository.TieneMovimientosAsync(cuenta.NumCta))
                throw new InvalidOperationException(
                    "No se puede desactivar una cuenta que tiene movimientos contables registrados en AUXILIAR25.");

            var hijos = await _cuentaRepository.ObtenerHijosAsync(cuenta.NumCta);
            var hijosActivos = hijos.Where(x =>
                x != null && !string.Equals(x.Status, "B", StringComparison.OrdinalIgnoreCase)).ToList();

            if (hijosActivos.Count > 0)
                throw new InvalidOperationException(
                    "No se puede desactivar una cuenta que tiene cuentas hijas activas.");

            return await _cuentaRepository.CambiarStatusAsync(cuenta.NumCta, "B");
        }

        public async Task<ResultadoValidacionCuenta> ValidarCuentaParaMovimientoAsync(string numeroCuenta) {
            var resultado = new ResultadoValidacionCuenta();

            if (string.IsNullOrWhiteSpace(numeroCuenta)) {
                resultado.AgregarError("El número de cuenta es obligatorio.");
                return resultado;
            }

            try {
                var estructura = EstructuraCuenta.Crear(
                    await _parametroRepository.ObtenerAsync(_idEmpresa));

                string numeroFisico;
                try {
                    numeroFisico = estructura.NormalizarFisica(numeroCuenta);
                } catch (Exception ex) {
                    resultado.AgregarError(ex.Message);
                    return resultado;
                }

                var cuenta = await _cuentaRepository.ObtenerPorNumeroAsync(numeroFisico);
                if (cuenta == null) {
                    resultado.AgregarError("La cuenta no existe en CUENTAS25.");
                    return resultado;
                }

                if (!string.Equals(cuenta.Status, "A", StringComparison.OrdinalIgnoreCase))
                    resultado.AgregarError("La cuenta no está activa.");

                if (!string.Equals(cuenta.Tipo, "D", StringComparison.OrdinalIgnoreCase))
                    resultado.AgregarError("Una cuenta acumulativa (TIPO=A) no puede recibir movimientos directamente.");

                if (cuenta.Nivel < 1 || cuenta.Nivel > estructura.NivelActual)
                    resultado.AgregarError("El nivel de la cuenta no está habilitado en PARAMEMP.");

                if (cuenta.Naturaleza != 0 && cuenta.Naturaleza != 1)
                    resultado.AgregarError("La naturaleza de la cuenta debe ser Deudora (0) o Acreedora (1).");

                var hijos = await _cuentaRepository.ObtenerHijosAsync(numeroFisico);
                if (hijos.Count > 0)
                    resultado.AgregarError("La cuenta de detalle no puede tener cuentas hijas.");

                return resultado;
            } catch (InvalidOperationException ex) {
                resultado.AgregarError(ex.Message);
                return resultado;
            } catch (Exception ex) {
                throw new InvalidOperationException(
                    "No fue posible validar la cuenta para captura de movimientos.", ex);
            }
        }

        public async Task<bool> ReactivarCuentaAsync(string numeroCuenta) {
            var numero = Normalizar(numeroCuenta);
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("El número de cuenta es obligatorio.", nameof(numeroCuenta));

            var cuenta = await _cuentaRepository.ObtenerPorNumeroAsync(numero);
            if (cuenta == null)
                throw new InvalidOperationException("La cuenta no existe.");

            if (string.Equals(cuenta.Status, "A", StringComparison.OrdinalIgnoreCase))
                return true;

            if (cuenta.Nivel > 1 && !string.IsNullOrWhiteSpace(cuenta.CtaPapa) && cuenta.CtaPapa != "-1") {
                var padre = await _cuentaRepository.ObtenerPorNumeroAsync(cuenta.CtaPapa);
                if (padre == null)
                    throw new InvalidOperationException("No se puede reactivar la cuenta porque su cuenta padre no existe.");

                if (!string.Equals(padre.Status, "A", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("No se puede reactivar la cuenta mientras su cuenta padre esté inactiva.");
            }

            return await _cuentaRepository.CambiarStatusAsync(cuenta.NumCta, "A");
        }

        private static void NormalizarYValidar(CuentaContable cuenta, bool requiereNumero) {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));

            cuenta.NumCta = Normalizar(cuenta.NumCta);
            cuenta.Nombre = Normalizar(cuenta.Nombre);
            cuenta.Status = NormalizarMayusculas(cuenta.Status);
            cuenta.Tipo = NormalizarMayusculas(cuenta.Tipo);
            cuenta.CtaPapa = Normalizar(cuenta.CtaPapa);
            cuenta.CtaRaiz = Normalizar(cuenta.CtaRaiz);
            cuenta.DeptoSiNo = NormalizarMayusculas(cuenta.DeptoSiNo);
            cuenta.BandAjt = NormalizarMayusculas(cuenta.BandAjt);

            if (requiereNumero) {
                if (string.IsNullOrWhiteSpace(cuenta.NumCta))
                    throw new ArgumentException("El número de cuenta es obligatorio.");

                var digits = new string(cuenta.NumCta.Where(char.IsDigit).ToArray());
                if (digits.Length != EstructuraCuenta.LongitudFisica)
                    throw new ArgumentException("NUM_CTA debe contener exactamente 21 dígitos.");
            }

            if (string.IsNullOrWhiteSpace(cuenta.Nombre))
                throw new ArgumentException("El nombre de la cuenta es obligatorio.");

            if (cuenta.Nombre.Length > 40)
                throw new ArgumentException("El nombre de la cuenta no puede exceder 40 caracteres.");

            if (cuenta.Nivel < 1 || cuenta.Nivel > 9)
                throw new ArgumentOutOfRangeException(nameof(cuenta.Nivel));

            if (cuenta.Tipo != "A" && cuenta.Tipo != "D")
                throw new ArgumentException("TIPO debe ser A o D.");

            if (string.IsNullOrWhiteSpace(cuenta.Status))
                cuenta.Status = "A";

            if (string.IsNullOrWhiteSpace(cuenta.DeptoSiNo))
                cuenta.DeptoSiNo = "N";
        }

        private static void ValidarPadre(
            CuentaContable padre,
            short nivel,
            EstructuraCuenta estructura) {

            if (padre == null)
                throw new InvalidOperationException("La cuenta padre no existe.");

            if (!string.Equals(padre.Tipo, "A", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("La cuenta padre debe ser acumulativa.");

            if (!string.Equals(padre.Status, "A", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("La cuenta padre debe estar activa para registrar una cuenta hija.");

            if (padre.Nivel + 1 != nivel)
                throw new InvalidOperationException(
                    "El nivel de la cuenta no corresponde al de su padre.");

            var numeroPadre = estructura.NormalizarFisica(padre.NumCta);
            if (estructura.ObtenerNivelFisico(numeroPadre) != padre.Nivel)
                throw new InvalidOperationException(
                    "La cuenta padre no es consistente con su NIVEL en CUENTAS25.");

            if (padre.Nivel == 1 && !string.Equals(
                    estructura.NormalizarFisica(padre.CtaRaiz),
                    numeroPadre,
                    StringComparison.Ordinal))
                throw new InvalidOperationException(
                    "La cuenta raíz no es consistente con CTA_RAIZ.");

            if (padre.Nivel > 1 && string.IsNullOrWhiteSpace(padre.CtaRaiz))
                throw new InvalidOperationException(
                    "La cuenta padre no tiene una CTA_RAIZ válida.");
        }

        private static string Normalizar(string valor) {
            return string.IsNullOrWhiteSpace(valor) ? string.Empty : valor.Trim();
        }

        private static string NormalizarMayusculas(string valor) {
            return string.IsNullOrWhiteSpace(valor)
                ? string.Empty
                : valor.Trim().ToUpperInvariant();
        }

        public Task<List<RubroContableModel>> ObtenerRangosPorCuentaAsync(string numeroCuenta) {
            return _cuentaRepository.ObtenerRangosPorCuentaAsync(numeroCuenta);
        }

        public async Task<List<RubroContableModel>> ListarRangosDisponiblesParaCuentaAsync(string numeroCuenta) {
            var todos = await _cuentaRepository.ObtenerRangosActivosAsync();

            var asociados = await _cuentaRepository.ObtenerRangosPorCuentaAsync(
                numeroCuenta);

            var asociadosIds = new HashSet<int>(
                asociados.Select(x => x.Rango));

            return todos
                .Where(x => !asociadosIds.Contains(x.Rango))
                .OrderBy(x => x.Rango)
                .ToList();
        }

        public async Task<bool> AsociarCuentaRangoAsync(string numeroCuenta, int rango) {
            var cuenta = await _cuentaRepository.ObtenerPorNumeroAsync(numeroCuenta);

            if (cuenta == null)
                throw new InvalidOperationException(
                    "La cuenta no existe.");

            if (string.Equals(cuenta.Status, "B", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(
                    "No se puede asociar una cuenta inactiva a un rango.");

            if (rango <= 0)
                throw new ArgumentOutOfRangeException(nameof(rango),
                    "El rango contable debe ser mayor que cero.");

            var rangoExistente =
                await _cuentaRepository.ObtenerRangosPorCuentaAsync(numeroCuenta);

            if (rangoExistente.Any(x => x.Rango == rango))
                return true;

            var rangoCatalogo =
                await _cuentaRepository.ObtenerRangosActivosAsync();

            if (!rangoCatalogo.Any(x => x.Rango == rango))
                throw new InvalidOperationException(
                    "El rango seleccionado no existe.");

            var parametro = await _parametroRepository.ObtenerAsync(_idEmpresa);
            var estructura = EstructuraCuenta.Crear(parametro);
            var segPapa = CalcularSegPapa(estructura, cuenta.NumCta);

            return await _cuentaRepository.AsociarCuentaRangoAsync(
                numeroCuenta,
                rango,
                segPapa);
        }

        /// <summary>
        /// Calcula el valor de SEGPAPA a partir de la estructura física de NUM_CTA.
        /// Para una cuenta raíz, SEGPAPA corresponde a su propia cuenta lógica.
        /// Para una cuenta hija, corresponde a la cuenta lógica de su nivel padre.
        /// </summary>
        /// <param name="estructura">Estructura configurada en PARAMEMP.</param>
        /// <param name="numeroCuenta">NUM_CTA físico de la cuenta.</param>
        /// <returns>Cuenta lógica correspondiente a SEGPAPA.</returns>
        private static string CalcularSegPapa(
            EstructuraCuenta estructura,
            string numeroCuenta) {

            if (estructura == null)
                throw new ArgumentNullException(nameof(estructura));

            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException(
                    "El número de cuenta es obligatorio.", nameof(numeroCuenta));

            var numeroFisico = estructura.NormalizarFisica(numeroCuenta);
            var nivel = estructura.ObtenerNivelFisico(numeroFisico);
            var cuentaLogica = estructura.ObtenerCuentaLogicaDesdeFisica(numeroFisico);

            if (nivel <= 1)
                return cuentaLogica;

            var segmentos = estructura.ObtenerSegmentos(cuentaLogica, nivel);
            return string.Concat(segmentos.Take(nivel - 1));
        }

        public async Task<bool> DesasociarCuentaRangoAsync(string numeroCuenta, int rango) {
            var cuenta = await _cuentaRepository.ObtenerPorNumeroAsync(numeroCuenta);

            if (cuenta == null)
                throw new InvalidOperationException(
                    "La cuenta no existe.");

            var asociados =
                await _cuentaRepository.ObtenerRangosPorCuentaAsync(numeroCuenta);

            if (!asociados.Any(x => x.Rango == rango))
                return true;

            return await _cuentaRepository.DesasociarCuentaRangoAsync(
                numeroCuenta,
                rango);
        }

        public async Task<CuentaContable> ObtenerPorNumeroAsync(string numeroCuenta) {
            return await _cuentaRepository.ObtenerPorNumeroAsync(numeroCuenta);
        }
    }
}
