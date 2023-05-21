namespace LAB4.commands
{
    public interface ICommand
    {
        void Execute();
        string GetCommandName();
    }
}
