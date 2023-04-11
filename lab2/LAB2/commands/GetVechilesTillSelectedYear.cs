using LAB2.interfaces;
using System;
using System.IO;


namespace LAB2.commands
{
    class GetVechilesTillSelectedYear : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetVechilesTillSelectedYear(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
                throw new FileNotFoundException();
            int year;
            Console.WriteLine("Введіть рік");
            while (true) {
                bool flag = int.TryParse(Console.ReadLine(), out year);
                if (!flag)
                {
                    Console.WriteLine("Введіть число\n");
                    continue;
                }
                break;
            }
            foreach (var vechile in dataHandler.GetVechilesTillSelectedYear(year))
            {
                Console.WriteLine(vechile);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Машини, що виготовленi до заданого року";
        }
    }
}
