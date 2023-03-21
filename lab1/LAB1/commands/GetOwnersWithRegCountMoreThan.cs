using LAB1.interfaces;
using System;
using System.Linq;


namespace LAB1.commands
{
    class GetOwnersWithRegCountMoreThan : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetOwnersWithRegCountMoreThan(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            Console.WriteLine("Введіть кількість:");
            while (true)
            {
                try
                {
                    int regCount = int.Parse(Console.ReadLine());

                    if (regCount <= 0)
                    {
                        throw new Exception();
                    }

                    var owners = dataHandler.GetOwnersWithRegCountMoreThan(regCount);

                    if (owners.Count() <= 0)
                    {
                        Console.WriteLine("Такого власника не існує\n");
                        break;
                    }

                    foreach (var owner in owners)
                    {
                        Console.WriteLine($"{owner}");
                    }
                    Console.WriteLine();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Кількість має бути цифрою(числом), більше за 0.");
                }
            }
        }
    }
}
