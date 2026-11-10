using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.ValueObjects;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Valida y prepara una póliza completa antes de delegar su persistencia transaccional.
    /// </summary>
    public sealed class PolizaContableService : IPolizaContableService {
        private readonly IMotorMovimientoContableService _motor;
        private readonly IPolizaContableRepository _repository;
        private readonly IPeriodoContableService _periodoService;
        private readonly ITipoPolizaService _tipoPolizaService;
        private readonly ICatalogosPartidaService _catalogosPartidaService;
        private readonly IPolizaContableValidator _validator;

        public PolizaContableService(
            IMotorMovimientoContableService motor,
            IPolizaContableRepository repository,
            IPeriodoContableService periodoService,
            ITipoPolizaService tipoPolizaService,
            ICatalogosPartidaService catalogosPartidaService,
            IPolizaContableValidator validator) {

            _motor = motor ?? throw new ArgumentNullException(nameof(motor));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _periodoService = periodoService ?? throw new ArgumentNullException(nameof(periodoService));
            _tipoPolizaService = tipoPolizaService ?? throw new ArgumentNullException(nameof(tipoPolizaService));
            _catalogosPartidaService = catalogosPartidaService ?? throw new ArgumentNullException(nameof(catalogosPartidaService));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<ResultadoRegistroPoliza> RegistrarAsync(PolizaContableRequest request) {
            _validator.ValidarCabecera(request);

            var tipo = await _tipoPolizaService.ObtenerAsync(request.TipoPoliza.Trim());
            if (tipo == null)
                throw new InvalidOperationException(string.Format(
                    "El tipo de póliza '{0}' no existe en TIPOSPOL.",
                    request.TipoPoliza.Trim()));

            request.TipoPoliza = tipo.Tipo.Trim();

            // La validación del periodo ocurre antes de abrir la transacción de persistencia.
            await _periodoService.ValidarRegistroAsync(request.Ejercicio, request.Periodo);

            var preparadas = new List<MovimientoContableRequest>(request.Partidas.Count);
            double totalDebe = 0d;
            double totalHaber = 0d;

            for (int i = 0; i < request.Partidas.Count; i++) {
                var partida = request.Partidas[i];
                _validator.ValidarPartida(partida, i + 1);

                await ValidarCatalogosPartidaAsync(partida, i + 1);

                var preparada = await _motor.PrepararAsync(new MovimientoCuenta {
                    NumeroCuenta = partida.NumeroCuenta,
                    Ejercicio = request.Ejercicio,
                    Periodo = request.Periodo,
                    DebeHaber = partida.DebeHaber,
                    Importe = partida.Importe
                });

                partida.TipoPoliza = request.TipoPoliza;
                partida.NumeroPoliza = request.NumeroPoliza == null ? string.Empty : request.NumeroPoliza.Trim();
                partida.Ejercicio = request.Ejercicio;
                partida.Periodo = request.Periodo;
                partida.Fecha = request.Fecha;
                if (string.IsNullOrWhiteSpace(partida.Concepto))
                    partida.Concepto = request.Concepto;
                partida.NumeroCuenta = preparada.NumeroCuenta;
                partida.DebeHaber = preparada.DebeHaber;
                partida.Importe = ImporteContable.Redondear(preparada.Importe);
                partida.NumeroPartida = i + 1;

                preparadas.Add(partida);

                if (partida.DebeHaber == "D")
                    totalDebe = ImporteContable.Redondear(totalDebe + partida.Importe);
                else
                    totalHaber = ImporteContable.Redondear(totalHaber + partida.Importe);
            }

            _validator.ValidarBalance(totalDebe, totalHaber);

            request.Partidas = preparadas;

            // Hasta aquí no se ha iniciado la transacción de escritura.
            await _repository.RegistrarAsync(request);

            return new ResultadoRegistroPoliza(
                request.TipoPoliza,
                request.NumeroPoliza == null ? string.Empty : request.NumeroPoliza.Trim(),
                request.Ejercicio,
                request.Periodo,
                preparadas.Count,
                totalDebe,
                totalHaber,
                true,
                new List<string>());
        }

        public async Task ActualizarAsync(PolizaContableRequest request) {
            _validator.ValidarCabecera(request);

            var tipo = await _tipoPolizaService.ObtenerAsync(request.TipoPoliza.Trim());
            if (tipo == null)
                throw new InvalidOperationException(string.Format(
                    "El tipo de póliza '{0}' no existe en TIPOSPOL.", request.TipoPoliza.Trim()));

            request.TipoPoliza = tipo.Tipo.Trim();
            if (string.IsNullOrWhiteSpace(request.NumeroPoliza))
                throw new ArgumentException("El número de póliza es obligatorio para actualizar.", nameof(request));

            await _periodoService.ValidarRegistroAsync(request.Ejercicio, request.Periodo);
            request.Partidas = await PrepararPartidasAsync(request);
            await _repository.ActualizarAsync(request);
        }

        public async Task EliminarAsync(string tipoPoliza, string numeroPoliza, short ejercicio, short periodo) {
            if (string.IsNullOrWhiteSpace(tipoPoliza))
                throw new ArgumentException("El tipo de póliza es obligatorio.", nameof(tipoPoliza));
            if (string.IsNullOrWhiteSpace(numeroPoliza))
                throw new ArgumentException("El número de póliza es obligatorio.", nameof(numeroPoliza));
            if (ejercicio <= 0)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));
            if (periodo < 1 || periodo > 14)
                throw new ArgumentOutOfRangeException(nameof(periodo));

            await _periodoService.ValidarRegistroAsync(ejercicio, periodo);
            await _repository.EliminarAsync(tipoPoliza.Trim(), numeroPoliza.Trim(), ejercicio, periodo);
        }

        private async Task<List<MovimientoContableRequest>> PrepararPartidasAsync(PolizaContableRequest request) {
            if (request.Partidas == null || request.Partidas.Count == 0)
                throw new InvalidOperationException("La póliza debe contener al menos una partida.");

            var preparadas = new List<MovimientoContableRequest>(request.Partidas.Count);
            double totalDebe = 0d;
            double totalHaber = 0d;

            for (int i = 0; i < request.Partidas.Count; i++) {
                var partida = request.Partidas[i];
                _validator.ValidarPartida(partida, i + 1);
                await ValidarCatalogosPartidaAsync(partida, i + 1);

                var preparada = await _motor.PrepararAsync(new MovimientoCuenta {
                    NumeroCuenta = partida.NumeroCuenta,
                    Ejercicio = request.Ejercicio,
                    Periodo = request.Periodo,
                    DebeHaber = partida.DebeHaber,
                    Importe = partida.Importe
                });

                partida.TipoPoliza = request.TipoPoliza;
                partida.NumeroPoliza = request.NumeroPoliza.Trim();
                partida.Ejercicio = request.Ejercicio;
                partida.Periodo = request.Periodo;
                partida.Fecha = request.Fecha;
                if (string.IsNullOrWhiteSpace(partida.Concepto))
                    partida.Concepto = request.Concepto;
                partida.NumeroCuenta = preparada.NumeroCuenta;
                partida.DebeHaber = preparada.DebeHaber;
                partida.Importe = ImporteContable.Redondear(preparada.Importe);
                partida.NumeroPartida = i + 1;
                preparadas.Add(partida);

                if (partida.DebeHaber == "D")
                    totalDebe = ImporteContable.Redondear(totalDebe + partida.Importe);
                else
                    totalHaber = ImporteContable.Redondear(totalHaber + partida.Importe);
            }

            _validator.ValidarBalance(totalDebe, totalHaber);
            return preparadas;
        }

        private async Task ValidarCatalogosPartidaAsync(
            MovimientoContableRequest partida,
            int numeroPartida) {

            if (partida.NumeroDepartamento.HasValue &&
                !await _catalogosPartidaService.ExisteDepartamentoAsync(partida.NumeroDepartamento.Value))
                throw new InvalidOperationException(string.Format(
                    "El departamento {0} de la partida {1} no existe en DEPTOS.",
                    partida.NumeroDepartamento.Value,
                    numeroPartida));

            if (partida.CentroCostos.HasValue &&
                !await _catalogosPartidaService.ExisteCentroCostoAsync(partida.CentroCostos.Value))
                throw new InvalidOperationException(string.Format(
                    "El centro de costos {0} de la partida {1} no existe en CCOSTOS.",
                    partida.CentroCostos.Value,
                    numeroPartida));

            if (partida.Grupo.HasValue &&
                !await _catalogosPartidaService.ExisteGrupoAsync(partida.Grupo.Value))
                throw new InvalidOperationException(string.Format(
                    "El grupo {0} de la partida {1} no existe en CGRUPOS.",
                    partida.Grupo.Value,
                    numeroPartida));
        }
    }
}
