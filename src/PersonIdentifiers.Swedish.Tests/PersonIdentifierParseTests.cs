using System;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonIdentifierParseTests
{
    [Theory]
    [ClassData(typeof(PersonalIdentityNumbersTheoryData))]
    [ClassData(typeof(CoordinationNumbersTheoryData))]
    [ClassData(typeof(NationalReserveNumbersTheoryData))]
    public void CanTryParse(string value, PersonIdentifierKind kind, DateOnly? dateOfBirth, PersonIdentifierGender? gender)
    {
        if (PersonIdentifier.TryParse(value, out var identifier))
        {
            Assert.Equal(value, identifier.Value);
            Assert.Equal(kind, identifier.Kind);
            Assert.Equal(dateOfBirth.HasValue, identifier.IsDateOfBirthKnown);
            Assert.Equal(dateOfBirth, identifier.DateOfBirth);
            Assert.Equal(gender.HasValue, identifier.IsGenderKnown);
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
    [ClassData(typeof(PersonalIdentityNumbersTheoryData))]
    [ClassData(typeof(CoordinationNumbersTheoryData))]
    [ClassData(typeof(NationalReserveNumbersTheoryData))]
    public void CanParse(string value, PersonIdentifierKind kind, DateOnly? dateOfBirth, PersonIdentifierGender? gender)
    {
        var identifier = PersonIdentifier.Parse(value);

        Assert.Equal(value, identifier.Value);
        Assert.Equal(kind, identifier.Kind);
        Assert.Equal(dateOfBirth.HasValue, identifier.IsDateOfBirthKnown);
        Assert.Equal(dateOfBirth, identifier.DateOfBirth);
        Assert.Equal(gender.HasValue, identifier.IsGenderKnown);
        Assert.Equal(gender, identifier.Gender);
    }

    [Fact]
    public void ThrowsOnParseInvalidFormat()
    {
        Assert.Throws<PersonIdentifierFormatException>(() => PersonIdentifier.Parse("ASDF"));
    }
}
