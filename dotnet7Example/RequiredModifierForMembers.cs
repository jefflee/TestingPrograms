using System.Diagnostics.CodeAnalysis;

namespace Dotnet7Example
{
    [TestFixture]
    public class RequiredModifierForMembers
    {
        [SetUp]
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