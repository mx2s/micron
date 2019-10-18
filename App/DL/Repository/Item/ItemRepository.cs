using ItemModel = App.DL.Model.Item.Item;

namespace App.DL.Repository.Item {
    public static class ItemRepository {
        public static ItemModel Find(int id) => ItemModel.Find(id);

        public static ItemModel FindByGuid(string guid) => ItemModel.FindByGuid(guid);

        public static ItemModel FindByTitle(string title) => ItemModel.FindByTitle(title);

        public static int Count() => ItemModel.Count();

        public static ItemModel CreateAndGet(string title, double price)
        {
            var id = Create(title, price);

            return ItemModel.Find(id);
        }

        public static int Create(string title, double price) =>
            ItemModel.Create(title, price);
    }
}