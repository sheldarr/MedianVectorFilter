namespace MedianVectorFilter.Extensions
{
    using System;
    using System.Drawing;

    public static class ColorExtensions
    {
        public static double RgbDistanceTo(this Color start, Color end)
        {
            var distance = Math.Sqrt(
                Math.Pow(end.R - start.R, 2)
                + Math.Pow(end.G - start.G, 2)
                + Math.Pow(end.B - start.B, 2));

            return distance;
        } 
    }
}