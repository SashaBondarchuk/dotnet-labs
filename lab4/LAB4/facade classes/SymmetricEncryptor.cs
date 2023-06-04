using System.Security.Cryptography;
using System.Text;

namespace LAB4
{
    public class SymmetricEncryptor : IEncryptionStrategy
    {
        public string Encrypt(string dataToEncrypt, string symmetricKey)
        {
            byte[] key = TransformKey(symmetricKey);
            byte[] encryptedBytes;
            byte[] iv;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                iv = aes.IV;
                using ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(dataToEncrypt);
                csEncrypt.Write(plaintextBytes, 0, plaintextBytes.Length);
                csEncrypt.FlushFinalBlock();
                encryptedBytes = msEncrypt.ToArray();
            }

            byte[] combinedBytes = new byte[iv.Length + encryptedBytes.Length];
            Array.Copy(iv, 0, combinedBytes, 0, iv.Length);
            Array.Copy(encryptedBytes, 0, combinedBytes, iv.Length, encryptedBytes.Length);

            return Convert.ToBase64String(combinedBytes);
        }
        public string Decrypt(string dataToDecrypt, string symmetricKey)
        {
            byte[] key = TransformKey(symmetricKey);
            byte[] combinedBytes;

            try
            {
                combinedBytes = Convert.FromBase64String(dataToDecrypt);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Невірний формат даних, " + ex.Message);
                throw;
            }

            byte[] iv = new byte[16];
            byte[] encryptedBytes = new byte[combinedBytes.Length - iv.Length];
            Array.Copy(combinedBytes, 0, iv, 0, iv.Length);
            Array.Copy(combinedBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

            string decrypted;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using MemoryStream msDecrypt = new(encryptedBytes);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);
                try
                {
                    decrypted = srDecrypt.ReadToEnd();
                }
                catch (CryptographicException ex)
                {
                    Console.WriteLine("Невірний ключ, " + ex.Message);
                    throw;
                }
            }
            return decrypted;
        }
        private byte[] TransformKey(string keyToValidate)
        {
            try
            {
                return Convert.FromBase64String(keyToValidate);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Невірний формат ключа, " + ex.Message);
                throw;
            }
        }
    }
}
