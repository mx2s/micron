using BaseFramework.DL.Module.Config;
using NUnit.Framework;
using Tests.Utils.DB;

namespace Tests.BaseFramework.DL.Module.Config {
    [TestFixture]
    public class AppConfigTests {
        [SetUp]
        public void SetUp() {
            DbCleaner.TruncateAll();
        }

        [Test]
        public void GetConnectionString_WithData_Ok() {
            var config = AppConfig.Get();
            Assert.AreNotEqual(config.GetConnectionString(), "Host=;Username=;Password=;Database=");
        }
    }
}