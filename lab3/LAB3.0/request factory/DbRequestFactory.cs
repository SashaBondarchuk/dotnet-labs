using LAB3._0.enums;
using LAB3._0.helpers;
using LAB3._0.interfaces;
using LAB3._0.requests;


namespace LAB3._0.factories
{
    public class DbRequestFactory : IRequestFactory
    {
        public IRequest CreateRequest(string parameters)
        {
            DbRequestType requestType = (DbRequestType)RandProvider.Random.Next(0, 2);
            return new DbRequest()
            {
                Id = Guid.NewGuid(),
                CreationTime = DateTime.Now,
                RequestType = requestType,
                Params = parameters,
            };
        }
    }
}
