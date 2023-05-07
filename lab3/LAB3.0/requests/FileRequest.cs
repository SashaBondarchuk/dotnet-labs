using LAB3._0.interfaces;


namespace LAB3._0.requests
{
    public class FileRequest : IRequest
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string? Params { get; set; }

        public override string ToString()
        {
            return $"{Id}\nPARAMETERS: {Params}\nCREATION_TIME: {CreationTime}\n";
        }
    }
}
