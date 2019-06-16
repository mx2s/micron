using System.Data;
using Core.DL.Module.Config;
using Npgsql;

namespace Core.DL.Module.Db {
    public class DbConnection {
        private readonly IDbConnection _connection;

        private static DbConnection _instance;

        private DbConnection() {
            _connection = new NpgsqlConnection(AppConfig.Get().GetConnectionString());
        }

        public static DbConnection Get() {
            if (_instance == null) {
                return _instance = new DbConnection();
            }

            return _instance;
        }

        public static IDbConnection Connection() => Get()._connection;
    }
}