using AutoFixture;
using TestingPrograms.AutoFixture.Tests.TestingClasses;

namespace TestingPrograms.AutoFixture.Tests
{
    public class AnonymousDataTests
    {
        [Test]
        public void GenerateTestingData()
        {
            var fixture = new Fixture();

            Console.WriteLine($"string={fixture.Create<string>()}");
            Console.WriteLine($"char={fixture.Create<char>()}");

            Console.WriteLine($"int={fixture.Create<int>()}");
            Console.WriteLine($"decimal={fixture.Create<decimal>()}");
            Console.WriteLine($"byte={fixture.Create<byte>()}");
            Console.WriteLine($"double={fixture.Create<double>()}");
            Console.WriteLine($"short={fixture.Create<short>()}");
            Console.WriteLine($"long={fixture.Create<long>()}");
            Console.WriteLine($"sbyte={fixture.Create<sbyte>()}");
            Console.WriteLine($"float={fixture.Create<float>()}");
            Console.WriteLine($"ushort={fixture.Create<ushort>()}");
            Console.WriteLine($"uint={fixture.Create<uint>()}");
            Console.WriteLine($"ulong={fixture.Create<ulong>()}");

            Console.WriteLine($"DateTime={fixture.Create<DateTime>()}");
            Console.WriteLine($"TimeSpan={fixture.Create<TimeSpan>()}");
        }

        [Test]
        public void StringJoin_Success_Give2Strings()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new NameJoiner();

            // Need to install the package AutoFixture.SeedExtensions.
            var firstName = fixture.Create("First_");
            var lastName = fixture.Create("Last_");

            // act
            var result = sut.Join(firstName, lastName);

            // assert
            result.Should().Be(firstName + ' ' + lastName);
        }

        [Test]

        public void IntCalculator_Success_GiveAnInt()
        {
            // arrange
            var sut = new IntCalculator();
            Fixture fixture = new Fixture();

            // act
            sut.Subtract(fixture.Create<int>());

            // assert
            sut.Value.Should().BeNegative();
        }

        [Test]
        public void DecimalCalculator_Success_GiveAnDecimal()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new DecimalCalculator();

            decimal num = fixture.Create<decimal>();

            // act
            sut.Add(num);

            // assert
            sut.Value.Should().Be(num);
        }
    }
}
