using BaseFramework.DL.Repository.User;
using NUnit.Framework;
using Tests.Utils.DB;
using Tests.Utils.Fake.User;

namespace Tests.Core.DL.Repository.User {
    [TestFixture]
    public class UserRepositoryTests {
        [SetUp]
        public void SetUp() {
            DbCleaner.TruncateAll();
        }
        
        [Test]
        public void FindByEmail_DataCorrect_Ok() {
            var user = UserFaker.Create();
            Assert.NotNull(UserRepository.FindByEmail(user.email));
        }
    }
}