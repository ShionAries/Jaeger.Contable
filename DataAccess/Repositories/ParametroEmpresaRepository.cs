using System;
using System.Threading.Tasks;
using SqlSugar;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    public sealed class ParametroEmpresaRepository : IParametroEmpresaRepository {
        private readonly MariaDbContext _context;
        public ParametroEmpresaRepository(MariaDbContext context) { _context = context ?? throw new ArgumentNullException(nameof(context)); }
        public async Task<ParametroEmpresa> ObtenerAsync(int idEmpresa) {
            if (idEmpresa <= 0)
                throw new ArgumentOutOfRangeException(nameof(idEmpresa));
            try {
                var x = await _context.Db.Queryable<ParamempEntity>().Where(p => p.IdEmp == idEmpresa).FirstAsync();
                if (x == null)
                    throw new InvalidOperationException("No existe PARAMEMP para la empresa indicada.");
                return new ParametroEmpresa {
                    IDEMP = x.IdEmp,
                    DIGCTA1 = x.DigCta1 ?? 0,
                    DIGCTA2 = x.DigCta2 ?? 0,
                    DIGCTA3 = x.DigCta3 ?? 0,
                    DIGCTA4 = x.DigCta4 ?? 0,
                    DIGCTA5 = x.DigCta5 ?? 0,
                    DIGCTA6 = x.DigCta6 ?? 0,
                    DIGCTA7 = x.DigCta7 ?? 0,
                    DIGCTA8 = x.DigCta8 ?? 0,
                    DIGCTA9 = x.DigCta9 ?? 0,
                    NIVELACTU = x.NivelActu ?? 0,
                    GUION_SINO = x.GuionSiNo,
                    CONTABLINEA = x.ContabLinea
                };
            } catch (SqlSugarException ex) { throw new InvalidOperationException("Error al consultar PARAMEMP.", ex); }
        }

        public async Task ActualizarEstructuraCuentaAsync(ParametroEmpresa p) {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            try {
                await _context.Db.Updateable<ParamempEntity>()
                    .SetColumns(x => new ParamempEntity {
                        DigCta1 = p.DIGCTA1,
                        DigCta2 = p.DIGCTA2,
                        DigCta3 = p.DIGCTA3,
                        DigCta4 = p.DIGCTA4,
                        DigCta5 = p.DIGCTA5,
                        DigCta6 = p.DIGCTA6,
                        DigCta7 = p.DIGCTA7,
                        DigCta8 = p.DIGCTA8,
                        DigCta9 = p.DIGCTA9,
                        NivelActu = p.NIVELACTU,
                        GuionSiNo = p.GUION_SINO
                    }).Where(x => x.IdEmp == p.IDEMP).ExecuteCommandAsync();
            } catch (SqlSugarException ex) { throw new InvalidOperationException("Error al actualizar la estructura de cuentas en PARAMEMP.", ex); }
        }
    }
}
