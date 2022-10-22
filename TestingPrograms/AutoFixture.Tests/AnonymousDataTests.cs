using System.Net.Mail;
using AutoFixture;
using FluentAssertions.Execution;
using TestingPrograms.AutoFixture.Tests.TestingClasses;

namespace TestingPrograms.AutoFixture.Tests
{
    public class AnonymousDataTests
    {
        private string _separator = new String('-', 50);

        [Test]
        public void AutoFixture_Create_GenerateTestingData()
        {
            var fixture = new Fixture();

            Console.WriteLine($"string={fixture.Create<string>()}");
            Console.WriteLine($"char={fixture.Create<char>()}");
            Console.WriteLine(_separator);

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
            Console.WriteLine(_separator);

            Console.WriteLine($"DateTime={fixture.Create<DateTime>()}");
            Console.WriteLine($"TimeSpan={fixture.Create<TimeSpan>()}");
            Console.WriteLine(_separator);

            Console.WriteLine($"Guid={fixture.Create<Guid>()}");
            Console.WriteLine($"StatusEnum={fixture.Create<StatusEnum>()}");
            Console.WriteLine(_separator);

            Console.WriteLine($"EmailAddressLocalPart={fixture.Create<EmailAddressLocalPart>().LocalPart}");
            Console.WriteLine($"DomainName={fixture.Create<DomainName>()}");
            Console.WriteLine($"MailAddress={fixture.Create<MailAddress>().Address}");
            Console.WriteLine(_separator);
        }

        [Test]
        public void AutoFixture_CreateMany_GenerateTestingData()
        {
            var fixture = new Fixture();
            // Default is creating 3 elements.
            IEnumerable<string> stringList = fixture.CreateMany<string>(6);
            Console.WriteLine($"String List Count={stringList.Count()}");
            foreach (string str in stringList)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine(_separator);
        }

        [Test]
        public void AutoFixture_AddMany_GenerateTestingData()
        {
            var fixture = new Fixture();

            // Default is creating 3 elements.
            // ToList() is important. We will append more elements later.
            // AutoFixture needs ICollection. IEnumerable is not working.
            IList<int> intList = fixture.CreateMany<int>().ToList();
            PrintList(intList);

            // Append 7 elements to list
            fixture.AddManyTo(intList, 7);
            intList.Count.Should().Be(10);
            PrintList(intList);

            // append 5 elements which are 100
            fixture.RepeatCount = 5;
            fixture.AddManyTo(intList, () => (int)1E+6); // or 1_000_000. 1 million.
            intList.Count.Should().Be(15);
            PrintList(intList);

            void PrintList(IEnumerable<int> intList)
            {
                Console.WriteLine($"Integer List Count={intList.Count()}");
                foreach (int integer in intList)
                {
                    Console.WriteLine(integer);
                }
                Console.WriteLine(_separator);
            }
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

        [Test]
        public void Create_Success_CustomType()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<EmailMessage>();
            Console.WriteLine($"Id={sut.Id}");
            Console.WriteLine($"SomePublicField={sut.SomePublicField}");
            Console.WriteLine($"ToAddress={sut.ToAddress}");
            Console.WriteLine($"MessageBody={sut.MessageBody}");
            Console.WriteLine($"Subject={sut.Subject}");
            Console.WriteLine($"IsImportant={sut.IsImportant}");
            Console.WriteLine($"MessageType={sut.MessageType}");
            Console.WriteLine($"SomePrivateProperty={sut.GetSomePrivateProperty()}");
            Console.WriteLine($"_somePrivateField={sut.GetSomePrivateField()}");
            sut.Should().NotBeNull();
        }

        [Test]
        public void Create_Success_CustomTypeWithDataAnnotations()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<PlayerCharacter>();
            Console.WriteLine($"RealName={sut.RealName}");
            Console.WriteLine($"GameCharacterName={sut.GameCharacterName}");
            Console.WriteLine($"CurrentHealth={sut.CurrentHealth}");
            using (new AssertionScope())
            {
                sut.RealName.Length.Should().BeLessThanOrEqualTo(20);
                sut.GameCharacterName.Length.Should().BeLessThanOrEqualTo(8);
                sut.CurrentHealth.Should().BeLessThanOrEqualTo(10);
            }
        }
    }
    public enum StatusEnum
    {
        Enabled,
        Disabled
    }
}
