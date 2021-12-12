using advent_of_code.BingoSubSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace advent_of_code.Tests.BingeSubSystem
{
    public class BingoBard_Tests
    {

        string[] inputLines = { "22 13 17 11  0", "8  2 23  4 24", "21  9 14 16  7", "6 10  3 18  5", "1 12 20 15 19" };

        [Fact]
        public void BingoBard_InitTest()
        {
            BingoBoard bb = new BingoBoard(inputLines, 0);

            Assert.Equal(22, bb.board[0, 0]);
            Assert.Equal(0, bb.board[0, 4]);
            Assert.Equal(21, bb.board[2, 0]);
            Assert.Equal(16, bb.board[2, 3]);
            Assert.Equal(3, bb.board[3, 2]);
            Assert.Equal(19, bb.board[4, 4]);

            Assert.Equal(25, bb.remainingNumberOnBoard.Count());
        }

        [Fact]
        public void BingoBard_noMatch()
        {
            BingoBoard bb = new BingoBoard(inputLines,0);

            bb.markNumberOnBoard(55,0);
            Assert.Equal(25, bb.remainingNumberOnBoard.Count());
        }

        [Fact]
        public void BingoBard_match()
        {
            BingoBoard bb = new BingoBoard(inputLines,0);

            bb.markNumberOnBoard(5,0);

            Assert.Equal(24, bb.remainingNumberOnBoard.Count());

        }

        [Fact]
        public void BingoBard_bingo()
        {
            BingoBoard bb = new BingoBoard(inputLines,0);

            //6 10  3 18  5
            bb.markNumberOnBoard(6,0);
            bb.markNumberOnBoard(10,1);
            bb.markNumberOnBoard(3,2);
            Assert.False(bb.markNumberOnBoard(18,3));
            Assert.True(bb.markNumberOnBoard(5,4));                       

            Assert.Equal(20, bb.remainingNumberOnBoard.Count());

        }

        [Fact]
        public void BingoBard_print()
        {
            BingoBoard bb = new BingoBoard(inputLines,0);
            string boardString = @"22 13 17 11  0 
 8  2 23  4 24 
21  9 14 16  7 
 6 10  3 18  5 
 1 12 20 15 19";
            Assert.Equal(boardString, bb.PrintBoard());
        }
            
    }
}
