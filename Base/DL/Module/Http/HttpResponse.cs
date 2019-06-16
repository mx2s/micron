using System.Collections.Generic;
using Core.DL.Module.Http;
using Core.PL.Transformer.Http;
using Nancy;
using Newtonsoft.Json.Linq;

namespace BaseFramework.DL.Module.Http {
    public static class HttpResponse {
        public static Response Data(JObject data, HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) new JObject() {
                ["data"] = data
            }.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response Item(string key, JObject data,
            HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) new JObject() {
                ["data"] = new JObject() {
                    [key] = data
                }
            }.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response Error(HttpStatusCode code, string message) {
            var response = (Response) new JObject() {
                ["errors"] = new HttpErrorTransformer().TransformList(
                    new[] {new HttpError(code, message)}
                )
            }.ToString();
            response.StatusCode = code;
            return response;
        }

        public static Response Error(HttpError err) => Error(err.StatusCode, err.Message);
        
        public static Response Errors(IEnumerable<HttpError> errors) {
            var response = (Response) new JObject() {
                ["errors"] = new HttpErrorTransformer().TransformList(errors)
            }.ToString();
            return response;
        }
    }
}