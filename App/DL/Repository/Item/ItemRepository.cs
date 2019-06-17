using ItemModel = App.DL.Model.Item.Item;

namespace App.DL.Repository.Item {
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

        public static ItemModel CreateAndGet(string title, double price) {
            return ItemModel.Find(Create(title, price));
        }
        
        public static int Create(string title, double price) {
            return ItemModel.Create(title, price);
        }
    }
}