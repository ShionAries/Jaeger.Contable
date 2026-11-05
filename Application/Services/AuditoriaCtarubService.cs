using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger.Contable.Application.Contracts;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    public sealed class AuditoriaCtarubService : IAuditoriaCtarubService {
        private readonly ICuentaRubroRepository _ctarubRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IRangoRepository _rangoRepository;
        private readonly IConfiguracionCuentaService _configuracionService;
        private readonly int _idEmpresa;

        public AuditoriaCtarubService(ICuentaRubroRepository ctarubRepository, ICuentaRepository cuentaRepository, IRangoRepository rangoRepository, IConfiguracionCuentaService configuracionService, int idEmpresa) {
            _ctarubRepository = ctarubRepository ?? throw new ArgumentNullException(nameof(ctarubRepository));
            _cuentaRepository = cuentaRepository ?? throw new ArgumentNullException(nameof(cuentaRepository));
            _rangoRepository = rangoRepository ?? throw new ArgumentNullException(nameof(rangoRepository));
            _configuracionService = configuracionService ?? throw new ArgumentNullException(nameof(configuracionService));
            _idEmpresa = idEmpresa;
        }

        public async Task<ResultadoAuditoriaCtarub> AuditarAsync() {
            var relacionesTask = _ctarubRepository.ObtenerTodasAsync();
            var cuentasTask = _cuentaRepository.ObtenerTodasAsync();
            var rangosTask = _rangoRepository.ObtenerTodosAsync();
            var configuracionTask = _configuracionService.ObtenerAsync(_idEmpresa);
            await Task.WhenAll(relacionesTask, cuentasTask, rangosTask, configuracionTask);

            var relaciones = await relacionesTask;
            var cuentas = await cuentasTask;
            var rangos = await rangosTask;
            var configuracion = await configuracionTask;
            var resultado = new ResultadoAuditoriaCtarub();

            EstructuraCuenta estructura = null;
            string errorEstructura = null;
            try {
                if (configuracion == null) throw new InvalidOperationException("No existe configuración de PARAMEMP para la empresa configurada.");
                estructura = EstructuraCuenta.Crear(configuracion);
            } catch (Exception ex) { errorEstructura = ex.Message; }

            var cuentasPorNumero = cuentas.Where(x => x != null && !string.IsNullOrWhiteSpace(x.NumCta))
                .GroupBy(x => Normalizar(x.NumCta), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => x.First(), StringComparer.Ordinal);
            var rangosIds = new HashSet<int>(rangos.Select(x => x.Rango));

            foreach (var relacion in relaciones) {
                var item = new ResultadoAuditoriaCtarubItem(relacion.Rubro, relacion.Cuenta, relacion.SegPapa);
                if (relacion.Rubro <= 0) item.AgregarError("RUBRO debe ser mayor que cero.");
                if (!rangosIds.Contains(relacion.Rubro)) item.AgregarError("RUBRO no existe en RANGOS.");

                var cuentaNumero = Normalizar(relacion.Cuenta);
                CuentaContable cuenta;
                if (cuentaNumero.Length == 0 || !cuentasPorNumero.TryGetValue(cuentaNumero, out cuenta)) {
                    item.AgregarError("CUENTA no existe en CUENTAS25.");
                    resultado.Agregar(item);
                    continue;
                }

                if (errorEstructura != null) { item.AgregarError("No fue posible validar la estructura de cuenta: " + errorEstructura); resultado.Agregar(item); continue; }

                try {
                    estructura.NormalizarFisica(cuenta.NumCta);
                    var logicaCuenta = estructura.ObtenerCuentaLogicaDesdeFisica(cuenta.NumCta);
                    var esperado = ObtenerSegPapaEsperado(cuenta, cuentasPorNumero, estructura);
                    if (!string.Equals(Normalizar(relacion.SegPapa), Normalizar(esperado), StringComparison.Ordinal))
                        item.AgregarError("SEGPAPA no corresponde a la cuenta lógica del padre.");
                    if (cuenta.Nivel == 1 && !string.Equals(Normalizar(relacion.SegPapa), Normalizar(logicaCuenta), StringComparison.Ordinal))
                        item.AgregarError("Para una cuenta raíz, SEGPAPA debe corresponder a su cuenta lógica.");
                } catch (Exception ex) { item.AgregarError(ex.Message); }

                resultado.Agregar(item);
            }
            return resultado;
        }

        private static string ObtenerSegPapaEsperado(CuentaContable cuenta, IDictionary<string, CuentaContable> cuentas, EstructuraCuenta estructura) {
            if (cuenta.Nivel <= 1) return estructura.ObtenerCuentaLogicaDesdeFisica(cuenta.NumCta);
            var papaNumero = Normalizar(cuenta.CtaPapa);
            CuentaContable padre;
            if (papaNumero.Length == 0 || !cuentas.TryGetValue(papaNumero, out padre)) return string.Empty;
            return estructura.ObtenerCuentaLogicaDesdeFisica(padre.NumCta);
        }

        private static string Normalizar(string value) { return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim(); }
    }
}
