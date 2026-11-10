using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.DataAccess.Mappers;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    public sealed class CuentaRepository : ICuentaRepository {
        private readonly MariaDbContext _context;

        public CuentaRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<CuentaContable>> ObtenerPorPadreAsync(string ctaPapa) {
            if (string.IsNullOrWhiteSpace(ctaPapa))
                return new List<CuentaContable>();

            try {
                var parent = ctaPapa.Trim();
                var rows = await _context.Db.Queryable<CuentaContableEntity>()
                    .Where(x => x.CtaPapa == parent)
                    .OrderBy(x => x.NumCta)
                    .ToListAsync();

                return rows.Select(CuentaMapper.ToDomain).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar las cuentas hijas.", ex);
            }
        }

        public async Task<CuentaContable> ObtenerPorNumeroAsync(string numeroCuenta) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                return null;

            try {
                var number = numeroCuenta.Trim();
                var row = await _context.Db.Queryable<CuentaContableEntity>()
                    .Where(x => x.NumCta == number)
                    .FirstAsync();

                return CuentaMapper.ToDomain(row);
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar la cuenta en CUENTAS25.", ex);
            }
        }

        public async Task<List<CuentaContable>> ObtenerTodasAsync() {
            try {
                var rows = await _context.Db.Queryable<CuentaContableEntity>()
                    .OrderBy(x => x.NumCta)
                    .ToListAsync();

                return rows.Select(CuentaMapper.ToDomain).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar CUENTAS25.", ex);
            }
        }

        public async Task<List<CuentaContable>> ObtenerActivasAsync() {
            try {
                var rows = await _context.Db.Queryable<CuentaContableEntity>()
                    .Where(x => x.Status == "A")
                    .OrderBy(x => x.NumCta)
                    .ToListAsync();

                return rows.Select(CuentaMapper.ToDomain).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar las cuentas activas.", ex);
            }
        }

        public Task<List<CuentaContable>> ObtenerHijosAsync(string cuentaPapa) {
            return ObtenerPorPadreAsync(cuentaPapa);
        }

        public async Task<List<CuentaContable>> ObtenerRaicesAsync() {
            try {
                var rows = await _context.Db.Queryable<CuentaContableEntity>()
                    .Where(x => x.Nivel == 1)
                    .OrderBy(x => x.NumCta)
                    .ToListAsync();

                return rows.Select(CuentaMapper.ToDomain).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar las cuentas raíz.", ex);
            }
        }

        public async Task<List<RangoConCuentasDto>> ObtenerRangosConCuentasAsync() {
            var rangos = await ObtenerRangosActivosAsync();
            var cuentas = await ObtenerTodasAsync();
            var relaciones = await ObtenerRelacionesAsync();

            return ConstruirRangos(rangos, cuentas, relaciones);
        }

        public async Task<bool> ExisteAsync(string numeroCuenta) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                return false;

            try {
                var number = numeroCuenta.Trim();
                return await _context.Db.Queryable<CuentaContableEntity>()
                    .Where(x => x.NumCta == number)
                    .AnyAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al comprobar la existencia de la cuenta.", ex);
            }
        }

        public async Task<bool> RegistrarNuevaAsync(CuentaContable cuenta, EstructuraCuenta estructura) {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));
            if (estructura == null)
                throw new ArgumentNullException(nameof(estructura));

            var lockName = CrearNombreBloqueo(cuenta.CtaPapa, cuenta.Nivel);
            var parentLockName = CrearNombreBloqueoPadre(cuenta.CtaPapa, cuenta.Nivel);
            var parentLockAcquired = false;
            var createLockAcquired = false;

            try {
                _context.BeginTransaction();

                try {
                    if (cuenta.Nivel > 1) {
                        await AdquirirBloqueoAsync(parentLockName);
                        parentLockAcquired = true;
                    }

                    await AdquirirBloqueoAsync(lockName);
                    createLockAcquired = true;
                } catch {
                    _context.RollbackTransaction();
                    throw;
                }

                try {
                    await PrepararNuevaCuentaAsync(cuenta, estructura);

                    var entity = CuentaMapper.ToEntity(cuenta);
                    var inserted = await _context.Db.Insertable(entity).ExecuteCommandAsync();
                    if (inserted <= 0) {
                        _context.RollbackTransaction();
                        return false;
                    }

                    _context.CommitTransaction();
                    return true;
                } catch {
                    _context.RollbackTransaction();
                    throw;
                } finally {
                    if (createLockAcquired)
                        await LiberarBloqueoAsync(lockName);
                    if (parentLockAcquired)
                        await LiberarBloqueoAsync(parentLockName);
                }
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible registrar la nueva cuenta en CUENTAS25.", ex);
            }
        }

        public async Task<bool> RegistrarNuevaEnRangoAsync(CuentaContable cuenta, EstructuraCuenta estructura, int rango) {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));
            if (estructura == null)
                throw new ArgumentNullException(nameof(estructura));
            if (rango <= 0)
                throw new ArgumentOutOfRangeException(nameof(rango));

            var lockName = CrearNombreBloqueo(cuenta.CtaPapa, cuenta.Nivel);
            var parentLockName = CrearNombreBloqueoPadre(cuenta.CtaPapa, cuenta.Nivel);
            var parentLockAcquired = false;
            var createLockAcquired = false;

            try {
                _context.BeginTransaction();

                try {
                    if (cuenta.Nivel > 1) {
                        await AdquirirBloqueoAsync(parentLockName);
                        parentLockAcquired = true;
                    }

                    await AdquirirBloqueoAsync(lockName);
                    createLockAcquired = true;
                } catch {
                    _context.RollbackTransaction();
                    throw;
                }

                try {
                    await PrepararNuevaCuentaAsync(cuenta, estructura);

                    var inserted = await _context.Db.Insertable(CuentaMapper.ToEntity(cuenta)).ExecuteCommandAsync();
                    if (inserted <= 0) {
                        _context.RollbackTransaction();
                        return false;
                    }

                    var rangoExiste = await _context.Db.Queryable<RubroContableEntity>()
                        .Where(x => x.Rango == rango)
                        .AnyAsync();
                    if (!rangoExiste)
                        throw new InvalidOperationException("El rango seleccionado no existe.");

                    var relacion = await _context.Db.Queryable<CuentaRubroContableEntity>()
                        .Where(x => x.Rubro == rango && x.Cuenta == cuenta.NumCta)
                        .FirstAsync();

                    if (relacion != null)
                        throw new InvalidOperationException("La cuenta ya está asociada al rango seleccionado.");

                    var segPapa = await ObtenerSegPapaAsync(cuenta, estructura);
                    var insertedRelation = await _context.Db.Insertable(new CuentaRubroContableEntity {
                        Rubro = rango,
                        Cuenta = cuenta.NumCta,
                        SegPapa = segPapa
                    }).ExecuteCommandAsync();

                    if (insertedRelation <= 0) {
                        _context.RollbackTransaction();
                        return false;
                    }

                    _context.CommitTransaction();
                    return true;
                } catch {
                    _context.RollbackTransaction();
                    throw;
                } finally {
                    if (createLockAcquired)
                        await LiberarBloqueoAsync(lockName);
                    if (parentLockAcquired)
                        await LiberarBloqueoAsync(parentLockName);
                }
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    string.Format("No fue posible registrar la cuenta y asociarla al rango {0}.", rango), ex);
            }
        }

        private async Task<string> ObtenerSegPapaAsync(CuentaContable cuenta, EstructuraCuenta estructura) {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));
            if (estructura == null)
                throw new ArgumentNullException(nameof(estructura));

            if (cuenta.Nivel <= 1)
                return estructura.ObtenerCuentaLogicaDesdeFisica(cuenta.NumCta);

            var padre = await _context.Db.Queryable<CuentaContableEntity>()
                .Where(x => x.NumCta == cuenta.CtaPapa)
                .FirstAsync();

            if (padre == null)
                throw new InvalidOperationException(
                    "No fue posible determinar SEGPAPA porque la cuenta padre no existe.");

            return estructura.ObtenerCuentaLogicaDesdeFisica(padre.NumCta);
        }

        private async Task PrepararNuevaCuentaAsync(CuentaContable cuenta, EstructuraCuenta estructura) {
            if (cuenta.Nivel < 1 || cuenta.Nivel > estructura.NivelActual)
                throw new ArgumentOutOfRangeException(nameof(cuenta.Nivel),
                    "El nivel de la cuenta no está habilitado en PARAMEMP.");

            CuentaContable padre = null;
            if (cuenta.Nivel == 1) {
                cuenta.CtaPapa = "-1";
            } else {
                if (string.IsNullOrWhiteSpace(cuenta.CtaPapa))
                    throw new ArgumentException("La cuenta padre es obligatoria.", nameof(cuenta.CtaPapa));

                padre = await ObtenerPorNumeroAsync(cuenta.CtaPapa);
                if (padre == null)
                    throw new InvalidOperationException("La cuenta padre no existe.");
                if (!string.Equals(padre.Tipo, "A", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("La cuenta padre debe ser acumulativa.");
                if (!string.Equals(padre.Status, "A", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("La cuenta padre debe estar activa para registrar una cuenta hija.");
                if (padre.Nivel + 1 != cuenta.Nivel)
                    throw new InvalidOperationException("El nivel de la cuenta no corresponde al nivel de su padre.");
            }

            var generador = new GeneradorNumeroCuenta(estructura);
            var existentes = cuenta.Nivel == 1
                ? await ObtenerRaicesAsync()
                : await ObtenerPorPadreAsync(padre.NumCta);

            cuenta.NumCta = generador.Generar(existentes, padre, cuenta.Nivel);
            cuenta.CtaPapa = cuenta.Nivel == 1
                ? "-1"
                : estructura.NormalizarFisica(padre.NumCta);
            cuenta.CtaRaiz = cuenta.Nivel == 1
                ? cuenta.NumCta
                : estructura.NormalizarFisica(padre.CtaRaiz);

            if (await ExisteAsync(cuenta.NumCta))
                throw new InvalidOperationException(
                    string.Format("La cuenta generada '{0}' ya existe.", cuenta.NumCta));
        }

        private static string CrearNombreBloqueo(string cuentaPapa, short nivel) {
            var papa = string.IsNullOrWhiteSpace(cuentaPapa) ? "-1" : cuentaPapa.Trim();
            return string.Format("jaeger:cuentas25:{0}:{1}", papa, nivel);
        }

        private static string CrearNombreBloqueoPadre(string cuentaPapa, short nivel) {
            if (nivel <= 1 || string.IsNullOrWhiteSpace(cuentaPapa))
                return string.Empty;

            return string.Format("jaeger:cuentas25:status:{0}", cuentaPapa.Trim());
        }

        private async Task AdquirirBloqueoAsync(string lockName) {
            var result = await _context.Db.Ado.SqlQueryAsync<int>(
                "SELECT GET_LOCK(@lockName, 15);",
                new SugarParameter("@lockName", lockName));

            if (result == null || result.Count == 0 || result[0] != 1)
                throw new TimeoutException("No fue posible obtener el bloqueo para generar el número de cuenta.");
        }

        private async Task LiberarBloqueoAsync(string lockName) {
            try {
                await _context.Db.Ado.ExecuteCommandAsync(
                    "SELECT RELEASE_LOCK(@lockName);",
                    new SugarParameter("@lockName", lockName));
            } catch (SqlSugarException) {
            }
        }

        public async Task<bool> ActualizarAsync(CuentaContable cuenta) {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));
            if (string.IsNullOrWhiteSpace(cuenta.NumCta))
                throw new ArgumentException("El número de cuenta es obligatorio.", nameof(cuenta));

            var numero = cuenta.NumCta.Trim();
            var lockName = string.Format("jaeger:cuentas25:update:{0}", numero);

            try {
                _context.BeginTransaction();
                await AdquirirBloqueoAsync(lockName);

                try {
                    var actual = await _context.Db.Queryable<CuentaContableEntity>()
                        .Where(x => x.NumCta == numero)
                        .FirstAsync();

                    if (actual == null)
                        throw new InvalidOperationException("La cuenta no existe en CUENTAS25.");

                    if (cuenta.Nivel != (actual.Nivel ?? 0) ||
                        !string.Equals(Normalizar(cuenta.CtaPapa), Normalizar(actual.CtaPapa), StringComparison.Ordinal))
                        throw new InvalidOperationException(
                            "El número, nivel y cuenta padre de una cuenta existente no pueden modificarse.");

                    var tipoActual = (actual.Tipo ?? string.Empty).Trim().ToUpperInvariant();
                    var tipoNuevo = (cuenta.Tipo ?? string.Empty).Trim().ToUpperInvariant();
                    var naturalezaActual = actual.Naturaleza ?? 0;
                    var naturalezaNueva = cuenta.Naturaleza;

                    if (tipoNuevo != "A" && tipoNuevo != "D")
                        throw new InvalidOperationException("El tipo de cuenta debe ser A o D.");

                    if (tipoNuevo == "D") {
                        var tieneHijos = await _context.Db.Queryable<CuentaContableEntity>()
                            .Where(x => x.CtaPapa == numero)
                            .AnyAsync();

                        if (tieneHijos)
                            throw new InvalidOperationException(
                                "Una cuenta con cuentas hijas no puede convertirse en cuenta de detalle.");
                    }

                    var cambioTipo = !string.Equals(tipoActual, tipoNuevo, StringComparison.Ordinal);
                    var cambioNaturaleza = naturalezaActual != naturalezaNueva;

                    if (cambioTipo || cambioNaturaleza) {
                        var tieneMovimientos = await _context.Db.Queryable<Auxiliar25Entity>()
                            .Where(x => x.NUM_CTA == numero)
                            .AnyAsync();

                        if (tieneMovimientos && cambioTipo)
                            throw new InvalidOperationException(
                                "No se puede cambiar el tipo A/D de una cuenta que tiene movimientos contables en AUXILIAR25.");

                        if (tieneMovimientos && cambioNaturaleza)
                            throw new InvalidOperationException(
                                "No se puede cambiar la naturaleza de una cuenta que tiene movimientos contables en AUXILIAR25.");
                    }

                    var entity = CuentaMapper.ToEntity(cuenta);
                    entity.NumCta = actual.NumCta;
                    entity.CtaPapa = actual.CtaPapa;
                    entity.CtaRaiz = actual.CtaRaiz;
                    entity.Nivel = actual.Nivel;

                    var actualizado = await _context.Db.Updateable(entity)
                        .IgnoreColumns(x => new { x.NumCta, x.CtaPapa, x.CtaRaiz, x.Nivel })
                        .WhereColumns(x => x.NumCta)
                        .ExecuteCommandAsync() > 0;

                    if (!actualizado) {
                        _context.RollbackTransaction();
                        return false;
                    }

                    _context.CommitTransaction();
                    return true;
                } catch {
                    _context.RollbackTransaction();
                    throw;
                } finally {
                    await LiberarBloqueoAsync(lockName);
                }
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible actualizar la cuenta.", ex);
            }
        }

        public async Task<bool> CambiarStatusAsync(string numeroCuenta, string status) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException("El número de cuenta es obligatorio.", nameof(numeroCuenta));

            if (string.IsNullOrWhiteSpace(status) || status.Trim().Length != 1)
                throw new ArgumentException("El estatus debe contener exactamente un carácter.", nameof(status));

            var cuenta = numeroCuenta.Trim();
            var nuevoStatus = status.Trim().ToUpperInvariant();
            if (nuevoStatus != "A" && nuevoStatus != "B")
                throw new ArgumentException("El estatus de la cuenta debe ser A o B.", nameof(status));

            var lockName = string.Format("jaeger:cuentas25:status:{0}", cuenta);

            try {
                _context.BeginTransaction();
                await AdquirirBloqueoAsync(lockName);

                try {
                    var entity = await _context.Db.Queryable<CuentaContableEntity>()
                        .Where(x => x.NumCta == cuenta)
                        .FirstAsync();

                    if (entity == null)
                        throw new InvalidOperationException("La cuenta no existe en CUENTAS25.");

                    if (string.Equals(entity.Status, nuevoStatus, StringComparison.OrdinalIgnoreCase)) {
                        _context.CommitTransaction();
                        return true;
                    }

                    if (nuevoStatus == "B") {
                        var tieneMovimientos = await _context.Db.Queryable<Auxiliar25Entity>()
                            .Where(x => x.NUM_CTA == cuenta)
                            .AnyAsync();

                        if (tieneMovimientos)
                            throw new InvalidOperationException(
                                "No se puede desactivar una cuenta que tiene movimientos contables registrados en AUXILIAR25.");

                        var hijosActivos = await _context.Db.Queryable<CuentaContableEntity>()
                            .Where(x => x.CtaPapa == cuenta && x.Status == "A")
                            .AnyAsync();

                        if (hijosActivos)
                            throw new InvalidOperationException(
                                "No se puede desactivar una cuenta que tiene cuentas hijas activas.");
                    } else {
                        if (entity.Nivel > 1 && !string.IsNullOrWhiteSpace(entity.CtaPapa) && entity.CtaPapa != "-1") {
                            var padre = await _context.Db.Queryable<CuentaContableEntity>()
                                .Where(x => x.NumCta == entity.CtaPapa)
                                .FirstAsync();

                            if (padre == null)
                                throw new InvalidOperationException(
                                    "No se puede reactivar la cuenta porque su cuenta padre no existe.");

                            if (!string.Equals(padre.Status, "A", StringComparison.OrdinalIgnoreCase))
                                throw new InvalidOperationException(
                                    "No se puede reactivar la cuenta mientras su cuenta padre esté inactiva.");
                        }
                    }

                    var actualizado = await _context.Db.Updateable<CuentaContableEntity>()
                        .SetColumns(x => x.Status == nuevoStatus)
                        .Where(x => x.NumCta == cuenta)
                        .ExecuteCommandAsync() > 0;

                    if (!actualizado) {
                        _context.RollbackTransaction();
                        return false;
                    }

                    _context.CommitTransaction();
                    return true;
                } catch {
                    _context.RollbackTransaction();
                    throw;
                } finally {
                    await LiberarBloqueoAsync(lockName);
                }
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible cambiar el estatus de la cuenta.", ex);
            }
        }

        public async Task<List<RubroContableModel>> ObtenerRangosActivosAsync() {
            try {
                var rows = await _context.Db.Queryable<RubroContableEntity>()
                    .OrderBy(x => x.Rango)
                    .ToListAsync();

                return rows.Select(x => new RubroContableModel {
                    Rango = x.Rango,
                    Descripcion = x.Descripcion
                }).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar RANGOS.", ex);
            }
        }

        public async Task<List<RangoCuentaModel>> Lista1() {
            var rangos = await ObtenerRangosActivosAsync();
            var cuentas = await ObtenerTodasAsync();
            var relaciones = await ObtenerRelacionesAsync();
            var resultado = new List<RangoCuentaModel>();

            var cuentasPorNumero = cuentas
                .Where(x => x != null && !string.IsNullOrWhiteSpace(x.NumCta))
                .GroupBy(x => x.NumCta.Trim(), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => x.First(), StringComparer.Ordinal);

            var hijos = cuentasPorNumero.Values
                .Where(x => !string.IsNullOrWhiteSpace(x.CtaPapa) && x.CtaPapa.Trim() != "-1")
                .GroupBy(x => x.CtaPapa.Trim(), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => x.ToList(), StringComparer.Ordinal);

            foreach (var rango in rangos) {
                var incluidos = new HashSet<string>(StringComparer.Ordinal);

                foreach (var relacion in relaciones.Where(x => x.Rubro == rango.Rango)) {
                    AgregarCuentaYJerarquia(
                        relacion.Cuenta,
                        cuentasPorNumero,
                        hijos,
                        incluidos);
                }

                foreach (var numero in incluidos) {
                    CuentaContable cuenta;
                    if (!cuentasPorNumero.TryGetValue(numero, out cuenta))
                        continue;

                    resultado.Add(new RangoCuentaModel {
                        NumCta = cuenta.NumCta,
                        Status = cuenta.Status,
                        Tipo = cuenta.Tipo,
                        Nombre = cuenta.Nombre,
                        DeptoSiNo = cuenta.DeptoSiNo,
                        BandMulti = cuenta.BandMulti,
                        BandAjt = cuenta.BandAjt,
                        CtaPapa = cuenta.CtaPapa,
                        CtaRaiz = cuenta.CtaRaiz,
                        Nivel = cuenta.Nivel,
                        CtaComp = cuenta.CtaComp,
                        Naturaleza = cuenta.Naturaleza,
                        RFC = cuenta.RFC,
                        CodAgrup = cuenta.CodAgrup,
                        CapturaCheque = cuenta.CapturaCheque,
                        CapturaUUID = cuenta.CapturaUUID,
                        Banco = cuenta.Banco,
                        CtaBancaria = cuenta.CtaBancaria,
                        CapturaChequeTipoMovimiento = cuenta.CapturaChequeTipoMovimiento,
                        NoIncluirXML = cuenta.NoIncluirXML,
                        IdFiscal = cuenta.IdFiscal,
                        EsFlujoEfectivo = cuenta.EsFlujoEfectivo,
                        BancoExtranjero = cuenta.BancoExtranjero,
                        RfcFlujo = cuenta.RfcFlujo,
                        Rango = rango.Rango,
                        Descripcion = rango.Descripcion
                    });
                }
            }

            return resultado
                .OrderBy(x => x.Rango)
                .ThenBy(x => x.Nivel)
                .ThenBy(x => x.NumCta)
                .ToList();
        }

        private async Task<List<RelacionRangoCuenta>> ObtenerRelacionesAsync() {
            try {
                var rows = await _context.Db.Queryable<CuentaRubroContableEntity>().ToListAsync();
                return rows.Select(x => new RelacionRangoCuenta {
                    Rubro = x.Rubro,
                    Cuenta = Normalizar(x.Cuenta)
                }).Where(x => !string.IsNullOrWhiteSpace(x.Cuenta)).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar CTARUB.", ex);
            }
        }

        private static List<RangoConCuentasDto> ConstruirRangos(
            IEnumerable<RubroContableModel> rangos,
            IEnumerable<CuentaContable> cuentas,
            IEnumerable<RelacionRangoCuenta> relaciones) {

            var cuentasPorNumero = cuentas
                .Where(x => x != null && !string.IsNullOrWhiteSpace(x.NumCta))
                .GroupBy(x => Normalizar(x.NumCta), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => x.First(), StringComparer.Ordinal);

            var hijos = cuentasPorNumero.Values
                .Where(x => !string.IsNullOrWhiteSpace(x.CtaPapa) && Normalizar(x.CtaPapa) != "-1")
                .GroupBy(x => Normalizar(x.CtaPapa), StringComparer.Ordinal)
                .ToDictionary(x => x.Key, x => x.ToList(), StringComparer.Ordinal);

            var result = new List<RangoConCuentasDto>();

            foreach (var rango in rangos) {
                var incluidos = new HashSet<string>(StringComparer.Ordinal);

                foreach (var relacion in relaciones.Where(x => x.Rubro == rango.Rango))
                    AgregarCuentaYJerarquia(relacion.Cuenta, cuentasPorNumero, hijos, incluidos);

                result.Add(new RangoConCuentasDto {
                    Rango = rango.Rango,
                    Descripcion = rango.Descripcion,
                    CuentasAsociadas = incluidos
                        .Where(cuentasPorNumero.ContainsKey)
                        .Select(x => cuentasPorNumero[x])
                        .OrderBy(x => x.Nivel)
                        .ThenBy(x => x.NumCta)
                        .ToList()
                });
            }

            return result;
        }

        private static void AgregarCuentaYJerarquia(
            string numero,
            IDictionary<string, CuentaContable> cuentas,
            IDictionary<string, List<CuentaContable>> hijos,
            ISet<string> incluidos) {

            numero = Normalizar(numero);
            if (string.IsNullOrWhiteSpace(numero) || !cuentas.ContainsKey(numero))
                return;

            var actual = numero;
            var guard = 0;
            while (!string.IsNullOrWhiteSpace(actual) && actual != "-1" && guard++ < 10) {
                if (!cuentas.ContainsKey(actual))
                    break;

                if (!incluidos.Add(actual))
                    break;

                actual = Normalizar(cuentas[actual].CtaPapa);
            }

            AgregarDescendientes(numero, hijos, incluidos);
        }

        private static void AgregarDescendientes(
            string padre,
            IDictionary<string, List<CuentaContable>> hijos,
            ISet<string> incluidos) {

            List<CuentaContable> lista;
            if (!hijos.TryGetValue(padre, out lista))
                return;

            foreach (var hijo in lista) {
                var numero = Normalizar(hijo.NumCta);
                if (!incluidos.Add(numero))
                    continue;

                AgregarDescendientes(numero, hijos, incluidos);
            }
        }

        public async Task<bool> DesasociarCuentaRangoAsync(string numeroCuenta, int rango) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException("La cuenta es obligatoria.", nameof(numeroCuenta));
            if (rango <= 0)
                throw new ArgumentOutOfRangeException(nameof(rango));

            var cuenta = numeroCuenta.Trim();
            var lockName = CrearNombreBloqueoRango(cuenta, rango);

            try {
                _context.BeginTransaction();
                await AdquirirBloqueoAsync(lockName);

                try {
                    var existeCuenta = await _context.Db.Queryable<CuentaContableEntity>()
                        .Where(x => x.NumCta == cuenta)
                        .AnyAsync();

                    if (!existeCuenta)
                        throw new InvalidOperationException("La cuenta no existe en CUENTAS25.");

                    var existeRango = await _context.Db.Queryable<RubroContableEntity>()
                        .Where(x => x.Rango == rango)
                        .AnyAsync();

                    if (!existeRango)
                        throw new InvalidOperationException("El rango no existe.");

                    var eliminado = await _context.Db.Deleteable<CuentaRubroContableEntity>()
                        .Where(x => x.Rubro == rango && x.Cuenta == cuenta)
                        .ExecuteCommandAsync() > 0;

                    _context.CommitTransaction();
                    return eliminado;
                } catch {
                    _context.RollbackTransaction();
                    throw;
                } finally {
                    await LiberarBloqueoAsync(lockName);
                }
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible desasociar la cuenta del rango.", ex);
            }
        }

        private static string Normalizar(string value) {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
        }

        private sealed class RelacionRangoCuenta {
            public int Rubro { get; set; }
            public string Cuenta { get; set; }
        }

        public async Task<List<RubroContableModel>> ObtenerRangosPorCuentaAsync(string numeroCuenta) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                return new List<RubroContableModel>();

            try {
                var cuenta = numeroCuenta.Trim();
                var relaciones = await _context.Db.Queryable<CuentaRubroContableEntity>()
                    .Where(x => x.Cuenta == cuenta)
                    .ToListAsync();

                if (relaciones.Count == 0)
                    return new List<RubroContableModel>();

                var rubros = relaciones.Select(x => x.Rubro).Distinct().ToList();
                var rangos = await _context.Db.Queryable<RubroContableEntity>()
                    .Where(x => rubros.Contains(x.Rango))
                    .OrderBy(x => x.Rango)
                    .ToListAsync();

                return rangos.Select(x => new RubroContableModel {
                    Rango = x.Rango,
                    Descripcion = x.Descripcion
                }).ToList();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("Error al consultar los rangos asociados a la cuenta.", ex);
            }
        }

        public async Task<bool> AsociarCuentaRangoAsync(string numeroCuenta, int rango, string segPapa) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException("La cuenta es obligatoria.", nameof(numeroCuenta));
            if (rango <= 0)
                throw new ArgumentOutOfRangeException(nameof(rango));
            if (string.IsNullOrWhiteSpace(segPapa))
                throw new ArgumentException("SEGPAPA es obligatorio.", nameof(segPapa));

            var cuenta = numeroCuenta.Trim();
            var segmentoPadre = segPapa.Trim();
            var lockName = CrearNombreBloqueoRango(cuenta, rango);

            try {
                _context.BeginTransaction();
                await AdquirirBloqueoAsync(lockName);

                try {
                    var cuentaEntity = await _context.Db.Queryable<CuentaContableEntity>()
                        .Where(x => x.NumCta == cuenta)
                        .FirstAsync();

                    if (cuentaEntity == null)
                        throw new InvalidOperationException("La cuenta no existe en CUENTAS25.");

                    if (!string.Equals(cuentaEntity.Status, "A", StringComparison.OrdinalIgnoreCase))
                        throw new InvalidOperationException("No se puede asociar una cuenta inactiva a un rango.");

                    var existeRango = await _context.Db.Queryable<RubroContableEntity>()
                        .Where(x => x.Rango == rango)
                        .AnyAsync();

                    if (!existeRango)
                        throw new InvalidOperationException("El rango no existe.");

                    var existente = await _context.Db.Queryable<CuentaRubroContableEntity>()
                        .Where(x => x.Rubro == rango && x.Cuenta == cuenta)
                        .FirstAsync();

                    if (existente != null) {
                        if (string.Equals(
                            Normalizar(existente.SegPapa),
                            segmentoPadre,
                            StringComparison.Ordinal)) {
                            _context.CommitTransaction();
                            return false;
                        }

                        existente.SegPapa = segmentoPadre;
                        var actualizado = await _context.Db.Updateable(existente)
                            .WhereColumns(x => new { x.Rubro, x.Cuenta })
                            .ExecuteCommandAsync() > 0;

                        _context.CommitTransaction();
                        return actualizado;
                    }

                    var insertado = await _context.Db.Insertable(new CuentaRubroContableEntity {
                        Rubro = rango,
                        Cuenta = cuenta,
                        SegPapa = segmentoPadre
                    }).ExecuteCommandAsync() > 0;

                    _context.CommitTransaction();
                    return insertado;
                } catch {
                    _context.RollbackTransaction();
                    throw;
                } finally {
                    await LiberarBloqueoAsync(lockName);
                }
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible asociar la cuenta al rango.", ex);
            }
        }

        private static string CrearNombreBloqueoRango(string numeroCuenta, int rango) {
            return string.Format(
                "jaeger:ctarub:{0}:{1}",
                numeroCuenta.Trim(),
                rango);
        }
    }
}
