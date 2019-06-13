using Newtonsoft.Json.Linq;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace Core.DL.Middleware {
    public class MiddlewareError {
        public HttpStatusCode StatusCode { get; }

        public string Message { get; }

        public JObject Data { get; }
        
        public MiddlewareError(HttpStatusCode code, string msg, JObject data = null) {
            StatusCode = code;
            Message = msg;
            Data = data;
        }
    }
}