using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Repository.User;
using Core.DL.Auth;
using Core.DL.Crypto;
using Nancy;
using Newtonsoft.Json.Linq;

namespace BaseFramework.AL.Controller.Auth {
    public sealed class JwtAuthController : NancyModule {
        public JwtAuthController() {
            Get("/api/v1/login", _ => {
                var email = (string) Request.Query["email"];
                var password = (string) Request.Query["password"];

                var user = UserRepository.FindByEmail(email);

                if (user == null) {
                    return HttpResponse.SimpleError("User not found", HttpStatusCode.NotFound);
                }

                if (Encryptor.Encrypt(password) != user.password) {
                    return HttpResponse.SimpleError(
                        "Your email / password combination is incorrect", HttpStatusCode.Unauthorized
                    );
                }

                return HttpResponse.ReturnData(new JObject() {
                    ["token"] = Jwt.FromUserId(user.id)
                });
            });
        }
    }
}