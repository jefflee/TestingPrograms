using System.Buffers;
using BenchmarkDotNet.Attributes;

namespace SearchValuesType;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

    private static readonly char[] Base64CharsArr =
    {
        'A',
        'B',
        'C',
        'D',
        'E',
        'F',
        'G',
        'H',
        'I',
        'J',
        'K',
        'L',
        'M',
        'N',
        'O',
        'P',
        'Q',
        'R',
        'S',
        'T',
        'U',
        'V',
        'W',
        'X',
        'Y',
        'Z',
        'a',
        'b',
        'c',
        'd',
        'e',
        'f',
        'g',
        'h',
        'i',
        'j',
        'k',
        'l',
        'm',
        'n',
        'o',
        'p',
        'q',
        'r',
        's',
        't',
        'u',
        'v',
        'w',
        'x',
        'y',
        'z',
        '0',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9',
        '+',
        '/',
        '='
    };

    private static readonly SearchValues<char> Base64SearchVal = SearchValues.Create(Base64Chars);

    [Params("dQw4w9WgXcQ", "6iFbuI^pe68k", "dQw4w9WgXcQdQw4w9WgXcQdQw4w9WgXcQdQw4w9WgXcQdQw4w9WgXcQ")]
    public string ExampleText { get; set; }

    [Benchmark]
    public bool IsBase64_SearchValues()
    {
        return ExampleText.AsSpan().IndexOfAnyExcept(Base64SearchVal) == -1;
    }

    [Benchmark]
    public bool IsBase64_CharArray()
    {
        return ExampleText.AsSpan().IndexOfAnyExcept(Base64CharsArr) == -1;
    }

    [Benchmark]
    public bool IsBase64_Naive()
    {
        for (var i = 0; i < ExampleText.Length; i++)
        {
            var chr = ExampleText[i];
            if (!Base64CharsArr.Contains(chr))
            {
                return false;
            }
        }

        return true;
    }
}