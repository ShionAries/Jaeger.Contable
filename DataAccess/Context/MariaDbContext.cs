using System;
using System.Configuration;
using SqlSugar;

namespace Jaeger.Contable.DataAccess.Context {
    /// <summary>Contexto de acceso a MariaDB mediante SqlSugar.</summary>
    public sealed class MariaDbContext : IDisposable {
        public SqlSugarClient Db { get; private set; }

        public MariaDbContext(string connectionString) {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new System.ArgumentException("La cadena de conexión es obligatoria.", "connectionString");

            this.Db = new SqlSugarClient(new ConnectionConfig {
                ConnectionString = connectionString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }

        public void BeginTransaction() {
            if (Db == null)
                throw new ObjectDisposedException(nameof(MariaDbContext));
            Db.Ado.BeginTran();
        }

        public void CommitTransaction() {
            if (Db == null)
                throw new ObjectDisposedException(nameof(MariaDbContext));
            Db.Ado.CommitTran();
        }

        public void RollbackTransaction() {
            if (Db == null)
                return;
            Db.Ado.RollbackTran();
        }

        public void Dispose() {
            if (Db != null)
                Db.Dispose();
            Db = null;
        }
    }
}
