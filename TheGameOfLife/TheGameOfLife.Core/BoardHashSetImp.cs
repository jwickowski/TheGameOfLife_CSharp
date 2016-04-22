using System.Collections.Generic;

namespace TheGameOfLife.Core
{
    public class BoardHashSetImp : Board
    {
        private HashSet<KeyValuePair<int, int>> board;
        public int Width { get; }
        public int Height { get; }
        public BoardHashSetImp(bool[,] initBoard)
        {
            Width = initBoard.GetLength(0);
            Height = initBoard.GetLength(1);
            board = new HashSet<KeyValuePair<int, int>>();
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (initBoard[x, y])
                        board.Add(new KeyValuePair<int, int>(x, y));
        }

        public bool IsAlive(int x, int y)
        {
            return board.Contains(new KeyValuePair<int, int>(x,y));
        }

        public void MakeAlive(int x, int y)
        {
            board.Add(new KeyValuePair<int, int>(x, y));
        }

        public void Kill(int x, int y)
        {
            if (IsAlive(x, y))
            {
                board.Remove(new KeyValuePair<int, int>(x, y));
            }
        }

        public int GetAliveNeighbours(int x, int y)
        {
            var aliveNeighbours = 0;

            for (int indexX = -1; indexX <= 1; indexX++)
            {
                for (int indexY = -1; indexY <= 1; indexY++)
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
                    if (board.Contains(new KeyValuePair<int, int>(x + indexX, y + indexY)))
                    {
                        aliveNeighbours++;
                    }
                }
            }

            return aliveNeighbours;
        }

        public Board GetEmptyBoard()
        {
            return new BoardHashSetImp(new bool[Width, Height]);
        }
    }
}