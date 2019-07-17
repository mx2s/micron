using System;
using BaseFramework.DL.Module.Auth;
using NUnit.Framework;

namespace Tests.BaseFramework.DL.Auth {
    [TestFixture]
    public class JwtTests {
        [Test]
        public void FromUserId_DataCorrect_AbleToGenerateToken() {
            var userId = new Random().Next(1, 99999);
            
            Jwt.FromUserId(userId);
        }

        [Test]
        public void FromUserId_DataCorrect_OkDecoded() {
            var userId = new Random().Next(1, 99999);
            
            var token = Jwt.FromUserId(userId);
            
            Assert.AreEqual(userId, Jwt.GetUserIdFromToken(token));
        }
    }
}