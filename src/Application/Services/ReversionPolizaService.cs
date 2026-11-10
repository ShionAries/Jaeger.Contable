using System;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>Construye una póliza inversa a partir de una póliza existente.</summary>
    public sealed class ReversionPolizaService : IReversionPolizaService {
        private readonly IPeriodoContableService _periodoService;
        private readonly IReversionPolizaRepository _repository;
        private readonly IFolioContableService _folioService;

        public ReversionPolizaService(IPeriodoContableService periodoService,
            IReversionPolizaRepository repository, IFolioContableService folioService) {
            _periodoService = periodoService ?? throw new ArgumentNullException(nameof(periodoService));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _folioService = folioService ?? throw new ArgumentNullException(nameof(folioService));
        }

        public async Task<ResultadoReversionPoliza> RevertirAsync(PolizaReversionRequest request) {
            Validar(request);
            await _periodoService.ValidarRegistroAsync(request.Ejercicio, request.Periodo);

            var original = await _repository.ObtenerOriginalAsync(
                request.TipoPolizaOriginal.Trim(), request.NumeroPolizaOriginal.Trim(),
                request.Ejercicio, request.Periodo);

            if (original == null)
                throw new InvalidOperationException("La póliza original no existe en POLIZAS25.");

            string tipoNuevo = string.IsNullOrWhiteSpace(request.TipoPolizaNueva)
                ? request.TipoPolizaOriginal.Trim()
                : request.TipoPolizaNueva.Trim();

            string numeroNuevo = request.NumeroPolizaNueva;
            if (string.IsNullOrWhiteSpace(numeroNuevo)) {
                var folio = await _folioService.ObtenerSiguienteAsync(
                    tipoNuevo, request.Ejercicio, request.Periodo);
                numeroNuevo = folio.NumeroPoliza;
            }

            var partidas = original.Partidas.ToList();
            if (partidas.Count == 0)
                throw new InvalidOperationException("La póliza original no contiene partidas en AUXILIAR25.");

            foreach (var partida in partidas) {
                partida.TipoPoliza = tipoNuevo;
                partida.NumeroPoliza = numeroNuevo.Trim();
                partida.DebeHaber = InvertirDebeHaber(partida.DebeHaber);
                partida.Fecha = request.Fecha ?? partida.Fecha;
                partida.Concepto = ConstruirConcepto(request.Motivo, partida.Concepto);
            }

            original.TipoPoliza = tipoNuevo;
            original.NumeroPoliza = numeroNuevo.Trim();
            original.Fecha = request.Fecha ?? original.Fecha;
            original.Concepto = ConstruirConcepto(request.Motivo, original.Concepto);
            original.Partidas = partidas;

            await _repository.RegistrarReversionAsync(original);

            double importe = partidas.Sum(x => x.Importe);
            return new ResultadoReversionPoliza(
                request.TipoPolizaOriginal.Trim(), request.NumeroPolizaOriginal.Trim(),
                tipoNuevo, numeroNuevo.Trim(), request.Ejercicio, request.Periodo,
                partidas.Count, importe);
        }

        private static void Validar(PolizaReversionRequest request) {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrWhiteSpace(request.TipoPolizaOriginal))
                throw new ArgumentException("El tipo de póliza original es obligatorio.", nameof(request.TipoPolizaOriginal));
            if (request.TipoPolizaOriginal.Trim().Length > 2)
                throw new ArgumentException("El tipo de póliza original no puede exceder 2 caracteres.", nameof(request.TipoPolizaOriginal));
            if (string.IsNullOrWhiteSpace(request.NumeroPolizaOriginal))
                throw new ArgumentException("El número de póliza original es obligatorio.", nameof(request.NumeroPolizaOriginal));
            if (request.NumeroPolizaOriginal.Trim().Length > 7)
                throw new ArgumentException("El número de póliza original no puede exceder 7 caracteres.", nameof(request.NumeroPolizaOriginal));
            if (!string.IsNullOrWhiteSpace(request.TipoPolizaNueva) && request.TipoPolizaNueva.Trim().Length > 2)
                throw new ArgumentException("El nuevo tipo de póliza no puede exceder 2 caracteres.", nameof(request.TipoPolizaNueva));
            if (!string.IsNullOrWhiteSpace(request.NumeroPolizaNueva) && request.NumeroPolizaNueva.Trim().Length > 7)
                throw new ArgumentException("El nuevo número de póliza no puede exceder 7 caracteres.", nameof(request.NumeroPolizaNueva));
            if (request.Ejercicio <= 0) throw new ArgumentOutOfRangeException(nameof(request.Ejercicio));
            if (request.Periodo < 1 || request.Periodo > 14) throw new ArgumentOutOfRangeException(nameof(request.Periodo));
        }

        private static string InvertirDebeHaber(string valor) {
            if (string.Equals(valor, "D", StringComparison.OrdinalIgnoreCase)) return "H";
            if (string.Equals(valor, "H", StringComparison.OrdinalIgnoreCase)) return "D";
            throw new InvalidOperationException("La póliza original contiene una partida con DEBE_HABER inválido.");
        }

        private static string ConstruirConcepto(string motivo, string original) {
            string texto = string.IsNullOrWhiteSpace(motivo) ? "REVERSIÓN" : "REVERSIÓN: " + motivo.Trim();
            if (texto.Length > 120) texto = texto.Substring(0, 120);
            return texto;
        }
    }
}
