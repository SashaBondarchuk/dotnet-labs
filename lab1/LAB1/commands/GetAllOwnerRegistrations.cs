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
                try
                {
                    int ownerID = int.Parse(Console.ReadLine());

                    if (ownerID <= 0)
                    {
                        throw new Exception();
                    }

                    var registrations = dataHandler.GetAllOwnerRegistrations(ownerID);

                    if (registrations.Count() <= 0)
                    {
                        Console.WriteLine("Власника з таким ID не існує");
                        break; 
                    }
                    foreach (var reg in registrations)
                    {
                        Console.WriteLine($"{reg.VinId} {reg}");
                    }
                    Console.WriteLine();
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
