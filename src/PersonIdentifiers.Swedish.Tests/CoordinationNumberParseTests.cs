﻿using System;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class CoordinationNumberParseTests
{
    [Theory]
    [ClassData(typeof(CoordinationNumbersTheoryData))]
    public void CanTryParse(string value, PersonIdentifierKind kind, DateOnly? dateOfBirth, PersonIdentifierGender? gender)
    {
        if (CoordinationNumber.TryParse(value, out var identifier))
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

    [Theory]
    [ClassData(typeof(PersonalIdentityNumbersTheoryData))]
    [ClassData(typeof(NationalReserveNumbersTheoryData))]
    [ClassData(typeof(InvalidCoordinationNumbersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Common test data for multiple tests")]
    public void CanTryParseInvalid(string value, PersonIdentifierKind kind, DateOnly? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = CoordinationNumber.TryParse(value, out var _);

        Assert.False(result);
    }

    [Fact]
    public void ThrowsOnTryParseNullIdentity()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = CoordinationNumber.TryParse(null!, out var _));
        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [ClassData(typeof(CoordinationNumbersTheoryData))]
    public void CanParse(string value, PersonIdentifierKind kind, DateOnly? dateOfBirth, PersonIdentifierGender? gender)
    {
        var identifier = CoordinationNumber.Parse(value);

        Assert.Equal(value, identifier.Value);
        Assert.Equal(kind, identifier.Kind);
        Assert.Equal(dateOfBirth.HasValue, identifier.IsDateOfBirthKnown);
        Assert.Equal(dateOfBirth, identifier.DateOfBirth);
        Assert.Equal(gender.HasValue, identifier.IsGenderKnown);
        Assert.Equal(gender, identifier.Gender);
    }

    [Theory]
    [ClassData(typeof(PersonalIdentityNumbersTheoryData))]
    [ClassData(typeof(NationalReserveNumbersTheoryData))]
    [ClassData(typeof(InvalidCoordinationNumbersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Common test data for multiple tests")]
    public void ThrowsOnParseInvalid(string value, PersonIdentifierKind kind, DateOnly? dateOfBirth, PersonIdentifierGender? gender)
    {
        var ex = Assert.Throws<PersonIdentifierFormatException>(() => _ = CoordinationNumber.Parse(value));
        Assert.Equal(typeof(CoordinationNumber), ex.PersonIdentifierType);
    }
}
