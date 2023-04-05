using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class GetChauffeursCount : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetChauffeursCount(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            Console.WriteLine("Введіть ID реєстрації машини:");
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out int regID);
                if (!flag)
                {
                    Console.WriteLine("Введіть число");
                    continue;
                }
                if (regID <= 0)
                {
                    Console.WriteLine("ID має бути більше за 0.");
                    continue;
                }
                int count = dataHandler.GetChauffeursCount(regID);
                Console.WriteLine($"Кількість водіїв на реєстрацію #{regID} - {count}.\n");
                break;
            }
        }

        public string GetCommandName()
        {
            return "Отримати кількість шоферів на конкретну реєстрацію авто";
        }
    }
}
