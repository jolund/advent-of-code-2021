using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code.BingoSubSystem
{
    public class BingoGame
    {

        private ILogger logger;
        private string[] rawdata = null;

        public int gameIteration = -1;

        public List<int> numberSequence;
        public List<BingoBoard> bingoBoards;
                
        public List<int> boardsWithNoWins = new List<int>();

        public List<WinningRound> winningRounds = new List<WinningRound>();
        public BingoBoard winnerBoard;
        public WinningRound lastWinningRound;

        public BingoGame(ILogger logger, string[] rawdata)
        {
            this.logger = logger.ForContext<BingoGame>();
            this.rawdata = rawdata;
        }
        public BingoGame(ILogger logger)
        {
            this.logger = logger;

            bingoBoards = new List<BingoBoard>();
        }

        public void InitializeGame(string[] rawdata)
        {
            this.rawdata = rawdata;

            // firstline is the number sequence
            string sequence = rawdata[0];
            numberSequence = sequence.Split(',').Select<string,int>(x=> Convert.ToInt32(x)).ToList();
            logger.Information($"Sequence loaded of {numberSequence.Count()} numbers");

            // following that are boards
            int boardId = 0;
            for (int i = 1; i < rawdata.Length; i++) 
            {
                string line = rawdata[i];
                if (line == "")
                {
                    // skipp
                } 
                else
                {
                    if (i+4 < rawdata.Length)
                    {
                     
                        // Read 5 lines for a bingoBoard
                        string[] boardLines = new string[5];

                        boardLines[0] = rawdata[i];
                        boardLines[1] = rawdata[i + 1];
                        boardLines[2] = rawdata[i + 2];
                        boardLines[3] = rawdata[i + 3];
                        boardLines[4] = rawdata[i + 4];

                        BingoBoard bb = new BingoBoard(boardLines, boardId);
                        boardsWithNoWins.Add(boardId);
                        boardId++;
                        bingoBoards.Add(bb);

                        i += 5;
                    }
                }
                
            }
            logger.Information($"Number of Boards loaded: {bingoBoards.Count()} ");

        }

        public void RunGame()
        {
            this.gameIteration = -1;
            foreach (int drawNumber in numberSequence)
            {
                this.gameIteration++;
                logger.Debug($"> { gameIteration } - { drawNumber }");
                foreach (BingoBoard board in bingoBoards)
                {                    
                    bool hadBingo = board.markNumberOnBoard(drawNumber, gameIteration);
                    if(hadBingo)
                    {
                        WinningRound wr = new WinningRound(gameIteration, drawNumber, sumOfUnmarkedValues(board), board);
                        this.winningRounds.Add(wr);

                        if (boardsWithNoWins.Count() == 1 && boardsWithNoWins.Contains(board.boardId))
                        {
                            this.lastWinningRound = wr;
                        }

                        boardsWithNoWins.Remove(board.boardId);
                        logger.Debug($"> { gameIteration } - { drawNumber } - W: {board.boardId}  >> {String.Join(",", boardsWithNoWins)} ");

                        winnerBoard = board;                        
                    }                    
                }               
            }            
        }

        internal string PrintLastBoardWinningRound()
        {
            return printAWinningRound(this.lastWinningRound);           
        }

        public string PrintWinnerRound()
        {
            return printAWinningRound(this.winningRounds[0]);                        
        }


        private string printAWinningRound(WinningRound wr)
        {
            int resultValue = wr.winningNumber * wr.sumOfRemainingNumbers;
            string output = $"Last number in the iteration: {wr.round} . number: {wr.winningNumber} :  BingoBoard:\r\n {wr.board.PrintBoard()} : \r\nresultvalue {resultValue}";
            return output;
        }


        private int sumOfUnmarkedValues(BingoBoard board)
        {

            return board.remainingNumberOnBoard.Sum();
        }
    }

    public class WinningRound
    {
        public int round;
        public int sumOfRemainingNumbers;
        public int winningNumber;
        public BingoBoard board;

        public WinningRound(int round, int winningValue, int sumOfRemainingNumbers, BingoBoard board)
        {
            this.round = round;
            this.sumOfRemainingNumbers = sumOfRemainingNumbers;
            this.board = board.Clone();
            this.winningNumber = winningValue;
        }
    }
}

