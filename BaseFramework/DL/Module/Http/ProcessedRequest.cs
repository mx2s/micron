using System.Collections.Generic;
using System.Linq;
using BaseFramework.DL.Model.User;
using Core.DL.Middleware;
using Nancy;

namespace BaseFramework.DL.Module.Http {
    public class ProcessedRequest {
        public Request Request { get; }
        public List<MiddlewareError> Errors { get; }
        
        public User User { get; set; }

        public ProcessedRequest(Request request) {
            Request = request;
            Errors = new List<MiddlewareError>();
        }

        public bool HasErrors() => Errors.Count > 0;

        public MiddlewareError FirstError => Errors.First();

        public void PushError(MiddlewareError error) => Errors.Add(error);
    }
}