using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Repository.User;
using Core.DL.Middleware;
using Core.DL.Module.Auth;
using Nancy;

namespace BaseFramework.DL.Middleware.Auth {
    public class JwtMiddleware : IMiddleware {
        public ProcessedRequest Process(ProcessedRequest request) {
            var userId = Jwt.GetUserIdFromToken((string) request.Request.Query["api_token"] ?? "");

            var user = UserRepository.Find(userId);

            if (user != null) {
                request.User = user;
            }
            else {
                request.PushError(
                    new MiddlewareError(HttpStatusCode.Unauthorized, "Invalid api_token")
                );
            }

            return request;
        }
    }
}