namespace LAB3._0.interfaces
{
    public interface IServer
    {
        int Id { get; set; }
        bool IsAccessible { get; }
        void ExecuteRequest(IRequest request);
    }
}
