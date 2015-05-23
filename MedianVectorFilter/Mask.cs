namespace MedianVectorFilter
{
    using System;

    public class Mask
    {
        public int Size { get; private set; }

        public Mask(int size)
        {
            if (size <= 1 || size % 2 == 0)
                throw new ArgumentOutOfRangeException("size", "Mask size must be greater than 1 and odd number.");

            Size = size;
        }
    }
}