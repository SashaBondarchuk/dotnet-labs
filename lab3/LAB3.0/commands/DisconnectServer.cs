using LAB3._0.helpers;
using LAB3._0.interfaces;


namespace LAB3._0.commands
{
    public class DisconnectServer : ICommand
    {
        private readonly IReceiver _receiver;
        public DisconnectServer(IReceiver receiver)
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
                    Console.WriteLine("ID має бути більше за 0.");
                    continue;
                }
                break;
            }
            try
            {
                _receiver.DisconnectServer(serverID);
                Console.WriteLine($"Cервер #{serverID} видалено з пула серверів\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
        }

        public string GetCommandName()
        {
            return "Від'єднати сервер";
        }
    }
}
