using System;
using NodaTime;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class NationalReserveNumberIdentifierParseTests
{
    [Theory]
    [ClassData(typeof(NationalReserveNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = NationalReserveNumberIdentifier.TryParse(value, out var _);

        Assert.True(result);
    }

    [Fact]
    public void ThrowsOnTryParseNullIdentity()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = NationalReserveNumberIdentifier.TryParse(null!, out var _));
        Assert.Equal("value", ex.ParamName);
    }
}
