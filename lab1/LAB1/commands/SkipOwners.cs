using LAB1.interfaces;
using System;
using System.Linq;


namespace LAB1.commands
{
    class SkipOwners : ICommand
    {
        private readonly IDataHandler dataHandler;
        public SkipOwners(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть index:");
            while (true)
            {
                try
                {
                    int index = int.Parse(Console.ReadLine());

                    if (index < 1)
                    {
                        throw new Exception();
                    }

                    var skippedOwners = dataHandler.SkipOwners(index);

                    if (skippedOwners.Count() == 0) 
                    {
                        Console.WriteLine("Введіть менше число");
                        continue;
                    }
                    foreach (var owner in skippedOwners)
                    {
                        Console.WriteLine(owner);
                    }
                    Console.WriteLine();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Індекс має бути цифрою(числом) і більшою за 0.");
                }
            }
        }
    }
}
