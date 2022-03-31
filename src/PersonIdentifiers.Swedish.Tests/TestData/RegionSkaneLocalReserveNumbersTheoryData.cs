using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class RegionSkaneLocalReserveNumbersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public RegionSkaneLocalReserveNumbersTheoryData()
    {
        Add("810829DA1B", PersonIdentifierKind.LocalReserveNumber, new LocalDate(1981, 8, 29), PersonIdentifierGender.Male);
    }
}
