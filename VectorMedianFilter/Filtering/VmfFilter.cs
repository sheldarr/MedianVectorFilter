namespace MedianVectorFilter.Filtering
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Extensions;

    public static class VmfFilter
    {
        public static void ApplyOnBitmap(Bitmap bitmap, Mask mask)
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var pixel = new Pixel
                    {
                        Coordinates = Vector2.FromCoordinates(x, y),
                        Color = bitmap.GetPixel(x, y),
                    };

                    var maskContext = CreateMaskContextForPixel(bitmap, mask, pixel);
                    var sortedPixels = maskContext.Pixels.OrderBy(pix => pix.TotalDistanceToNeighbors);

                    bitmap.SetPixel(pixel.Coordinates.X, pixel.Coordinates.Y, sortedPixels.First().Color);
                }
            }
        }

        private static MaskContext CreateMaskContextForPixel(Bitmap bitmap, Mask mask, Pixel pixel)
        {
            var offset = (mask.Size -1) / 2;

            var pixels = new List<Pixel> { pixel };

            for (var y = -offset; y <= offset; y++)
            {
                for (var x = -offset; x <= offset; x++)
                {
                    var neighborX = pixel.Coordinates.X + x;
                    var neighborY = pixel.Coordinates.Y + y;

                    if (x == 0 && y == 0)
                        continue;

                    if (neighborX < 0 || neighborX >= bitmap.Width
                        || neighborY < 0 || neighborY >= bitmap.Height)
                        continue;

                    var neighborPixel = new Pixel
                    {
                        Coordinates = Vector2.FromCoordinates(neighborX, neighborY),
                        Color = bitmap.GetPixel(neighborX, neighborY),
                    };

                    pixels.Add(neighborPixel);
                }
            }

            CalculateDistancesToNeighbors(pixels);

            return new MaskContext
            {
                Pixels = pixels
            };
        }

        private static void CalculateDistancesToNeighbors(ICollection<Pixel> pixels)
        {
            foreach (var pixel in pixels)
            {
                pixel.TotalDistanceToNeighbors =
                    pixels.Where(neighborPixel => neighborPixel != pixel).Sum(neighborPixel => neighborPixel.Color.RgbDistanceTo(pixel.Color));
            }
        }
    }
}