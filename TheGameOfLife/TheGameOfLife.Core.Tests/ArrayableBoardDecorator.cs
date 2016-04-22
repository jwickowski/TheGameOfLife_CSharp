using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfLife.Core.Tests
{
    public class ArrayableBoardDecorator
    {
        private Board board;

        public ArrayableBoardDecorator(Board board)
        {
            this.board = board;
        }

        public bool[,] GetArray()
        {
            var result = new bool[board.Width, board.Height];
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (board.IsAlive(x, y))
                    {
                        result[x, y] = true;
                    }
                }
            }
            return result;
        }
    }
}
