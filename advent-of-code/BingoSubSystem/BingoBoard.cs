using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code.BingoSubSystem
{
    public class BingoBoard
    {
        public int boardId;
        public int[,] board = new int[5, 5];
        public int[,] marked = new int[5, 5];

        public List<int> remainingNumberOnBoard = new List<int>();
      

        public BingoBoard(string[] lines, int id)
        {
            parseStringLinesToBoard(lines);
            this.boardId = id;
        }
        private BingoBoard()
        {

        }

        public bool markNumberOnBoard(int number, int gameIteration)
        {
            return markNumberOnMatrixBoard(number, gameIteration);
            //return markNumberOnListBoard(number, gameIteration);
        }

        public bool markNumberOnMatrixBoard(int number, int gameIteration)
        {
            if (!remainingNumberOnBoard.Contains(number))
            {
                return false;
            }

            bool wasMarked = false;
            int[] columnsums = new int[5];
            int[] rowsums = new int[5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i,j] == number && marked[i,j] == 0)
                    {
                        marked[i, j] = 1;
                        wasMarked = true;
                        remainingNumberOnBoard.Remove(number);
                    }

                    columnsums[i] += marked[i, j];
                    rowsums[j] += marked[i, j];
                }
            }

            if (wasMarked)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (columnsums[i] == 5 || rowsums[i] == 5 )
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public string PrintBoard()
        {
            string output = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    output += string.Format("{0,2}", board[i, j]) + " ";
                }
                output.TrimEnd();
                output += "\r\n";
            }
            return output.TrimEnd();
        }


        private void parseStringLinesToBoard(string[] lines)
        {
            List<int>[] remainingNumberRows = new List<int>[5];
            for (int i = 0;i<lines.Length;i++)
            {         
                try { 
                    remainingNumberRows[i] = lines[i].Trim().Replace("  ", " ").Split(' ').Select<string,int>(x=>Convert.ToInt32(x)).ToList();
                    this.remainingNumberOnBoard.AddRange(lines[i].Trim().Replace("  ", " ").Split(' ').Select<string,int>(x=>Convert.ToInt32(x)).ToList());
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"{lines[i]} iteration: {i}", e);
                }
            }

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < remainingNumberRows.Length; j++) 
                {
                    board[i, j] = remainingNumberRows[i][j];
                }                
            }
        }

        public BingoBoard Clone()
        {
            BingoBoard nbb = new BingoBoard();
            
            nbb.boardId = this.boardId;
            nbb.board = this.board;


            for (int i = 0; i < 5; i++)
            {
              
            }
            return nbb;
        }
    }
}
