using System;
using LAB2.interfaces;


namespace LAB2.commands
{
    class GetYearOfOldestCar : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetYearOfOldestCar(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            Console.WriteLine(dataHandler.GetYearOfOldestCar());
        }

        public string GetCommandName()
        {
            return "Рік випуску найстарішої машини";
        }
    }
}
