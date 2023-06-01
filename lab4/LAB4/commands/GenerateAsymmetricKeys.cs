namespace LAB4.commands
{
    public class GenerateAsymmetricKeys : ICommand
    {
        private readonly KeyGenerationFacade keyGenerationFacade;
        public GenerateAsymmetricKeys(KeyGenerationFacade keyGenerationFacade)
        {
            this.keyGenerationFacade = keyGenerationFacade;
        }
        public void Execute()
        {
            string publicKey = keyGenerationFacade.GetPublicAsymmetricKey();
            string privateKey = keyGenerationFacade.GetPrivateAsymmetricKey();
            Console.WriteLine($"Згенеровано пару ключів\n\nPublic: {publicKey}\n\nPrivate: {privateKey}\n");
        }

        public string GetCommandName()
        {
            return "Згенерувати пару ключів для асиметричного шифрування";
        }
    }
}
