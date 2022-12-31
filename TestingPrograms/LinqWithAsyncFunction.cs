namespace TestingPrograms
{
    [TestFixture]
    public class LinqWithAsyncFunction
    {
        private static readonly HashSet<int> _hashSet = new HashSet<int>();

        [Test]
        public async Task Select_ItIsParallel_WithTaskWhenAll()
        {
            _hashSet.Clear();
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

        /// <summary>
        /// Access a shared HashSet. So, sometime it gets an error.
        /// Message:
        /// System.ArgumentException : Destination array was not long enough.Check the destination index, length, and the array's lower bounds. (Parameter 'destinationArray')
        /// </summary>
        /// <returns></returns>
        // [Test]
        public async Task Select_SometimesError_WhenAccessASharedHashSet()
        {
            _hashSet.Clear();
            var intArray = Enumerable.Range(1, 100);
            await Task.WhenAll(
                intArray.Select(async k =>
                {
                    Console.WriteLine("In the Select function. k=" + k);
                    await AddToHashSetAsync(k);
                })).ConfigureAwait(false);
        }

        private static async Task AddToHashSetAsync(int k)
        {
            await Task.Delay(10);

            // use lock to solve this problem.
            //lock (_hashSet)
            //{
            _hashSet.Add(k);
            Console.WriteLine("AddToHashSetAsync(). k=" + k);
            //}
        }
    }
}
