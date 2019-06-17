using System;
using System.Linq;
using Core.DL.Module.Crypto;
using Dapper;

// ReSharper disable InconsistentNaming

namespace BaseFramework.DL.Model.User {
    public class User : BaseFramework.DL.Model.Model {

        public int id;

        public string guid;

        public string login;

        public string password;

        public string email;

        public DateTime register_date;
        
        public static User Find(int id)
            => Connection().Query<User>(
                "SELECT * FROM users WHERE id = @id LIMIT 1",
                new {id}
            ).FirstOrDefault();

        public static User FindByEmail(string email)
            => Connection().Query<User>(
                "SELECT * FROM users WHERE email = @email LIMIT 1",
                new {email}
            ).FirstOrDefault();

        public static void Create(string email, string login, string password)
            => ExecuteSql(
                "INSERT INTO public.users(guid, email, login, password) VALUES (@guid, @email, @login, @password)"
                , new {guid = Guid.NewGuid().ToString(), email, login, password = Encryptor.Encrypt(password)}
            );
        
        public static int Count() => ExecuteScalarInt("SELECT count(*) FROM users WHERE id = @id");
    }
}