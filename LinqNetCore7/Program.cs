// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Running;
using LinqNetCore7;

namespace StringEquals
{
    public class Program
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
  [Host]        : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT AVX2
  .NET 6.0      : .NET 6.0.28 (6.0.2824.12007), X64 RyuJIT AVX2
  .NET 7.0      : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  .NET Core 3.1 : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT AVX2


| Method  | Job           | Runtime       | Size | Mean       | Error     | StdDev      | Median     | Allocated |
|-------- |-------------- |-------------- |----- |-----------:| ---------:| ----------_:| ----------:| ---------:|
| Min     | .NET 6.0      | .NET 6.0      | 1000 | 7,442.2 ns | 357.22 ns | 1,053.27 ns | 7,524.6 ns | 32 B      |
| Max     | .NET 6.0      | .NET 6.0      | 1000 | 5,373.2 ns | 106.97 ns | 308.64 ns   | 5,353.5 ns | 32 B      |
| Average | .NET 6.0      | .NET 6.0      | 1000 | 6,272.2 ns | 331.39 ns | 977.11 ns   | 6,059.6 ns | 32 B      |
| Sum     | .NET 6.0      | .NET 6.0      | 1000 | 5,722.1 ns | 113.64 ns | 170.09 ns   | 5,641.5 ns | 32 B      |
| Min     | .NET 7.0      | .NET 7.0      | 1000 | 131.9 ns   | 1.56 ns   | 1.30 ns     | 132.0 ns   | -         |
| Max     | .NET 7.0      | .NET 7.0      | 1000 | 131.9 ns   | 2.67 ns   | 3.07 ns     | 132.4 ns   | -         |
| Average | .NET 7.0      | .NET 7.0      | 1000 | 172.5 ns   | 3.78 ns   | 10.14 ns    | 169.8 ns   | -         |
| Sum     | .NET 7.0      | .NET 7.0      | 1000 | 545.2 ns   | 10.94 ns  | 18.87 ns    | 543.1 ns   | -         |
| Min     | .NET Core 3.1 | .NET Core 3.1 | 1000 | 6,952.1 ns | 235.37 ns |   693.99 ns | 6,764.2 ns |      32 B |
| Max     | .NET Core 3.1 | .NET Core 3.1 | 1000 | 6,403.1 ns | 188.49 ns |   555.75 ns | 6,327.2 ns |      32 B |
| Average | .NET Core 3.1 | .NET Core 3.1 | 1000 | 6,704.7 ns | 356.32 ns | 1,050.63 ns | 6,239.5 ns |      32 B |
| Sum     | .NET Core 3.1 | .NET Core 3.1 | 1000 | 5,647.3 ns |  80.71 ns |    63.01 ns | 5,623.5 ns |      32 B |

*/