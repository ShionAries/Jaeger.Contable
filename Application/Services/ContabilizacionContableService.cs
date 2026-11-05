using System;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Enums;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Valida el periodo y delega la contabilización transaccional de sus pólizas.</summary>
    public sealed class ContabilizacionContableService : IContabilizacionContableService {
        private readonly IContabilizacionContableRepository _repository;
        private readonly IPeriodoContableService _periodoService;

        public ContabilizacionContableService(
            IContabilizacionContableRepository repository,
            IPeriodoContableService periodoService) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _periodoService = periodoService ?? throw new ArgumentNullException(nameof(periodoService));
        }

        public async Task<ResultadoContabilizacionPeriodo> ContabilizarPolizaAsync(
            string tipoPoliza,
            string numeroPoliza,
            short ejercicio,
            short periodo) {
            if (string.IsNullOrWhiteSpace(tipoPoliza))
                throw new ArgumentException("El tipo de póliza es obligatorio.", nameof(tipoPoliza));
            if (string.IsNullOrWhiteSpace(numeroPoliza))
                throw new ArgumentException("El número de póliza es obligatorio.", nameof(numeroPoliza));
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo));

            await _periodoService.ValidarRegistroAsync(ejercicio, periodo);
            return await _repository.ContabilizarPolizaAsync(
                tipoPoliza.Trim().ToUpperInvariant(), numeroPoliza.Trim(), ejercicio, periodo);
        }

        public async Task<ResultadoContabilizacionPeriodo> ContabilizarPeriodoAsync(
            short ejercicio,
            short periodo,
            ContabilizacionModoEnum modo,
            string tipoPoliza) {
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio), "El ejercicio contable debe ser mayor que cero.");
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo), "El periodo contable debe estar entre 1 y 14.");
            if (!Enum.IsDefined(typeof(ContabilizacionModoEnum), modo))
                throw new ArgumentOutOfRangeException(nameof(modo), "El modo de contabilización no es válido.");
            if (modo == ContabilizacionModoEnum.SoloNoContabilizadasTipo && string.IsNullOrWhiteSpace(tipoPoliza))
                throw new ArgumentException("Debe seleccionar el tipo de póliza.", nameof(tipoPoliza));

            await _periodoService.ValidarRegistroAsync(ejercicio, periodo);
            string tipo = string.IsNullOrWhiteSpace(tipoPoliza) ? null : tipoPoliza.Trim().ToUpperInvariant();
            return await _repository.ContabilizarPeriodoAsync(ejercicio, periodo, modo, tipo);
        }
    }
}
