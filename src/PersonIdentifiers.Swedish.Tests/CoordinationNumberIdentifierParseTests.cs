using System;
using NodaTime;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class CoordinationNumberIdentifierParseTests
{
    [Theory]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = CoordinationNumberIdentifier.TryParse(value, out var identifier);

        Assert.True(result);
        Assert.Equal(kind, identifier!.Kind);
        Assert.Equal(dateOfBirth, identifier!.DateOfBirth);
        Assert.Equal(gender, identifier!.Gender);
    }

    [Theory]
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Common test data for multiple tests")]
    public void CanTryParseInvalid(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = CoordinationNumberIdentifier.TryParse(value, out var _);

        Assert.False(result);
    }

    [Fact]
    public void ThrowsOnTryParseNullIdentity()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = CoordinationNumberIdentifier.TryParse(null!, out var _));
        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    public void CanParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var identifier = CoordinationNumberIdentifier.Parse(value);

        Assert.Equal(kind, identifier!.Kind);
        Assert.Equal(dateOfBirth, identifier!.DateOfBirth);
        Assert.Equal(gender, identifier!.Gender);
    }
}
