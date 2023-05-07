using LAB3._0.factories;
using LAB3._0.helpers;
using LAB3._0.interfaces;


namespace LAB3._0.commands
{
    public class SendRequest : ICommand
    {
        private readonly IReceiver _receiver;
        private IRequestFactory _requestFactory;
        public SendRequest(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            Console.Write("Введіть тип запиту\n1 - Http request\n2 - Database request\n3 - File request\n");
            int userOption;
            while (true)
            {
                userOption = InputHelper.GetInteger();
                if (userOption < 1 || userOption > 3)
                {
                    Console.WriteLine("Уведіть число в межах від 1 до 3");
                    continue;
                }
                break;
            }
            switch (userOption)
            {
                case 1:
                    _requestFactory = new HttpRequestFactory();
                    break;
                case 2:
                    _requestFactory = new DbRequestFactory();
                    break;
                case 3:
                    _requestFactory = new FileRequestFactory();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Введіть параметри запиту:");
            string parameters = InputHelper.GetNotEmptyString();
            IRequest request = _requestFactory.CreateRequest(parameters);
            _receiver.SendRequest(request);
        }

        public string GetCommandName()
        {
            return "Надіслати запит обраного типу";
        }
    }
}
