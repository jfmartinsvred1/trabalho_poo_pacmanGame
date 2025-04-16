namespace PacManGame.Models
{
    public class GameBoard
    {
        private char[,] board;
        public int Width => board.GetLength(1);
        public int Height => board.GetLength(0);

        public GameBoard(string[] layout)
        {
            board = new char[layout.Length, layout[0].Length];
            for (int y = 0; y < layout.Length; y++)
                for (int x = 0; x < layout[y].Length; x++)
                    board[y, x] = layout[y][x];
        }

        public bool IsWall(Position pos) => board[pos.Y, pos.X] == '#';
        public bool IsDot(Position pos) => board[pos.Y, pos.X] == '.';

        public void ClearDot(Position pos)
        {
            if (IsDot(pos))
                board[pos.Y, pos.X] = ' ';
        }

        public void Draw(Position playerPos, Position ghostPos)
        {
            Console.Clear();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (playerPos.X == x && playerPos.Y == y)
                        Console.Write('P');
                    else if (ghostPos.X == x && ghostPos.Y == y)
                        Console.Write('G');
                    else
                        Console.Write(board[y, x]);
                }
                Console.WriteLine();
            }
        }

        public int TotalDots()
        {
            int total = 0;
            foreach (var cell in board)
                if (cell == '.') total++;
            return total;
        }
    }
}
