using LAB2.interfaces;
using System;
using System.IO;

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
                throw new FileNotFoundException();

            foreach (var vechile in dataHandler.GetVehiclesWithLinq("Vechiles"))
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
