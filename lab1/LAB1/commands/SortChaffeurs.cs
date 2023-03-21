using LAB1.interfaces;
using System;


namespace LAB1.commands
{
    class SortChaffeurs : ICommand
    {
        private readonly IDataHandler dataHandler;
        public SortChaffeurs(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public void Execute()
        {
            foreach (var ch in dataHandler.SortChaffeurs())
            {
                Console.WriteLine(ch);
            }
            Console.WriteLine();
        }
    }
}
