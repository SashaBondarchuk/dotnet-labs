using LAB4.helpers;

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
            Console.WriteLine("Введіть приватний ключ: ");
            string privateKey = InputHelper.GetNotEmptyString();

            Console.WriteLine("\nЗчитую інформацію з файлу...\n");
            Thread.Sleep(1000);
            string decrypted;
            string dataToDecrypt = BinaryParser.ReadFromFile();
            try
            {
                decrypted = encryptionFacade.DecryptTextAsymmetric(dataToDecrypt, privateKey);
            }
            catch (Exception) { throw; }
            Console.WriteLine("Розшифровані дані: " + decrypted + "\n");   
        }

        public string GetCommandName()
        {
            return "Асиметричне дешифрування";
        }
    }
}
