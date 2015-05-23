namespace MedianVectorFilter.Parsers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class ArgumentsParser
    {
        private const string FilenameWithoutExtensionRegex = @".*(?=\.)";

        public static Arguments Parse(string[] arguments)
        {
            var pictureFilename = arguments.First();
            var pictureFilenameWithoutExtension = Regex.Match(pictureFilename, FilenameWithoutExtensionRegex).ToString();
            var maskSize = Convert.ToInt32(arguments.Skip(1).First());

            return new Arguments
            {
                PictureFilename = pictureFilename,
                PictureFilenameWithoutExtension = pictureFilenameWithoutExtension,
                MaskSize = maskSize
            };
        }
    }
}