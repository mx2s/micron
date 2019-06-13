using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Core.DL.Module.Config;

// Used example from: https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
namespace Core.DL.Module.Crypto {
    public static class Encryptor {
        private const int Keysize = 256;

        private const int DerivationIterations = 1000;

        public static string Encrypt(string text, string key = null) {
            if (text.Length == 0) {
                return null;
            }
            if (key == null) {
                key = AppConfig.Get().GetEncryptionKey();
            }

            byte[] clearBytes = Encoding.Unicode.GetBytes(text);
            using (Aes encryptor = Aes.Create()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    ) {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    text = Convert.ToBase64String(ms.ToArray());
                }
            }

            return text;
        }

        public static string Decrypt(string text, string key = null) {
            if (key == null) {
                key = AppConfig.Get().GetEncryptionKey();
            }

            text = text.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(text);
            using (Aes encryptor = Aes.Create()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    ) {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }

                    text = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return text;
        }
    }
}