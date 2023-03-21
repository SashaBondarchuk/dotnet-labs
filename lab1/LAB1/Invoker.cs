using LAB1.interfaces;
using System.Collections.Generic;

namespace LAB1
{
    class Invoker
    {
        private List<ICommand> commands = new List<ICommand>();
        public Invoker() {}
        public int GetCommandsCount()
        {
            return commands.Count;
        }
        public void SetUpCommand(ICommand command)
        {
            if(command is ICommand)
            {
                commands.Add(command);
            }
        }
        public void ExecuteCommand(int commandNumber)
        {
            commands[commandNumber].Execute();
        }
    }
}
