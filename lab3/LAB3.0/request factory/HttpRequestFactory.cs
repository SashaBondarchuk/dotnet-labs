using LAB3._0.enums;
using LAB3._0.helpers;
using LAB3._0.interfaces;
using LAB3._0.requests;


namespace LAB3._0.factories
{
    public class HttpRequestFactory : IRequestFactory
    {
        public IRequest CreateRequest(string parameters)
        {
            HttpRequestType requestType = (HttpRequestType)RandProvider.Random.Next(0, 3);
            return new HttpRequest()
            {
                Id = Guid.NewGuid(),
                CreationTime = DateTime.Now,
                RequestType = requestType,
                Params = parameters,
            };
        }
    }
}
