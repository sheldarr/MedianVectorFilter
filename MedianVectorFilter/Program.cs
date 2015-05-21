namespace MedianVectorFilter
{
    using System;
    using System.Linq;
    using System.Drawing;
    using System.Runtime.InteropServices;


    class Program
    {
        static void Main(string[] args)
        {
            var pictureFilename = args.First();

            var picture = Image.FromFile(pictureFilename);

            var bitmapPicture = new Bitmap(picture);
            for (var i = 0; i < bitmapPicture.Width; i++)
            {
                for (var j = 0; j < bitmapPicture.Height; j++)
                {
                    var pixel = bitmapPicture.GetPixel(i,j);
                    var r = pixel.R + 30;
                    var g = pixel.G + 30;
                    var b = pixel.B + 30;

                    r = r > 255 ? 255 : r;
                    g = g > 255 ? 255 : g;
                    b = b > 255 ? 255 : b;

                    var newColor = Color.FromArgb(r, g, b);

                    bitmapPicture.SetPixel(i, j, newColor);
                }
            } 

            bitmapPicture.Save(Guid.NewGuid() + ".bmp");
        }
    }
}
