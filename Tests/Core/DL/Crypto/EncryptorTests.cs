using Core.DL.Crypto;
using NUnit.Framework;

namespace Tests.Core.DL.Crypto {
    [TestFixture]
    public class EncryptorTests {
        [Test]
        public void Encrypt_DataCorrect_AbleToEncrypt() {
            Encryptor.Encrypt("some string");
        }

        [Test]
        public void Encrypt_DataCorrect_AbleToDecrypt() {
            var strToEncrypt = "some string";
            
            var encrypted = Encryptor.Encrypt(strToEncrypt);
            var decrypted = Encryptor.Decrypt(encrypted);
            Assert.AreEqual(strToEncrypt, decrypted);
        }
    }
}