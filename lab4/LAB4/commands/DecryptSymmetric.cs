namespace LAB4.commands
{
    public class DecryptSymmetric : ICommand
    {
        private readonly EncryptionFacade encryptionFacade;
        public DecryptSymmetric(EncryptionFacade encryptionFacade)
        {
            this.encryptionFacade = encryptionFacade;
        }
        public void Execute()
        {
            encryptionFacade.SetStrategy(new SymmetricEncryptor());
            Console.WriteLine("Введіть ключ");
            string userKey = InputHelper.GetNotEmptyString();

            Console.WriteLine("Введіть дані для розшифровки");
            string dataToDecrypt = InputHelper.GetNotEmptyString();

            string decrypted = encryptionFacade.Decrypt(dataToDecrypt, userKey);
            Console.WriteLine("Розшифровані дані: " + decrypted + "\n");
        }

        public string GetCommandName()
        {
            return "Симетричне дешифрування";
        }
    }
}
