using LAB3._0.interfaces;


namespace LAB3._0.helpers
{
    public static class CommandMenu
    {
        private static List<string> _commands = new List<string>();
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
