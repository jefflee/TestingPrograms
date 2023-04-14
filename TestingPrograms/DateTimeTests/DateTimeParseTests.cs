using System.Globalization;

namespace TestingPrograms.DateTimeTests
{
    [TestFixture]
    internal class DateTimeParseTests
    {
        DateTime ParseDateTime(string dateTime)
        {
            // Using '' to escape
            DateTime date = DateTime.ParseExact(dateTime, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
            return date;
        }

        DateTime ParseDateTimeWithAdjustToUniversal(string dateTime)
        {
            // There is no '' to escape
            DateTime date = DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            return date;
        }

        DateTime ParseDateTimeWithAssumeUniversal(string dateTime)
        {
            // There is no '' to escape
            DateTime date = DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            return date;
        }

        /// <summary>
        /// The expected result is local time. My laptop is UTC+8
        /// </summary>
        /// <param name="dateTimeString"></param>
        /// <param name="expected"></param>
        [TestCase("2023-04-13T13:15:20.123Z", "2023-04-13T13:15:20.123Z")]
        public void ParseDateTime_ShouldGetDateTimeObj_WhenGiveAString(string dateTimeString, string expected)
        {
            var dt = ParseDateTime(dateTimeString);
            dt.ToString("yyyy-MM-ddTHH:mm:ss.fffZ").Should().Be(expected);
        }

        /// <summary>
        /// The expected result is local time. My laptop is UTC+8
        /// </summary>
        /// <param name="dateTimeString"></param>
        /// <param name="expected"></param>
        [TestCase("2023-04-13T13:15:20+08:00", "2023-04-13T05:15:20.000Z")]
        [TestCase("2023-04-13T13:15:20+00:00", "2023-04-13T13:15:20.000Z")]
        public void ParseDateTimeWithAdjustToUniversal_ShouldGetDateTimeObj_WhenGiveAString(string dateTimeString, string expected)
        {
            var dt = ParseDateTimeWithAdjustToUniversal(dateTimeString);
            dt.ToString("yyyy-MM-ddTHH:mm:ss.fffZ").Should().Be(expected);
        }

        /// <summary>
        /// The expected result is local time. My laptop is UTC+8
        /// </summary>
        /// <param name="dateTimeString"></param>
        /// <param name="expected"></param>
        [TestCase("2023-04-13T13:15:20+08:00", "2023-04-13T13:15:20.000Z")]
        [TestCase("2023-04-13T13:15:20+00:00", "2023-04-13T21:15:20.000Z")]
        public void ParseDateTimeWithAssumeUniversal_ShouldGetDateTimeObj_WhenGiveAString(string dateTimeString, string expected)
        {
            var dt = ParseDateTimeWithAssumeUniversal(dateTimeString);
            dt.ToString("yyyy-MM-ddTHH:mm:ss.fffZ").Should().Be(expected);
        }
    }
}
