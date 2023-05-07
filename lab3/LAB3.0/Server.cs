using LAB3._0.interfaces;


namespace LAB3._0
{
    public class Server : IServer
    {
        public int Id { get; set; }
        public bool IsAccessible { get; private set; } = true;
        public Server(int id)
        {
            Id = id;
        }
        public void ExecuteRequest(IRequest request)
        {
            IsAccessible = false;
            Thread.Sleep(1000);
            Console.WriteLine($"Запит: {request}виконано сервером #{Id}\n");
            IsAccessible = true;
        }
        public override string ToString()
        {
            return $"Server #{Id} IsAccessible: {IsAccessible}";
        }
    }
}
