using System.ComponentModel.DataAnnotations;

namespace TestingPrograms.AutoFixture.Tests.TestingClasses
{
    public class PlayerCharacter
    {
        [StringLength(20)] public string RealName { get; set; } = string.Empty;

        [StringLength(8)] public string GameCharacterName { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.Range(0, 10)]
        public int CurrentHealth { get; set; }
    }
}