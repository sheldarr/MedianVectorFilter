namespace TestsProject
{
    using System.Drawing;
    using MedianVectorFilter.Extensions;
    using NUnit.Framework;

    [TestFixture]
    public class ColorExtensionsTests
    {
        [Test]
        public void ShouldProperlyCalculateRgbDistanceBetweenTwoColors()
        {
            //given
            const double expectedDistance = 1.7320;

            var start = Color.FromArgb(0, 0, 0, 0);

            var end = Color.FromArgb(0, 1, 1, 1);

            //when
            var distance = start.RgbDistanceTo(end);

            //then
            Assert.That(distance, Is.EqualTo(expectedDistance).Within(.001));
        }
    }
}
