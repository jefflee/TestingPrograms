namespace TestingPrograms.ErrorHandlingResultPattern
{
    public interface IFollowerRepository
    {
        Task<bool> IsAlreadyFollowingAsync(Guid userId, Guid followedId, CancellationToken cancellationToken);

        void Insert(User follower);
    }
}