using LAB1.classes;
using LAB1.commands;
using LAB1.interfaces;
using LAB1.services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace LAB1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;

            /* With DI Container 
            
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDataProvider, DataProvider>();
            services.AddScoped<IDataHandler, DataHandler>();

            var container = services.BuildServiceProvider();

            
            IDataHandler dataHandler = container.GetService<IDataHandler>();
            /* ================= */

            /* Without DI Container */
            IDataProvider dataProvider = new DataProvider();
            IDataHandler dataHandler = new DataHandler(dataProvider);
            /* ===================== */

            CommandMenu.LoadMenu();
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

            
            while (true)
            {
                int option;
                Console.Write("Запит #");
                try
                {
                    option = int.Parse(Console.ReadLine());
                    if (option < 1 || option > invoker.GetCommandsCount())
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Введіть число в межах від 1 до кількості команд");
                    continue;
                }
                invoker.ExecuteCommand(option - 1);
            }
        }
    }
}
