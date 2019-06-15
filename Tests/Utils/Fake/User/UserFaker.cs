using System;
using BaseFramework.DL.Repository.User;
using UserModel = BaseFramework.DL.Model.User.User;

namespace Tests.Utils.Fake.User {
    public static class UserFaker {
        public static UserModel Create() {
            var rand = new Random();
            var email = $"email-{rand.Next(1, 99999)}@mail.com";
            UserModel.Create(
                email,
                $"some-login-{rand.Next(1,99999)}",
                Guid.NewGuid().ToString()
            );
            return UserRepository.FindByEmail(email);
        }
    }
}