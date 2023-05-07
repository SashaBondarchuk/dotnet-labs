using LAB3._0.interfaces;
using Microsoft.Extensions.DependencyInjection;
using LAB3._0.commands;
using LAB3._0.helpers;


namespace LAB3._0.classes
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IReceiver, Receiver>();
            services.AddSingleton<IDataContext, DataContext>();
            services.AddSingleton<LoadBalancer>();
            services.AddTransient<DataInitializer>();

            var container = services.BuildServiceProvider();

            DataInitializer dataInitializer = container.GetRequiredService<DataInitializer>();
            dataInitializer.InitializeServers();
            IReceiver receiver = container.GetRequiredService<IReceiver>();
            

            Invoker invoker = new();
            invoker.SetUpCommand(new GetAvailableServers(receiver));
            invoker.SetUpCommand(new ConnectToServer(receiver));
            invoker.SetUpCommand(new DisconnectServer(receiver));
            invoker.SetUpCommand(new SendRequest(receiver));

            CommandMenu.GenerateMenu(invoker.GetCommands());
            CommandMenu.PrintMenu();

            int commandCount = invoker.GetCommandsCount();
            while (true)
            {
                Console.Write("Дія #");
                int option = InputHelper.GetInteger();
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

