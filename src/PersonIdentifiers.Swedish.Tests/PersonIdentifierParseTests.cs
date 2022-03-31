using System;
using NodaTime;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonIdentifierParseTests
{
    [Theory]
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
    public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        if (PersonIdentifier.TryParse(value, out var identifier))
        {
            Assert.Equal(value, identifier.Value);
            Assert.Equal(kind, identifier.Kind);
            Assert.Equal(dateOfBirth, identifier.DateOfBirth);
            Assert.Equal(gender, identifier.Gender);
        }
        else
        {
            Assert.Fail($"Failed to parse {identifier}");
        }
    }

    [Fact]
    public void ThrowsOnTryParseNullIdentity()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = PersonIdentifier.TryParse(null!, out var _));
        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
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
}
