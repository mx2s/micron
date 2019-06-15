using BaseFramework.DL.Middleware;
using BaseFramework.DL.Module.Http;
using Core.DL.Module.Http;
using Nancy;

namespace BaseFramework.DL.Module.Controller {
    public abstract class BaseController : NancyModule {
        protected ProcessedRequest CurrentRequest { get; set; }

        protected abstract IMiddleware[] Middleware();

        public BaseController() {
            Before += ctx => {
                CurrentRequest = new ProcessedRequest(Request);

                var middlewareError = MiddlewareProcessor.Process(CurrentRequest, Middleware());

                if (middlewareError != null) {
                    return HttpResponse.Error(middlewareError);
                }
                
                return null;
            };
        }
    }
}