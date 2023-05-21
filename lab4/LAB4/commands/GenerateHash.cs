namespace LAB4.commands
{
    public class GenerateHash : ICommand
    {
        private readonly EncryptionFacade encryptionFacade;
        public GenerateHash(EncryptionFacade encryptionFacade)
        {
            this.encryptionFacade = encryptionFacade;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть дані, які треба хешувати");
            string dataToEncrypt = InputHelper.GetNotEmptyString();
            string hashed = encryptionFacade.GenerateHash(dataToEncrypt);
            Console.WriteLine("Захешовані дані: " + hashed + "\n");
        }

        public string GetCommandName()
        {
            return "Хешування";
        }
    }
}
