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
        public string Encrypt(string dataToEncrypt, string key)
        {
            return encryptionStrategy.Encrypt(dataToEncrypt, key);
        }
        public string Decrypt(string dataToDecrypt, string key)
        {
            return encryptionStrategy.Decrypt(dataToDecrypt, key);
        }
        public string GenerateHash(string dataToHash)
        {
            return hashGenerator.GenerateHash(dataToHash);
        }
    }
}
