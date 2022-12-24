namespace TestingPrograms
{
    [TestFixture]
    public class StringEquals
    {
        [TestCase("ä", "a", false)]
        public void Equals_WhenUsingOrdinalIgnoreCase(string left, string right, bool isEqualed)
        {
            left.Equals(right, StringComparison.OrdinalIgnoreCase).Should().Be(isEqualed);
        }

        [TestCase("lasst", "laßt", true)]
        public void Equals_WhenUsingInvariantCultureIgnoreCase(string left, string right, bool isEqualed)
        {
            // todo: Can't find a way to let it be true.
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-CH");
            //left.Equals(right, StringComparison.CurrentCulture).Should().Be(isEqualed);
        }
    }
}