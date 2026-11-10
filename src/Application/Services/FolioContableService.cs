using System;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Valida los parámetros y delega la generación transaccional del folio.</summary>
    public sealed class FolioContableService : Contracts.IFolioContableService {
        private readonly IFolioContableRepository _repository;

        public FolioContableService(IFolioContableRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<FolioContable> ObtenerSiguienteAsync(string tipoPoliza, short ejercicio, short periodo) {
            if (string.IsNullOrWhiteSpace(tipoPoliza))
                throw new ArgumentException("El tipo de póliza es obligatorio.", nameof(tipoPoliza));
            if (tipoPoliza.Trim().Length > 2)
                throw new ArgumentException("El tipo de póliza no puede exceder 2 caracteres.", nameof(tipoPoliza));
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo));

            return _repository.ObtenerSiguienteAsync(tipoPoliza.Trim(), ejercicio, periodo);
        }
    }
}
