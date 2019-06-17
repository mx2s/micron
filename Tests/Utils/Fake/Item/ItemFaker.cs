using App.DL.Repository.Item;
using Core.DL.Module.Misc;
using ItemModel = App.DL.Model.Item.Item;

namespace Tests.Utils.Fake.Item {
    public static class ItemFaker {
        public static ItemModel Create() {
            var title = "test_item_" + Rand.SmallInt();
            ItemModel.Create(
                title,
                Rand.SmallInt() * 0.05
            );
            return ItemRepository.FindByTitle(title);
        }
    }
}