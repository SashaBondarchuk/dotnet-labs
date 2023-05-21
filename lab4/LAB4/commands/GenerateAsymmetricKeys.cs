namespace LAB4.commands
{
    public class GenerateAsymmetricKeys : ICommand
    {
        private readonly EncryptionFacade encryptionFacade;
        public GenerateAsymmetricKeys(EncryptionFacade encryptionFacade)
        {
            this.encryptionFacade = encryptionFacade;
        }
        public void Execute()
        {
            string publicKey = encryptionFacade.GetPublicAsymmetricKey();
            string privateKey = encryptionFacade.GetPrivateAsymmetricKey();
            Console.WriteLine($"Згенеровано пару ключів\n\nPublic: {publicKey}\n\nPrivate: {privateKey}\n");
        }

        public string GetCommandName()
        {
            return "Згенерувати пару ключів для асиметричного шифрування";
        }
    }
}
