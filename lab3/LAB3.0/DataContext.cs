using LAB3._0.interfaces;


namespace LAB3._0
{
    public class DataContext : IDataContext
    {
        public IEnumerable<IServer>? Servers { get; set; }
    }
}
