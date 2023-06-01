namespace LAB4
{
    public class KeyGenerationFacade
    {
        private readonly KeyGenerator keyGenerator;
        public KeyGenerationFacade()
        {
            keyGenerator = new KeyGenerator();
        }
        public string GetPublicAsymmetricKey()
        {
            return keyGenerator.PublicKey;
        }
        public string GetPrivateAsymmetricKey()
        {
            return keyGenerator.PrivateKey;
        }
        public byte[] GetSymmetricKey()
        {
            return keyGenerator.SymmetricKey;
        }
    }
}
