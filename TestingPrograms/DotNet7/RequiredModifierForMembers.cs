using System.Diagnostics.CodeAnalysis;

namespace Dotnet7Example
{
    [TestFixture]
    public class RequiredModifierForMembers
    {
        /// <summary>
        /// required modifier (C# Reference)
        /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required
        /// </summary>
        [Test]
        public void NewPerson_Success_PersonHasSomeRequiredMembers()
        {
            var p = new Person() { FirstName = "Eric", LastName = "Clapton" };
        }
    }

    public class Person
    {
        public Person() { }

        [SetsRequiredMembers]
        public Person(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);

        public required string FirstName { get; init; }
        public required string LastName { get; init; }

        public int? Age { get; set; }
    }
}