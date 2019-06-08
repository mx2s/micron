using System;
using Microsoft.Extensions.Configuration;

namespace Core.DL.Config {
    public class AppConfig {
        private readonly string _dbHost;
        private readonly int _dbPort;
        private readonly string _dbUser;
        private readonly string _dbPassword;
        private readonly string _dbName;

        private readonly string _jwtSecretKey;
        private readonly int _jwtTokenLifeDays;

        private readonly string _encryptionKey;
        
        private static AppConfig _instance;

        private AppConfig() {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            _jwtSecretKey = config["auth:jwt:secret_key"];
            _jwtTokenLifeDays = Convert.ToInt32(config["auth:jwt:token_life_days"]);

            _encryptionKey = config["auth:encryption_key"];
            
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

        public string GetConnectionString() 
            => $"Host={_dbHost};Username={_dbUser};Password={_dbPassword};Database={_dbName}";

        public string GetJwtSecretKey() => _jwtSecretKey;
        
        public int GetJwtLifeDays() => _jwtTokenLifeDays;
        
        public string GetEncryptionKey() => _encryptionKey;
    }
}