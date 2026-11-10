using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Valida parámetros y delega las consultas de trazabilidad de pólizas.</summary>
    public sealed class PolizaConsultaService : Contracts.IPolizaConsultaService {
        private readonly IPolizaConsultaRepository _repository;

        public PolizaConsultaService(IPolizaConsultaRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<PolizaContableConsulta> ObtenerAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo) {
            Validar(tipoPoliza, numeroPoliza, ejercicio, periodo);
            return await _repository.ObtenerAsync(tipoPoliza.Trim(), numeroPoliza.Trim(), ejercicio, periodo);
        }

        public async Task<List<PolizaContableResumen>> ObtenerPorCuentaAsync(string numeroCuenta, short ejercicio, short periodo) {
            if (string.IsNullOrWhiteSpace(numeroCuenta)) throw new ArgumentException("La cuenta es obligatoria.", nameof(numeroCuenta));
            if (ejercicio <= 0) throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14) throw new ArgumentOutOfRangeException(nameof(periodo));
            return await _repository.ObtenerPorCuentaAsync(NormalizarCuenta(numeroCuenta), ejercicio, periodo);
        }

        public async Task<List<PolizaContableResumen>> ObtenerPorPeriodoAsync(short ejercicio, short periodo) {
            if (ejercicio <= 0) throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14) throw new ArgumentOutOfRangeException(nameof(periodo));
            return await _repository.ObtenerPorPeriodoAsync(ejercicio, periodo);
        }

        private static void Validar(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo) {
            if (string.IsNullOrWhiteSpace(tipoPoliza)) throw new ArgumentException("El tipo de póliza es obligatorio.", nameof(tipoPoliza));
            if (string.IsNullOrWhiteSpace(numeroPoliza)) throw new ArgumentException("El número de póliza es obligatorio.", nameof(numeroPoliza));
            if (tipoPoliza.Trim().Length > 2) throw new ArgumentException("El tipo de póliza no puede exceder 2 caracteres.", nameof(tipoPoliza));
            if (numeroPoliza.Trim().Length > 7) throw new ArgumentException("El número de póliza no puede exceder 7 caracteres.", nameof(numeroPoliza));
            if (ejercicio <= 0) throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14) throw new ArgumentOutOfRangeException(nameof(periodo));
        }

        private static string NormalizarCuenta(string numeroCuenta) {
            var caracteres = numeroCuenta.Trim().ToCharArray();
            var resultado = new System.Text.StringBuilder(caracteres.Length);
            foreach (char caracter in caracteres)
                if (char.IsDigit(caracter)) resultado.Append(caracter);
            return resultado.ToString();
        }
    }
}
