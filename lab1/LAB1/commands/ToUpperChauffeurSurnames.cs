using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class ToUpperChauffeurSurnames : ICommand
    {
        private readonly IDataHandler dataHandler;
        public ToUpperChauffeurSurnames(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            foreach (var ch in dataHandler.ToUpperChauffeurSurnames())
            {
                Console.WriteLine(ch);
            }
            Console.WriteLine();
        }
    }
}
