using LAB4.helpers;

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
            Console.WriteLine("Введіть ключ");
            string userKey = InputHelper.GetNotEmptyString();

            Console.WriteLine("Введіть дані, які треба зашифрувати");
            string dataToEncrypt = InputHelper.GetNotEmptyString();
            string encrypted;
            try
            {
                encrypted = encryptionFacade.EncryptText(dataToEncrypt, userKey);
            }
            catch (Exception) { throw; }
            BinarySerializer.WriteIntoFile(encrypted);

            Console.WriteLine($"Зашифровані дані:\n{encrypted}\n");
        }

        public string GetCommandName()
        {
            return "Симетричне шифрування";
        }
    }
}
