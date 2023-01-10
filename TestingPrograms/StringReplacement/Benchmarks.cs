using BenchmarkDotNet.Attributes;

namespace TestingPrograms.StringReplacement
{
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        private const string Input = "abcdeABCDE~!@#$%^&*()_+=-`[]\\{}|;':\",./<>?1234567";

        [Benchmark]
        public string ReplaceByRegx() => new MyCore.StringReplacement.StringReplacement().ReplaceByRegx(Input, string.Empty);

        [Benchmark]
        public string ReplaceWithALoop() => new MyCore.StringReplacement.StringReplacement().ReplaceWithALoop(Input, string.Empty);
    }
}
