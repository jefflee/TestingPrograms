using BCryptNet = BCrypt.Net.BCrypt;

namespace TestingPrograms.BCryptHelper
{
    internal class BCryptPasswordHelper
    {
        // The log2 of the number of rounds of hashing to apply
        // The bigger value cause the longer computation.
        // default is 11.
        private const int WorkFactor = 11;

        /// <summary>
        ///     Hash password
        /// </summary>
        /// <param name="plainPassword"></param>
        /// <returns></returns>
        public static string HashPassword(string plainPassword)
        {
            return BCryptNet.HashPassword(plainPassword, WorkFactor);
        }

        /// <summary>
        ///     Verify password
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return BCryptNet.Verify(inputPassword, hashedPassword);
        }
    }
}