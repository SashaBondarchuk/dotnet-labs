using LAB4.commands;

namespace LAB4
{
    public class Invoker
    {
        private readonly List<ICommand> commands = new();
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
