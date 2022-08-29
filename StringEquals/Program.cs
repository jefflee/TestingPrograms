using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringEquals
{
    public class Program
    {
        private readonly string[] _tokens = { "This", "is", "a", "pen", "This", "is", "an", "apple." };

        static void Main(string[] args)
        {
            // Do benchmark test
            // BenchmarkTest();

            // Word count test
            new WordCounter().PerformanceTest();
        }

        private static void BenchmarkTest()
        {
            var summary = BenchmarkRunner.Run<Program>();
        }

        [Benchmark]
        public int StringCountWithOrdinalIgnoreCase()
        {
            return StringCount("a", StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]

        public int StringCountWithInvariantCultureIgnoreCase()
        {
            return StringCount("a", StringComparison.InvariantCultureIgnoreCase);
        }

        private int StringCount(string comparedString, StringComparison comparision)
        {
            int count = 0;

            foreach (var token in _tokens)
            {
                if (token.Equals(comparedString, comparision))
                {
                    count++;
                }
            }

            return count;
        }
    }
}