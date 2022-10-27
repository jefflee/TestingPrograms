using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;

namespace TestingPrograms.AutoFixture.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
