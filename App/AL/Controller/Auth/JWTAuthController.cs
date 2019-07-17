using BaseFramework.DL.Middleware;
using BaseFramework.DL.Module.Auth;
using BaseFramework.DL.Module.Controller;
using BaseFramework.DL.Module.Crypto;
using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Repository.User;
using Nancy;
using Newtonsoft.Json.Linq;

namespace App.AL.Controller.Auth {
    public sealed class JwtAuthController : BaseController {
        protected override IMiddleware[] Middleware() => new IMiddleware[] { };

        public JwtAuthController() {
            Get("/api/v1/login", _ => {
                var email = (string) Request.Query["email"];
                var password = (string) Request.Query["password"];

                var user = UserRepository.FindByEmail(email);

                if (user == null) {
                    return HttpResponse.Error(HttpStatusCode.NotFound, "User not found");
                }

                if (Encryptor.Encrypt(password) != user.password) {
                    return HttpResponse.Error(
                        new HttpError(HttpStatusCode.Unauthorized, "Your email / password combination is incorrect")
                    );
                }

                return HttpResponse.Data(new JObject() {
                    ["token"] = Jwt.FromUserId(user.id)
                });
            });
        }
    }
}