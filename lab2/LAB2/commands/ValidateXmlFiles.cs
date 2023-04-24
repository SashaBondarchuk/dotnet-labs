using LAB2.interfaces;


namespace LAB2.commands
{
    class ValidateXmlFiles : ICommand
    {
        private readonly IDataHandler dataHandler;
        public ValidateXmlFiles(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            dataHandler.ValidateXmlFiles();
        }

        public string GetCommandName()
        {
            return "Провалідувати поточні XML - файли";
        }
    }
}
