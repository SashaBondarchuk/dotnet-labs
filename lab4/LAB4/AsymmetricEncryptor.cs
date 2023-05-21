using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LAB4
{
    public class AsymmetricEncryptor
    {
        public string PublicKey { get; }
        public string PrivateKey { get; }
        public AsymmetricEncryptor()
        {
            using (RSACryptoServiceProvider rsa = new())
            {
                PublicKey = rsa.ToXmlString(false);
                PrivateKey = rsa.ToXmlString(true);
            }
        }
        public string Encrypt(string dataToEncrypt, string publicKey)
        {
            byte[] dataToEncryptBytes = Encoding.UTF8.GetBytes(dataToEncrypt);
            using (RSACryptoServiceProvider rsa = new())
            {
                try
                {
                    rsa.FromXmlString(publicKey);
                }
                catch (CryptographicException ex)
                {
                    Console.WriteLine("Не вдалось зчитати ключ, " + ex.Message);
                    throw;
                }
                byte[] encryptedBytes = rsa.Encrypt(dataToEncryptBytes, true);
                string encrypted = Convert.ToBase64String(encryptedBytes);
                return encrypted;
            }
        }

        public string Decrypt(string dataToDecrypt, string privateKey)
        {
            using (RSACryptoServiceProvider rsa = new())
            {
                byte[] toDecrypt;
                byte[] decryptedBytes;
                try
                {
                    rsa.FromXmlString(privateKey);
                    toDecrypt = Convert.FromBase64String(dataToDecrypt);
                    decryptedBytes = rsa.Decrypt(toDecrypt, true);
                }
                catch (CryptographicException ex)
                {
                    Console.WriteLine("Не вдалось зчитати ключ, " + ex.Message);
                    throw;
                }
                string decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedData;
            }
        }
    }
}
