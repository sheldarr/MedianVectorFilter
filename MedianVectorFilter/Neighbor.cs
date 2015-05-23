namespace MedianVectorFilter
{
    using System.Drawing;

    public class Neighbor
    {
        public Vector2 Coordinates { get; set; }
        public Color Color { get; set; }
        public double DistanceToNeighbors { get; set; }
    }
}