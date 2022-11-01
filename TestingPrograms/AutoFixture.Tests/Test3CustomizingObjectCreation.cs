using AutoFixture;
using FluentAssertions.Execution;
using TestingPrograms.AutoFixture.Tests.TestingClasses;

namespace TestingPrograms.AutoFixture.Tests
{
    public class Test3CustomizingObjectCreation
    {
        [Test]
        public void Create_Success_CustomizeSomeFields()
        {
            // arrange
            var fixture = new Fixture();


            fixture.Inject(new FlightDetails
            {
                DepartureAirportCode = "TPE",
                ArrivalAirportCode = "KHH",
                FlightDuration = TimeSpan.FromHours(1),
                AirlineName = "Airline Company"
            });


            var flight1 = fixture.Create<FlightDetails>();
            var flight2 = fixture.Create<FlightDetails>();

            flight1.Should().BeSameAs(flight2);
        }

        [Test]
        public void Register_Success_OverrideStringCreatingLogicByAFunc()
        {
            // arrange
            var fixture = new Fixture();

            fixture.Register(() => DateTime.Now.Ticks.ToString());

            var str1 = fixture.Create<string>();
            var str2 = fixture.Create<string>();

            Console.WriteLine($"str1 = {str1}");
            Console.WriteLine($"str2 = {str2}");
        }

        [Test]
        public void Freeze_Success_FreezingValues()
        {
            // arrange
            var fixture = new Fixture();

            // Using Freeze instead of Create. If we use Freeze, we will get fixed value going forward.
            var id = fixture.Freeze<int>();
            var customerName = fixture.Freeze<string>();

            var sut = fixture.Create<Order>();

            // Because we freeze the value, we know how to write this assert.
            sut.ToString().Should().Be(id + "-" + customerName);
        }

        [Test]
        public void Build_Success_WithoutSomeProperties()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .Without(x => x.ArrivalAirportCode) // Don't assign value to this property
                .Without(x => x.DepartureAirportCode)
                .Create();

            using (new AssertionScope())
            {
                flight.AirlineName.Should().NotBeNullOrWhiteSpace();
                flight.ArrivalAirportCode.Should().BeNull();
                flight.DepartureAirportCode.Should().BeNull();
                flight.MealOptions.Should().HaveCount(3);
            }
        }

        [Test]
        public void Build_Success_UsingOmitAutoProperties()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .OmitAutoProperties() // Don't assign value to all properties
                .Create();

            using (new AssertionScope())
            {
                flight.AirlineName.Should().BeNull();
                flight.ArrivalAirportCode.Should().BeNull();
                flight.DepartureAirportCode.Should().BeNull();
                flight.FlightDuration.Should().Be(default);
                flight.MealOptions.Should().HaveCount(0);
            }
        }

        [Test]
        public void Build_Success_UsingWith()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .With(x => x.ArrivalAirportCode, "LAX") // Assign LAX to ArrivalAirportCode
                .With(x => x.DepartureAirportCode, "LHR")
                .Create();

            using (new AssertionScope())
            {
                flight.AirlineName.Should().NotBeNullOrWhiteSpace();
                flight.ArrivalAirportCode.Should().Be("LAX");
                flight.DepartureAirportCode.Should().Be("LHR");
                flight.MealOptions.Should().HaveCount(3);
            }
        }

        [Test]
        public void Build_Success_UsingDoForPostProcessing()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .With(x => x.DepartureAirportCode, "LHR")
                .With(x => x.ArrivalAirportCode, "LAX")
                .Without(x => x.MealOptions)
                .Do(x => x.MealOptions.Add("Chicken")) // Using Do to add 2 elements into MealOptions.
                .Do(x => x.MealOptions.Add("Fish"))
                .Create();

            using (new AssertionScope())
            {
                flight.AirlineName.Should().NotBeNullOrWhiteSpace();
                flight.ArrivalAirportCode.Should().Be("LAX");
                flight.DepartureAirportCode.Should().Be("LHR");
                flight.MealOptions.Should().HaveCount(2);
            }
        }

        [Test]
        public void Build_Success_CustomizedForType()
        {
            // arrange
            var fixture = new Fixture();

            fixture.Customize<FlightDetails>(fd =>
                fd.With(x => x.DepartureAirportCode, "LHR")
                    .With(x => x.ArrivalAirportCode, "LAX")
                    .With(x => x.AirlineName, "Fly Fly Premium Air")
                    .With(x => x.FlightDuration, TimeSpan.FromHours(2))
                    .Without(x => x.MealOptions)
                    .Do(x => x.MealOptions.Add("Chicken"))
                    .Do(x => x.MealOptions.Add("Fish"))); // notice no .Create() is required here)

            var flight1 = fixture.Create<FlightDetails>();
            var flight2 = fixture.Create<FlightDetails>();

            using (new AssertionScope())
            {
                flight1.AirlineName.Should().NotBeNullOrWhiteSpace();
                flight1.ArrivalAirportCode.Should().Be("LAX");
                flight1.DepartureAirportCode.Should().Be("LHR");
                flight1.MealOptions.Should().HaveCount(2);

                flight1.Should().NotBeSameAs(flight2);
            }
        }
    }
}
