using LAB1.interfaces;
using System;
using System.Collections.Generic;


namespace LAB1
{
    class CommandMenu
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
