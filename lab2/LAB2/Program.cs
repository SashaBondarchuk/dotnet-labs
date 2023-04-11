using LAB2.commands;
using LAB2.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;


namespace LAB2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDataProvider, DataProvider>();
            services.AddTransient<IDataHandler, DataHandler>();

            var container = services.BuildServiceProvider();

            IDataHandler dataHandler = container.GetService<IDataHandler>();


            Invoker invoker = new Invoker();
            invoker.SetUpCommand(new WriteDataToXml(dataHandler));
            invoker.SetUpCommand(new GetFileContent(dataHandler));
            invoker.SetUpCommand(new GetXmlFileNames(dataHandler));
            invoker.SetUpCommand(new GetVehicles(dataHandler));
            invoker.SetUpCommand(new GetSelectedDescendants(dataHandler));
            invoker.SetUpCommand(new GetBrandsAndSort(dataHandler));
            invoker.SetUpCommand(new GetElementWithSelectedText(dataHandler));
            invoker.SetUpCommand(new GetVehiclesWithLinq(dataHandler));
            invoker.SetUpCommand(new XmlNodeDelete(dataHandler));
            invoker.SetUpCommand(new GroupByManufacturer(dataHandler));
            invoker.SetUpCommand(new GetNewVehicles(dataHandler));
            invoker.SetUpCommand(new AllVechilesIs(dataHandler));
            invoker.SetUpCommand(new GetVechilesTillSelectedYear(dataHandler));
            invoker.SetUpCommand(new ChangeColorByVin(dataHandler));
            invoker.SetUpCommand(new GetYearOfOldestCar(dataHandler));  
            invoker.SetUpCommand(new GetCountOfSelectedBrand(dataHandler));
            invoker.SetUpCommand(new GetSelectedVechilesByPlate(dataHandler));
            invoker.SetUpCommand(new TakeWhile(dataHandler));

            CommandMenu.GenerateMenu(invoker.GetCommands());
            CommandMenu.PrintMenu();

            int commandCount = invoker.GetCommandsCount();
            while (true)
            {
                Console.Write("Запит #");
                bool flag = int.TryParse(Console.ReadLine(), out int option);
                if (!flag)
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
                try
                {
                    invoker.ExecuteCommand(option - 1);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файлу не існує");
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
