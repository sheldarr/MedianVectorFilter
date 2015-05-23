namespace MedianVectorFilter.Loaders
{
    using System.Drawing;

    public static class ImageLoader
    {
        public static Bitmap LoadAsBitmap(string filename)
        {
            var image = Image.FromFile(filename);

            return new Bitmap(image);
        }
    }
}