using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code.HydrothermalDectionSubSystem
{
    public class HydrothermalVentDetection
    {
        private ILogger logger;

        public int[,] OceanFloorMap = new int[1000, 1000];

        List<Line> LineData = new List<Line>();
        List<Line> LinesDrawnOnMap = new List<Line>();

        public HydrothermalVentDetection(ILogger logger)
        {
            this.logger = logger.ForContext<HydrothermalVentDetection>();
        }

        public void InitializeData(string[] rawdata)
        {
            OceanFloorMap = new int[1000, 1000];
            LineData = new List<Line>();
            LinesDrawnOnMap = new List<Line>();

            logger.Information($"Initializing data for HydrothermalVentDetection");
            foreach (string line in rawdata)
            {
                string[] twoPoints = line.Split(" -> ");

                Point a = ParseToPoint(twoPoints[0]);
                Point b = ParseToPoint(twoPoints[1]);
                LineData.Add(new Line(a, b));
            }

            logger.Information($"Lines created {LineData.Count()}");
        }

                private Point ParseToPoint(string inputstring)
        {
            // x,y
            int[] vals = inputstring.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            return new Point(vals[0], vals[1]);
        }

        public int countOnMap()
        {
            int count = 0;
            for (int w = 0; w < 1000; w++)
            {
                for (int h = 0; h < 1000; h++)
                {
                    if (OceanFloorMap[w, h] > 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void DrawALine(Line line)
        {
            logger.Debug($" Drawing: {line.ToString()}");
            int height = Math.Abs(line.Begin.Y - line.End.Y);
            int width = Math.Abs(line.Begin.X - line.End.X);

            int xOffset = line.Begin.X;
            int yOffset = line.Begin.Y;
            if (line.IsHorizontalOrVerticalLine())
            {
                if (line.Begin.X >= line.End.X && line.Begin.Y >= line.End.Y)
                {
                    for (int w = 0; w <= width; w++)
                    {
                        for (int h = 0; h <= height; h++)
                        {
                            OceanFloorMap[xOffset + w * -1, yOffset + h * -1] += 1;
                            logger.Debug($"{w},{h}");
                        }
                    }
                }

                if (line.Begin.X < line.End.X && line.Begin.Y >= line.End.Y)
                {
                    for (int w = 0; w <= width; w++)
                    {
                        for (int h = 0; h <= height; h++)
                        {
                            OceanFloorMap[xOffset + w, yOffset + h * -1] += 1;
                            logger.Debug($"{w},{h}");
                        }
                    }
                }

                if (line.Begin.X < line.End.X && line.Begin.Y < line.End.Y)
                {
                    for (int w = 0; w <= width; w++)
                    {
                        for (int h = 0; h <= height; h++)
                        {
                            OceanFloorMap[xOffset + w, yOffset + h] += 1;
                            logger.Debug($"{w},{h}");
                        }
                    }
                }

                if (line.Begin.X >= line.End.X && line.Begin.Y < line.End.Y)
                {
                    for (int w = 0; w <= width; w++)
                    {
                        for (int h = 0; h <= height; h++)
                        {
                            OceanFloorMap[xOffset + w * -1, yOffset + h] += 1;
                            logger.Debug($"{w},{h}");
                        }
                    }
                }
            } 
            else // diagonal always
            {
                if (line.Begin.X >= line.End.X && line.Begin.Y >= line.End.Y)
                {
                    for (int w = 0; w <= width; w++)
                    {
                        OceanFloorMap[xOffset + w * -1, yOffset + w * -1] += 1;
                        logger.Debug($"{xOffset + w * -1},{yOffset + w * -1}");
                    }
                }

                if (line.Begin.X < line.End.X && line.Begin.Y >= line.End.Y)
                {
                    for (int w = 0; w <= width; w++)
                    {
                        OceanFloorMap[xOffset + w, yOffset + w * -1] += 1;
                        logger.Debug($"{xOffset + w},{yOffset + w * -1}");
                    }
                }

                if (line.Begin.X < line.End.X && line.Begin.Y < line.End.Y)
                {
                    for (int w = 0; w <= width; w++)
                    {
                        OceanFloorMap[xOffset + w, yOffset + w] += 1;
                        logger.Debug($"{xOffset + w},{yOffset + w}");
                    }
                }

                if (line.Begin.X >= line.End.X && line.Begin.Y < line.End.Y)
                {
                    for (int w = 0; w <= width; w++)
                    {
                        OceanFloorMap[xOffset + w * -1, yOffset + w] += 1;
                        logger.Debug($"{xOffset + w * -1},{yOffset + w}");
                        
                    }
                }
            }
        }

        public void DrawHorizontalAndVerticalLinesOnMap()
        {
            foreach (Line l in LineData)
            {
                if (l.IsHorizontalOrVerticalLine())
                {
                    DrawALine(l);
                    LinesDrawnOnMap.Add(l);
                }
            }
            logger.Information($"Lines drawned on map: {LinesDrawnOnMap.Count()}"); 
        }

        public void DrawHAllLinesOnMap()
        {
            foreach (Line l in LineData)
            {                
                DrawALine(l);
                LinesDrawnOnMap.Add(l);
            }
            logger.Information($"Lines drawned on map: {LinesDrawnOnMap.Count()}");
        }

        private void drawPoint(Point p)
        {
            OceanFloorMap[p.X, p.Y] += 1;
        }
    }






}
