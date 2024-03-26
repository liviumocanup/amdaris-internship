using System.Security.Cryptography;
using SecurityDriven.Inferno;

namespace ConsoleApp.Utilities.Encryption
{
    public class InfernoEncryptionService : IEncryptionService
    {
        private readonly byte[] _key;

        public InfernoEncryptionService()
        {
            _key = GenerateBase64EncodedKey();
        }

        private byte[] GenerateBase64EncodedKey()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[32];
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
        }

        public string Encrypt(string plainText)
        {
            var encryptedBytes = SuiteB.Encrypt(_key, Utils.SafeUTF8.GetBytes(plainText), null);
            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string encryptedText)
        {
            var decryptedBytes = SuiteB.Decrypt(_key, Convert.FromBase64String(encryptedText), null);
            return Utils.SafeUTF8.GetString(decryptedBytes);
        }
    }
}
