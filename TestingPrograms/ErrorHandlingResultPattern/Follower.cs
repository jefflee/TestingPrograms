namespace TestingPrograms.ErrorHandlingResultPattern
{
    internal class Follower
    {
        public static User Create(Guid userId, Guid followedId, DateTime createdOnUtc)
        {
            return new User();
        }
    }
}