using System;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.DataAccess.Entities;
using Jaeger.Contable.Domain.Entities;
using Jaeger.Contable.Domain.Interfaces.Repositories;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Consulta la actividad contable de una cuenta en un ejercicio determinado.</summary>
    public sealed class EstadoContableCuentaRepository : IEstadoContableCuentaRepository {
        private readonly MariaDbContext _context;
        private readonly IEjercicioContableTableResolver _tableResolver;

        public EstadoContableCuentaRepository(
            MariaDbContext context,
            IEjercicioContableTableResolver tableResolver) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tableResolver = tableResolver ?? throw new ArgumentNullException(nameof(tableResolver));
        }

        public Task<EstadoContableCuenta> ObtenerEstadoAsync(string numeroCuenta) {
            return ObtenerAsync(numeroCuenta, 25);
        }

        public Task<EstadoContableCuenta> ObtenerAsync(string numeroCuenta) {
            return ObtenerAsync(numeroCuenta, 25);
        }

        public Task<EstadoContableCuenta> ObtenerEstadoAsync(string numeroCuenta, short ejercicio) {
            return ObtenerAsync(numeroCuenta, ejercicio);
        }

        public async Task<EstadoContableCuenta> ObtenerAsync(string numeroCuenta, short ejercicio) {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException("El número de cuenta es obligatorio.", nameof(numeroCuenta));

            if (ejercicio < 1 || ejercicio > 99)
                throw new ArgumentOutOfRangeException(nameof(ejercicio));

            var numero = numeroCuenta.Trim();

            try {
                var tablaAuxiliar = _tableResolver.ObtenerTablaAuxiliar(ejercicio);
                var tablaSaldos = _tableResolver.ObtenerTablaSaldos(ejercicio);
                var tablaSaldosDp = _tableResolver.ObtenerTablaSaldosDepartamentales(ejercicio);

                var tieneMovimientos = await _context.Db
                    .Queryable<Auxiliar25Entity>()
                    .AS(tablaAuxiliar)
                    .Where(x => x.NUM_CTA == numero && x.EJERCICIO == ejercicio)
                    .AnyAsync();

                var tieneSaldos = await _context.Db
                    .Queryable<SaldosEntity>()
                    .AS(tablaSaldos)
                    .Where(x => x.NUM_CTA == numero && x.EJERCICIO == ejercicio)
                    .Where(ActividadSaldosSql)
                    .AnyAsync();

                var tieneSaldosDepartamentales = await _context.Db
                    .Queryable<SaldosDp25Entity>()
                    .AS(tablaSaldosDp)
                    .Where(x => x.NUM_CTA == numero && x.EJERCICIO == ejercicio)
                    .Where(ActividadSaldosSql)
                    .AnyAsync();

                return new EstadoContableCuenta {
                    NumeroCuenta = numero,
                    TieneMovimientos = tieneMovimientos,
                    TieneSaldos = tieneSaldos,
                    TieneSaldosDepartamentales = tieneSaldosDepartamentales
                };
            } catch (SqlSugarException ex) {
                throw new InvalidOperationException(
                    "No fue posible consultar el estado contable de la cuenta.", ex);
            }
        }

        private const string ActividadSaldosSql =
            "INICIAL <> 0 OR INICIALEX <> 0 " +
            "OR CARGO01 <> 0 OR ABONO01 <> 0 OR CARGOEX01 <> 0 OR ABONOEX01 <> 0 " +
            "OR CARGO02 <> 0 OR ABONO02 <> 0 OR CARGOEX02 <> 0 OR ABONOEX02 <> 0 " +
            "OR CARGO03 <> 0 OR ABONO03 <> 0 OR CARGOEX03 <> 0 OR ABONOEX03 <> 0 " +
            "OR CARGO04 <> 0 OR ABONO04 <> 0 OR CARGOEX04 <> 0 OR ABONOEX04 <> 0 " +
            "OR CARGO05 <> 0 OR ABONO05 <> 0 OR CARGOEX05 <> 0 OR ABONOEX05 <> 0 " +
            "OR CARGO06 <> 0 OR ABONO06 <> 0 OR CARGOEX06 <> 0 OR ABONOEX06 <> 0 " +
            "OR CARGO07 <> 0 OR ABONO07 <> 0 OR CARGOEX07 <> 0 OR ABONOEX07 <> 0 " +
            "OR CARGO08 <> 0 OR ABONO08 <> 0 OR CARGOEX08 <> 0 OR ABONOEX08 <> 0 " +
            "OR CARGO09 <> 0 OR ABONO09 <> 0 OR CARGOEX09 <> 0 OR ABONOEX09 <> 0 " +
            "OR CARGO10 <> 0 OR ABONO10 <> 0 OR CARGOEX10 <> 0 OR ABONOEX10 <> 0 " +
            "OR CARGO11 <> 0 OR ABONO11 <> 0 OR CARGOEX11 <> 0 OR ABONOEX11 <> 0 " +
            "OR CARGO12 <> 0 OR ABONO12 <> 0 OR CARGOEX12 <> 0 OR ABONOEX12 <> 0 " +
            "OR CARGO13 <> 0 OR ABONO13 <> 0 OR CARGOEX13 <> 0 OR ABONOEX13 <> 0 " +
            "OR CARGO14 <> 0 OR ABONO14 <> 0 OR CARGOEX14 <> 0 OR ABONOEX14 <> 0 " +
            "OR MOV01 <> 0 OR MOV02 <> 0 OR MOV03 <> 0 OR MOV04 <> 0 OR MOV05 <> 0 " +
            "OR MOV06 <> 0 OR MOV07 <> 0 OR MOV08 <> 0 OR MOV09 <> 0 OR MOV10 <> 0 " +
            "OR MOV11 <> 0 OR MOV12 <> 0 OR MOV13 <> 0 OR MOV14 <> 0";
    }
}
