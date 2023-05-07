namespace LAB3._0.interfaces
{
    public interface IReceiver
    {
        IEnumerable<IServer> GetAvailableServers();
        void ConnectToServer(int serverId);
        void DisconnectServer(int serverId);
        void SendRequest(IRequest request);
    }
}
