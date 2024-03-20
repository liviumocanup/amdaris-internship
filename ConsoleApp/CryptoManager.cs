using System.Security.Cryptography;
using SecurityDriven.Inferno;

public static class CryptoManager
{
    private static readonly byte[] Key;

    static CryptoManager()
    {
        Key = GenerateBase64EncodedKey();
    }

    private static byte[] GenerateBase64EncodedKey()
    {
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[32];
            rng.GetBytes(randomBytes);
            return randomBytes;
        }
    }

    public static string Encrypt(string plainText)
    {
        var encryptedBytes = SuiteB.Encrypt(Key, Utils.SafeUTF8.GetBytes(plainText), null);
        return Convert.ToBase64String(encryptedBytes);
    }

    public static string Decrypt(string encryptedText)
    {
        var decryptedBytes = SuiteB.Decrypt(Key, Convert.FromBase64String(encryptedText), null);
        return Utils.SafeUTF8.GetString(decryptedBytes);
    }
}
