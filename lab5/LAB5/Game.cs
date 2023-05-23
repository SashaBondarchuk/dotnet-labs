namespace LAB5
{
    public class Game
    {
        private readonly Stack<GameMemento> stateHistory = new Stack<GameMemento>();
        private Player currentPlayer;
        private Player PlayerX;
        private Player PlayerO;
        private GameField GameField;
        public Game(Player playerX, Player playerO, GameField gameField)
        {
            PlayerX = playerX;
            PlayerO = playerO;
            GameField = gameField;
            currentPlayer = playerX;
        }
        public void StartGame()
        {
            bool gameOver = false;
            stateHistory.Push(GameField.SaveState());
            while (!gameOver) 
            {
                Console.WriteLine("Хід гравця " + currentPlayer.Side);
                int move = currentPlayer.GetMove(GameField);
                MakeMove(move);
                GameField.PrintBoard();
                if (TryUndoMove()) { continue; }

                if (GameField.IsWinningMove(move))
                {
                    Console.WriteLine($"Гравець {currentPlayer.Side} виграв");
                    gameOver = true;
                }
                else if (GameField.IsBoardFull())
                {
                    Console.WriteLine("Нічия");
                    gameOver = true;
                }
                currentPlayer = (currentPlayer.Side == 'X') ? PlayerO : PlayerX;
            }
        }
        private void MakeMove(int move)
        {
            int row = move / 3;
            int col = move % 3;
            GameField.MakeMove(row, col, currentPlayer.Side);
            GameMemento gameState = GameField.SaveState();
            stateHistory.Push(gameState);
        }
        private bool TryUndoMove()
        {
            char option;
            while (true)
            {
                Console.Write("Для відміни ходу натисніть 'U', для продовження - 'R': ");
                option = InputHelper.GetChar();
                if (option != 'U' && option != 'R')
                {
                    Console.WriteLine("Введіть іншу літеру");
                    continue;
                }
                break;
            }
            if (option == 'U')
            {
                stateHistory.Pop();
                GameMemento gameState = stateHistory.Peek();
                GameField.RestoreState(gameState);
                return true;
            }
            return false;
        }
    }
}
