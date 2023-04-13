using System.Diagnostics;

namespace TestingPrograms.DotNet7
{
    [TestFixture]
    public class StopwatchTests
    {
        /// <summary>
        /// This is a new way of using Stopwatch in .Net 7. It saves memory
        /// Refer to https://www.youtube.com/watch?v=NTz99yN2urc
        /// </summary>
        /// <returns></returns>
        [Test()]
        public async Task GetElapsedTime_GetTimeSpan_WithNewDotNet7Methods()
        {
            var starTime = Stopwatch.GetTimestamp();

            //do something here
            await Task.Delay(1000);

            TimeSpan diff = Stopwatch.GetElapsedTime(starTime);
            Console.WriteLine(diff);
        }
    }
}
