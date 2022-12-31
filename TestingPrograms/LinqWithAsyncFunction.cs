namespace TestingPrograms
{
    [TestFixture]
    public class LinqWithAsyncFunction
    {
        [Test]
        public async Task Select_ItIsParallel_WithTaskWhenAll()
        {
            var intArray = Enumerable.Range(1, 100);
            await Task.WhenAll(
                intArray.Select(async k =>
                {
                    Console.WriteLine("In the Select function. k=" + k);
                    await PrintNumberAsync(k);
                })).ConfigureAwait(false);
        }

        /// <summary>
        /// Print nothing, because there is a Task.Delay in PrintNumber().
        /// It can't print the function's message in time.
        /// </summary>
        [Test]
        public void Select_PrintNothing_WithoutTaskWhenAll()
        {
            var intArray = Enumerable.Range(1, 100);

            var result = intArray.Select(async k =>
            {
                Console.WriteLine("In the Select function. k=" + k);

                await PrintNumberAsync(k);
            });
        }

        private static async Task PrintNumberAsync(int k)
        {
            await Task.Delay(10);
            Console.WriteLine("PrintNumber(). k=" + k);
        }
    }
}
