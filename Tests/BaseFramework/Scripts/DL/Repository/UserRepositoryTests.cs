using System;
using BaseFramework.DL.Model.User;
using BaseFramework.DL.Repository.User;
using NUnit.Framework;
using Tests.Utils.DB;
using Tests.Utils.Fake.User;

namespace Tests.BaseFramework.Scripts.DL.Repository {
    [TestFixture]
    public class UserRepositoryTests {
        [SetUp]
        public void SetUp() {
            DbCleaner.TruncateAll();
        }
        
        [Test]
        public void Find_DataCorrect_Ok() {
            Assert.AreEqual(0,User.Count());
            var user = UserFaker.Create();
            Assert.NotNull(UserRepository.Find(user.id));
        }

        [Test]
        public void Find_Empty_GetNull() {
            Assert.AreEqual(0,User.Count());
            Assert.IsNull(UserRepository.Find(new Random().Next()));
        }
        
        [Test]
        public void FindByEmail_DataCorrect_Ok() {
            Assert.AreEqual(0,User.Count());
            var user = UserFaker.Create();
            Assert.NotNull(UserRepository.FindByEmail(user.email));
        }
    }
}