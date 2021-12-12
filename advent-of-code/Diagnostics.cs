using System.Collections.Generic;
using System.Linq;
using System;

namespace advent_of_code
{
    public class Diagnostics
    {
        public int PowerConsumption {get; private set;}
        public int OxygenGeneration {get; private set;}
        public int CO2ScrubberRating {get; private set;}
        public int LifeSupportRating {get; private set;}

        List<int[]> lines = new List<int[]>();
        int[] countOfOnes = new int[12];

        int inputsize;
       


        public void LoadDiagnostics(List<string> diagnostics) 
        {
            inputsize = diagnostics.First().Count();
            Console.WriteLine($"inputsize {inputsize}");
            foreach(string l in diagnostics) 
            {            
                int[] intArray = new int[inputsize];
                for (int i = 0; i<inputsize; i++) 
                {
                    int v = l[i]-48;
                    intArray[i] = v;

                    countOfOnes[i] += v;
                }
                lines.Add(intArray);
            }

            PowerConsumption = ComputePowerConsumption();

            OxygenGeneration = ComputeOxygenValue();
            CO2ScrubberRating = CompputeCO2ScrubberRating();

            LifeSupportRating = OxygenGeneration*CO2ScrubberRating;

            Console.WriteLine($"A casted char {string.Join(',',new List<int>(countOfOnes).Select(x=>x.ToString())) }");
        }

        public string ComputeGammaString() {            
            return string.Join(string.Empty,countOfOnes.ToList().Select(x=>GetGammaBit(x,inputsize/2).ToString()));
        }
        public string ComputeEpsilonString() {            
            return string.Join(string.Empty,countOfOnes.ToList().Select(x=>GetEpsilon(x,inputsize/2).ToString()));
        }

        private int ComputePowerConsumption() {
            int gamma = Convert.ToInt32(ComputeGammaString(),2);           
            int epsilon = Convert.ToInt32(ComputeEpsilonString(),2);
            return gamma * epsilon;
        }

        private int GetGammaBit(int v, int threashold) {
            if (v>threashold) 
            {
                return 1;
            }
            return 0;
        }

        private int GetEpsilon(int v, int threashold) {
            if (v<threashold) 
            {
                return 1;
            }
            return 0;
        }
        
        public int ComputeOxygenValue() {
            
            int[] array = ComputeOxygenValueList(lines,0).First();
            System.Console.WriteLine(string.Join(string.Empty,array.ToList()));
            return Convert.ToInt32(string.Join(string.Empty,array.ToList()),2);
        }
        //111111111001


        public List<int[]> ComputeOxygenValueList(List<int[]> input, int index) 
        {
            return DrilldownForBit(input, index, 1);
        }

        public List<int[]> DrilldownForBit(List<int[]> input, int index, int decidingBit) 
        {
            //input.ForEach(x=> System.Console.WriteLine(printArray(x)));

            if (input.Count() == 1) {
                return input;
            }
            Console.WriteLine($" {index} {input.Count()} {input[0].Count()}");
            if (index == input[0].Count()) {                
                System.Console.WriteLine("FAIL" + input.Count() );
            }

            List<int[]> zeroes = new List<int[]>();
            List<int[]> ones = new List<int[]>();

            foreach(int[] line in input) 
            {
                if (line[index] == 1) 
                {
                    ones.Add(line);  
                } 
                else 
                {
                    zeroes.Add(line);  
                }                
            }
                            
            if (decidingBit == 1) 
            {
                if (ones.Count() >= zeroes.Count() )
                {
                    return DrilldownForBit(ones,index+1, decidingBit);
                } else {
                    
                    return DrilldownForBit(zeroes,index+1, decidingBit);
                }
            } 
            else // decigin bit = 0       
            {                    
                if (zeroes.Count() <= ones.Count())
                {
                    return DrilldownForBit(zeroes,index+1, decidingBit);
                } else  {
                    return DrilldownForBit(ones,index+1, decidingBit); 
                } 
            }
        }


        private int CompputeCO2ScrubberRating() {
            
            int[] array = DrilldownForBit(lines, 0, 0).First();
            System.Console.WriteLine(string.Join(string.Empty,array.ToList()));
            return Convert.ToInt32(string.Join(string.Empty,array.ToList()),2);     

        }


        private string printArray(int[] array) {
            return string.Join(string.Empty,array.ToList());
        }
    }


}