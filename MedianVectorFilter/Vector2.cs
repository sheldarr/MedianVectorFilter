namespace MedianVectorFilter
{
    public class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Vector2 FromCoordinates(int x, int y)
        {
            return new Vector2
            {
                X = x,
                Y = y
            };
        } 
    }
}