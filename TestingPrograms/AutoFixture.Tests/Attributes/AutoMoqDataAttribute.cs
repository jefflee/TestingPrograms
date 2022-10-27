using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using TestingPrograms.AutoFixture.Tests.AutoFixtureGenerators;

namespace TestingPrograms.AutoFixture.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                fixture.Customizations.Add(new AirportCodeStringPropertyGenerator());
                return fixture;
            })
        {
        }
    }
}
