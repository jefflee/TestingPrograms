using AutoFixture;
using FluentAssertions.Execution;
using TestingPrograms.AutoFixture.Tests.AutoFixtureGenerators;
using TestingPrograms.AutoFixture.Tests.TestingClasses;

namespace TestingPrograms.AutoFixture.Tests
{
    public class Test4CustomizationDemos
    {
        [Test]
        public void CreateDateTime_Success_GetCurrentDateTime()
        {
            // arrange
            var fixture = new Fixture();

            //fixture.Customize(new CurrentDateTimeCustomization());
            fixture.Customizations.Add(new CurrentDateTimeGenerator());

            var date1 = fixture.Create<DateTime>();
            var date2 = fixture.Create<DateTime>();

            date1.Date.Should().Be(date2.Date);
        }

        [Test]
        public void Create_Success_WithCustomSpecimenBuilder()
        {
            // arrange
            var fixture = new Fixture();
            fixture.Customizations.Add(new AirportCodeStringPropertyGenerator());

            var flight = fixture.Create<FlightDetails>();
            var airport = fixture.Create<Airport>();

            // assert
            string[] airportCodes = { "LHR", "PER" };
            using (new AssertionScope())
            {
                flight.DepartureAirportCode.Should().BeOneOf(airportCodes);
                flight.ArrivalAirportCode.Should().BeOneOf(airportCodes);
                airport.AirportCode.Should().BeOneOf(airportCodes);
            }
        }
    }
}
