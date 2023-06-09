﻿using LAB1.interfaces;
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
                bool flag = int.TryParse(Console.ReadLine(), out int year);
                if (!flag)
                {
                    Console.WriteLine("Введіть число");
                    continue;
                }
                if (year <= 1920 || year > (DateTime.Now.Year - 18))
                {
                    Console.WriteLine($"Рік має бути числом, більше за 1920 і менше за {DateTime.Now.Year - 17}.");
                    continue;
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
        }

        public string GetCommandName()
        {
            return "Вивести власників, поки рік народження менший заданого";
        }
    }
}
