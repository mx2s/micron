using System.Data;
using BaseFramework.Scripts.DL.Module.Config;
using Npgsql;

namespace BaseFramework.Scripts.DL.Module.DB {
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