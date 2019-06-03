using System;
using Microsoft.Extensions.Configuration;

namespace Core.DL.Config {
    public class AppConfig {
        private readonly string _dbHost;
        private readonly int _dbPort;
        private readonly string _dbUser;
        private readonly string _dbPassword;
        private readonly string _dbName;
        
        private static AppConfig _instance;

        private AppConfig() {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            _dbName = config["database:name"];
            _dbHost = config["database:host"];
            _dbPort = Convert.ToInt32(config["database:port"]);
            _dbUser = config["database:user"];
            _dbPassword = config["database:password"];
        }

        public static AppConfig Get() {
            if (_instance == null) {
                _instance = new AppConfig();
            }
            return _instance;
        }

        public string GetConnectionString() {
            return $"Host={_dbHost};Username={_dbUser};Password={_dbPassword};Database={_dbName}";
        }
    }
}