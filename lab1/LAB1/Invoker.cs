using LAB1.interfaces;
using System.Collections.Generic;

namespace LAB1
{
    class Invoker
    {
        private List<ICommand> commands = new List<ICommand>();
        public List<ICommand> GetCommands() 
        { 
            return commands; 
        }
        public int GetCommandsCount()
        {
            return commands.Count;
        }
        public void SetUpCommand(ICommand command)
        { 
            commands.Add(command);
        }
        public void ExecuteCommand(int commandNumber)
        {
            commands[commandNumber].Execute();
        }
        public string GetCommandName(int commandNumber)
        {
            return commands[commandNumber].GetCommandName();
        }
    }
}
