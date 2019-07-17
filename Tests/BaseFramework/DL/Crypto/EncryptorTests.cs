using BaseFramework.DL.Module.Crypto;
using NUnit.Framework;

namespace Tests.BaseFramework.DL.Crypto {
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
        
        [Test]
        public void Encrypt_DataCorrect_AbleToDecryptWithKey() {
            var strToEncrypt = "some string";
            var key = "somekey";
            
            var encrypted = Encryptor.Encrypt(strToEncrypt, key);
            var decrypted = Encryptor.Decrypt(encrypted, key);
            Assert.AreEqual(strToEncrypt, decrypted);
        }
    }
}