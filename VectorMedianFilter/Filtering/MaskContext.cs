namespace MedianVectorFilter.Filtering
{
    using System.Collections.Generic;

    public class MaskContext
    {
        public ICollection<Pixel> Pixels;

        public MaskContext()
        {
            Pixels = new List<Pixel>();
        }
    }
}