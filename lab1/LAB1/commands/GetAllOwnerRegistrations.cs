using LAB1.classes;
using LAB1.interfaces;
using System;
using System.Linq;


namespace LAB1.commands
{
    class GetAllOwnerRegistrations : ICommand
    {
        private readonly IDataHandler dataHandler;
        public GetAllOwnerRegistrations(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            Console.WriteLine("Введіть ID власника:");
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out int ownerID);
                if (!flag)
                {
                    Console.WriteLine("Введіть число");
                    continue;
                }
                if (ownerID <= 0)
                {
                    Console.WriteLine("ID має бути більше за 0.");
                    continue;
                }

                var registrations = dataHandler.GetAllOwnerRegistrations(ownerID);

                if (registrations.Count() <= 0)
                {
                    Console.WriteLine("Власника з таким ID не існує\n");
                    break;
                }
                foreach (var reg in registrations)
                {
                    Console.WriteLine($"{reg.VinId} {reg}");
                }
                Console.WriteLine();
                break;
            }
        }

        public string GetCommandName()
        {
            return "Показати всі реєстрації власника по Id";
        }
    }
}
