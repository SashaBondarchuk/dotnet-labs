using LAB4.helpers;

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
            Console.WriteLine("Введіть ключ");
            string userKey = InputHelper.GetNotEmptyString();

            Console.WriteLine("\nЗчитую інформацію з файлу...\n");
            Thread.Sleep(1000);
            string dataToDecrypt = BinaryParser.ReadFromFile();
            string decrypted;
            try
            {
                decrypted = encryptionFacade.DecryptText(dataToDecrypt, userKey);
            }
            catch (Exception) { throw; }
            Console.WriteLine("Розшифровані дані: " + decrypted + "\n");
        }

        public string GetCommandName()
        {
            return "Симетричне дешифрування";
        }
    }
}
