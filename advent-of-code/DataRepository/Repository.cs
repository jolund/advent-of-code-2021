using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2021.DataRepository
{
    public class Repository
    {
        private readonly ILogger logger;
        private string datapath;

        public string[] depthMeasurements = null;  
        public string[] travelDirections = null;
        public string[] diagnostics = null;
        public string[] bingoInput = null;

       

        public Repository(ILogger logger, string filepath = null)
        {
            this.logger = logger;
            this.datapath = filepath;

            ReadDataIntorepository();
        }

        public void ReadDataIntorepository()
        {
            depthMeasurements = ReadLines(Path.Combine(datapath, "d01_input.txt"));
            travelDirections = ReadLines(Path.Combine(datapath, "d02_position.txt"));
            diagnostics = ReadLines(Path.Combine(datapath, "d03_diagnostics.txt"));
            bingoInput = ReadLines(Path.Combine(datapath, "d04_bingo.txt"));
        }


        public string[] ReadLines(string pathToFile)
        {
            string[] lines = null;
            if (File.Exists(pathToFile))
            {
                lines = File.ReadAllLines(pathToFile);
                logger.Information($"File read: {pathToFile}. content lines: {lines.Length}" );
            }
            else
            {
                logger.Information($"No file found: {pathToFile}.");
            }
            
            return lines;
        }
    }
}
