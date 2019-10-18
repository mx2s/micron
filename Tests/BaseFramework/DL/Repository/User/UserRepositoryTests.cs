using System;
using BaseFramework.DL.Module.Misc;
using BaseFramework.DL.Repository.User;
using NUnit.Framework;
using Tests.Utils.DB;
using Tests.Utils.Fake.User;

namespace Tests.BaseFramework.DL.Repository.User {
    [TestFixture]
    public class UserRepositoryTests {
        [SetUp]
        public void SetUp() => DbCleaner.TruncateAll();

        [Test]
        public void Create_DataCorrect_Ok() {
            var randomEmail = $"somemail{Rand.SmallInt()}@root.com";
            Assert.AreEqual(0,global::BaseFramework.DL.Model.User.User.Count());
            UserRepository.Create(randomEmail, "admin", "1234");
            Assert.AreEqual(randomEmail, UserRepository.FindByEmail(randomEmail).email);
            Assert.AreEqual(1,global::BaseFramework.DL.Model.User.User.Count());
        }

        [Test]
        public void Find_DataCorrect_Ok() {
            Assert.AreEqual(0,global::BaseFramework.DL.Model.User.User.Count());
            var user = UserFaker.Create();
            Assert.NotNull(UserRepository.Find(user.id));
        }

        [Test]
        public void Find_Empty_GetNull() {
            Assert.AreEqual(0,global::BaseFramework.DL.Model.User.User.Count());
            Assert.IsNull(UserRepository.Find(new Random().Next()));
        }

        [Test]
        public void FindByEmail_DataCorrect_Ok() {
            Assert.AreEqual(0,global::BaseFramework.DL.Model.User.User.Count());
            var user = UserFaker.Create();
            Assert.NotNull(UserRepository.FindByEmail(user.email));
        }
    }
}