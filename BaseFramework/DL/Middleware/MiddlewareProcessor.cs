using BaseFramework.DL.Module.Http;
using Core.DL.Module.Http;

namespace BaseFramework.DL.Middleware {
    public static class MiddlewareProcessor {
        public static HttpError Process(ProcessedRequest request, IMiddleware[] middleware) {
            foreach (var m in middleware) {
                m.Process(request);
                if (request.HasErrors()) {
                    return request.FirstError;
                }
            }
            return null;
        }
    }
}