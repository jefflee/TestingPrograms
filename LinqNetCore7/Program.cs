// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Running;
using LinqNetCore7;

namespace StringEquals
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}


