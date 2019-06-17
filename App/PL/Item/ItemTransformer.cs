using BaseFramework.PL.Transformer;
using Newtonsoft.Json.Linq;
using ItemModel = App.DL.Model.Item.Item;

namespace App.PL.Item {
    public class ItemTransformer : BaseTransformer {
        public override JObject Transform(object obj) {
            var item = (ItemModel) obj;
            return new JObject {
                ["guid"] = item.guid,
                ["title"] = item.title,
                ["price"] = item.price,
            };
        }
    }
}