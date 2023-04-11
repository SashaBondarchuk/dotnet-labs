using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class WriteDataToXml : ICommand
    {
        private readonly IDataHandler dataHandler;
        public WriteDataToXml(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public void Execute()
        {
            Console.WriteLine("Виберіть спосіб:\n1 - Сереалізація звичайним способом\n2 - Writer-cереалізація");
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out int option);
                if (!flag)
                {
                    Console.WriteLine("Введіть число");
                    continue;
                }
                if (option < 1 || option > 2)
                {
                    Console.WriteLine("Число має бути 1 або 2\n");
                    continue;
                }
                dataHandler.WriteDataToXml(option);
                break;
            }
        }

        public string GetCommandName()
        {
            return "Записати дані у файл";
        }
    }
}
