using Nito.AsyncEx;
using Nito.AsyncEx.Synchronous;

namespace TestingPrograms.AsyncException
{
    internal class DbRepository
    {
        public async Task<String> GetStringAsync()
        {
            // do something async here.
            throw new NotImplementedException("This is not implemented");
        }

        public void CallingWithResult()
        {
            var r = GetStringAsync().Result;
        }

        public async Task CallingWithAwait()
        {
            await GetStringAsync();
        }

        /// <summary>
        /// If you have a simple asynchronous method that doesn't need to synchronize back to its context,
        /// then you can use Task.WaitAndUnwrapException
        /// Refer to https://stackoverflow.com/a/9343733 Solution A
        /// </summary>
        public void CallingWithWaitAndUnwrapException()
        {
            GetStringAsync().WaitAndUnwrapException();
        }

        /// <summary>
        /// If "GetStringAsync" does need to synchronize back to its context,
        /// then you may be able to use AsyncContext.RunTask to provide a nested context
        /// Refer to https://stackoverflow.com/a/9343733 Solution B
        /// </summary>
        public void CallingWithAsyncContext()
        {
            var r = AsyncContext.Run(GetStringAsync);
        }

        /// <summary>
        /// AsyncContext.RunTask won't work in every scenario.
        /// For example, if the async method awaits something that requires a UI event to complete,
        /// then you'll deadlock even with the nested context.
        /// In that case, you could start the async method on the thread pool:
        /// Refer to https://stackoverflow.com/a/9343733 Solution C
        /// </summary>
        public void CallingWithTaskAndNitoAsyncEx()
        {
            var task = Task.Run(async () => await GetStringAsync());
            var r = task.WaitAndUnwrapException();
        }

        public void CallingWithTask()
        {
            var task = Task.Run(
                async () => await GetStringAsync());
            var r = task.Result;

        }
    }
}
