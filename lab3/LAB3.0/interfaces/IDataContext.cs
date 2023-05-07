namespace LAB3._0.interfaces
{
    public interface IDataContext
    {
        IEnumerable<IServer>? Servers { get; set; }
    }
}
