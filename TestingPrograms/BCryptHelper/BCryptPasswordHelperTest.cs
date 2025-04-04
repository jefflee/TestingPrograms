namespace TestingPrograms.BCryptHelper
{
    [TestFixture]
    public class BCryptPasswordHelperTest
    {
        // hashed password by "Passoword1234"
        private readonly string hashedPassword1234 = "$2a$11$e4gA7pWSXegSn13Qe6qa0uRVz3lkhzSH8pSB1G/gJVLpeyIDVsF7e";

        [Test]
        public void HashPassword_GetHashCode_WithAPassword()
        {
            var password = "Passoword1234";

            var hashed1 = BCryptPasswordHelper.HashPassword(password);
            var hashed2 = BCryptPasswordHelper.HashPassword(password);

            hashed1.Should().NotBe(hashed2, "BCrypt hashed with salt");

            Console.WriteLine($"hashed1：{hashed1}");
            Console.WriteLine($"hashed2：{hashed2}");
        }

        [Test]
        public void VerifyPassword_ReturnTrue_WithACorrectPassword()
        {
            var result = BCryptPasswordHelper.VerifyPassword("Passoword1234", hashedPassword1234);

            result.Should().BeTrue();
        }

        [Test]
        public void VerifyPassword_ReturnFalse_WithAWrongPassword()
        {
            var result = BCryptPasswordHelper.VerifyPassword("wrong password", hashedPassword1234);

            result.Should().BeFalse();
        }
    }
}