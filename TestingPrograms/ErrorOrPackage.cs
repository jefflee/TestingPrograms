using ErrorOr;
using FluentAssertions.Execution;
using Throw;

namespace TestingPrograms;

/// <summary>
///     https://github.com/amantinband/error-or
/// </summary>
[TestFixture]
internal class ErrorOrPackage
{
    [Test]
    public void BasicExampleOfResultPattern()
    {
        var result = Divide(4, 2);

        if (result.IsError)
        {
            Console.WriteLine(result.FirstError.Description);
        }
    }

    [Test]
    public void ExampleOfSwitch()
    {
        var result = Divide(4, 2);

        // Use switch, if you don't need a return value.
        // Use match, if you need a return value.
        result.Switch(
            r => Console.WriteLine($"Result is {r}"),
            errors => errors.ForEach(e => Console.WriteLine($"Error: {e.Description}"))
        );
    }

    [Test]
    public void ExampleOfThen()
    {
        var result = Divide(4, 2)
            .Then(val => val * 2)
            .Then(val => $"The result is {val}");

        result.Value.Should().Be("The result is 4");

        result.Throw().IfType<Error>();
    }

    [Test]
    public void ExampleOfThen_ReturnError_WhenDevide0()
    {
        var result = Divide(4, 0)
            .Then(val => val * 2)
            .Then(val => $"The result is {val}");

        using (new AssertionScope())
        {
            result.Value.Should().BeNull();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].Code.Should().Be("General.Unexpected");
        }
    }

    private ErrorOr<float> Divide(int a, int b)
    {
        if (b == 0)
        {
            return Error.Unexpected(description: "Cannot divide by zero");
        }

        return a / b;
    }

    [Test]
    public void BuiltInResult()
    {
        // https://github.com/amantinband/error-or?tab=readme-ov-file#built-in-result-types-resultsuccess-

        var result = PrintString("Jeff");

        if (result.IsError)
        {
            Console.WriteLine(result.FirstError.Description);
        }
    }

    private ErrorOr<Success> PrintString(string str)
    {
        Console.WriteLine(str);

        return Result.Success;
    }
}