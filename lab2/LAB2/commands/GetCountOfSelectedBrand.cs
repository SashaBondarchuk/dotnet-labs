using LAB2.enums;
using LAB2.interfaces;
using System;
using System.IO;


namespace LAB2.commands
{
    class GetCountOfSelectedBrand : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetCountOfSelectedBrand(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
                
            Brand brand;
            while (true)
            {
                bool flag = Enum.TryParse(Console.ReadLine(), true, out brand);
                if (!flag)
                {
                    Console.WriteLine("Введіть інший бренд");
                    continue;
                }
                break;
            }
            Console.WriteLine(dataHandler.GetCountOfSelectedBrand(brand) + "\n");
        }

        public string GetCommandName()
        {
            return "Кількість машин вказаного бренду";
        }
    }
}
