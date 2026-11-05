using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using Jaeger.Contable.Domain.Entities;

namespace Jaeger.Contable.Application.Services {
    /// <summary>
    /// Aplica las reglas de aplicación del catálogo de activos fijos ACTIVOS25.
    /// </summary>
    public sealed class ActivoFijoService : Contracts.IActivoFijoService {
        private readonly IActivoFijoRepository _repository;

        public ActivoFijoService(IActivoFijoRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<ActivoFijo>> ObtenerTodosAsync() {
            return _repository.ObtenerTodosAsync();
        }

        public Task<ActivoFijo> ObtenerAsync(string clave) {
            ValidarClave(clave);
            return _repository.ObtenerAsync(clave.Trim());
        }

        public async Task CrearAsync(ActivoFijo activo) {
            Validar(activo);
            if (await _repository.ObtenerAsync(activo.Clave.Trim()) != null)
                throw new InvalidOperationException("El activo fijo ya existe.");
            await ValidarReferenciasAsync(activo);
            await _repository.CrearAsync(Normalizar(activo));
        }

        public async Task ActualizarAsync(ActivoFijo activo) {
            Validar(activo);
            if (await _repository.ObtenerAsync(activo.Clave.Trim()) == null)
                throw new InvalidOperationException("El activo fijo no existe.");
            await ValidarReferenciasAsync(activo);
            await _repository.ActualizarAsync(Normalizar(activo));
        }

        public async Task EliminarAsync(string clave) {
            ValidarClave(clave);
            if (await _repository.ObtenerAsync(clave.Trim()) == null)
                throw new InvalidOperationException("El activo fijo no existe.");
            await _repository.EliminarAsync(clave.Trim());
        }

        private async Task ValidarReferenciasAsync(ActivoFijo activo) {
            if (activo.Tipo.HasValue && !await _repository.ExisteTipoAsync(activo.Tipo.Value))
                throw new InvalidOperationException("El tipo de activo indicado no existe en TIPACTIV.");
        }

        private static void Validar(ActivoFijo activo) {
            if (activo == null)
                throw new ArgumentNullException(nameof(activo));
            ValidarClave(activo.Clave);
            if (string.IsNullOrWhiteSpace(activo.Descripcion))
                throw new ArgumentException("La descripción del activo es obligatoria.", nameof(activo.Descripcion));
            ValidarLongitud(activo.Descripcion, 30, "DESCRIP no puede exceder 30 caracteres.");
            ValidarLongitud(activo.Localizacion, 9, "LOCALIZ no puede exceder 9 caracteres.");
            ValidarLongitud(activo.MetodoDepresiacion, 1, "METDEP no puede exceder 1 carácter.");
            ValidarLongitud(activo.Status, 1, "STATUS no puede exceder 1 carácter.");
            ValidarLongitud(activo.NumSerie, 24, "NUMSERIE no puede exceder 24 caracteres.");
            ValidarLongitud(activo.BANDEDINM, 1, "BANDEDINM no puede exceder 1 carácter.");
            ValidarLongitud(activo.Nota, 250, "OBSERVACIO no puede exceder 250 caracteres.");
            ValidarLongitud(activo.PolizaSeguro, 20, "POLIZASEG no puede exceder 20 caracteres.");
            ValidarLongitud(activo.CompaniaSeguro, 40, "COMPASEGU no puede exceder 40 caracteres.");
            ValidarLongitud(activo.AgenteSeguro, 40, "AGENTESEG no puede exceder 40 caracteres.");
            ValidarLongitud(activo.TelefonoSiniestro, 15, "TELSINIES no puede exceder 15 caracteres.");
            ValidarLongitud(activo.TipoCobertura, 20, "TIPOCOBER no puede exceder 20 caracteres.");
            ValidarLongitud(activo.Responsable, 60, "RESPACTFIJO no puede exceder 60 caracteres.");
            ValidarDouble(activo.MontoOriginal, "MONTORIG");
            ValidarDouble(activo.MontoOriginalMonedaExtranjera, "MONTORIGEX");
            ValidarDouble(activo.MaximoDeducible, "MAXDED");
            ValidarDouble(activo.ValorMercado, "VALMER");
            ValidarDouble(activo.DepresiacionAcumulada, "DEPACU");
            ValidarDouble(activo.VidaUtil, "VIDAUT");
            ValidarDouble(activo.TasaDepresiacion, "TASDEP");
            ValidarDouble(activo.TasaDepresiacionFiscal, "TASDEPFIS");
            ValidarDouble(activo.DepresiacionAcumuladaFiscal, "DEPACUFISC");
            ValidarDouble(activo.TipoCambio, "TIPOCAMBIO");
            ValidarDouble(activo.MontoAsegurado, "MONTOASEG");
            ValidarDouble(activo.PrimaTotal, "PRIMATOTA");
            ValidarDouble(activo.Deducible, "DEDUCIBLE");
            ValidarDouble(activo.CostoMantto, "COSTOMANT");
        }

        private static void ValidarClave(string clave) {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave del activo es obligatoria.", nameof(clave));
            if (clave.Trim().Length > 16)
                throw new ArgumentException("CLAVE no puede exceder 16 caracteres.", nameof(clave));
        }

        private static void ValidarLongitud(string valor, int maximo, string mensaje) {
            if (!string.IsNullOrWhiteSpace(valor) && valor.Trim().Length > maximo)
                throw new ArgumentException(mensaje);
        }

        private static void ValidarDouble(double? valor, string nombre) {
            if (valor.HasValue && (double.IsNaN(valor.Value) || double.IsInfinity(valor.Value)))
                throw new ArgumentException(nombre + " debe contener un valor numérico válido.", nombre);
        }

        private static string Texto(string valor) {
            return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }

        private static ActivoFijo Normalizar(ActivoFijo x) {
            return new ActivoFijo {
                Clave = x.Clave.Trim(), Tipo = x.Tipo, Descripcion = Texto(x.Descripcion), Localizacion = Texto(x.Localizacion),
                MontoOriginal = x.MontoOriginal, MontoOriginalMonedaExtranjera = x.MontoOriginalMonedaExtranjera, FecAdquisicion = x.FecAdquisicion, MaximoDeducible = x.MaximoDeducible,
                ValorMercado = x.ValorMercado, DepresiacionAcumulada = x.DepresiacionAcumulada, VidaUtil = x.VidaUtil, MetodoDepresiacion = Texto(x.MetodoDepresiacion),
                TasaDepresiacion = x.TasaDepresiacion, TasaDepresiacionFiscal = x.TasaDepresiacionFiscal, Status = Texto(x.Status), FechaBaja = x.FechaBaja,
                IdDepartamento = x.IdDepartamento, FECHAULTRE = x.FECHAULTRE, NumSerie = Texto(x.NumSerie),
                BANDEDINM = Texto(x.BANDEDINM), FecInicioDepresiacion = x.FecInicioDepresiacion, FecInicioDepresiacionFiscal = x.FecInicioDepresiacionFiscal,
                DepresiacionAcumuladaFiscal = x.DepresiacionAcumuladaFiscal, Nota = Texto(x.Nota), TipoCambio = x.TipoCambio,
                PolizaSeguro = Texto(x.PolizaSeguro), CompaniaSeguro = Texto(x.CompaniaSeguro), AgenteSeguro = Texto(x.AgenteSeguro),
                TelefonoSiniestro = Texto(x.TelefonoSiniestro), TipoCobertura = Texto(x.TipoCobertura), MontoAsegurado = x.MontoAsegurado,
                PrimaTotal = x.PrimaTotal, Deducible = x.Deducible, FecVigencia = x.FecVigencia,
                FecProximoMantto = x.FecProximoMantto, FecUltMantto = x.FecUltMantto, PeriodoMantto = x.PeriodoMantto,
                CostoMantto = x.CostoMantto, Responsable = Texto(x.Responsable)
            };
        }
    }
}
