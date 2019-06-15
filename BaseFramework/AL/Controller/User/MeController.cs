using BaseFramework.DL.Middleware;
using BaseFramework.DL.Middleware.Auth;
using BaseFramework.DL.Module.Controller;
using BaseFramework.PL.Transformer.User;
using Core.DL.Module.Http;
using UserModel = BaseFramework.DL.Model.User.User;

namespace BaseFramework.AL.Controller.User {
    public class MeController : BaseController {
        protected override IMiddleware[] Middleware() => new IMiddleware[] {
            new JwtMiddleware()
        };
        
        public MeController() {
            Get("/api/v1/me", _ => {
                return HttpResponse.Item("user", new UserTransformer().Transform(CurrentRequest.User));
            });
        }
    }
}