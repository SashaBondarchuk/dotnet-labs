using LAB2.interfaces;
using System;
using System.Linq;


namespace LAB2.commands
{
    class GetXmlFileNames : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetXmlFileNames(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            var names = dataHandler.GetXmlFileNames();
            if (names.Count() <= 0)
            {
                Console.WriteLine("Файлів ще не додано");
                return;
            }
            foreach (var filename in names)
            {
                Console.WriteLine(filename);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Отримати назви існуючих XML-файлів";
        }
    }
}
