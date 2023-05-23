namespace LAB5
{
    public class GameMemento
    {
        public char[,] Board { get; }

        public GameMemento(char[,] board)
        {
            Board = board;
        }
    }
}
