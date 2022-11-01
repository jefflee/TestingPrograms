using AutoFixture;
using AutoFixture.NUnit3;
using TestingPrograms.AutoFixture.Tests.TestingClasses;

namespace TestingPrograms.AutoFixture.Tests
{
    public class Test5ParameterizedTests
    {
        [Test]
        [AutoData]
        public void Add_Success_WithAutoData(int a, int b)
        {
            var fixture = new Fixture();
            var sut = fixture.Create<Calculator>();

            sut.Add(a);
            sut.Add(b);

            sut.Value.Should().Be(a + b);
        }

        [Test]
        [InlineAutoData] // AddTwoPositiveNumbers
        [InlineAutoData(0)] // AddZeroAndPositiveNumber
        [InlineAutoData(-5)] // AddNegativeAndPositiveNumber
        public void Add_Success_WithParameterizedWay(int a, int b, Calculator sut)
        {
            sut.Add(a);
            sut.Add(b);

            sut.Value.Should().Be(a + b);
        }
    }
}
