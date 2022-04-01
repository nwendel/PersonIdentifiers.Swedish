using System;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class RegionSkaneLocalReserveNumbersTheoryData : TheoryData<string, PersonIdentifierKind, DateOnly?, PersonIdentifierGender?>
{
    public RegionSkaneLocalReserveNumbersTheoryData()
    {
        Add("810829DA1B", PersonIdentifierKind.LocalReserveNumber, new(1981, 8, 29), PersonIdentifierGender.Male);
    }
}
