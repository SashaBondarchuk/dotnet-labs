using LAB2.enums;
using LAB2.interfaces;
using System;
using System.IO;


namespace LAB2.commands
{
    class AllVechilesIs : ICommand
    {
        private readonly IDataHandler dataHandler;
        public AllVechilesIs(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            if (!dataHandler.DocumentIsInitialized())
                throw new FileNotFoundException();
            Console.WriteLine("Введіть тип кузову");
            BodyType type = (BodyType)Enum.Parse(typeof(BodyType), Console.ReadLine());
            Console.WriteLine(dataHandler.AllVechilesIsSedan(type));
        }

        public string GetCommandName()
        {
            return "Чи всi машини мають вказаний тип кузову";
        }
    }
}
