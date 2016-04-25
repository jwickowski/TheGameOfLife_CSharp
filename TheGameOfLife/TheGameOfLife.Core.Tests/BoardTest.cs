

using System.Collections.Generic;
using System.Dynamic;
using FluentAssertions;
using tgol.App;
using Xunit;

namespace TheGameOfLife.Core.Tests
{
    public abstract class BoardTest
    {
        protected abstract Board GetBoardFromArray(bool[,] array);

        [Fact]
        public void InitSimpleBoard()
        {
            Board board = GetBoardFromArray(new bool[1, 1] { { false } });
            board.IsAlive(0, 0).Should().BeFalse();
        }

        [Fact]
        public void MakeAlive()
        {
            var board = GetBoardFromArray(new bool[1, 1] { { false } });
            board.MakeAlive(0, 0);
            board.IsAlive(0, 0).Should().BeTrue();
        }

        [Fact]
        public void OneNeighbour()
        {
            var board = GetBoardFromArray(new bool[1, 2] { { false, true } });

            board.GetAliveNeighbours(0, 0).Should().Be(1);
        }

        [Fact]
        public void ZeroNeighbour()
        {
            var board = GetBoardFromArray(new bool[1, 2] { { false, true } });

            board.GetAliveNeighbours(0, 1).Should().Be(0);
        }

        [Fact]
        public void EightNeighbours()
        {
            var board = GetBoardFromArray(new bool[3, 3]
            {
                { true, true, true},
                { true, false, true },
                { true, true, true }
            });
            board.GetAliveNeighbours(1, 1).Should().Be(8);
        }

        [Fact]
        public void GetEmptyBoard()
        {
            var board = GetBoardFromArray(new bool[4, 3]
            {
                { true, true, true },
                { true, true, true },
                { true, false, true },
                { true, true, true }
            });

            var expectedBoard = new bool[4, 3]
            {{false, false, false},
            {false, false, false},
            {false, false, false},
            {false, false, false}};

           new ArrayableBoardDecorator(board.GetEmptyBoard()).GetArray().ShouldBeEquivalentTo(expectedBoard);
        }

        [Fact]
        public void getArray()
        {
            var board = GetBoardFromArray(new bool[4, 3]
            {
                { true, true, true },
                { true, true, true },
                { true, false, true },
                { true, true, true }
            });

            var expectedBoard = new bool[4, 3]
            {
                {true, true, true},
                {true, true, true},
                {true, false, true},
                {true, true, true}
            };

            new ArrayableBoardDecorator(board).GetArray().ShouldBeEquivalentTo(expectedBoard);
        }
    }
}
