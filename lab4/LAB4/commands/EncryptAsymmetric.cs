namespace LAB4.commands
{
    public class EncryptAsymmetric : ICommand
    {
        private readonly EncryptionFacade encryptionFacade;
        public EncryptAsymmetric(EncryptionFacade encryptionFacade) 
        { 
            this.encryptionFacade = encryptionFacade;
        }

        public void Execute()
        {
            encryptionFacade.SetStrategy(new AsymmetricEncryptor());
            Console.WriteLine("Введіть публічний ключ");
            string userPublicKey = InputHelper.GetNotEmptyString();

            Console.WriteLine("Введіть дані, які треба зашифрувати");
            string dataToEncrypt = InputHelper.GetNotEmptyString();

            string encrypted = encryptionFacade.Encrypt(dataToEncrypt, userPublicKey);
            Console.WriteLine($"Зашифровані дані:\n{encrypted}\n");
        }

        public string GetCommandName()
        {
            return "Асиметричне шифрування";
        }
    }
}
