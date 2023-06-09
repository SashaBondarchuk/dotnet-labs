using LAB4.commands;

namespace LAB4
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            EncryptionFacade encryptionFacade = new();
            KeyGenerationFacade keyGenerationFacade = new();

            Invoker invoker = new();
            invoker.SetUpCommand(new GenerateAsymmetricKeys(keyGenerationFacade));
            invoker.SetUpCommand(new GenerateSymmetricKey(keyGenerationFacade));
            invoker.SetUpCommand(new EncryptAsymmetric(encryptionFacade));
            invoker.SetUpCommand(new DecryptAsymmetric(encryptionFacade));
            invoker.SetUpCommand(new EncryptSymmetric(encryptionFacade));
            invoker.SetUpCommand(new DecryptSymmetric(encryptionFacade));
            invoker.SetUpCommand(new GenerateHash(encryptionFacade));
            
            CommandMenu.GenerateMenu(invoker.GetCommands());
            CommandMenu.PrintMenu();

            int commandCount = invoker.GetCommandsCount();
            while (true)
            {
                Console.Write("Дія #");
                int option = InputHelper.GetInteger();
                if (option < 1 || option > commandCount)
                {
                    Console.WriteLine($"Введіть число в межах від 1 до {commandCount}\n");
                    continue;
                }
                Console.WriteLine(invoker.GetCommandName(option - 1) + ":\n");
                try
                {
                    invoker.ExecuteCommand(option - 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nСпробуйте ще раз\n");
                }
            }
        }
    }
}