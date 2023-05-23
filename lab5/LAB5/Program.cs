namespace LAB5
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            GameField board = new GameField();
            Player playerX = new Player('X');
            Player playerO = new Player('O');
            Game game = new Game(playerX, playerO, board);

            game.StartGame();
        }
    }
}