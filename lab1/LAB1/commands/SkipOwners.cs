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
                bool flag = int.TryParse(Console.ReadLine(), out int index);
                if (!flag)
                {
                    Console.WriteLine("Введіть число");
                    continue;
                }
                if (index <= 0)
                {
                    Console.WriteLine("Число має бути більше за 0\n");
                    continue;
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
        }

        public string GetCommandName()
        {
            return "Вивести власників, пропустивши перші n людей";
        }
    }
}
