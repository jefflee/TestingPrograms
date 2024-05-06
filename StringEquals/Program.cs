using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringEquals
{
    public class Program
    {
        private readonly string[] _tokens = { "This", "is", "a", "pen", "This", "is", "an", "apple." };

        private static void Main(string[] args)
        {
            // Do benchmark test
            // BenchmarkTest();

            // Word count test
            new WordCounter().PerformanceTest();
        }

        /* * Benchmark Summary *

        BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
        12th Gen Intel Core i9-12900H, 1 CPU, 20 logical and 14 physical cores
            .NET SDK 8.0.204
        [Host]     : .NET 6.0.28 (6.0.2824.12007), X64 RyuJIT AVX2
            DefaultJob : .NET 6.0.28 (6.0.2824.12007), X64 RyuJIT AVX2


        | Method                                    | Mean      | Error    | StdDev    |
        |------------------------------------------ |----------:|---------:|----------:|
        | StringCountWithOrdinalIgnoreCase          |  32.97 ns | 2.165 ns |  6.384 ns |
        | StringCountWithInvariantCultureIgnoreCase | 289.61 ns | 9.111 ns | 25.699 ns |
         */

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
            var count = 0;

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