namespace TestingPrograms.DarkThreadDuplicatedItems
{
    [TestFixture]
    internal class DuplicateItemTests
    {
        [Test]
        public void FindDuplicatedItems_GetDuplicatedString_GiveAnStringArray()
        {
            string[] input = new String[] { "A", "B", "B", "C", "X", "C", "C", "B", "B", "D", "D", "D" };
            string[][] expected =
            {
                new[] { "B", "B" },
                new[] { "C", "C" },
                new[] { "B", "B" },
                new[] { "D", "D","D" },
            };

            var sut = new DuplicateItems();
            var result = sut.FindDuplicatedItems(input, EqualityComparer<string>.Default);
            result.Should().BeEquivalentTo(expected, option => option.WithStrictOrdering());
        }

        [Test]
        public void FindDuplicatedItems_GetDuplicatedInt_GiveAnIntArray()
        {
            int[] input = new int[] { 1, 1, 1, 5, 5, 6, 7, 2, 3, 5, 5, 5 };
            int[][] expected =
            {
                new[] { 1,1,1 },
                new[] { 5,5 },
                new[] { 5,5,5},
            };

            var sut = new DuplicateItems();
            var result = sut.FindDuplicatedItems(input, EqualityComparer<int>.Default);
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void FindDuplicatedItems_NoError_GiveAnOneElementArray()
        {
            string[] input = new String[] { "A" };
            var expected = Array.Empty<string>();

            var sut = new DuplicateItems();
            var result = sut.FindDuplicatedItems(input, EqualityComparer<string>.Default);
            result.Should().BeEquivalentTo(expected, option => option.WithStrictOrdering());
        }

        [Test]
        public void FindDuplicatedItems_NoError_GiveAnEmptyArray()
        {
            string[] input = Array.Empty<string>();
            var expected = Array.Empty<string>();

            var sut = new DuplicateItems();
            var result = sut.FindDuplicatedItems(input, EqualityComparer<string>.Default);
            result.Should().BeEquivalentTo(expected, option => option.WithStrictOrdering());
        }
    }
}
