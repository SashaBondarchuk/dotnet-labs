using LAB3._0.interfaces;
 

namespace LAB3._0
{
    public class Invoker
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
