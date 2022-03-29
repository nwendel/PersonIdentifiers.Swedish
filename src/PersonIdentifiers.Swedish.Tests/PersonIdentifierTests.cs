using System;
using NodaTime;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests
{
    public class PersonIdentifierTests
    {
        [Theory]
        [ClassData(typeof(PersonIdentifiersTheoryData))]
        public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
        {
            var result = PersonIdentifier.TryParse(value, out var identifier);

            Assert.True(result);
            Assert.Equal(value, identifier!.Value);
            Assert.Equal(kind, identifier!.Kind);
            Assert.Equal(dateOfBirth, identifier!.DateOfBirth);
            Assert.Equal(gender, identifier!.Gender);
        }

        [Fact]
        public void ThrowsOnTryParseNullIdentity()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = PersonIdentifier.TryParse(null!, out var _));
            Assert.Equal("value", ex.ParamName);
        }

        [Theory]
        [ClassData(typeof(PersonIdentifiersTheoryData))]
        public void CanParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
        {
            var identifier = PersonIdentifier.Parse(value);

            Assert.Equal(value, identifier.Value);
            Assert.Equal(kind, identifier.Kind);
            Assert.Equal(dateOfBirth, identifier.DateOfBirth);
            Assert.Equal(gender, identifier.Gender);
        }

        [Fact]
        public void ThrowsOnParseInvalidFormat()
        {
            Assert.Throws<PersonIdentifierFormatException>(() => PersonIdentifier.Parse("ASDF"));
        }

        [Fact]
        public void CanToString()
        {
            var pnr = "191212121212";
            var identifier = PersonIdentifier.Parse(pnr);

            Assert.Equal(pnr, identifier.ToString());
        }
    }
}
