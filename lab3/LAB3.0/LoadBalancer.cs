using LAB3._0.interfaces;


namespace LAB3._0
{
    public class LoadBalancer
    {
        public List<IServer> ServerPool { get; } = new List<IServer>();
        private int _currentIndex = 0;
        public void AddServer(IServer server)
        {
            ServerPool.Add(server);
        }
        public void RemoveServer(IServer server)
        {
            ServerPool.Remove(server);
        }
        private IServer GetServer()
        {
            if(ServerPool.Count == 0)
            {
                throw new Exception("Список серверів користувача пустий\n");
            }
            IServer nextServer = ServerPool[_currentIndex];
            _currentIndex = (_currentIndex + 1) % ServerPool.Count;
            if (!nextServer.IsAccessible)
            {
                GetServer();
            }
            return nextServer;
        }
        public void Balance(IRequest request)
        {
            try
            {
                IServer serverToUse = GetServer();
                serverToUse.ExecuteRequest(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
