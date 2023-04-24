using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GetVehiclesWithLinq : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetVehiclesWithLinq(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            foreach (var vechile in dataHandler.GetVehiclesWithLinq())
            {
                Console.WriteLine(vechile);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Отримати список машин, своривши колекцію";
        }
    }
}
