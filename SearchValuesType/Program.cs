using BenchmarkDotNet.Running;
using SearchValuesType;

BenchmarkRunner.Run<Benchmarks>();


/* * Summary *

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
12th Gen Intel Core i9-12900H, 1 CPU, 20 logical and 14 physical cores
    .NET SDK 8.0.204
    [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2


    | Method                | ExampleText          | Mean       | Error     | StdDev     | Median     | Allocated |
    |---------------------- |--------------------- |-----------:| ---------:| ----------:| ----------:| ----------:|
    | IsBase64_SearchValues | 6iFbuI ^ pe68k       | 4.097 ns   | 0.1544 ns | 0.4381 ns  | 4.044 ns   | - |
    | IsBase64_CharArray    | 6iFbuI ^ pe68k       | 30.201 ns  | 0.6412 ns | 1.5487 ns  | 30.273 ns  | - |
    | IsBase64_Naive        | 6iFbuI ^ pe68k       | 57.114 ns  | 1.1996 ns | 3.2433 ns  | 57.005 ns  | - |
    | IsBase64_SearchValues | dQw4w9WgXcQ          | 3.489 ns   | 0.1791 ns | 0.5196 ns  | 3.360 ns   | - |
    | IsBase64_CharArray    | dQw4w9WgXcQ          | 51.840 ns  | 1.0736 ns | 3.0630 ns  | 51.560 ns  | - |
    | IsBase64_Naive        | dQw4w9WgXcQ          | 88.365 ns  | 2.0880 ns | 6.1237 ns  | 87.109 ns  | - |
    | IsBase64_SearchValues | dQw4w(...)WgXcQ[55]  | 4.087 ns   | 0.1738 ns | 0.5041 ns  | 3.994 ns   | - |
    | IsBase64_CharArray    | dQw4w(...)WgXcQ[55]  | 82.621 ns  | 1.6876 ns | 3.9112 ns  | 80.807 ns  | - |
    | IsBase64_Naive        | dQw4w(...)WgXcQ[55]  | 473.773 ns | 9.4678 ns | 24.6082 ns | 466.248 ns | - |

*/