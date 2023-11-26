using System.Buffers;

namespace TestingPrograms.DotNet8.SearchValuesType;

internal class SearchValuesTests
{
    private const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

    private readonly SearchValues<char> _base64SearchVals = SearchValues.Create(Base64Chars);

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