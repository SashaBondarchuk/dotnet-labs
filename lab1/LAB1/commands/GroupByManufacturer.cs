using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GroupByManufacturer : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GroupByManufacturer(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            foreach (var vManufacturer in dataHandler.GroupByManufacturer())
            {
                Console.WriteLine(vManufacturer.Key + ":");
                foreach (var value in vManufacturer)
                {
                    Console.WriteLine(value);
                }
                Console.WriteLine();
            }
        }
    }
}
