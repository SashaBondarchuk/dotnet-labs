using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GetElementWithSelectedText : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetElementWithSelectedText(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            Console.WriteLine("Введіть номерний знак");
            Console.WriteLine(dataHandler.GetElementWithSelectedText(Console.ReadLine()) + "\n");
        }

        public string GetCommandName()
        {
            return "Знайти машину по номерному знаку";
        }
    }
}
