using Nancy;

namespace Core.DL.Module.Http {
    public class HttpError {
        public HttpStatusCode StatusCode { get; }

        public string Message { get; }
        
        public string Parameter { get; } // for validation errors

        public HttpError(HttpStatusCode code, string message, string param = null) {
            StatusCode = code;
            Message = message;
            Parameter = param;
        }
    }
}