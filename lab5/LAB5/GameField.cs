namespace LAB5
{
    public class GameField
    {
        private char[,] board;

        public GameField()
        {
            board = new char[3, 3];
        }

        public void MakeMove(int row, int column, char mark)
        {
            board[row, column] = mark;
        }

        public bool IsAvailableMove(int row, int col)
        {
            return board[row, col] == '\0';
        }

        public bool IsWinningMove(int move)
        {
            int row = move / 3;
            int col = move % 3;
            char sellState = board[row, col];

            if (board[row, 0] == sellState && board[row, 1] == sellState && board[row, 2] == sellState)
                return true;
            if (board[0, col] == sellState && board[1, col] == sellState && board[2, col] == sellState)
                return true;
            if (board[0, 0] == sellState && board[1, 1] == sellState && board[2, 2] == sellState)
                return true;
            if (board[0, 2] == sellState && board[1, 1] == sellState && board[2, 0] == sellState)
                return true;

            return false;
        }

        public bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '\0')
                        return false;
                }
            }
            return true;
        }

        public void PrintBoard()
        {
            BoardRenderer.Render(board);
        }

        public GameMemento SaveState()
        {
            char[,] copy = new char[3, 3];
            Array.Copy(board, copy, board.Length);
            return new GameMemento(copy);
        }

        public void RestoreState(GameMemento state)
        {
            board = state.Board;
        }
    }
}
