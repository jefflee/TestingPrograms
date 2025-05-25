using BenchmarkDotNet.Running;
using SpanBenchmarks;

BenchmarkRunner.Run<Benchmarks>();

/*
    // * Summary *

   BenchmarkDotNet v0.15.0, Windows 11 (10.0.26100.4061/24H2/2024Update/HudsonValley)
   12th Gen Intel Core i9-12900H 2.90GHz, 1 CPU, 20 logical and 14 physical cores
   .NET SDK 9.0.203
     [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
     DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2


   | Method                  | Number           | Mean     | Error   | StdDev  | Allocated |
   |------------------------ |----------------- |---------:|--------:|--------:|----------:|
   | FormatNumberTraditional | 562759.832431761 | 155.6 ns | 2.18 ns | 1.93 ns |     240 B |
   | FormatNumberWithSpan    | 562759.832431761 | 123.3 ns | 1.90 ns | 1.78 ns |      48 B |

   // * Hints *
   Outliers
     Benchmarks.FormatNumberTraditional: Default -> 1 outlier  was  removed (168.61 ns)
     Benchmarks.FormatNumberWithSpan: Default    -> 1 outlier  was  detected (122.12 ns)

   // * Legends *
     Number    : Value of the 'Number' parameter
     Mean      : Arithmetic mean of all measurements
     Error     : Half of 99.9% confidence interval
     StdDev    : Standard deviation of all measurements
     Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
     1 ns      : 1 Nanosecond (0.000000001 sec)



 */