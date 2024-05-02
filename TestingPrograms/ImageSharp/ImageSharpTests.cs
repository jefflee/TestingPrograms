using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace TestingPrograms.ImageSharp
{
    [TestFixture]
    internal class ImageSharpTests
    {
        [Test]
        public void Mutate_JpgFile_WhenGiveANoBackgroundPngFile()
        {
            using var image = Image.Load("ImageSharp/Data/testPic.png");
            var width = image.Width;
            var height = image.Height;

            image.Mutate(x =>
            {
                x.Resize(width, height);
                x.BackgroundColor(Color.White);
            });

            image.Save("ImageSharp/Data/UT1_output_white_bg.jpg");
        }

        [Test]
        public void Mutate_PngFile_WhenGiveANoBackgroundPngFile()
        {
            using var image = Image.Load("ImageSharp/Data/testPic.png");
            var width = image.Width;
            var height = image.Height;
            var resizeOptions = new ResizeOptions
            {
                Mode = ResizeMode.Max,
                PremultiplyAlpha = false,
                Size = new Size(width, height)
            };
            image.Mutate(x => { x.Resize(resizeOptions); });

            image.Save("ImageSharp/Data/UT2_output_no_bg.png");
        }
    }
}