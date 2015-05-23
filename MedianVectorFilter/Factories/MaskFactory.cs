namespace MedianVectorFilter.Factories
{
    using System;
    using Filtering;

    public static class MaskFactory
    {
        public static Mask CreateMask(int size)
        {
            if (size <= 1 || size % 2 == 0)
                throw new ArgumentOutOfRangeException("size", "Mask size must be greater than 1 and odd number.");

            return new Mask(size);
        }
    }
}