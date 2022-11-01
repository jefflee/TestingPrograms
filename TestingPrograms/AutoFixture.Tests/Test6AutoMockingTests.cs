using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using Moq;
using TestingPrograms.AutoFixture.Tests.Attributes;
using TestingPrograms.AutoFixture.Tests.TestingClasses;

namespace TestingPrograms.AutoFixture.Tests
{
    public class Test6AutoMockingTests
    {
        [Test]
        public void SendEmailToGateway_Success_WithManualMoq()
        {
            // arrange
            var fixture = new Fixture();

            var mockGateway = new Mock<IEmailGateway>();

            var sut = new EmailMessageBuffer(mockGateway.Object);

            sut.Add(fixture.Create<EmailMessage>());


            // act
            sut.SendAll();


            // assert
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }

        [Test]
        public void SendEmailToGateway_Success_WithAutoMoq()
        {
            // arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var mockGateway = fixture.Freeze<Mock<IEmailGateway>>();

            var sut = fixture.Create<EmailMessageBuffer>();

            sut.Add(fixture.Create<EmailMessage>());

            // act
            sut.SendAll();

            // assert
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }

        [Theory]
        [AutoMoqData]
        public void SendEmailToGateway_Success_WithAutoMoqAndParameterized(
            EmailMessage message,
            [Frozen] Mock<IEmailGateway> mockGateway,
            EmailMessageBuffer sut)
        {
            // arrange
            sut.Add(message);

            // act
            sut.SendAll();

            // assert
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }
    }
}
