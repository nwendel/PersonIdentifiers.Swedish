using System;
using NodaTime;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class NationalReserveNumberParseTests
{
    [Theory]
    [ClassData(typeof(NationalReserveNumbersTheoryData))]
    public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        if (NationalReserveNumber.TryParse(value, out var identifier))
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
    [ClassData(typeof(PersonalIdentityNumbersTheoryData))]
    [ClassData(typeof(CoordinationNumbersTheoryData))]
    [ClassData(typeof(InvalidNationalReserveNumbersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Common test data for multiple tests")]
    public void CanTryParseInvalid(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = NationalReserveNumber.TryParse(value, out var _);

        Assert.False(result);
    }

    [Fact]
    public void ThrowsOnTryParseNullIdentity()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = NationalReserveNumber.TryParse(null!, out var _));
        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [ClassData(typeof(NationalReserveNumbersTheoryData))]
    public void CanParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var identifier = NationalReserveNumber.Parse(value);

        Assert.Equal(value, identifier.Value);
        Assert.Equal(kind, identifier.Kind);
        Assert.Equal(dateOfBirth, identifier.DateOfBirth);
        Assert.Equal(gender, identifier.Gender);
    }

    [Theory]
    [ClassData(typeof(PersonalIdentityNumbersTheoryData))]
    [ClassData(typeof(CoordinationNumbersTheoryData))]
    [ClassData(typeof(InvalidNationalReserveNumbersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Common test data for multiple tests")]
    public void ThrowsOnParseInvalid(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        Assert.Throws<NationalReserveNumberFormatException>(() => _ = NationalReserveNumber.Parse(value));
    }
}
