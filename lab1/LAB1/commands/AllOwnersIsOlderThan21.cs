using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class AllOwnersIsOlderThan21 : ICommand
    {
        private readonly IDataHandler dataHandler;
        public AllOwnersIsOlderThan21(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            Console.WriteLine(dataHandler.AllOwnersIsOlderThan21().ToString() + "\n");
        }
        public string GetCommandName()
        {
            return "Чи всім власниками більше 21 року?";
        }
    }
}
