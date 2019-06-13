using BaseFramework.DL.Middleware;
using BaseFramework.DL.Middleware.Auth;
using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Repository.User;
using BaseFramework.PL.Transformer.User;
using UserModel = BaseFramework.DL.Model.User.User;

namespace BaseFramework.AL.Controller.User {
    public class MeController : BaseController {
        public MeController() {
            Get("/api/v1/me", _ => {
                var middleware = ProcessMiddleware(Request, new IMiddleware[] {new JwtMiddleware()});

                if (middleware.HasErrors()) {
                    return HttpResponse.SimpleError(middleware.FirstError);
                }

                var user = UserRepository.Find(1);
                
                return HttpResponse.SimpleReturnItem("user", new UserTransformer().Transform(user));
            });
        }
    }
}