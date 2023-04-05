using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class AverageBirthYearOfChauffeurs : ICommand
    {
        private readonly IDataHandler dataHandler;
        public AverageBirthYearOfChauffeurs(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            Console.WriteLine(dataHandler.AverageBirthYearOfChauffeurs() + "\n");
        }
        public string GetCommandName()
        {
            return "Середній рік народження шоферів";
        }
    }
}
