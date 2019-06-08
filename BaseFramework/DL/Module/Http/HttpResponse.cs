using Nancy;
using Newtonsoft.Json.Linq;

namespace BaseFramework.DL.Module.Http {
    public static class HttpResponse {
        public static Response Transform(JObject content, HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) content.ToString();
            response.StatusCode = statusCode;
            return response;
        }
    }
}