using System.Buffers;

namespace TestingPrograms.DotNet8.SearchValuesType;

internal class SearchValuesTests
{
    private const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

    private readonly SearchValues<char> _base64SearchVals = SearchValues.Create(Base64Chars);

    private char[] _base64CharsArr =
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

    private bool IsBase64(string inputString)
    {
        return inputString.AsSpan().IndexOfAnyExcept(_base64SearchVals) == -1;
    }

    [Test]
    public void IsBase64_true_WhenGiveAValidBased64String()
    {
        var input = "as89dha98d=";
        IsBase64(input).Should().BeTrue();
    }

    [Test]
    public void IsBase64_false_WhenInputContainsInvalidCharacters()
    {
        var input = "as89dh%a98d=";
        IsBase64(input).Should().BeFalse();
    }
}