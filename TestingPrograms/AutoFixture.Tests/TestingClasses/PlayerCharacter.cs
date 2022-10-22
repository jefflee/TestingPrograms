using System.ComponentModel.DataAnnotations;
using RangeAttribute = System.ComponentModel.DataAnnotations.RangeAttribute;

namespace TestingPrograms.AutoFixture.Tests.TestingClasses
{
    public class PlayerCharacter
    {
        [StringLength(20)]
        public string RealName { get; set; }

        [StringLength(8)]
        public string GameCharacterName { get; set; }

        [Range(0, 10)]
        public int CurrentHealth { get; set; }
    }
}
