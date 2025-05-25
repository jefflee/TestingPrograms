using BenchmarkDotNet.Attributes;

namespace SpanBenchmarks;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private static readonly Random Random = new();

    [ParamsSource(nameof(RandomNumbers))] public double Number { get; set; }

    public IEnumerable<double> RandomNumbers()
    {
        // Generate a new random double for each benchmark iteration
        yield return Random.NextDouble() * 1_000_000; // Example: random double between 0 and 1,000,000
    }

    // Traditional way - Create many temqporary strings
    [Benchmark]
    public string FormatNumberTraditional()
    {
        var numStr = Number.ToString("F2");
        if (numStr.Contains("."))
        {
            var parts = numStr.Split('.');
            var intPart = parts[0];
            var decPart = parts[1];

            // Insert commas to the integer part
            for (var i = intPart.Length - 3; i > 0; i -= 3)
            {
                intPart = intPart.Insert(i, ",");
            }

            return intPart + "." + decPart;
        }

        return numStr;
    }

    // Span way - reduce temporary string allocations
    [Benchmark]
    public string FormatNumberWithSpan()
    {
        Span<char> buffer = stackalloc char[32];

        if (Number.TryFormat(buffer, out var written, "F2"))
        {
            var numSpan = buffer.Slice(0, written);

            // Add the index of the decimal point
            var dotIndex = numSpan.IndexOf('.');
            if (dotIndex > 3)
            {
                // Insert commas to the integer part
                Span<char> result = stackalloc char[48];
                var resultIndex = 0;

                for (var i = 0; i < dotIndex; i++)
                {
                    if (i > 0 && (dotIndex - i) % 3 == 0)
                    {
                        result[resultIndex++] = ',';
                    }

                    result[resultIndex++] = numSpan[i];
                }

                // copy the decimal part
                numSpan.Slice(dotIndex).CopyTo(result.Slice(resultIndex));
                resultIndex += numSpan.Length - dotIndex;

                return result.Slice(0, resultIndex).ToString();
            }

            return numSpan.ToString();
        }

        return Number.ToString("F2");
    }
}