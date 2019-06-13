using BaseFramework.DL.Middleware;
using BaseFramework.DL.Module.Http;
using Nancy;

namespace BaseFramework.AL.Controller {
    public abstract class BaseController : NancyModule {
        public ProcessedRequest ProcessMiddleware(Request request, IMiddleware[] middleware) {
            var processed = new ProcessedRequest(request);

            foreach (var mid in middleware) {
                mid.Process(processed);
                if (processed.HasErrors()) {
                    return processed;
                }
            }
            
            return processed;
        }
    }
}