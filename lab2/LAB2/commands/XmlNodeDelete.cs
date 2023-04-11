using LAB2.interfaces;
using System;
using System.IO;

namespace LAB2.commands
{
    class XmlNodeDelete : ICommand
    {
        private readonly IDataHandler dataHandler;
        public XmlNodeDelete(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
                throw new FileNotFoundException();

            foreach (var vechile in dataHandler.XmlNodeDelete())
            {
                Console.WriteLine(vechile);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Вивети документ з видаленим вузлом Color";
        }
    }
}
