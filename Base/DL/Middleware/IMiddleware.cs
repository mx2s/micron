using BaseFramework.DL.Module.Http;

namespace BaseFramework.DL.Middleware {
    public interface IMiddleware {
        ProcessedRequest Process(ProcessedRequest request);
    }
}