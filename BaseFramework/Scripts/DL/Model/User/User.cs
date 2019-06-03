using System;
using System.Linq;
using Dapper;

// ReSharper disable InconsistentNaming

namespace BaseFramework.Scripts.DL.Model.User {
    public class User : Core.DL.Model.Model {

        public int id;

        public string login;

        public string password;

        public string email;

        public DateTime register_date;

        public static int Count() => ExecuteScalarInt("SELECT count(*) FROM users WHERE id = @id LIMIT 1");

        public static void Create(string email, string login, string password)
            => ExecuteSql(
                "INSERT INTO public.users(email, login, password) VALUES (@email, @login, @password)"
                , new {email, login, password}
            );

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
    }
}