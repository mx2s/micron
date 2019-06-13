using Core.DL.Middleware;
using Nancy;
using Newtonsoft.Json.Linq;

namespace BaseFramework.DL.Module.Http {
    public static class HttpResponse {
        public static Response Transform(JObject content, HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) content.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response ReturnData(JObject data, HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) new JObject() {
                ["data"] = data
            }.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response SimpleReturnItem(string key, JObject data, HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) new JObject() {
                ["data"] = new JObject() {
                    [key] = data
                }
            }.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response SimpleError(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.NotFound) {
            var response = (Response) new JObject() {
                ["errors"] = new JArray() {
                    new JObject() {
                        ["message"] = errorMessage
                    }
                }
            }.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response SimpleError(MiddlewareError error) => SimpleError(error.Message, error.StatusCode);
    }
}