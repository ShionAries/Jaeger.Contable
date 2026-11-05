using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SqlSugar;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>
    /// Lee la estructura contable desde PARAMEMP.
    /// </summary>
    public sealed class ConfiguracionCuentaRepository : IConfiguracionCuentaRepository {
        private MariaDbContext context;

        public ConfiguracionCuentaRepository(MariaDbContext context) {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ConfiguracionNiveles> ObtenerAsync(int idEmpresa) {
            try {
                var entity = await context.Db.Queryable<ParamempEntity>()
                        .Where(x => x.IdEmp == idEmpresa)
                    .FirstAsync();

                if (entity == null)
                    throw new InvalidOperationException("No existe la configuración de la empresa en PARAMEMP.");

                var digitos = new List<int> {
                        entity.DigCta1 ?? 0, entity.DigCta2 ?? 0, entity.DigCta3 ?? 0,
                        entity.DigCta4 ?? 0, entity.DigCta5 ?? 0, entity.DigCta6 ?? 0,
                        entity.DigCta7 ?? 0, entity.DigCta8 ?? 0, entity.DigCta9 ?? 0
                };

                var nivel = entity.NivelActu ?? 0;
                if (nivel < 1 || nivel > 9)
                    throw new InvalidOperationException("NIVELACTU de PARAMEMP no contiene un nivel válido.");

                var usarGuiones = string.Equals((entity.GuionSiNo ?? string.Empty).Trim(), "S", StringComparison.OrdinalIgnoreCase);
                return new ConfiguracionNiveles(digitos, usarGuiones, nivel);
            } catch (InvalidOperationException) {
                throw;
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible consultar la configuración de cuentas en PARAMEMP.", ex);
            }
        }
    }
}
