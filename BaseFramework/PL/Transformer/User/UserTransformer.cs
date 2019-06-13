using System;
using Core.PL.Transformer;
using Newtonsoft.Json.Linq;
using UserModel = BaseFramework.DL.Model.User.User;

namespace BaseFramework.PL.Transformer.User {
    public class UserTransformer : BaseTransformer {
        public override JObject Transform(Object obj) {
            var item = (UserModel) obj;
            return new JObject {
                ["guid"] = item.id,
                ["login"] = item.login,
                ["email"] = item.email,
                ["register_date"] = item.register_date
            };
        }
    }
}