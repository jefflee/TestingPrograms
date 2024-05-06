using BenchmarkDotNet.Running;
using MyBenchmarks.StringReplacement;

namespace MyBenchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}

/* * Summary *

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
12th Gen Intel Core i9-12900H, 1 CPU, 20 logical and 14 physical cores
    .NET SDK 8.0.204
    [Host]     : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
DefaultJob : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2


    | Method           | Mean       | Error     | StdDev    | Median     | Allocated |
    |----------------- |-----------:| ---------:| ---------:| ----------:| ---------:|
    | ReplaceByRegx    | 3,592.3 ns | 122.68 ns | 359.80 ns | 3,549.6 ns | 56 B      |
    | ReplaceWithALoop | 206.7 ns   | 6.59 ns   | 17.92 ns  | 200.1 ns   | 256 B     |
*/