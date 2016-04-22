using TheGameOfLife.Core;

namespace tgol.App
{
    public class LifeGame
    {
        private Board board;

        public LifeGame(Board board)
        {
            this.board = board;
        }

        public Board NextRound()
        {
            var newBoard = board.GetEmptyBoard();

            for (var x = 0; x < board.Width; x++)
            {
                for (var y = 0; y < board.Height; y++)
                {
                    var aliveNeighbours = board.GetAliveNeighbours(x, y);
                    if (aliveNeighbours == 2 && board.IsAlive(x,y))
                    {
                        newBoard.MakeAlive(x, y);
                    }
                    if (aliveNeighbours == 3)
                    {
                        newBoard.MakeAlive(x, y);
                    }
                }
            }

            board = newBoard;

            return newBoard;
        }
    }
}