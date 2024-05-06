using Throw;

namespace TestingPrograms;

/// <summary>
///     https://github.com/amantinband/throw
/// </summary>
[TestFixture]
internal class ThrowPackage
{
    [Test]
    public void Throw_DefaultException_WhenTheStringIsFoo()
    {
        void LocalFunc()
        {
            "foo".Throw().IfEquals("foo");
        }

        var act = () => LocalFunc();

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void Throw_SpecificException_WhenTheStringIsFoo()
    {
        void LocalFunc()
        {
            "foo".Throw(() => new TimeoutException("test")).IfEquals("foo");
        }

        var act = () => LocalFunc();

        act.Should().Throw<TimeoutException>();
    }

    [Test]
    public void Throw_Exception_WhenTheListContains5()
    {
        void LocalFunc()
        {
            // Verify the contains integer 5.
            var list = Enumerable.Range(1, 10);
            var isExisted = list.Any(x => x == 5);
            isExisted.Throw().IfTrue();
        }

        var act = LocalFunc;

        act.Should().Throw<ArgumentException>();
    }
}