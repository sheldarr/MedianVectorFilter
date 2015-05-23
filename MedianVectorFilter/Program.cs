namespace MedianVectorFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;

    class Program
    {
        static void Main(string[] args)
        {
            var pictureFilename = args.First();
            var maskSize = Convert.ToInt32(args.Skip(1).First());

            var mask = new Mask(maskSize);

            var picture = Image.FromFile(pictureFilename);
            var originalPicture = new Bitmap(picture);

            ApplyFilter(originalPicture, mask);

            originalPicture.Save(Guid.NewGuid() + ".png");
        }

        private static void ApplyFilter(Bitmap bitmap, Mask mask)
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
            var offset = mask.Size - 2;

            var pixels = new List<Pixel> { pixel };

            for (var y = -offset; y <= offset; y++)
            {
                for (var x = -offset; x <= offset; x++)
                {
                    var neighborX = pixel.Coordinates.X + x;
                    var neighborY = pixel.Coordinates.Y + y;

                    if(x == 0 && y == 0)
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
