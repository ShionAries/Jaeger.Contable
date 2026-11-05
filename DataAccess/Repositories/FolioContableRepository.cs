using System;
using System.Threading.Tasks;
using Jaeger.Contable.DataAccess.Context;
using Jaeger.Contable.Domain.Entities;
using SqlSugar;
using Jaeger.Contable.Domain.Interfaces.Repositories;

namespace Jaeger.Contable.DataAccess.Repositories {
    /// <summary>Obtiene y reserva el siguiente folio usando la transacción activa del contexto.</summary>
    public sealed class FolioContableRepository : IFolioContableRepository {
        private readonly MariaDbContext _context;

        public FolioContableRepository(MariaDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<FolioContable> ObtenerSiguienteAsync(string tipoPoliza, short ejercicio, short periodo) {
            string columna = ObtenerColumnaFolio(periodo);
            try {
                string sqlCrear = string.Format(
                    "INSERT INTO FOLIOS (TIPPOL,EJERCICIO) VALUES (@tipo,@ejercicio) ON DUPLICATE KEY UPDATE TIPPOL=TIPPOL");
                await _context.Db.Ado.ExecuteCommandAsync(
                    sqlCrear,
                    new SugarParameter("@tipo", tipoPoliza),
                    new SugarParameter("@ejercicio", ejercicio));

                string sqlBloqueo = string.Format(
                    "SELECT {0} FROM FOLIOS WHERE TIPPOL=@tipo AND EJERCICIO=@ejercicio FOR UPDATE", columna);
                var valor = await _context.Db.Ado.GetScalarAsync(
                    sqlBloqueo,
                    new SugarParameter("@tipo", tipoPoliza),
                    new SugarParameter("@ejercicio", ejercicio));

                int actual = ParsearFolio(valor == null ? null : Convert.ToString(valor), columna);
                int siguiente = actual + 1;
                int maximo = columna == "FOLIO14" ? 9999999 : 99999;
                if (siguiente > maximo)
                    throw new InvalidOperationException(string.Format("Se agotó la numeración disponible para {0}.", columna));

                string nuevo = siguiente.ToString("D" + (columna == "FOLIO14" ? "7" : "5"));
                string sqlActualizar = string.Format(
                    "UPDATE FOLIOS SET {0}=@folio WHERE TIPPOL=@tipo AND EJERCICIO=@ejercicio", columna);
                int afectados = await _context.Db.Ado.ExecuteCommandAsync(
                    sqlActualizar,
                    new SugarParameter("@folio", nuevo),
                    new SugarParameter("@tipo", tipoPoliza),
                    new SugarParameter("@ejercicio", ejercicio));
                if (afectados != 1)
                    throw new InvalidOperationException("No fue posible actualizar el folio contable.");

                return new FolioContable(tipoPoliza, ejercicio, periodo, nuevo);
            }
            catch (SqlSugarException ex) {
                throw new InvalidOperationException("No fue posible obtener el siguiente folio de FOLIOS.", ex);
            }
        }

        private static string ObtenerColumnaFolio(short periodo) {
            return "FOLIO" + periodo.ToString("00");
        }

        private static int ParsearFolio(string valor, string columna) {
            if (string.IsNullOrWhiteSpace(valor))
                return 0;

            int resultado;
            if (!int.TryParse(valor.Trim(), out resultado) || resultado < 0)
                throw new InvalidOperationException(string.Format("El valor '{0}' de {1} no es un folio numérico válido.", valor, columna));
            return resultado;
        }
    }
}
