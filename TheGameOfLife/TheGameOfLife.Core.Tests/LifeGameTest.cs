using FluentAssertions;
using tgol.App;
using Xunit;

namespace TheGameOfLife.Core.Tests
{
    public class LifeGameTest
    {
        [Fact]
        public void oneCell()
        {
            var board = new BoardArrayImp(new bool[1, 1] { { true } });
            var lifeGame = new LifeGame(board);
            Board newBoard = lifeGame.NextRound();

            newBoard.IsAlive(0, 0).Should().BeFalse();
        }

        [Fact]
        public void twoCells()
        {

            var board = new BoardArrayImp(new bool[1, 2] { { true, true } });
            var lifeGame = new LifeGame(board);
            Board newBoard = lifeGame.NextRound();

            newBoard.GetArray().ShouldBeEquivalentTo(new bool[,] { { false, false } });
        }

        [Fact]
        public void threeInRow_after_one_round()
        {
            var board = new BoardArrayImp(new bool[3, 3]
            {
                { false, false, false },
                { true, true, true },
                { false, false, false }
            });
            var lifeGame = new LifeGame(board);
            Board newBoard = lifeGame.NextRound();

            newBoard.GetArray().ShouldBeEquivalentTo(new bool[,] { 
                { false, true, false },
                { false, true, false },
                { false, true, false } });
        }

        [Fact]
        public void Fact5()
        {
            var board = new BoardArrayImp(new bool[3, 3]
            {
                { false, true, false },
                { true, true, true },
                { false, false, true }
            });
            var lifeGame = new LifeGame(board);
            Board newBoard = lifeGame.NextRound();

            newBoard.GetArray().ShouldBeEquivalentTo(new bool[,] {
                { true, true, true },
                { true, false, true },
                { false, false, true } });
        }

        [Fact]
        public void threeInRow_after_two_round()
        {
            var board = new BoardArrayImp(new bool[3, 3]
            {
                { false, false, false },
                { true, true, true },
                { false, false, false }
            });
            var lifeGame = new LifeGame(board);
            lifeGame.NextRound();
            Board newBoard = lifeGame.NextRound();

            newBoard.GetArray().ShouldBeEquivalentTo(new bool[,] {
               { false, false, false },
                { true, true, true },
                { false, false, false }});
        }
    }
}
