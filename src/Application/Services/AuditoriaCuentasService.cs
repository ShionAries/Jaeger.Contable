using System;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Ejecuta la auditoría completa de la jerarquía de CUENTAS25.</summary>
    public sealed class AuditoriaCuentasService : IAuditoriaCuentasService {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IValidadorJerarquiaCuenta _validador;

        public AuditoriaCuentasService(
            ICuentaRepository cuentaRepository,
            IValidadorJerarquiaCuenta validador) {
            _cuentaRepository = cuentaRepository ?? throw new ArgumentNullException(nameof(cuentaRepository));
            _validador = validador ?? throw new ArgumentNullException(nameof(validador));
        }

        public async Task<ResultadoAuditoriaCuentas> AuditarAsync() {
            var cuentas = await _cuentaRepository.ObtenerTodasAsync();
            return await _validador.ValidarTodasAsync(cuentas);
        }
    }
}
