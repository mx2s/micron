using BaseFramework.PL.Transformer;
using Newtonsoft.Json.Linq;
using UserModel = BaseFramework.DL.Model.User.User;

namespace App.PL.User {
    public class UserTransformer : BaseTransformer {
        public override JObject Transform(object obj) {
            var item = (UserModel) obj;
            return new JObject {
                ["guid"] = item.guid,
                ["login"] = item.login,
                ["email"] = item.email,
                ["register_date"] = item.register_date
            };
        }
    }
}