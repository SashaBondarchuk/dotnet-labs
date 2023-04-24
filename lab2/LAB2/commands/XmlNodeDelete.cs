using LAB2.interfaces;
using System;


namespace LAB2.commands
{
    class XmlNodeDelete : ICommand
    {
        private readonly IDataHandler dataHandler;
        public XmlNodeDelete(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
            {
                throw new Exception("Файл не ініціалізований даними за вказаною схемою");
            }
            dataHandler.XmlNodeDelete();
        }

        public string GetCommandName()
        {
            return "Видалити вузлол Color";
        }
    }
}
