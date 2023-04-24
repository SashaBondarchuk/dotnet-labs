using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GetVehicles : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetVehicles(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            foreach (var vNode in dataHandler.GetVehicles())
            {
                Console.WriteLine(vNode);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Отримати перелік всіх дочірніх вузлів файлу Vechiles";
        }
    }
}