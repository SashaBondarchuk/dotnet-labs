using System.Security.Cryptography;
using System.Text;

namespace LAB4
{
    public class HashGenerator
    {
        public string GenerateHash(string data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = sha256.ComputeHash(dataBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "");

                return hash;
            }
        }
    }
}
