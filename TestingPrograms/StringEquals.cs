namespace TestingPrograms
{
    [TestFixture]
    public class StringEquals
    {
        [TestCase("‰", "a", false)]
        public void Equals_WhenUsingOrdinalIgnoreCase(string left, string right, bool isEqualed)
        {
            left.Equals(right, StringComparison.OrdinalIgnoreCase).Should().Be(isEqualed);
        }

        [TestCase("lasst", "laﬂt", true)]
        public void Equals_WhenUsingInvariantCultureIgnoreCase(string left, string right, bool isEqualed)
        {
            var c = Thread.CurrentThread.CurrentCulture;
            left.Equals(right, StringComparison.InvariantCulture).Should().Be(isEqualed);
        }
    }
}