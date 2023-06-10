#pragma warning disable CS0169
namespace TestingPrograms.ProtectedStaticMethod
{
    public abstract class DatabaseAccessor
    {
        protected static object GetDataFromDatabase()
        {
            Console.WriteLine("DatabaseAccessor::GetDataFromDatabase()");
            return new object();
        }

        protected static object UpdateSomething()
        {
            Console.WriteLine("DatabaseAccessor::UpdateSomething()");
            return new object();
        }
    }

    public abstract class ServerCache : DatabaseAccessor
    {
        private static object? _cachedResources;

        protected static object GetFromCacheOrGetFresh()
        {
            Console.WriteLine("ServerCache::GetFromCacheOrGetFresh()");
            return new object();
        }

        protected static void InvalidateCache()
        {
            Console.WriteLine("ServerCache::InvalidateCache()");
        }
    }

    public class DepartmentsService : ServerCache
    {
        public static object Read()
        {
            Console.WriteLine("DepartmentsService::Read()");
            return GetFromCacheOrGetFresh();
        }

        public static object Update()
        {
            Console.WriteLine("DepartmentsService::Update()");
            UpdateSomething();
            InvalidateCache();
            return Read();
        }

        public static object Create()
        {
            Console.WriteLine("DepartmentsService::Create()");
            return new object();
        }
    }

    public class EmployeeService : ServerCache
    {
        public static object Create()
        {
            Console.WriteLine("EmployeeService::Create()");

            /*
             *  EmployeeService can see these method:
                   protected static DatabaseAccessor.GetDataFromDatabase(...)
                   protected static DatabaseAccessor.UpdateSomething(...)
                   protected static ServerCache.GetFromCacheOrGetFresh(...)
                   protected static ServerCache.InvalidateCache(...)
                   public static DepartmentsService.Read()
                   public static DepartmentsService.Update(string id)
                   public static DepartmentsService.Create(...)
             *
             */

            return DepartmentsService.Read();
        }
    }

    [TestFixture]
    internal class ProtectedStaticMethodVisibility
    {
        [Test]
        public void EmployeeServiceCreate()
        {
            EmployeeService.Create();

            /*
                Standard Output: 
                EmployeeService::Create()
                DepartmentsService::Read()
                ServerCache::GetFromCacheOrGetFresh()
            */
        }
    }
}