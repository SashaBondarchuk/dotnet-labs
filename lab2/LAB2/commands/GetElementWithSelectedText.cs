using LAB2.interfaces;
using System;
using System.IO;

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
                throw new FileNotFoundException();

            Console.WriteLine("Введіть номерний знак");
            Console.WriteLine(dataHandler.GetElementWithSelectedText(Console.ReadLine()) + "\n");
        }

        public string GetCommandName()
        {
            return "Знайти машину по номерному знаку";
        }
    }
}
