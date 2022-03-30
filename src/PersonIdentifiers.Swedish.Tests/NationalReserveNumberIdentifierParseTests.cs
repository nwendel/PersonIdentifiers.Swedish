using System;
using NodaTime;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class NationalReserveNumberIdentifierParseTests
{
    [Theory]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
    public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        if (NationalReserveNumberIdentifier.TryParse(value, out var identifier))
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
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Common test data for multiple tests")]
    public void CanTryParseInvalid(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = NationalReserveNumberIdentifier.TryParse(value, out var _);

        Assert.False(result);
    }

    [Fact]
    public void ThrowsOnTryParseNullIdentity()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = NationalReserveNumberIdentifier.TryParse(null!, out var _));
        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
    public void CanParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var identifier = NationalReserveNumberIdentifier.Parse(value);

        Assert.Equal(value, identifier.Value);
        Assert.Equal(kind, identifier.Kind);
        Assert.Equal(dateOfBirth, identifier.DateOfBirth);
        Assert.Equal(gender, identifier.Gender);
    }
}
