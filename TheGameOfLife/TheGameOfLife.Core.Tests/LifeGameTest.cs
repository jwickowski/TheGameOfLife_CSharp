using FluentAssertions;
using tgol.App;
using Xunit;
using Xunit.Sdk;

namespace TheGameOfLife.Core.Tests
{
    public class LifeGameTest
    {
        [Fact]
        public void oneCell()
        {
            var inputArray = new bool[1, 1] {{true}};
            var expectedArray = new [,] {{false}};

            ExecuteTest(inputArray, expectedArray);
        }

        [Fact]
        public void twoCells()
        {
            var inputArray = new bool[1, 2] {{true, true}};
            var expectedArray = new bool[,] {{false, false}};

            ExecuteTest(inputArray, expectedArray);
        }

        [Fact]
        public void threeInRow_after_one_round()
        {
            var inputArray = new bool[3, 3]
            {
                {false, false, false},
                {true, true, true},
                {false, false, false}
            };
            var expectedArray = new bool[,]
            {
                {false, true, false},
                {false, true, false},
                {false, true, false}
            };

            ExecuteTest(inputArray, expectedArray);
        }

        [Fact]
        public void Fact5()
        {
            var inputArray = new bool[3, 3]
            {
                {false, true, false},
                {true, true, true},
                {false, false, true}
            };

            var expectedArray = new bool[,]
            {
                {true, true, true},
                {true, false, true},
                {false, false, true}
            };

            ExecuteTest(inputArray, expectedArray);
        }

        [Fact]
        public void threeInRow_after_two_round()
        {

            var inputArray = new bool[3, 3]
            {
                { false, false, false },
                { true, true, true },
                { false, false, false }
            };
            var expectedArray = new bool[,]
            {
                {false, false, false},
                {true, true, true},
                {false, false, false}
            };

            ExecuteTest(inputArray, expectedArray, rounds:2);
        }

        private void ExecuteTest(bool[,] inputArray, bool[,] expectedArray, int rounds = 1)
        {
            var board = new BoardArrayImp(inputArray);
            var lifeGame = new LifeGame(board);
            Board newBoard = null;
            for (int i = 0; i < rounds; i++)
            {
                newBoard = lifeGame.NextRound();
            }
            new ArrayableBoardDecorator(newBoard).GetArray().ShouldBeEquivalentTo(expectedArray);
        }
    }
}
