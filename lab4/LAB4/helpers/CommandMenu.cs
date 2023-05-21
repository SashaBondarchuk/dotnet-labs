namespace LAB4.commands
{
    public class CommandMenu
    {
        private static readonly List<string> _commands = new();
        public static void GenerateMenu(List<ICommand> commands)
        {
            foreach (var command in commands)
            {
                _commands.Add(command.GetCommandName());
            }
        }
        public static void PrintMenu()
        {
            for (int index = 0; index < _commands.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {_commands[index]}");
            }
            Console.WriteLine();
        }
    }
}
