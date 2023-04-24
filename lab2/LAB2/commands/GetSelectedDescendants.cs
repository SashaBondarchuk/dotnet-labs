using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class GetSelectedDescendants : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetSelectedDescendants(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }

            foreach (var model in dataHandler.GetSelectedDescendants())
            {
                Console.WriteLine(model.Value);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Отримати всіх потомків з ім'ям Model";
        }
    }
}
