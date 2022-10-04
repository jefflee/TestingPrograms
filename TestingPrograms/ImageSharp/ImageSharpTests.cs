using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace TestingPrograms.ImageSharp
{
    [TestFixture]
    internal class ImageSharpTests
    {
        [Test]
        public void ConvertPngToJpeg()
        {
            using (Image image = Image.Load("ImageSharp/Data/testPic.png"))
            {
                int width = image.Width;
                int height = image.Height;
                image.Mutate(x =>
                {
                    x.Resize(width, height);
                    x.BackgroundColor(Color.White);
                });

                image.Save("ImageSharp/Data/output.jpg");
            }
        }
    }
}
