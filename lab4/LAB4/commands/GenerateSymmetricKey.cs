namespace LAB4.commands
{
    public class GenerateSymmetricKey : ICommand
    {
        private readonly EncryptionFacade encryptionFacade;
        public GenerateSymmetricKey(EncryptionFacade encryptionFacade)
        {
            this.encryptionFacade = encryptionFacade;
        }
        public void Execute()
        {
            byte[] key = encryptionFacade.GetSymmetricKey();
            Console.WriteLine($"Ваш ключ: {Convert.ToBase64String(key)}\n");
        }

        public string GetCommandName()
        {
            return "Згенерувати ключ для симетричного шифрування";
        }
    }
}
