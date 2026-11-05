using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Consulta datos necesarios para conciliar movimientos y saldos por ejercicio.</summary>
    public sealed class ConciliacionCuentaRepository : IConciliacionCuentaRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public ConciliacionCuentaRepository(
            MariaDbContext context,
            IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public async Task<List<MovimientoCuenta>> ObtenerMovimientosAsync(
            string numeroCuenta, short ejercicio, short periodo) {
            try {
                var tabla = _tableResolver.ObtenerTablaAuxiliar(ejercicio);
                var rows = await _context.Db.Queryable<Auxiliar25Entity>()
                    .AS(tabla)
                    .Where(x => x.NUM_CTA == numeroCuenta &&
                               x.EJERCICIO == ejercicio &&
                               x.PERIODO == periodo)
                    .Select(x => new MovimientoCuenta {
                        NumeroCuenta = x.NUM_CTA,
                        Ejercicio = x.EJERCICIO,
                        Periodo = x.PERIODO,
                        DebeHaber = x.DEBE_HABER,
                        Importe = x.MONTOMOV ?? 0
                    }).ToListAsync();

                return rows;
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar los movimientos para la conciliación.", ex);
            }
        }

        public async Task<SaldosCuenta> ObtenerSaldoAsync(
            string numeroCuenta, short ejercicio, short periodo) {
            try {
                var tabla = _tableResolver.ObtenerTablaSaldos(ejercicio);
                var row = await _context.Db.Queryable<SaldosEntity>()
                    .AS(tabla)
                    .Where(x => x.NUM_CTA == numeroCuenta && x.EJERCICIO == ejercicio)
                    .FirstAsync();

                if (row == null)
                    return new SaldosCuenta();

                return new SaldosCuenta {
                    Cargo = ObtenerCargo(row, periodo),
                    Abono = ObtenerAbono(row, periodo)
                };
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar los saldos para la conciliación.", ex);
            }
        }

        public async Task<bool> TieneSaldosDepartamentalesAsync(
            string numeroCuenta, short ejercicio, short periodo) {
            try {
                var tabla = _tableResolver.ObtenerTablaSaldosDepartamentales(ejercicio);
                return await _context.Db.Queryable<SaldosDp25Entity>()
                    .AS(tabla)
                    .Where(x => x.NUM_CTA == numeroCuenta && x.EJERCICIO == ejercicio)
                    .AnyAsync();
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar los saldos departamentales para la conciliación.", ex);
            }
        }

        private static double ObtenerCargo(SaldosEntity row, short periodo) {
            switch (periodo) {
                case 1: return row.CARGO01 ?? 0; case 2: return row.CARGO02 ?? 0;
                case 3: return row.CARGO03 ?? 0; case 4: return row.CARGO04 ?? 0;
                case 5: return row.CARGO05 ?? 0; case 6: return row.CARGO06 ?? 0;
                case 7: return row.CARGO07 ?? 0; case 8: return row.CARGO08 ?? 0;
                case 9: return row.CARGO09 ?? 0; case 10: return row.CARGO10 ?? 0;
                case 11: return row.CARGO11 ?? 0; case 12: return row.CARGO12 ?? 0;
                case 13: return row.CARGO13 ?? 0; case 14: return row.CARGO14 ?? 0;
                default: throw new ArgumentOutOfRangeException(nameof(periodo));
            }
        }

        private static double ObtenerAbono(SaldosEntity row, short periodo) {
            switch (periodo) {
                case 1: return row.ABONO01 ?? 0; case 2: return row.ABONO02 ?? 0;
                case 3: return row.ABONO03 ?? 0; case 4: return row.ABONO04 ?? 0;
                case 5: return row.ABONO05 ?? 0; case 6: return row.ABONO06 ?? 0;
                case 7: return row.ABONO07 ?? 0; case 8: return row.ABONO08 ?? 0;
                case 9: return row.ABONO09 ?? 0; case 10: return row.ABONO10 ?? 0;
                case 11: return row.ABONO11 ?? 0; case 12: return row.ABONO12 ?? 0;
                case 13: return row.ABONO13 ?? 0; case 14: return row.ABONO14 ?? 0;
                default: throw new ArgumentOutOfRangeException(nameof(periodo));
            }
        }
    }
}
