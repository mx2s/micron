using BaseFramework.DL.Middleware;
using BaseFramework.DL.Module.Http;
using Core.DL.Module.Validator;
using Nancy;

namespace BaseFramework.DL.Module.Controller {
    public static class ControllerProcessor {
        public static ProcessedRequest ProcessAll(Request request, IMiddleware[] middleware, IValidatorRule[] rules) {
            var processed = new ProcessedRequest(request);

            foreach (var mid in middleware) {
                mid.Process(processed);
                if (processed.HasErrors()) {
                    return processed;
                }
            }

            foreach (var rule in rules) {
                var result = rule.Process(processed.Request);
                if (result != null) {
                    processed.AddError(result);
                }
            }
            
            return processed;
        }
    }
}