using BaseFramework.DL.Module.Db;
using Dapper;

namespace Tests.Utils.DB {
    public class DbCleaner {
        public static void TruncateAll() {
            var connection = DbConnection.Connection();
            var tables = connection.Query<string>("SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' and table_name <> 'phinxlog'");
            var listOfTables = string.Join(',', tables);

            connection.Execute($"TRUNCATE {listOfTables};");
        }
    }
}
