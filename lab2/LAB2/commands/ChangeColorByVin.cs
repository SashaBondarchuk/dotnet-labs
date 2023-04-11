using LAB2.enums;
using LAB2.interfaces;
using System;
using System.IO;


namespace LAB2.commands
{
    class ChangeColorByVin : ICommand
    {
        private readonly IDataHandler dataHandler;
        public ChangeColorByVin(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
                throw new FileNotFoundException();
            Console.Write("Vin: ");
            string vin = Console.ReadLine();
            Console.Write("Color: ");
            CarColor carColor;
            while (true)
            {
                bool flag = Enum.TryParse(Console.ReadLine(), out carColor);
                if (!flag)
                {
                    Console.WriteLine("Введіть інший колір\n");
                    continue;
                }
                break;
            }
            Console.WriteLine(dataHandler.ChangeColorByVin(vin, carColor));
        }

        public string GetCommandName()
        {
            return "Змінити колір машини за Vin-кодом";
        }
    }
}
