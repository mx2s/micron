using Core.DL.Model;
using UserModel = BaseFramework.DL.Model.User.User;

namespace BaseFramework.DL.Repository.User {
    public class UserRepository : ModelRepository {
        public static UserModel Find(int id) {
            return UserModel.Find(id);
        }

        public static UserModel FindByEmail(string email) {
            return UserModel.FindByEmail(email);
        }

        public static void Create(string email, string login, string password) {
            UserModel.Create(email, login, password);
        }
    }
}