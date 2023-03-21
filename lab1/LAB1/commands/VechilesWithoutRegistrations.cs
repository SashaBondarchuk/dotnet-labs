using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class VechilesWithoutRegistrations : ICommand
    {
        private readonly IDataHandler dataHandler;
        public VechilesWithoutRegistrations(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            foreach (var car in dataHandler.VechilesWithoutRegistrations())
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }
    }
}
