using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Repository.User;
using Core.DL.Module.Auth;
using Core.DL.Module.Http;
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
                request.AddError(
                    new HttpError(HttpStatusCode.Unauthorized, "Invalid api_token")
                );
            }

            return request;
        }
    }
}