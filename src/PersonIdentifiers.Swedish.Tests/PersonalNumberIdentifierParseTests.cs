using System;
using NodaTime;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonalNumberIdentifierParseTests
{
    [Theory]
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        if (PersonalNumberIdentifier.TryParse(value, out var identifier))
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

    [Theory]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
    [ClassData(typeof(InvalidPersonalNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Common test data for multiple tests")]
    public void CanTryParseInvalid(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = PersonalNumberIdentifier.TryParse(value, out var _);

        Assert.False(result);
    }

    [Fact]
    public void ThrowsOnTryParseNullIdentity()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = PersonalNumberIdentifier.TryParse(null!, out var _));
        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    public void CanParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var identifier = PersonalNumberIdentifier.Parse(value);

        Assert.Equal(value, identifier.Value);
        Assert.Equal(kind, identifier.Kind);
        Assert.Equal(dateOfBirth, identifier.DateOfBirth);
        Assert.Equal(gender, identifier.Gender);
    }

    [Theory]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
    [ClassData(typeof(InvalidPersonalNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Common test data for multiple tests")]
    public void ThrowsOnParseInvalid(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        Assert.Throws<PersonalNumberIdentifierFormatException>(() => _ = PersonalNumberIdentifier.Parse(value));
    }
}
