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
                bool flag = int.TryParse(Console.ReadLine(), out int regCount);
                if (!flag)
                {
                    Console.WriteLine("Введіть число");
                    continue;
                }
                if (regCount <= 0)
                {
                    Console.WriteLine("Число має бути більше за 0\n");
                    continue;
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
        }

        public string GetCommandName()
        {
            return "Вибрати власників, у яких більше X реєстрацій";
        }
    }
}
