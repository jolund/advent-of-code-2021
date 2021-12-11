using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2021
{
    public class BingoSubSystem
    {

        private ILogger logger;
        private string[] rawdata = null;

        public List<int> numberSequence;
        private List<BingoBoard> bingoBoards;

        public BingoSubSystem(ILogger logger, string[] rawdata)
        {
            this.logger = logger;
            this.rawdata = rawdata;
        }

        internal class BingoBoard 
        {
            int[][] board;              
                        
        }
       
    }
}
