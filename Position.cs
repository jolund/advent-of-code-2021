using System.Collections.Generic;


namespace advent_of_code_2021
{
    public class Position
    {
        public int aim {get; private set;}
        public int depth {get; private set;}
        public int horizontal {get; private set;}

        public Position() 
        {
            this.depth = 0;
            this.horizontal = 0;
        }

        public void TravelBasicsFromDirectionList(List<string> directionList)
        {
            foreach(string direction in directionList) 
            {
                Movement m = new Movement(direction);
                
                if ((m.Direction).Equals(Direction.Forward)) {
                    horizontal += m.Speed;
                }
                if ((m.Direction).Equals(Direction.Up)) {
                    depth -= m.Speed;
                }
                if ((m.Direction).Equals(Direction.Down)) {
                    depth += m.Speed;
                }
            }            
        }

        public void TravelWithAimFromDirectionList(List<string> directionList)
        {
            foreach(string direction in directionList) 
            {
                Movement m = new Movement(direction);
                
                if ((m.Direction).Equals(Direction.Forward)) {
                    horizontal += m.Speed;
                    depth += aim * m.Speed;
                    
                }
                if ((m.Direction).Equals(Direction.Up)) {
                    aim -= m.Speed;                   
                }
                if ((m.Direction).Equals(Direction.Down)) {
                    aim += m.Speed;        
                }
            }  
        }

        public string PrintPosition() 
        {
            return $"Horizontal position: {horizontal}  :  Depth: {depth}";
        }

        


    }



    
}