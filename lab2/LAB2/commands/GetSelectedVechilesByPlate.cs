using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GetSelectedVechilesByPlate : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetSelectedVechilesByPlate(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            string symbols = Console.ReadLine();
            foreach (var vehicle in dataHandler.GetSelectedVechilesByPlate(symbols))
            {
                Console.WriteLine(vehicle);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Список машин, номер яких починається з літер";
        }
    }
}
