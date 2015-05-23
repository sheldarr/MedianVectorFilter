namespace MedianVectorFilter
{
    using System.Drawing;

    public class Pixel
    {
        public Vector2 Coordinates { get; set; }
        public Color Color { get; set; }
        public double TotalDistanceToNeighbors { get; set; }
    }
}