using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GetLastRegistratedVehicle : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetLastRegistratedVehicle(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            Console.WriteLine(dataHandler.GetLastRegistratedVehicle() + "\n");
        }

        public string GetCommandName()
        {
            return "Вивести останню реєстрацію авто";
        }
    }
}
