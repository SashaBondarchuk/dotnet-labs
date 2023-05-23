namespace LAB5
{
    public static class BoardRenderer
    {
        public static void Render(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < 3; col++)
                {
                    char mark = board[row, col];
                    Console.Write(mark != '\0' ? mark.ToString() : " ");
                    Console.Write(" | ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
