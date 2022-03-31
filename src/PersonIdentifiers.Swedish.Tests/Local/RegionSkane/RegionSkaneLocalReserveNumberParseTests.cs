using NodaTime;
using PersonIdentifiers.Swedish.Local.RegionSkane;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Local.RegionSkane;

public class RegionSkaneLocalReserveNumberParseTests
{
    [Theory]
    [ClassData(typeof(RegionSkaneLocalReserveNumbersTheoryData))]
    public void CanTryParse(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        if (RegionSkaneLocalReserveNumber.TryParse(value, out var identifier))
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
}
