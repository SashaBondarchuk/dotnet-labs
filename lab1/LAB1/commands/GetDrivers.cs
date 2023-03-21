using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GetDrivers : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetDrivers(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            foreach (var driver in dataHandler.GetDrivers())
            {
                Console.WriteLine(driver);
            }
            Console.WriteLine();
        }
    }
}
