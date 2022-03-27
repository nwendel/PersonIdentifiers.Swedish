using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests
{
    public class PersonIdentifierTests
    {
        [Theory]
        [ClassData(typeof(PersonIdentifiersTheoryData))]
        public void CanTryParse(string identity, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
        {
            var result = PersonIdentifier.TryParse(identity, out var identifier);

            Assert.True(result);
            Assert.Equal(kind, identifier!.Kind);
            Assert.Equal(dateOfBirth, identifier!.DateOfBirth);
            Assert.Equal(gender, identifier!.Gender);
        }
    }
}
