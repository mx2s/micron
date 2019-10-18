using BaseFramework.DL.Repository.User;
using Nancy;
using Nancy.Testing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Tests.Utils.DB;
using Tests.Utils.Fake.User;

namespace Tests.App.AL.Controller.Auth {
    [TestFixture]
    public class JwtAuthControllerTests {
        [SetUp]
        public void SetUp() => DbCleaner.TruncateAll();

        [Test]
        public void Login_WithEmptyPassword_WithoutCrashing() {
            var user = UserFaker.Create();
            var browser = new Browser(new DefaultNancyBootstrapper());

            var result = browser.Get("/api/v1/login", with => {
                with.HttpRequest();
                with.Query("email", user.email);
                with.Query("password", null);
            }).Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        [Test]
        public void Login_CorrectCredentials_LoggedIn() {
            var email = "testemail@root.com";
            var password = "test1234";

            UserRepository.Create(email, "root", password);

            var user = UserRepository.FindByEmail(email);

            var browser = new Browser(new DefaultNancyBootstrapper());

            var result = browser.Get("/api/v1/login", with => {
                with.HttpRequest();
                with.Query("email", user.email);
                with.Query("password", password);
            }).Result;

            var body = JObject.Parse(result.Body.AsString());

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsNotEmpty(body["data"]["token"].ToString());
        }
    }
}