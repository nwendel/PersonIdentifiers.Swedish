﻿using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class NationalReserveNumberIdentifierParseTests
{
    [Theory]
    [ClassData(typeof(PersonIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    public void CanTryParse(string identity, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var result = NationalReserveNumberIdentifier.TryParse(identity, out var _);
        Assert.Equal(kind == PersonIdentifierKind.NationalReserveNumber, result);
    }
}
