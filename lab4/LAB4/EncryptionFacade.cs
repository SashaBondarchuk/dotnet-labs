namespace LAB4
{
    public class EncryptionFacade
    {
        private readonly SymmetricEncryptor symmetricEncryptor;
        private readonly AsymmetricEncryptor asymmetricEncryptor;
        private readonly HashGenerator hashGenerator;
        public EncryptionFacade()
        {
            symmetricEncryptor = new SymmetricEncryptor();
            asymmetricEncryptor = new AsymmetricEncryptor();
            hashGenerator = new HashGenerator();
        }
        public string GetPublicAsymmetricKey()
        {
            return asymmetricEncryptor.PublicKey;
        }
        public string GetPrivateAsymmetricKey()
        {
            return asymmetricEncryptor.PrivateKey;
        }
        public byte[] GetSymmetricKey()
        {
            return symmetricEncryptor.Key;
        }
        public string EncryptText(string dataToEncrypt, string symmetricKey)
        {
            try
            {
                return symmetricEncryptor.Encrypt(dataToEncrypt, symmetricKey);
            }
            catch (Exception) { throw; }
        }
        public string DecryptText(string dataToDecrypt, string symmetricKey)
        {
            try
            {
                return symmetricEncryptor.Decrypt(dataToDecrypt, symmetricKey);
            }
            catch (Exception) { throw; }
            
        }
        public string EncryptTextAsymmetric(string dataToEncrypt, string publicKey)
        {
            try
            {
                return asymmetricEncryptor.Encrypt(dataToEncrypt, publicKey);
            }
            catch (Exception) { throw; }
        }
        public string DecryptTextAsymmetric(string dataToDecrypt, string privateKey)
        {
            try
            {
                return asymmetricEncryptor.Decrypt(dataToDecrypt, privateKey);
            }
            catch (Exception) { throw; }
        }
        public string GenerateHash(string data)
        {
            return hashGenerator.GenerateHash(data);
        }
    }
}
