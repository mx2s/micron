using ItemModel = BaseFramework.DL.Model.Item.Item;

namespace BaseFramework.DL.Repository.Item {
    public static class ItemRepository {
        public static ItemModel Find(int id) {
            return ItemModel.Find(id);
        }
        
        public static ItemModel FindByGuid(string guid) {
            return ItemModel.FindByGuid(guid);
        }
        
        public static ItemModel FindByTitle(string title) {
            return ItemModel.FindByTitle(title);
        }

        public static int Count() {
            return ItemModel.Count();
        }

        public static void Create(string title, double price) {
            ItemModel.Create(title, price);
        }
    }
}