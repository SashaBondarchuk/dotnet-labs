namespace LAB4.commands
{
    public class DecryptAsymmetric : ICommand
    {
        private readonly EncryptionFacade encryptionFacade;
        public DecryptAsymmetric(EncryptionFacade encryptionFacade)
        {
            this.encryptionFacade = encryptionFacade;
        }
        public void Execute()
        {
            encryptionFacade.SetStrategy(EncyptionType.Asymmetric);
            Console.WriteLine("Введіть приватний ключ: ");
            string privateKey = InputHelper.GetNotEmptyString();

            Console.WriteLine("Введіть дані для розшифровки");
            string dataToDecrypt = InputHelper.GetNotEmptyString();

            string decrypted = encryptionFacade.Decrypt(dataToDecrypt, privateKey);
            Console.WriteLine("Розшифровані дані: " + decrypted + "\n");   
        }

        public string GetCommandName()
        {
            return "Асиметричне дешифрування";
        }
    }
}
