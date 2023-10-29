using TestingPrograms.ErrorHandlingResultPattern.Errors;

namespace TestingPrograms.ErrorHandlingResultPattern
{
    public sealed class FollowerService
    {
        private readonly IFollowerRepository _followerRepository;

        public FollowerService(IFollowerRepository followerRepository)
        {
            _followerRepository = followerRepository;
        }

        public async Task<Result> StartFollowingAsync(
            User user,
            User followed,
            DateTime utcNow,
            CancellationToken cancellationToken = default)
        {
            if (user.Id == followed.Id)
            {
                return Result.Failure(FollowerErrors.SameUser);
            }

            if (!followed.HasPublicProfile)
            {
                return Result.Failure(FollowerErrors.NonPublicProfile);
            }

            if (await _followerRepository.IsAlreadyFollowingAsync(
                    user.Id,
                    followed.Id,
                    cancellationToken))
            {
                return Result.Failure(FollowerErrors.AlreadyFollowing);
            }

            var follower = Follower.Create(user.Id, followed.Id, utcNow);

            _followerRepository.Insert(follower);

            return Result.Success();
        }
    }
}