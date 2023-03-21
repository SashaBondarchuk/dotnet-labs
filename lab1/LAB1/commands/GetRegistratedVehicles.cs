using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GetRegistratedVehicles : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetRegistratedVehicles(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public void Execute()
        {
            foreach (var v in dataHandler.GetRegistratedVehicles())
            {
                Console.WriteLine($"{v.Vechile.Brand} {v.Vechile.Model} ({v.Vechile.Vin}) має наступні реєстрації:");
                foreach (var reg in v.VehicleRegistrations)
                {
                    Console.WriteLine(reg);
                }
                Console.WriteLine();
            }
        }
    }
}
