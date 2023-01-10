using BenchmarkDotNet.Running;
using MyBenchmarks.StringReplacement;

namespace MyBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}