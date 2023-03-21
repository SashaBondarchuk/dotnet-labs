using LAB1.interfaces;
using System;
using System.Linq;


namespace LAB1.commands
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
            Console.WriteLine("Введіть рік народження:");
            while (true)
            {
                try
                {
                    int year = int.Parse(Console.ReadLine());

                    if (year <= 1920 || year > (DateTime.Now.Year - 18))
                    {
                        throw new Exception();
                    }

                    var owners = dataHandler.TakeWhile(year);

                    if (owners.Count() <= 0) 
                    {
                        Console.WriteLine("Таких власників немає\n");
                        break;
                    }

                    foreach (var owner in owners)
                    {
                        Console.WriteLine($"{owner}, {owner.BirthDate.Year}");
                    }
                    Console.WriteLine();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Рік має бути числом, більше за 1920 і менше за {DateTime.Now.Year - 17}.");
                }
            }
        }
    }
}
