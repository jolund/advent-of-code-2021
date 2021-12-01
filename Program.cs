﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace advent_of_code_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Advent of Code !");



            if (File.Exists("data/d01_input.txt")) 
            {
                string[] lines = File.ReadAllLines("data/d01_input.txt");
                //string[] lines = File.ReadAllLines("data/test.txt");

                List<int> measurements = lines.Select(x => int.Parse(x)).ToList();

                int increatingCount = countIncreatingMeasurements(measurements);
                Console.WriteLine($"Increaments single: {increatingCount}");

                int increasingCountWindow = countSlidingWindow(measurements);
                Console.WriteLine($"Increaments window: {increasingCountWindow}");
                
            }
                


        }


        private static int countIncreatingMeasurements(List<int> measurements) 
        {
            int increaseCount = 0;
            int lastMeasurement = measurements[0];
            foreach (int m in measurements)
            {
                if(m > lastMeasurement) {                    
                    //print($"last: {lastMeasurement}  this: {m}  is larger {m > lastMeasurement}");
                    increaseCount++;
                } 
                else 
                {
                    //print($"last: {lastMeasurement}  this: {m}  is larger {m > lastMeasurement}");
                }
                lastMeasurement = m;
            }
            return increaseCount;

        }

        private static int countSlidingWindow(List<int> measurements)
        {
            int increaseCount = 0;
            int lastWindowSum = measurements[0] + measurements[1] + measurements[2];
            for(int i = 0; i+2 < measurements.Count; i++) 
            {
                int sum = measurements[i] + measurements[i+1] + measurements[i+2];
                if (sum > lastWindowSum) {
                    increaseCount++;
                }
                //print($"last: {lastWindowSum}  this: {sum}  - {sum > lastWindowSum}  :: {measurements[i]} + {measurements[i+1]} + {measurements[i+2]}");
                lastWindowSum = sum;
                
            }

            return increaseCount;       
     
        }




        private static void print(String s ) 
        {
            Console.WriteLine(s);   
        }

    }
}