using LAB3._0.enums;
using LAB3._0.interfaces;


namespace LAB3._0.requests
{
    public class HttpRequest : IRequest
    {
        public Guid Id { get; set; }
        public HttpRequestType RequestType { get; set; }
        public DateTime CreationTime { get; set; }
        public string? Params { get; set; }

        public override string ToString()
        {
            return $"{Id}\nTYPE: {RequestType}\nPARAMETERS: {Params}\nCREATION_TIME: {CreationTime}\n";
        }
    }
}
