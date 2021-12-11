using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Serilog;
using advent_of_code_2021.DataRepository;

namespace advent_of_code_2021
{
    class Program
    {
        
        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();


            logger.Information("TEST");

            Console.WriteLine("Hello Advent of Code !");


            logger.Information("\r\nHello Advent of Code !");
            Repository repository = new Repository(logger,"DataRepository/Data/");


            // depth measurements
            List<int> depthMeasurements = repository.depthMeasurements.Select(x => int.Parse(x)).ToList();
            int increatingCount = countIncreatingMeasurements(depthMeasurements);
            Console.WriteLine($"Increaments single: {increatingCount}");
            int increasingCountWindow = countSlidingWindow(depthMeasurements);
            Console.WriteLine($"Increaments window: {increasingCountWindow}");


            // position with Aim
            Position position = new Position();
            position.TravelBasicsFromDirectionList(repository.travelDirections.ToList());
            print(position.PrintPosition());
            print($"Basics:  {position.PrintPosition()} . multiplication: {position.horizontal * position.depth}");

            Position positionWithAim = new Position();
            positionWithAim.TravelWithAimFromDirectionList(repository.travelDirections.ToList());
            print($"With Aim:  {positionWithAim.PrintPosition()} . multiplication: {positionWithAim.horizontal * positionWithAim.depth}");

            // diagnostics

            Diagnostics d = new Diagnostics();
            d.LoadDiagnostics(repository.diagnostics.ToList());
            print($"PowerConsumption: {d.PowerConsumption}");
            print($"OxygenGeneration: {d.OxygenGeneration}");
            print($"CO2 Scrubber rating: {d.CO2ScrubberRating}");
            print($"Life support rating: {d.LifeSupportRating}");                           
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
