using LAB1.commands;
using LAB1.interfaces;
using LAB1.services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;


namespace LAB1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;

            /* DI Container */
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDataProvider, DataProvider>();
            services.AddScoped<IDataHandler, DataHandler>();
            services.AddScoped<DataInitializer>();

            var container = services.BuildServiceProvider();

            DataInitializer dataInitializer = container.GetService<DataInitializer>(); 
            dataInitializer.Initialize();
            IDataHandler dataHandler = container.GetService<IDataHandler>();


            Invoker invoker = new Invoker();
            invoker.SetUpCommand(new GetAllVehicles(dataHandler));
            invoker.SetUpCommand(new GetVehiclesByType(dataHandler));
            invoker.SetUpCommand(new GetRegistratedVehicles(dataHandler));
            invoker.SetUpCommand(new GetAllDriversCount(dataHandler));
            invoker.SetUpCommand(new GetChauffeursWithFistSurnameLetters(dataHandler));
            invoker.SetUpCommand(new GetAllOwnerRegistrations(dataHandler));
            invoker.SetUpCommand(new SortChaffeurs(dataHandler));
            invoker.SetUpCommand(new GetOwnersWithRegCountMoreThan(dataHandler));
            invoker.SetUpCommand(new GetYoungestChauffeur(dataHandler));
            invoker.SetUpCommand(new ToUpperChauffeurSurnames(dataHandler));
            invoker.SetUpCommand(new GetChauffeursCount(dataHandler));
            invoker.SetUpCommand(new TakeWhile(dataHandler)); 
            invoker.SetUpCommand(new VechilesWithoutRegistrations(dataHandler));
            invoker.SetUpCommand(new SkipOwners(dataHandler));
            invoker.SetUpCommand(new GroupByManufacturer(dataHandler));
            invoker.SetUpCommand(new AllOwnersIsOlderThan21(dataHandler));
            invoker.SetUpCommand(new AverageBirthYearOfChauffeurs(dataHandler));
            invoker.SetUpCommand(new GetDrivers(dataHandler));
            invoker.SetUpCommand(new GetLastRegistratedVehicle(dataHandler));
            invoker.SetUpCommand(new DeleteDublicateDriverLicences(dataHandler)); 

            
            CommandMenu.GenerateMenu(invoker.GetCommands());
            CommandMenu.PrintMenu();

            int commandCount = invoker.GetCommandsCount();
            while (true)
            {
                Console.Write("Запит #");
                bool flag = int.TryParse(Console.ReadLine(), out int option);
                if(!flag) 
                { 
                    Console.WriteLine("Введіть число\n");
                    continue;
                }
                if (option < 1 || option > commandCount)
                {
                    Console.WriteLine($"Введіть число в межах від 1 до {commandCount}\n");
                    continue;
                }
                Console.WriteLine(invoker.GetCommandName(option - 1) + ":\n");
                invoker.ExecuteCommand(option - 1);
            }
        }
    }
}
