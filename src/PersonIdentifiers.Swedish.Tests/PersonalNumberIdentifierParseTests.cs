using System;
using NodaTime;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonalNumberIdentifierParseTests
{
    [Theory]
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = PersonalNumberIdentifier.TryParse(value, out var _);

        Assert.True(result);
    }

    [Theory]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
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
}
