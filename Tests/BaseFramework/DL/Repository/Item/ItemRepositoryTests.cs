using App.DL.Repository.Item;
using NUnit.Framework;
using Tests.Utils.DB;
using ItemModel = App.DL.Model.Item.Item;

namespace Tests.BaseFramework.DL.Repository.Item {
    [TestFixture]
    public class ItemRepositoryTests {
        [SetUp]
        public void SetUp() {
            DbCleaner.TruncateAll();
        }

        [Test]
        public void Create_DataCorrect_Ok() {
            Assert.AreEqual(0, ItemRepository.Count());
            ItemRepository.Create("gold hammer", 0.25);
            Assert.AreEqual(1, ItemRepository.Count());
        }
        
        [Test]
        public void Create_DataCorrect_FoundByGuid() {
            var title = "gold hammer";
            Assert.AreEqual(0, ItemRepository.Count());
            ItemRepository.Create(title, 0.25);
            var item = ItemRepository.FindByTitle(title);
            Assert.NotNull(item);
            Assert.AreEqual(1, ItemRepository.Count());
            Assert.NotNull(ItemRepository.FindByGuid(item.guid));
        }
    }
}