namespace TestingPrograms.ErrorHandlingResultPattern.Errors
{
    public static class FollowerErrors
    {
        public static readonly Error SameUser = new(
            "Followers.SameUser", "Can't follow yourself");

        public static readonly Error NonPublicProfile = new(
            "Followers.NonPublicProfile", "Can't follow non-public profiles");

        public static readonly Error AlreadyFollowing = new(
            "Followers.AlreadyFollowing", "Already following");

        public static Error NotFound(Guid id)
        {
            return new(
                "Followers.NotFound", $"The follower with Id '{id}' was not found");
        }
    }
}