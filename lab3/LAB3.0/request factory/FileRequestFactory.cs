using LAB3._0.interfaces;
using LAB3._0.requests;
 

namespace LAB3._0.factories
{
    public class FileRequestFactory : IRequestFactory
    {
        public IRequest CreateRequest(string parameters)
        {
            return new FileRequest()
            {
                Id = Guid.NewGuid(),
                CreationTime = DateTime.Now,
                Params = parameters,
            };
        }
    }
}
