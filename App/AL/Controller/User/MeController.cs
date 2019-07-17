using App.PL.User;
using BaseFramework.DL.Middleware;
using BaseFramework.DL.Middleware.Auth;
using BaseFramework.DL.Module.Controller;
using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Repository.User;

namespace App.AL.Controller.User {
    public class MeController : BaseController {
        protected override IMiddleware[] Middleware() => new IMiddleware[] {
            new JwtMiddleware()
        };
        
        public MeController() {
            Get("/api/v1/me", _ => {
                var me = UserRepository.Find(CurrentRequest.UserId);
                return HttpResponse.Item("user", new UserTransformer().Transform(me));
            });
        }
    }
}