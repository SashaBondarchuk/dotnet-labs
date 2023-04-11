using LAB2.interfaces;
using System;
using System.IO;


namespace LAB2.commands
{
    class TakeWhile : ICommand
    {
        private readonly IDataHandler dataHandler;
        public TakeWhile(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute() 
        {
            if (!dataHandler.DocumentIsInitialized())
                throw new FileNotFoundException();
            int year;
            Console.WriteLine("Введіть рік");
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out year);
                if (!flag)
                {
                    Console.WriteLine("Введіть число\n");
                    continue;
                }
                break;
            }
            foreach (var model in dataHandler.TakeWhile(year))
            {
                Console.WriteLine(model);
            }
            Console.WriteLine();
        }
        public string GetCommandName()
        {
            return "Вивести машини, поки рік випуску менше заданого";
        }
    }
}
