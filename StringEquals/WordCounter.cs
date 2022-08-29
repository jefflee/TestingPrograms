using System.Diagnostics;

namespace StringEquals
{
    internal class WordCounter
    {
        private readonly string _textFile = ".\\Data\\rfc6749.txt";
        private readonly string[] _tokens;

        public WordCounter()
        {
            var wholeText = File.ReadAllText(_textFile);
            _tokens = wholeText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        public void PerformanceTest()
        {
            StopWatchWrapper(CountWordsWithOrdinalIgnoreCase);
            StopWatchWrapper(CountWordsWithInvariantCultureIgnoreCase);

        }

        private int CountWordsWithOrdinalIgnoreCase()
        {
            return CountWords(StringComparison.OrdinalIgnoreCase);
        }

        private int CountWordsWithInvariantCultureIgnoreCase()
        {
            return CountWords(StringComparison.InvariantCultureIgnoreCase);
        }

        private int StopWatchWrapper(Func<int> countWordFunc)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int count = countWordFunc();
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"{countWordFunc.Method.Name}() RunTime " + elapsedTime);

            return count;
        }

        private int CountWords(StringComparison comparision)
        {
            return _tokens.Count(token => token.Equals("oauth", comparision));
        }
    }
}
