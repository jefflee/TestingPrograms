using AutoFixture;
using TestingPrograms.AutoFixture.Tests.TestingClasses;

namespace TestingPrograms.AutoFixture.Tests
{
    public class FirstTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IntCalculator_Success_WithoutAutoFixture()
        {
            // arrange
            var sut = new IntCalculator();

            // act
            sut.Subtract(1);

            // assert
            Assert.True(sut.Value < 0);
        }

        [Test]
        public void IntCalculator_Success_WithAutoFixture()
        {
            // arrange
            var sut = new IntCalculator();
            var fixture = new Fixture();

            // act
            sut.Subtract(fixture.Create<int>());

            // assert
            Assert.True(sut.Value < 0);
        }

        [Test]
        public void IntCalculator_Success_GiveAnIntRangeWithAutoFixture()
        {
            // arrange
            var sut = new IntCalculator();
            var fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, 1000));

            // act
            sut.Subtract(fixture.Create<int>());

            // assert
            Assert.True(sut.Value < 0);
        }
    }
}