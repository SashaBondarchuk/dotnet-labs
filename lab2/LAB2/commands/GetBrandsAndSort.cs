using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GetBrandsAndSort : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetBrandsAndSort(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            foreach (var brand in dataHandler.GetBrandsAndSort())
            {
                Console.WriteLine(brand);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Вивести бренд кожної машини і відсортувати за зростанням";
        }
    }
}
