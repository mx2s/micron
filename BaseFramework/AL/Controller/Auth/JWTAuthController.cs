using BaseFramework.DL.Module.Http;
using Nancy;
using Newtonsoft.Json.Linq;

namespace BaseFramework.AL.Controller.Auth {
    public sealed class JwtAuthController : NancyModule {
        public JwtAuthController() {
            Get("/api/v1/login", _ => {
                var email = Request.Query["email"];
                var password = Request.Query["password"];
                return HttpResponse.Transform(new JObject() {
                    ["data"] = "some data"
                });
            });
        }
    }
}