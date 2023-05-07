using LAB3._0.interfaces;


namespace LAB3._0
{
    public class DataInitializer
    {
        private readonly IDataContext dataContext;
        public DataInitializer(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void InitializeServers()
        {
            dataContext.Servers = new List<IServer>()
            {
                new Server(id: 1),
                new Server(id: 2),
                new Server(id: 3),
                new Server(id: 4)
            };
        }
    }
}
