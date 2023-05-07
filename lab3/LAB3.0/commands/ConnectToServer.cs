using LAB3._0.helpers;
using LAB3._0.interfaces;


namespace LAB3._0.commands
{
    public class ConnectToServer : ICommand
    {
        private readonly IReceiver _receiver;
        public ConnectToServer(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            Console.Write("Введіть ID сервера: ");
            int serverID;
            while (true)
            {
                serverID = InputHelper.GetInteger();
                if (serverID <= 0)
                {
                    Console.WriteLine("ID має бути більше за 0");
                    continue;
                }
                break;
            }
            try
            {
                _receiver.ConnectToServer(serverID);
                Console.WriteLine($"Тепер сервер #{serverID} є в пулі серверів\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
        }

        public string GetCommandName()
        {
            return "Під'єднатись до серверу";
        }
    }
}
