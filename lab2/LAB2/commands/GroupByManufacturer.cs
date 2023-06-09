﻿using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GroupByManufacturer : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GroupByManufacturer(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            foreach (var group in dataHandler.GroupByManufacturer())
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
        }

        public string GetCommandName()
        {
            return "Згрупувати машини по виробнику";
        }
    }
}
