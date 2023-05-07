using LAB3._0.interfaces;


namespace LAB3._0.commands
{
    public class GetAvailableServers : ICommand
    {
        private readonly IReceiver _receiver;
        public GetAvailableServers(IReceiver receiver) 
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            try
            {
                foreach (var server in _receiver.GetAvailableServers())
                {
                    Console.WriteLine(server);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }

        public string GetCommandName()
        {
            return "Показати доступні сервери";
        }
    }
}
