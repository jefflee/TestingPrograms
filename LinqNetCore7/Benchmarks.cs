using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LinqNetCore7
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        private IEnumerable<int> _items = new List<int>();

        [Params(1000)] public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _items = Enumerable.Range(1, Size).ToArray();
        }

        [Benchmark]
        public int Min()
        {
            return _items.Min();
        }

        [Benchmark]
        public int Max()
        {
            return _items.Max();
        }

        [Benchmark]
        public double Average()
        {
            return _items.Average();
        }

        [Benchmark]
        public int Sum()
        {
            return _items.Sum();
        }
    }
}