using System.Security.Cryptography;

namespace LAB4
{
    public class AsymmetricKeyGenerator
    {
        public string PublicKey { get; }
        public string PrivateKey { get; }
        public AsymmetricKeyGenerator()
        {
            using RSACryptoServiceProvider rsa = new();
            PublicKey = rsa.ToXmlString(false);
            PrivateKey = rsa.ToXmlString(true);
        }
    }
}
