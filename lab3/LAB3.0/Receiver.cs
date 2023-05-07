using LAB3._0.interfaces;


namespace LAB3._0
{
    public class Receiver : IReceiver
    {
        private readonly IDataContext _dataContext;
        private readonly LoadBalancer _loadBalancer;
        public Receiver(IDataContext dataContext, LoadBalancer loadBalancer) 
        {
            _dataContext = dataContext;
            _loadBalancer = loadBalancer;
        }
        public IEnumerable<IServer> GetAvailableServers()
        {
            if (!_dataContext.Servers!.Any())
            {
                throw new Exception("Серверів не зареєстровано");
            }
            return _dataContext.Servers!.Where(s => s.IsAccessible);
        }
        public void ConnectToServer(int serverId)
        {
            if (_loadBalancer.ServerPool.Any(s => s.Id == serverId))
            {
                throw new Exception($"Сервер з Id {serverId} уже був доданий");
            }
            var availableServers = GetAvailableServers().ToList();
            var serverToAdd = availableServers.Single(s => s.Id == serverId);

            _loadBalancer.AddServer(serverToAdd);
        }
        public void DisconnectServer(int serverId)
        {
            var connectedServers = _loadBalancer.ServerPool;
            if (!connectedServers.Any()) 
            {
                throw new Exception("Пул серверів пустий");
            }
            var serverToDelete = connectedServers.Single(s => s.Id == serverId);
            _loadBalancer.RemoveServer(serverToDelete);
        }
        public void SendRequest(IRequest request)
        {
            _loadBalancer.Balance(request);
        }
    }
}
