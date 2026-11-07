using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Aplica las reglas de aplicación del catálogo TIPACTIV.
    /// </summary>
    public sealed class ActivoFijoTipoService : Contracts.IActivoFijoTipoService {
        private readonly IActivoFijoTipoRepository _repository;

        public ActivoFijoTipoService(IActivoFijoTipoRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<ActivoFijoTipo>> ObtenerTodosAsync() {
            return _repository.ObtenerTodosAsync();
        }

        public Task<ActivoFijoTipo> ObtenerAsync(short clave) {
            ValidarClave(clave);
            return _repository.ObtenerAsync(clave);
        }

        public async Task CrearAsync(ActivoFijoTipo tipo) {
            Validar(tipo);
            if (await _repository.ObtenerAsync(tipo.Clave) != null)
                throw new InvalidOperationException("El tipo de activo ya existe.");

            await ValidarReferenciasAsync(tipo);
            await _repository.CrearAsync(Normalizar(tipo));
        }

        public async Task ActualizarAsync(ActivoFijoTipo tipo) {
            Validar(tipo);
            if (await _repository.ObtenerAsync(tipo.Clave) == null)
                throw new InvalidOperationException("El tipo de activo no existe.");

            await ValidarReferenciasAsync(tipo);
            await _repository.ActualizarAsync(Normalizar(tipo));
        }

        public async Task EliminarAsync(short clave) {
            ValidarClave(clave);
            if (await _repository.ObtenerAsync(clave) == null)
                throw new InvalidOperationException("El tipo de activo no existe.");

            if (await _repository.EstaEnUsoAsync(clave))
                throw new InvalidOperationException("No se puede eliminar el tipo de activo porque está siendo utilizado.");

            await _repository.EliminarAsync(clave);
        }

        private async Task ValidarReferenciasAsync(ActivoFijoTipo tipo) {
            string[] cuentas = {
                tipo.CuentaActivo,
                tipo.CuentaDepresiacion,
                tipo.CuentaGastos,
                tipo.CuentaGanancias
            };

            foreach (string cuenta in cuentas) {
                if (string.IsNullOrWhiteSpace(cuenta))
                    continue;

                if (!await _repository.ExisteCuentaAsync(cuenta.Trim()))
                    throw new InvalidOperationException("La cuenta " + cuenta.Trim() + " no existe en CUENTAS25.");
            }

            if (tipo.Moneda.HasValue && !await _repository.ExisteMonedaAsync(tipo.Moneda.Value))
                throw new InvalidOperationException("La moneda indicada no existe en MONEDAS.");
        }

        private static ActivoFijoTipo Normalizar(ActivoFijoTipo tipo) {
            return new ActivoFijoTipo {
                Clave = tipo.Clave,
                Descripcion = NormalizarTexto(tipo.Descripcion),
                DepresiacionNormal = tipo.DepresiacionNormal,
                DepresiacionInmediata = tipo.DepresiacionInmediata,
                MaximoDepresiacion = tipo.MaximoDepresiacion,
                MetodoDepresiacion = NormalizarTexto(tipo.MetodoDepresiacion),
                DepresiacionProyectada = tipo.DepresiacionProyectada,
                CuentaActivo = NormalizarTexto(tipo.CuentaActivo),
                CuentaDepresiacion = NormalizarTexto(tipo.CuentaDepresiacion),
                CuentaGastos = NormalizarTexto(tipo.CuentaGastos),
                CuentaGanancias = NormalizarTexto(tipo.CuentaGanancias),
                Moneda = tipo.Moneda
            };
        }

        private static void Validar(ActivoFijoTipo tipo) {
            if (tipo == null)
                throw new ArgumentNullException(nameof(tipo));

            ValidarClave(tipo.Clave);
            ValidarLongitud(tipo.Descripcion, 20, "DESCRIP no puede exceder 20 caracteres.");
            ValidarLongitud(tipo.MetodoDepresiacion, 1, "METODODEP no puede exceder 1 carácter.");
            ValidarCuenta(tipo.CuentaActivo, "CTAAACTV");
            ValidarCuenta(tipo.CuentaDepresiacion, "CTADEPRE");
            ValidarCuenta(tipo.CuentaGastos, "CTAGASTOS");
            ValidarCuenta(tipo.CuentaGanancias, "CTAPERGAN");
            ValidarNumero(tipo.DepresiacionNormal, "DEDNORMAL");
            ValidarNumero(tipo.DepresiacionInmediata, "DEDIMED");
            ValidarNumero(tipo.MaximoDepresiacion, "MAXDED");
            ValidarNumero(tipo.DepresiacionProyectada, "DEPPROY");
        }

        private static void ValidarClave(short clave) {
            if (clave < 0)
                throw new ArgumentOutOfRangeException(nameof(clave), "La clave no puede ser negativa.");
        }

        private static void ValidarCuenta(string cuenta, string nombre) {
            if (!string.IsNullOrWhiteSpace(cuenta) && cuenta.Trim().Length > 21)
                throw new ArgumentException(nombre + " no puede exceder 21 caracteres.", nombre);
        }

        private static void ValidarLongitud(string valor, int maximo, string mensaje) {
            if (!string.IsNullOrWhiteSpace(valor) && valor.Trim().Length > maximo)
                throw new ArgumentException(mensaje);
        }

        private static void ValidarNumero(double? valor, string nombre) {
            if (valor.HasValue && (double.IsNaN(valor.Value) || double.IsInfinity(valor.Value)))
                throw new ArgumentException(nombre + " debe contener un valor numérico válido.", nombre);
        }

        private static string NormalizarTexto(string valor) {
            return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }
    }
}
