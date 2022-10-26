using AutoFixture;

namespace TestingPrograms.AutoFixture.Tests
{
    public class CustomizationDemos
    {
        [Test]
        public void DateTimeCustomization_Success_GetCurrentDateTime()
        {
            // arrange
            var fixture = new Fixture();

            //fixture.Customize(new CurrentDateTimeCustomization());
            fixture.Customizations.Add(new CurrentDateTimeGenerator());

            var date1 = fixture.Create<DateTime>();
            var date2 = fixture.Create<DateTime>();

            date1.Date.Should().Be(date2.Date);
        }
    }
}
