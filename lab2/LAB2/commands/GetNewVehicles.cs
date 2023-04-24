using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GetNewVehicles : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetNewVehicles(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }

            foreach (var vechile in dataHandler.GetNewVehicles())
            {
                Console.WriteLine(vechile);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Машини прямо з заводу";
        }
    }
}
