using System.Security.Cryptography;
using System.Text;

namespace LAB4
{
    public class AsymmetricEncryptor : IEncryptionStrategy
    {
        public string Encrypt(string dataToEncrypt, string publicKey)
        {
            byte[] dataToEncryptBytes = Encoding.UTF8.GetBytes(dataToEncrypt);
            using RSACryptoServiceProvider rsa = new();
            try
            {
                rsa.FromXmlString(publicKey);
            }
            catch (CryptographicException ex)
            {
                throw new CryptographicException("Не вдалось зчитати ключ", ex);
            }
            byte[] encryptedBytes = rsa.Encrypt(dataToEncryptBytes, true);
            string encrypted = Convert.ToBase64String(encryptedBytes);
            return encrypted;
        }
        public string Decrypt(string dataToDecrypt, string privateKey)
        {
            using RSACryptoServiceProvider rsa = new();
            byte[] toDecrypt;
            byte[] decryptedBytes;
            try
            {
                rsa.FromXmlString(privateKey);
            }
            catch (CryptographicException ex)
            {
                throw new CryptographicException("Не вдалось зчитати ключ", ex);
            }
            try
            {
                toDecrypt = Convert.FromBase64String(dataToDecrypt);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Невірний формат даних", ex);
            }
            try
            {
                decryptedBytes = rsa.Decrypt(toDecrypt, true);
            }
            catch (CryptographicException ex)
            {
                throw new CryptographicException("Невірний ключ", ex);
            }
            string decryptedData = Encoding.UTF8.GetString(decryptedBytes);
            return decryptedData;
        }
    }
}
