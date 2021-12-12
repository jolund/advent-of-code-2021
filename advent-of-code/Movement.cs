
namespace advent_of_code
{
    public class Movement 
    {
        public int Speed { get;}
        public string Direction { get;}
       
        public Movement(string text) {
            string[] data = text.Split(" ");

            Speed = int.Parse(data[1]);
            Direction = data[0];
        }   
    }
}