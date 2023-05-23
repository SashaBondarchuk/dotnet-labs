namespace LAB5
{
    public class Player
    {
        public char Side { get; }
        public Player(char side)
        {
            Side = side;
        }
        public int GetMove(GameField board)
        {
            while (true)
            {
                Console.Write("Введіть рядок клітинки: ");
                int row = InputHelper.GetInteger();
                Console.Write("Введіть стовпець клітинки: ");
                int col = InputHelper.GetInteger();
                if (!board.IsAvailableMove(row, col))
                {
                    Console.WriteLine("Спробуйте ввести інше значення");
                    continue;
                }
                return row * 3 + col;
            }
        }
    }
}
