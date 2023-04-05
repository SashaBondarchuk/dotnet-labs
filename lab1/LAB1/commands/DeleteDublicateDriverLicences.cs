using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class DeleteDublicateDriverLicences : ICommand
    {
        private readonly IDataHandler dataHandler;
        public DeleteDublicateDriverLicences(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            foreach (var driver in dataHandler.DeleteDublicateDriverLicences())
            {
                Console.WriteLine(driver);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Показати унікальні водійські посвідчення";
        }
    }
}
