using System;
using System.Linq;
using BaseFramework.AL.Validation.Db;
using BaseFramework.DL.Module.Validator;
using Nancy;
using NUnit.Framework;
using Tests.Utils.DB;
using Tests.Utils.Fake.Item;

namespace Tests.BaseFramework.AL.Validation.Db {
    [TestFixture]
    public class ExistsInTableTests {
        [SetUp]
        public void SetUp() {
            DbCleaner.TruncateAll();
        }
        
        [Test]
        public void Process_ItemExists_Ok() {
            var item = ItemFaker.Create();

            var request = new Request("GET", "/");
            request.Query["item_guid"] = item.guid;

            var errors = ValidationProcessor.Process(request, new IValidatorRule[] {
                new ExistsInTable("item_guid", "items", "guid"),
            });

            Assert.Zero(errors.Count);
        }

        [Test]
        public void Process_ItemNotExists_404() {
            var request = new Request("GET", "/");
            request.Query["item_guid"] = Guid.NewGuid().ToString();

            var errors = ValidationProcessor.Process(request, new IValidatorRule[] {
                new ExistsInTable("item_guid", "items", "guid"),
            });

            Assert.True(errors.Count == 1);
            Assert.True(errors.First().StatusCode == HttpStatusCode.NotFound);
        }
    }
}