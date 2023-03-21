using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GetAllDriversCount : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetAllDriversCount(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            Console.WriteLine($"Загальна кількість власників і шоферів: {dataHandler.GetAllDriversCount()}\n");
        }
    }
}
