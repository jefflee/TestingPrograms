namespace TestingPrograms.StringReplacement
{
    [TestFixture]
    public class StringReplacementTests
    {
        [TestCase("abcdeABCDE~!@#$%^&*()_+=-`[]\\{}|;':\",./<>?1234567", "abcdeABCDE1234567")]
        public void ReplaceByRegx_Success_GiveAString(string input, string expectation)
        {
            var stringReplacement = new MyCore.StringReplacement.StringReplacement();
            var result = stringReplacement.ReplaceByRegx(input, string.Empty);
            result.Should().Be(expectation);
        }

        [TestCase("abcdeABCDE~!@#$%^&*()_+=-`[]\\{}|;':\",./<>?1234567", "abcdeABCDE1234567")]
        public void ReplaceWithALoop_Success_GiveAString(string input, string expectation)
        {
            var stringReplacement = new MyCore.StringReplacement.StringReplacement();
            var result = stringReplacement.ReplaceWithALoop(input, string.Empty);
            result.Should().Be(expectation);
        }
    }
}
