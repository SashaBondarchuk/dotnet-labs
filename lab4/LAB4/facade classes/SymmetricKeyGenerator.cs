using System.Security.Cryptography;

namespace LAB4
{
    public class SymmetricKeyGenerator
    {
        public byte[] GenerateKey()
        {
            using Aes aes = Aes.Create();
            return aes.Key;
        }
    }
}
