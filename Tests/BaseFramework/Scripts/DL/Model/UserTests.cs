using BaseFramework.Scripts.DL.Model.User;
using NUnit.Framework;
using Tests.Utils.DB;

namespace Tests.BaseFramework.Scripts.DL.Model {
    [TestFixture]
    public class UserTests {
        [SetUp]
        public void SetUp() {
            DbCleaner.TruncateAll();
        }

        [Test]
        public void Count_EmptyTable_Get0() {
            Assert.AreEqual(0, User.Count());
        }
    }
}