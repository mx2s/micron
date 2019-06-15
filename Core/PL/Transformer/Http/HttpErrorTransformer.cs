using Core.DL.Module.Http;
using Newtonsoft.Json.Linq;

namespace Core.PL.Transformer.Http {
    public class HttpErrorTransformer : BaseTransformer {
        public override JObject Transform(object obj) {
            var error = (HttpError) obj;
            var result = new JObject() {
                ["code"] = (int) error.StatusCode,
                ["message"] = error.Message
            };
            if (error.Parameter != null) {
                result["parameter"] = error.Parameter;
            }
            return result;
        }
    }
}