using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Aplica las reglas de aplicación del catálogo MONEDAS.
    /// </summary>
    public sealed class MonedaService : Contracts.IMonedaService {
        private readonly IMonedaRepository _repository;

        public MonedaService(IMonedaRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<Moneda>> ObtenerTodosAsync() {
            return _repository.ObtenerTodosAsync();
        }

        //public Task<Moneda> ObtenerAsync(short moneda) {
        //    ValidarCodigo(moneda);
        //    return _repository.ObtenerAsync(moneda);
        //}

        public async Task<double?> ObtenerTipoCambioAsync(short moneda) {
            ValidarCodigo(moneda);

            var entidad = await _repository.ObtenerAsync(moneda);
            if (entidad == null)
                throw new InvalidOperationException("La moneda no existe.");

            if (!entidad.TipoCambio.HasValue)
                return null;

            if (entidad.TipoCambio.Value <= 0 ||
                double.IsNaN(entidad.TipoCambio.Value) ||
                double.IsInfinity(entidad.TipoCambio.Value))
                throw new InvalidOperationException("El tipo de cambio configurado para la moneda no es válido.");

            return entidad.TipoCambio.Value;
        }

        public async Task CrearAsync(Moneda moneda) {
            Validar(moneda);

            if (await _repository.ObtenerAsync(moneda.IdMoneda) != null)
                throw new InvalidOperationException("La moneda ya existe.");

            await _repository.CrearAsync(Normalizar(moneda));
        }

        public async Task ActualizarAsync(Moneda moneda) {
            Validar(moneda);

            var existente = await _repository.ObtenerAsync(moneda.IdMoneda);
            if (existente == null)
                throw new InvalidOperationException("La moneda no existe.");

            await _repository.ActualizarAsync(Normalizar(moneda));
        }

        public async Task EliminarAsync(short moneda) {
            ValidarCodigo(moneda);

            var existente = await _repository.ObtenerAsync(moneda);
            if (existente == null)
                throw new InvalidOperationException("La moneda no existe.");

            if (await _repository.ExisteEnHistorialAsync(moneda))
                throw new InvalidOperationException("No se puede eliminar la moneda porque tiene registros en HISTOR.");

            if (await _repository.ExisteEnTiposActivoAsync(moneda))
                throw new InvalidOperationException("No se puede eliminar la moneda porque está siendo utilizada por TIPACTIV.");

            await _repository.EliminarAsync(moneda);
        }

        private static Moneda Normalizar(Moneda moneda) {
            return new Moneda {
                IdMoneda = moneda.IdMoneda,
                Nombre = string.IsNullOrWhiteSpace(moneda.Nombre) ? null : moneda.Nombre.Trim(),
                Prefijo = string.IsNullOrWhiteSpace(moneda.Prefijo) ? null : moneda.Prefijo.Trim().ToUpperInvariant(),
                Fecha = moneda.Fecha,
                TipoCambio = moneda.TipoCambio,
                Monto = moneda.Monto,
                DESPAUTO = string.IsNullOrWhiteSpace(moneda.DESPAUTO) ? null : moneda.DESPAUTO.Trim().ToUpperInvariant(),
                CveSAT = string.IsNullOrWhiteSpace(moneda.CveSAT) ? null : moneda.CveSAT.Trim().ToUpperInvariant()
            };
        }

        private static void Validar(Moneda moneda) {
            if (moneda == null)
                throw new ArgumentNullException(nameof(moneda));

            ValidarCodigo(moneda.IdMoneda);

            ValidarLongitud(moneda.Nombre, 20, "El nombre de la moneda no puede exceder 20 caracteres.");
            ValidarLongitud(moneda.Prefijo, 4, "El prefijo de la moneda no puede exceder 4 caracteres.");
            ValidarLongitud(moneda.DESPAUTO, 1, "DESPAUTO no puede exceder 1 carácter.");
            ValidarLongitud(moneda.CveSAT, 3, "CLASSAT no puede exceder 3 caracteres.");

            if (!string.IsNullOrWhiteSpace(moneda.DESPAUTO) && moneda.DESPAUTO.Trim().Length != 1)
                throw new ArgumentException("DESPAUTO debe contener un solo carácter.", nameof(moneda.DESPAUTO));
        }

        private static void ValidarCodigo(short moneda) {
            if (moneda < 0)
                throw new ArgumentOutOfRangeException(nameof(moneda), "El código de moneda no puede ser negativo.");
        }

        private static void ValidarLongitud(string valor, int maximo, string mensaje) {
            if (!string.IsNullOrWhiteSpace(valor) && valor.Trim().Length > maximo)
                throw new ArgumentException(mensaje);
        }
    }
}
