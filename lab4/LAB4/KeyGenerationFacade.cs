namespace LAB4
{
    public class KeyGenerationFacade
    {
        private readonly SymmetricKeyGenerator symmetricKeyGenerator;
        private readonly AsymmetricKeyGenerator asymmetricKeyGenerator;
        public KeyGenerationFacade()
        {
            symmetricKeyGenerator = new SymmetricKeyGenerator();
            asymmetricKeyGenerator = new AsymmetricKeyGenerator();
        }
        public string GetPublicAsymmetricKey()
        {
            return asymmetricKeyGenerator.PublicKey;
        }
        public string GetPrivateAsymmetricKey()
        {
            return asymmetricKeyGenerator.PrivateKey;
        }
        public byte[] GetSymmetricKey()
        {
            return symmetricKeyGenerator.GenerateKey();
        }
    }
}
