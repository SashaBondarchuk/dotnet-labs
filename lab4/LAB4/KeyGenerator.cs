using System.Security.Cryptography;

namespace LAB4
{
    public class KeyGenerator
    {
        public byte[] SymmetricKey { get; }
        public string PublicKey { get; }
        public string PrivateKey { get; }
        public KeyGenerator()
        {
            using (Aes aes = Aes.Create())
            {
                SymmetricKey = aes.Key;
            }
            using (RSACryptoServiceProvider rsa = new())
            {
                PublicKey = rsa.ToXmlString(false);
                PrivateKey = rsa.ToXmlString(true);
            }
        }
    }
}
