namespace LAB4
{
    public class EncryptionFacade
    {
        private readonly HashGenerator hashGenerator;
        private IEncryptionStrategy encryptionStrategy;
        public EncryptionFacade()
        {
            hashGenerator = new HashGenerator();
        }
        public void SetStrategy(IEncryptionStrategy strategy) 
        {
            encryptionStrategy = strategy;
        }
        public string Encrypt(string dataToEncrypt, string symmetricKey)
        {
            return encryptionStrategy.Encrypt(dataToEncrypt, symmetricKey);
        }
        public string Decrypt(string dataToDecrypt, string symmetricKey)
        {
            return encryptionStrategy.Decrypt(dataToDecrypt, symmetricKey);
        }
        public string GenerateHash(string data)
        {
            return hashGenerator.GenerateHash(data);
        }
    }
}
