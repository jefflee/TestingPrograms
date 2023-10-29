using TestingPrograms.ErrorHandlingResultPattern.Extensions;

namespace TestingPrograms.ErrorHandlingResultPattern
{
    internal class Client
    {
        public async Task<string> Action(Guid userId, Guid followedId, FollowerService followerService)
        {
            var result = await followerService.StartFollowingAsync(
                new User { Id = userId },
                new User { Id = followedId },
                DateTime.UtcNow);

            // Using generic method here.
            // In Asp.NET，we can return IResult by Results.Ok(), Results.BadRequest(), Results.NotFound() and so on.
            return result.Match<string>(
                () => "success",
                error => "Fail");
        }
    }
}