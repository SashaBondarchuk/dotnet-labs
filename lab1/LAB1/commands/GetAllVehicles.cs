using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GetAllVehicles : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetAllVehicles(IDataHandler dataHandler) 
        {
            this.dataHandler = dataHandler;
        }

        public void Execute()
        {
            foreach (var car in dataHandler.GetAllVehicles())
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Список усіх машин";
        }
    }
}
