using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GetYoungestChauffeur : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetYoungestChauffeur(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            var youngest = dataHandler.GetYoungestChauffeur();
            Console.WriteLine($"Наймолодший {youngest}, йому {DateTime.Now.Year - youngest.BirthDate.Year} років\n");
        }
    }
}
