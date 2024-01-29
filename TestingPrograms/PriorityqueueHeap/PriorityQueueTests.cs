namespace TestingPrograms.PriorityqueueHeap;

[TestFixture]
internal class PriorityQueueTests
{
    [Test]
    public void PriorityQueue_PrintSmallValueFirst_MinHeapImplementation()
    {
        var birthdays = new PriorityQueue<string, int>();
        AddDataToQueue(birthdays);

        var result = new string[birthdays.Count];
        var i = 0;
        while (birthdays.TryDequeue(out var name, out var birthYear))
        {
            var output = $"{name} born in {birthYear}";
            Console.WriteLine(output);
            result[i] = output;
            i++;
        }

        result.Should().BeEquivalentTo(new[]
        {
            "Kate born in 1982",
            "Jeff born in 1982",
            "Noah born in 1996",
            "May born in 1998",
            "Shur born in 2000",
            "Jamie born in 2014"
        }, options => options.WithStrictOrdering());
    }

    [Test]
    public void PriorityQueue_PrintMaxValueFirst_MaxHeapImplementation()
    {
        var birthdays = new PriorityQueue<string, int>(new IntMaxCompare());
        AddDataToQueue(birthdays);

        var result = new string[birthdays.Count];
        var i = 0;
        while (birthdays.TryDequeue(out var name, out var birthYear))
        {
            var output = $"{name} born in {birthYear}";
            Console.WriteLine(output);
            result[i] = output;
            i++;
        }

        result.Should().BeEquivalentTo(new[]
        {
            "Jamie born in 2014",
            "Shur born in 2000",
            "May born in 1998",
            "Noah born in 1996",
            "Jeff born in 1982",
            "Kate born in 1982"
        }, options => options.WithStrictOrdering());
    }

    private static void AddDataToQueue(PriorityQueue<string, int> birthdays)
    {
        birthdays.Enqueue("May", 1998);
        birthdays.Enqueue("Kate", 1982);
        birthdays.Enqueue("Jeff", 1982);
        birthdays.Enqueue("Shur", 2000);
        birthdays.Enqueue("Jamie", 2014);
        birthdays.Enqueue("Noah", 1996);
    }

    private class IntMaxCompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}