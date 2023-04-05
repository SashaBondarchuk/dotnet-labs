using LAB1.enums;
using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GetVehiclesByType : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetVehiclesByType(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            BodyType requiredBodyType = BodyType.Coupe; //hardcode

            foreach (var car in dataHandler.GetVehiclesByType(requiredBodyType))
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Показати машити типу купе";
        }
    }
}
