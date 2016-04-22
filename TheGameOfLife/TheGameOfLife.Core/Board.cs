namespace TheGameOfLife.Core
{
    public interface Board
    {
        bool IsAlive(int x, int y);
        void MakeAlive(int x, int y);
        void Kill(int x, int y);
        int GetAliveNeighbours(int x, int y);
        Board GetEmptyBoard();
        int Width { get; }
        int Height { get; }
    }
}