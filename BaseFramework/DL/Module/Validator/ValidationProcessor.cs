using System.Collections.Generic;
using Core.DL.Module.Http;
using Core.DL.Module.Validator;
using Nancy;

namespace BaseFramework.DL.Module.Validator {
    public static class ValidationProcessor {
        public static List<HttpError> Process(Request request, IValidatorRule[] rules) {
            var list = new List<HttpError>();
            
            foreach (var rule in rules) {
                var error = rule.Process(request);
                if (error != null) {
                    list.Add(error);
                }
            }
            
            return list;
        }
    }
}