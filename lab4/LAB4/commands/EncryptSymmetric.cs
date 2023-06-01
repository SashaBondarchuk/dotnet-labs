namespace LAB4.commands
{
    public class EncryptSymmetric : ICommand
    {
        private readonly EncryptionFacade encryptionFacade;
        public EncryptSymmetric(EncryptionFacade encryptionFacade)
        {
            this.encryptionFacade = encryptionFacade;
        }
        public void Execute()
        {
            encryptionFacade.SetStrategy(new SymmetricEncryptor());
            Console.WriteLine("Введіть ключ");
            string userKey = InputHelper.GetNotEmptyString();

            Console.WriteLine("Введіть дані, які треба зашифрувати");
            string dataToEncrypt = InputHelper.GetNotEmptyString();

            string encrypted = encryptionFacade.Encrypt(dataToEncrypt, userKey);
            Console.WriteLine($"Зашифровані дані:\n{encrypted}\n");
        }

        public string GetCommandName()
        {
            return "Симетричне шифрування";
        }
    }
}
