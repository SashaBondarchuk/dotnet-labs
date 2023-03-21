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
                try
                {
                    int regID = int.Parse(Console.ReadLine());

                    if (regID <= 0)
                    {
                        throw new Exception();
                    }
                    int count = dataHandler.GetChauffeursCount(regID);

                    Console.WriteLine($"Кількість водіїв на реєстрацію #{regID} - {count}.\n");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("ID має бути цифрою(числом), більше за 0.");
                }
            }
        }
    }
}
