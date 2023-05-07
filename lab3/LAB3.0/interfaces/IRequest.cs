namespace LAB3._0.interfaces
{
    public interface IRequest
    {
        Guid Id { get; set; }
        DateTime CreationTime { get; set; }
        string? Params { get; set; }
    }
}
