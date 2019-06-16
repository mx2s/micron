using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BaseFramework.PL.Transformer {
    public abstract class BaseTransformer {
        public abstract JObject Transform(Object obj);
        
        public JArray TransformList(IEnumerable<Object> items) {
            JArray result = new JArray();

            foreach (var item in items) {
                result.Add(Transform(item));
            }

            return result;
        }
    }
}