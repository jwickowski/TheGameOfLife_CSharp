namespace TheGameOfLife.Core
{
    public class BoardArrayImp: Board
    {
        private bool[,] board;
        public int Width { get; }
        public int Height { get; }
        public BoardArrayImp(bool[,] initBoard)
        {
            Width = initBoard.GetLength(0);
            Height = initBoard.GetLength(1);
            board = initBoard;
        }

        public bool IsAlive(int x, int y)
        {
            return board[x,y];
        }

        public void MakeAlive(int x, int y)
        {
            board[x, y] = true;
        }

        public void Kill(int x, int y)
        {
            board[x, y] = false;
        }

        public int GetAliveNeighbours(int x, int y)
        {
            var aliveNeighbours = 0;

            for (int indexX = -1; indexX <= 1; indexX++)
            {
                for(int indexY = -1; indexY<=1; indexY++)
                {
                    if (indexY == 0 && indexX == 0)
                    {
                        continue;
                    }
                    if (x + indexX < 0 || x + indexX >= Width)
                    {
                        continue;
                    }
                    if (y + indexY < 0 || y + indexY >= Height)
                    {
                        continue;
                    }
                    if (board[x + indexX, y + indexY])
                    {
                        aliveNeighbours++;
                    }
                }
            }

            return aliveNeighbours;
        }

        public Board GetEmptyBoard()
        {
            return new BoardArrayImp(new bool[Width, Height]);
        }
    }
}