namespace LAB4.commands
{
    public class GenerateSymmetricKey : ICommand
    {
        private readonly KeyGenerationFacade keyGenerationFacade;
        public GenerateSymmetricKey(KeyGenerationFacade keyGenerationFacade)
        {
            this.keyGenerationFacade = keyGenerationFacade;
        }
        public void Execute()
        {
            byte[] key = keyGenerationFacade.GetSymmetricKey();
            Console.WriteLine($"Ваш ключ: {Convert.ToBase64String(key)}\n");
        }
        public string GetCommandName()
        {
            return "Згенерувати ключ для симетричного шифрування";
        }
    }
}
