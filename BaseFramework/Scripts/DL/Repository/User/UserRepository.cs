using Core.DL.Model;
using UserModel = BaseFramework.Scripts.DL.Model.User.User;

namespace BaseFramework.Scripts.DL.Repository.User {
    public class UserRepository : ModelRepository {
        public static UserModel Find(int id) => UserModel.Find(id);

        public static UserModel FindByEmail(string email) => UserModel.FindByEmail(email);

        public static void Create() {
        }
    }
}