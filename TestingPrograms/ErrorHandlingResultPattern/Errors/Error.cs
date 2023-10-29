namespace TestingPrograms.ErrorHandlingResultPattern.Errors
{
    public sealed record Error(string Code, string Description)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }
}