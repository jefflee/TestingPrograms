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
        [Params(1000)]
        public int Size { get; set; }

        private IEnumerable<int> _items;

        [GlobalSetup]
        public void Setup()
        {
            _items = Enumerable.Range(1, Size).ToArray();
        }

        [Benchmark]
        public int Min() => _items.Min();

        [Benchmark]
        public int Max() => _items.Max();

        [Benchmark]
        public double Average() => _items.Average();

        [Benchmark]
        public int Sum() => _items.Sum();
    }
}
