using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GetFileContent : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetFileContent(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            Console.WriteLine("Введіть назву файлу без розширення");
            string fileName = Console.ReadLine();
            Console.WriteLine(dataHandler.GetFileContent(fileName) + "\n");
        }

        public string GetCommandName()
        {
            return "Вивести зміст XML-файлу";
        }
    }
}
